using System;
using System.Net;
using System.Net.Sockets;

namespace MTHHelper
{
    /// <summary>
    /// Modbus TCP 主站通信类
    /// 支持功能码：01H、02H、03H、04H、05H、06H、0FH、10H
    /// 所有读方法失败返回 null，写方法失败返回 false，失败原因记录在 LastError
    /// </summary>
    public class ModbusTCP
    {
        #region 字段与属性

        /// <summary>与从站通信的套接字</summary>
        private Socket socket;

        /// <summary>事务标识，每次请求自增</summary>
        private ushort transactionId = 1;

        /// <summary>收发锁，保证多线程下请求与应答不会交叉</summary>
        private readonly object lockObj = new object();

        /// <summary>从站 IP 地址</summary>
        public string ServerIP { get; set; }

        /// <summary>从站端口号</summary>
        public int Port { get; set; } = 502;

        /// <summary>从站站号</summary>
        public byte UnitId { get; set; } = 1;

        /// <summary>连接超时时间（毫秒）</summary>
        public int ConnectTimeout { get; set; } = 3000;

        /// <summary>收发的超时时间（毫秒）</summary>
        public int ReceiveTimeout { get; set; } = 3000;

        /// <summary>是否已连接到从站</summary>
        public bool IsConnected
        {
            get { return socket != null && socket.Connected; }
        }

        /// <summary>最近一次失败的原因</summary>
        public string LastError { get; private set; } = string.Empty;

        /// <summary>累计发送次数</summary>
        public int SendCount { get; private set; }

        /// <summary>累计失败次数</summary>
        public int ErrorCount { get; private set; }

        #endregion

        #region 建立连接与断开连接

        /// <summary>
        /// 连接从站
        /// </summary>
        /// <param name="ip">从站 IP 地址</param>
        /// <param name="port">从站端口号</param>
        /// <returns>是否连接成功</returns>
        public bool Connect(string ip, int port)
        {
            ServerIP = ip;
            Port = port;
            return Connect();
        }

        /// <summary>
        /// 按当前 ServerIP / Port 建立连接，已连接时直接返回 true
        /// </summary>
        public bool Connect()
        {
            lock (lockObj)
            {
                if (IsConnected)
                {
                    return true;
                }

                if (string.IsNullOrWhiteSpace(ServerIP))
                {
                    LastError = "从站 IP 地址为空";
                    return false;
                }

                Close();

                try
                {
                    socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    socket.SendTimeout = ReceiveTimeout;
                    socket.ReceiveTimeout = ReceiveTimeout;
                    // 请求-应答模式下一问一答，禁用 Nagle 可降低往返延迟
                    socket.NoDelay = true;

                    IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(ServerIP), Port);
                    IAsyncResult ar = socket.BeginConnect(endPoint, null, null);
                    if (!ar.AsyncWaitHandle.WaitOne(ConnectTimeout, false))
                    {
                        LastError = "连接 " + ServerIP + ":" + Port + " 超时";
                        Close();
                        return false;
                    }

                    socket.EndConnect(ar);
                    LastError = string.Empty;
                    return true;
                }
                catch (Exception ex)
                {
                    LastError = ex.Message;
                    Close();
                    return false;
                }
            }
        }

        /// <summary>
        /// 断开连接
        /// </summary>
        public void DisConnect()
        {
            lock (lockObj)
            {
                Close();
            }
        }

        private void Close()
        {
            if (socket != null)
            {
                try
                {
                    socket.Close();
                }
                catch
                {
                    // 关闭过程中的异常忽略
                }
                socket = null;
            }
        }

        #endregion

        #region 01H读取输出线圈

        /// <summary>
        /// 01H 读取输出线圈（可读可写线圈，0x 区）
        /// </summary>
        /// <param name="startAddress">起始地址</param>
        /// <param name="quantity">读取数量，1~2000</param>
        /// <returns>按位打包的线圈数据字节数组，长度 (quantity+7)/8，失败返回 null</returns>
        public byte[] ReadOutputCoils(ushort startAddress, ushort quantity)
        {
            if (quantity < 1 || quantity > 2000)
            {
                LastError = "线圈数量必须在 1~2000 之间";
                return null;
            }

            byte[] response = Transact(0x01, AddressAndQuantity(startAddress, quantity));
            return ExtractBits(response, quantity);
        }

