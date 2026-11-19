using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace MTHDAL
{
    /// <summary>
    /// SQL Server 数据库操作帮助类
    /// </summary>
    public static class SQLHelper
    {
        private static string _connectionString = string.Empty;
        private static readonly object _lock = new object();

        /// <summary>
        /// 最近一次操作的错误信息，成功时为空字符串
        /// </summary>
        public static string LastError { get; private set; } = string.Empty;

        //SQLHelper 所在目录下的 Config\Device.ini
        private static readonly string DefaultIniPath =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config", "Device.ini");

        /// <summary>
        /// 数据库连接字符串。
        /// 优先级：手动赋值 > Device.ini 中的 [数据库] ConnectionString。
        /// 两种都没配时第一次调用会抛 InvalidOperationException。
        /// </summary>
        public static string ConnectionString
        {
            get
            {
                if (!string.IsNullOrEmpty(_connectionString))
                    return _connectionString;

                lock (_lock)
                {
                    if (!string.IsNullOrEmpty(_connectionString))
                        return _connectionString;

                    string fromIni = ReadIniConnectionString(DefaultIniPath);
                    if (!string.IsNullOrEmpty(fromIni))
                    {
                        _connectionString = fromIni;
                        return _connectionString;
                    }
                }

                throw new InvalidOperationException(
                    "SQLHelper.ConnectionString 未配置。请在 " + DefaultIniPath +
                    " 的 [数据库] 节添加 ConnectionString，或在代码里手动赋值 SQLHelper.ConnectionString = \"...\"");
            }
            set { _connectionString = value; }
        }

        private static string ReadIniConnectionString(string iniPath)
        {
            if (!File.Exists(iniPath)) return null;

            try
            {
                byte[] bytes = File.ReadAllBytes(iniPath);
                if (bytes.Length == 0) return null;

                //先按 UTF-8 解析（兼容记事本/VS 保存的 UTF-8 文件）
                string value = ParseConnectionString(Encoding.UTF8.GetString(StripBom(bytes)));
                if (value != null) return value;

                //再按系统默认编码解析（兼容 ANSI/GBK 文件，以及在参数设置里写回的节）
                return ParseConnectionString(Encoding.Default.GetString(bytes));
            }
            catch
            {
                //读 ini 失败时静默回退到"未配置"提示
            }
            return null;
        }

        private static byte[] StripBom(byte[] bytes)
        {
            if (bytes.Length >= 3 && bytes[0] == 0xEF && bytes[1] == 0xBB && bytes[2] == 0xBF)
            {
                byte[] result = new byte[bytes.Length - 3];
                Buffer.BlockCopy(bytes, 3, result, 0, result.Length);
                return result;
            }
            return bytes;
        }

        /// <summary>
        /// 从解码后的 ini 文本里找 [数据库] 节下的 ConnectionString
        /// </summary>
        private static string ParseConnectionString(string text)
        {
            string section = string.Empty;
            string[] lines = text.Replace("\r\n", "\n").Replace('\r', '\n').Split('\n');
            foreach (string raw in lines)
            {
                string line = raw.Trim();
                if (line.Length == 0 || line.StartsWith(";") || line.StartsWith("#")) continue;

                if (line.StartsWith("[") && line.EndsWith("]"))
                {
                    section = line.Substring(1, line.Length - 2).Trim();
                    continue;
                }

                if (section == "数据库")
                {
                    int eq = line.IndexOf('=');
                    if (eq > 0)
                    {
                        string key = line.Substring(0, eq).Trim();
                        string val = line.Substring(eq + 1).Trim();
                        if (string.Equals(key, "ConnectionString", StringComparison.OrdinalIgnoreCase))
                            return val;
                    }
                }
            }
            return null;
        }

        #region ExecuteNonQuery（增/删/改）

        /// <summary>
        /// 执行增删改语句，返回受影响的行数
        /// </summary>
        public static int ExecuteNonQuery(string sql, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                if (parameters != null && parameters.Length > 0)
                    cmd.Parameters.AddRange(parameters);

                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 异步执行增删改语句
        /// </summary>
        public static async Task<int> ExecuteNonQueryAsync(string sql, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                if (parameters != null && parameters.Length > 0)
                    cmd.Parameters.AddRange(parameters);

                await conn.OpenAsync();
                return await cmd.ExecuteNonQueryAsync();
            }
        }

        #endregion

        #region ExecuteScalar（查询单个值）

        /// <summary>
        /// 查询单个值（如 SELECT COUNT(*), SELECT MAX(Id)）
        /// </summary>
        public static object ExecuteScalar(string sql, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                if (parameters != null && parameters.Length > 0)
                    cmd.Parameters.AddRange(parameters);

                conn.Open();
                return cmd.ExecuteScalar();
            }
        }

        public static async Task<object> ExecuteScalarAsync(string sql, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                if (parameters != null && parameters.Length > 0)
                    cmd.Parameters.AddRange(parameters);

                await conn.OpenAsync();
                return await cmd.ExecuteScalarAsync();
            }
        }

        #endregion

        #region ExecuteReader（读取）

        /// <summary>
        /// 执行查询返回 SqlDataReader，使用方负责关闭
        /// </summary>
        public static SqlDataReader ExecuteReader(string sql, params SqlParameter[] parameters)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            try
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                if (parameters != null && parameters.Length > 0)
                    cmd.Parameters.AddRange(parameters);

                conn.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch
            {
                conn.Dispose();
                throw;
            }
        }

        #endregion

        #region ExecuteDataTable / ExecuteDataSet

        /// <summary>
        /// 执行查询返回 DataTable
        /// </summary>
        public static DataTable ExecuteDataTable(string sql, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                adapter.SelectCommand = new SqlCommand(sql, conn);
                if (parameters != null && parameters.Length > 0)
                    adapter.SelectCommand.Parameters.AddRange(parameters);

                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        public static async Task<DataTable> ExecuteDataTableAsync(string sql, params SqlParameter[] parameters)
        {
            return await Task.Run(() => ExecuteDataTable(sql, parameters));
        }

        /// <summary>
        /// 执行查询返回 DataSet（多表）
        /// </summary>
        public static DataSet ExecuteDataSet(string sql, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                adapter.SelectCommand = new SqlCommand(sql, conn);
                if (parameters != null && parameters.Length > 0)
                    adapter.SelectCommand.Parameters.AddRange(parameters);

                DataSet ds = new DataSet();
                adapter.Fill(ds);
                return ds;
            }
        }

        /// <summary>
        /// 执行查询返回 DataSet，查询失败时返回 null（不抛异常）
        /// </summary>
        public static DataSet GetDataSet(string sql, params SqlParameter[] parameters)
        {
            try
            {
                LastError = string.Empty;
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                using (SqlDataAdapter adapter = new SqlDataAdapter())
                {
                    adapter.SelectCommand = new SqlCommand(sql, conn);
                    if (parameters != null && parameters.Length > 0)
                        adapter.SelectCommand.Parameters.AddRange(parameters);

                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    return ds;
                }
            }
            catch (Exception ex)
            {
                LastError = ex.Message;
                return null;
            }
        }

        #endregion

        #region 事务

        /// <summary>
        /// 批量执行多条 SQL，在同一个事务里；任意一条失败全部回滚
        /// </summary>
        public static int ExecuteTransaction(IEnumerable<SqlCommand> commands)
        {
            int totalAffected = 0;
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlTransaction tran = conn.BeginTransaction())
                {
                    try
                    {
                        foreach (SqlCommand cmd in commands)
                        {
                            cmd.Connection = conn;
                            cmd.Transaction = tran;
                            totalAffected += cmd.ExecuteNonQuery();
                        }
                        tran.Commit();
                        return totalAffected;
                    }
                    catch
                    {
                        tran.Rollback();
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// 使用委托的事务包装，连接和事务由 SQLHelper 管理
        /// </summary>
        public static void ExecuteTransaction(Action<SqlConnection, SqlTransaction> action)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlTransaction tran = conn.BeginTransaction())
                {
                    try
                    {
                        action(conn, tran);
                        tran.Commit();
                    }
                    catch
                    {
                        tran.Rollback();
                        throw;
                    }
                }
            }
        }

        #endregion

        #region 工具

        /// <summary>
        /// 测试数据库连接是否正常
        /// </summary>
        public static bool TestConnection()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 构造 SqlParameter 的便捷方法
        /// </summary>
        public static SqlParameter Param(string name, object value)
        {
            //DBNull.Value 替代 null
            return new SqlParameter(name, value ?? DBNull.Value);
        }

        #endregion
    }
}
