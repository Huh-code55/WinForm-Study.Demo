using MTHHelper;
using MTHModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using thinger.DataConvertLib;

namespace MTHProject
{
    public class CommonMethods
    {
        public static Device Device { get; set; }

        public static Action<int, string> AddLog;

        public static SysAdmin CurrentAdmin { get; set; }
        /// <summary>
        /// ModbusTCP通信对象
        /// </summary>
        public static ModbusTCP Modbus { get; set; }
        public static DataFormat dataFormat = DataFormat.ABCD;
        private static Variable FindVariable(string varName)
        {
            foreach (var item in Device.GroupList)
            {
                var res = item.VarList.Find(c => c.VarName == varName);

                if (res != null)
                {
                    return res;
                }
            }
            return null;
        }

        public static bool CommonWrite(string varName, string varValue)
        {
            var variable = FindVariable(varName);

            //第一步：先找到变量对象
            if (variable != null)
            {
                //第二步：获取变量类型

                DataType dataType = (DataType)Enum.Parse(typeof(DataType), variable.DataType, true);

                //第三步：获取写入数据
                var result = MigrationLib.SetMigrationValue(varValue, dataType, variable.Scale.ToString(), variable.Offset.ToString());

                if (result.IsSuccess)
                {
                    try
                    {
                        //第四步：写入数据
                        switch (dataType)
                        {
                            case DataType.Bool:
                                return Modbus.PreSetSingleCoil(variable.Start, Convert.ToBoolean(result.Content));
                            case DataType.Short:
                                return Modbus.PreSetSingleRegister(variable.Start, Convert.ToInt16(result.Content));
                            case DataType.UShort:
                                return Modbus.PreSetSingleRegister(variable.Start, Convert.ToUInt16(result.Content));
                            case DataType.Int:
                                return Modbus.PreSetMultiRegisters(variable.Start, ByteArrayLib.GetByteArrayFromInt(Convert.ToInt32(result.Content), dataFormat));
                            case DataType.UInt:
                                return Modbus.PreSetMultiRegisters(variable.Start, ByteArrayLib.GetByteArrayFromUInt(Convert.ToUInt32(result.Content), dataFormat));
                            case DataType.Float:
                                return Modbus.PreSetMultiRegisters(variable.Start, ByteArrayLib.GetByteArrayFromFloat(Convert.ToSingle(result.Content), dataFormat));
                            case DataType.Double:
                                return Modbus.PreSetMultiRegisters(variable.Start, ByteArrayLib.GetByteArrayFromDouble(Convert.ToDouble(result.Content), dataFormat));
                            case DataType.Long:
                                return Modbus.PreSetMultiRegisters(variable.Start, ByteArrayLib.GetByteArrayFromLong(Convert.ToInt64(result.Content), dataFormat));
                            case DataType.ULong:
                                return Modbus.PreSetMultiRegisters(variable.Start, ByteArrayLib.GetByteArrayFromULong(Convert.ToUInt64(result.Content), dataFormat));
                            case DataType.String:
                                return Modbus.PreSetMultiRegisters(variable.Start, ByteArrayLib.GetByteArrayFromString(result.Content, Encoding.ASCII));
                            case DataType.ByteArray:
                                return Modbus.PreSetMultiRegisters(variable.Start, ByteArrayLib.GetByteArrayFromHexString(result.Content, " "));
                            case DataType.HexString:
                                return Modbus.PreSetMultiRegisters(variable.Start, ByteArrayLib.GetByteArrayFromHexString(result.Content, " "));
                            default:
                                break;
                        }
                    }
                    catch (Exception)
                    {

                        return false;
                    }
                    
                }
            }
            return false;
        }

    

    }
}