        #endregion

        #region 02H读取输入线圈

        /// <summary>
        /// 02H 读取输入线圈（只读线圈，1x 区）
        /// </summary>
        /// <param name="startAddress">起始地址</param>
        /// <param name="quantity">读取数量，1~2000</param>
        /// <returns>按位打包的线圈数据字节数组，长度 (quantity+7)/8，失败返回 null</returns>
        public byte[] ReadInputCoils(ushort startAddress, ushort quantity)
        {
            if (quantity < 1 || quantity > 2000)
            {
                LastError = "线圈数量必须在 1~2000 之间";
                return null;
            }

            byte[] response = Transact(0x02, AddressAndQuantity(startAddress, quantity));
            return ExtractBits(response, quantity);
        }

        #endregion

        #region 03H读取输出寄存器

        /// <summary>
        /// 03H 读取输出寄存器（保持寄存器，4x 区）
        /// </summary>
        /// <param name="startAddress">起始地址</param>
        /// <param name="quantity">读取数量，1~125</param>
        /// <returns>寄存器原始数据字节数组，长度 quantity*2，失败返回 null</returns>
        public byte[] ReadOutputRegisters(ushort startAddress, ushort quantity)
        {
            if (quantity < 1 || quantity > 125)
            {
                LastError = "寄存器数量必须在 1~125 之间";
                return null;
            }

            byte[] response = Transact(0x03, AddressAndQuantity(startAddress, quantity));
            return ExtractRegisters(response, quantity);
        }

        #endregion

        #region 04H读取输入寄存器

        /// <summary>
        /// 04H 读取输入寄存器（3x 区）
        /// </summary>
        /// <param name="startAddress">起始地址</param>
        /// <param name="quantity">读取数量，1~125</param>
        /// <returns>寄存器原始数据字节数组，长度 quantity*2，失败返回 null</returns>
        public byte[] ReadInputRegisters(ushort startAddress, ushort quantity)
        {
            if (quantity < 1 || quantity > 125)
            {
                LastError = "寄存器数量必须在 1~125 之间";
                return null;
            }

            byte[] response = Transact(0x04, AddressAndQuantity(startAddress, quantity));
            return ExtractRegisters(response, quantity);
        }

        #endregion

        #region 05H预置单线圈

        /// <summary>
        /// 05H 写单个线圈
        /// </summary>
        /// <param name="address">线圈地址</param>
        /// <param name="value">true 为 ON，false 为 OFF</param>
        /// <returns>是否写入成功</returns>
        public bool WriteSingleCoil(ushort address, bool value)
        {
            byte[] pdu = new byte[4];
            pdu[0] = (byte)(address >> 8);
            pdu[1] = (byte)(address & 0xFF);
            pdu[2] = value ? (byte)0xFF : (byte)0x00;
            pdu[3] = value ? (byte)0xFF : (byte)0x00;

            byte[] response = Transact(0x05, pdu);
            return CheckEcho(response, 0x05, pdu);
        }

        #endregion

        #region 06H预置单寄存器

        /// <summary>
        /// 06H 写单个寄存器
        /// </summary>
        /// <param name="address">寄存器地址</param>
        /// <param name="value">写入的原始值</param>
        /// <returns>是否写入成功</returns>
        public bool WriteSingleRegister(ushort address, ushort value)
        {
            byte[] pdu = new byte[4];
            pdu[0] = (byte)(address >> 8);
            pdu[1] = (byte)(address & 0xFF);
            pdu[2] = (byte)(value >> 8);
            pdu[3] = (byte)(value & 0xFF);

            byte[] response = Transact(0x06, pdu);
            return CheckEcho(response, 0x06, pdu);
        }

        #endregion

        #region 0FH预置多线圈

        /// <summary>
        /// 0FH 写多个线圈
        /// </summary>
        /// <param name="startAddress">起始地址</param>
        /// <param name="values">线圈状态，1~1968 个</param>
        /// <returns>是否写入成功</returns>
        public bool WriteMultiCoils(ushort startAddress, bool[] values)
        {
            if (values == null || values.Length < 1 || values.Length > 1968)
            {
                LastError = "线圈数量必须在 1~1968 之间";
                return false;
            }

            byte[] packed = BoolArrayToByteArray(values);
            byte[] pdu = new byte[5 + packed.Length];
            pdu[0] = (byte)(startAddress >> 8);
            pdu[1] = (byte)(startAddress & 0xFF);
            pdu[2] = (byte)(values.Length >> 8);
            pdu[3] = (byte)(values.Length & 0xFF);
            pdu[4] = (byte)packed.Length;
            Array.Copy(packed, 0, pdu, 5, packed.Length);

            byte[] response = Transact(0x0F, pdu);
            return CheckWriteMulti(response, 0x0F, startAddress, (ushort)values.Length);
        }

        #endregion

        #region 10H预置多寄存器

        /// <summary>
        /// 10H 写多个寄存器
        /// </summary>
        /// <param name="startAddress">起始地址</param>
        /// <param name="values">寄存器原始值，1~123 个</param>
        /// <returns>是否写入成功</returns>
        public bool WriteMultiRegisters(ushort startAddress, ushort[] values)
        {
            if (values == null || values.Length < 1 || values.Length > 123)
            {
                LastError = "寄存器数量必须在 1~123 之间";
                return false;
            }

            byte[] pdu = new byte[5 + values.Length * 2];
            pdu[0] = (byte)(startAddress >> 8);
            pdu[1] = (byte)(startAddress & 0xFF);
            pdu[2] = (byte)(values.Length >> 8);
            pdu[3] = (byte)(values.Length & 0xFF);
            pdu[4] = (byte)(values.Length * 2);
            for (int i = 0; i < values.Length; i++)
            {
                pdu[5 + i * 2] = (byte)(values[i] >> 8);
                pdu[6 + i * 2] = (byte)(values[i] & 0xFF);
            }

            byte[] response = Transact(0x10, pdu);
            return CheckWriteMulti(response, 0x10, startAddress, (ushort)values.Length);
        }

        #endregion

        #region 05H/06H/10H 预置方法（供 CommonMethods 调用）

        /// <summary>
        /// 05H 写单个线圈
        /// </summary>
        public bool PreSetSingleCoil(int address, bool value)
        {
            return WriteSingleCoil((ushort)address, value);
        }

        /// <summary>
        /// 06H 写单个寄存器
        /// </summary>
        public bool PreSetSingleRegister(int address, int value)
        {
            return WriteSingleRegister((ushort)address, (ushort)value);
        }

        /// <summary>
        /// 10H 写多个寄存器（字节数组按每 2 字节拆成一个寄存器，保持原字节顺序）
        /// </summary>
        public bool PreSetMultiRegisters(int address, byte[] data)
        {
            if (data == null || data.Length < 2 || data.Length % 2 != 0)
            {
                LastError = "写入字节长度必须为偶数且不少于 2 字节";
                return false;
            }

            ushort[] registers = new ushort[data.Length / 2];
            for (int i = 0; i < registers.Length; i++)
            {
                registers[i] = (ushort)((data[i * 2] << 8) | data[i * 2 + 1]);
            }

            return WriteMultiRegisters((ushort)address, registers);
        }

        #endregion

        #region 通用发送并接收方法

        /// <summary>
        /// 组装请求报文、发送并校验应答，成功返回应答 PDU（首字节为功能码），失败返回 null
        /// </summary>
        private byte[] Transact(byte function, byte[] pdu)
        {
            lock (lockObj)
            {
                if (!IsConnected)
                {
                    LastError = "从站未连接";
                    return null;
                }

                byte[] request = BuildRequest(function, pdu);

                try
                {
                    byte[] frame = SendAndReceive(request);
                    if (frame == null)
                    {
                        return null;
                    }

                    // 应答帧：6 字节 MBAP 头 + 1 字节站号 + PDU
                    byte[] response = new byte[frame.Length - 7];
                    Array.Copy(frame, 7, response, 0, response.Length);
                    return response;
                }
                catch (Exception ex)
                {
                    ErrorCount++;
                    LastError = ex.Message;
                    // 收发异常通常意味着链路已断，关闭套接字以便上层重连
                    Close();
                    return null;
                }
            }
        }

        /// <summary>
        /// 发送一帧请求并接收、校验一帧应答
        /// </summary>
        /// <returns>完整的应答帧，失败返回 null</returns>
        private byte[] SendAndReceive(byte[] request)
        {
            socket.Send(request);
            SendCount++;

            ByteArray frame = ReceiveFrame();
            string error;
            if (!CheckResponse(frame, request, out error))
            {
                ErrorCount++;
                LastError = error;
                return null;
            }

            return frame.Data;
        }

        /// <summary>
        /// 按 Modbus TCP 报文格式组装请求帧
        /// </summary>
        private byte[] BuildRequest(byte function, byte[] pdu)
        {
            ushort tid = transactionId++;
            if (transactionId == 0)
            {
                transactionId = 1;
            }

            byte[] request = new byte[8 + pdu.Length];
            request[0] = (byte)(tid >> 8);
            request[1] = (byte)(tid & 0xFF);
            request[2] = 0x00;                      // 协议标识，Modbus 固定为 0
            request[3] = 0x00;
            ushort length = (ushort)(pdu.Length + 2); // 站号 + 功能码 + 数据
            request[4] = (byte)(length >> 8);
            request[5] = (byte)(length & 0xFF);
            request[6] = UnitId;
            request[7] = function;
            Array.Copy(pdu, 0, request, 8, pdu.Length);
            return request;
        }

        /// <summary>
        /// 接收完整的一帧报文：先读 6 字节 MBAP 头，再按长度字段读取剩余部分
        /// </summary>
        private ByteArray ReceiveFrame()
        {
            byte[] header = new byte[6];
            ReceiveExact(header, 0, header.Length);

            ushort length = (ushort)((header[4] << 8) | header[5]);
            if (length < 2 || length > 260)
            {
                LastError = "应答报文长度异常：" + length;
                return null;
            }

            ByteArray frame = new ByteArray(6 + length);
            Array.Copy(header, 0, frame.Data, 0, 6);
            ReceiveExact(frame.Data, 6, length);
            return frame;
        }

        /// <summary>
        /// 读取指定字节数，不足则持续接收直到超时
        /// </summary>
        private void ReceiveExact(byte[] buffer, int offset, int count)
        {
            int received = 0;
            while (received < count)
            {
                int len = socket.Receive(buffer, offset + received, count - received, SocketFlags.None);
                if (len <= 0)
                {
                    throw new SocketException((int)SocketError.ConnectionReset);
                }
                received += len;
            }
        }

        #endregion

        #region 数组比较方法

        /// <summary>
        /// 比较两个数组的指定片段是否完全相同
        /// </summary>
        public static bool ArraysEqual(byte[] a, int aIndex, byte[] b, int bIndex, int length)
        {
            if (a == null || b == null)
            {
                return false;
            }
            if (aIndex + length > a.Length || bIndex + length > b.Length)
            {
                return false;
            }
            for (int i = 0; i < length; i++)
            {
                if (a[aIndex + i] != b[bIndex + i])
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 比较两个数组是否完全相同
        /// </summary>
        public static bool ArraysEqual(byte[] a, byte[] b)
        {
            if (a == null || b == null)
            {
                return a == b;
            }
            if (a.Length != b.Length)
            {
                return false;
            }
            return ArraysEqual(a, 0, b, 0, a.Length);
        }

        /// <summary>
        /// 校验应答帧：事务号、协议标识、站号、功能码，以及异常应答
        /// </summary>
        private bool CheckResponse(ByteArray frame, byte[] request, out string error)
        {
            error = string.Empty;

            if (frame == null || frame.Length < 8)
            {
                error = string.IsNullOrEmpty(LastError) ? "未收到有效应答" : LastError;
                return false;
            }

            if (frame.Data[2] != 0 || frame.Data[3] != 0)
            {
                error = "协议标识错误";
                return false;
            }

            if (!ArraysEqual(request, 0, frame.Data, 0, 2))
            {
                error = "事务标识不匹配";
                return false;
            }

            if (frame.Data[6] != UnitId)
            {
                error = "从站地址不匹配：" + frame.Data[6];
                return false;
            }

            byte function = frame.Data[7];
            if ((function & 0x80) != 0)
            {
                error = ModbusExceptionText(frame.Length > 8 ? frame.Data[8] : (byte)0x00);
                return false;
            }

            if (function != request[7])
            {
                error = "功能码不匹配";
                return false;
            }

            return true;
        }

        /// <summary>
        /// 把 Modbus 异常码翻译成中文说明
        /// </summary>
        private static string ModbusExceptionText(byte code)
        {
            switch (code)
            {
                case 0x01: return "非法功能码";
                case 0x02: return "非法数据地址";
                case 0x03: return "非法数据值";
                case 0x04: return "从站设备故障";
                case 0x05: return "请求已确认，正在处理";
                case 0x06: return "从站设备忙";
                case 0x08: return "存储奇偶校验错误";
                case 0x0A: return "网关路径不可用";
                case 0x0B: return "网关目标设备无响应";
                default: return "未知异常码：" + code;
            }
        }

        #endregion

        #region 将布尔数组转换成字节数组

        /// <summary>
        /// 把线圈状态按位打包成字节数组（低位在前），用于 0FH 写多个线圈
        /// </summary>
        public static byte[] BoolArrayToByteArray(bool[] values)
        {
            if (values == null || values.Length == 0)
            {
                return new byte[0];
            }

            byte[] result = new byte[(values.Length + 7) / 8];
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i])
                {
                    result[i / 8] |= (byte)(1 << (i % 8));
                }
            }
            return result;
        }

        #endregion

        #region 应答解析

        /// <summary>
        /// 组装「起始地址 + 数量」4 字节参数
        /// </summary>
        private static byte[] AddressAndQuantity(ushort startAddress, ushort quantity)
        {
            return new byte[]
            {
                (byte)(startAddress >> 8),
                (byte)(startAddress & 0xFF),
                (byte)(quantity >> 8),
                (byte)(quantity & 0xFF)
            };
        }

        /// <summary>
        /// 截取 01H/02H 应答中的线圈位数据，长度按读取数量计算
        /// </summary>
        private byte[] ExtractBits(byte[] response, ushort quantity)
        {
            if (response == null || response.Length < 2)
            {
                return null;
            }

            int byteCount = response[1];
            int need = (quantity + 7) / 8;
            if (byteCount < need || response.Length < 2 + byteCount)
            {
                LastError = "线圈应答数据长度不符";
                return null;
            }

            byte[] result = new byte[need];
            Array.Copy(response, 2, result, 0, need);
            return result;
        }

        /// <summary>
        /// 截取 03H/04H 应答中的寄存器数据，长度 = 数量 * 2
        /// </summary>
        private byte[] ExtractRegisters(byte[] response, ushort quantity)
        {
            if (response == null || response.Length < 2)
            {
                return null;
            }

            int byteCount = response[1];
            if (byteCount != quantity * 2 || response.Length < 2 + byteCount)
            {
                LastError = "寄存器应答数据长度不符";
                return null;
            }

            byte[] result = new byte[byteCount];
            Array.Copy(response, 2, result, 0, byteCount);
            return result;
        }

        /// <summary>
        /// 05H/06H 的应答是请求原样回显，逐字节比对
        /// </summary>
        private bool CheckEcho(byte[] response, byte function, byte[] requestPdu)
        {
            if (response == null || response.Length < 1 + requestPdu.Length)
            {
                return false;
            }
            if (response[0] != function || !ArraysEqual(response, 1, requestPdu, 0, requestPdu.Length))
            {
                LastError = "写入应答与请求不一致";
                return false;
            }
            return true;
        }

        /// <summary>
        /// 0FH/10H 的应答回显起始地址与数量
        /// </summary>
        private bool CheckWriteMulti(byte[] response, byte function, ushort startAddress, ushort quantity)
        {
            if (response == null || response.Length < 5 || response[0] != function)
            {
                return false;
            }

            ushort start = (ushort)((response[1] << 8) | response[2]);
            ushort count = (ushort)((response[3] << 8) | response[4]);
            if (start != startAddress || count != quantity)
            {
                LastError = "写入应答的地址或数量不一致";
                return false;
            }
            return true;
        }

        #endregion
    }

    /// <summary>
    /// 报文容器：保存一帧完整的 Modbus TCP 报文
    /// </summary>
    public class ByteArray
    {
        /// <summary>报文数据</summary>
        public byte[] Data { get; private set; }

        /// <summary>报文长度（字节）</summary>
        public int Length
        {
            get { return Data.Length; }
        }

        public ByteArray(int length)
        {
            Data = new byte[length];
        }

        public byte this[int index]
        {
            get { return Data[index]; }
        }
    }
}
