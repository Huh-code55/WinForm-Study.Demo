using MTHModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTHDAL
{
    public class SysLogService
    {
        /// <summary>
        /// 插入一条报警记录
        /// </summary>
        /// <param name="sysLog"></param>
        /// <returns></returns>
        public int AddSysLog(SysLog sysLog)
        {
            string sql = "Insert into SysLog(InsertTime,Note,Operator,VarName,AlarmType) ";

            sql += " values(@InsertTime,@Note,@Operator,@VarName,@AlarmType)";

            SqlParameter[] sqlParameters = new SqlParameter[]
            {
            new SqlParameter("@InsertTime",sysLog.InsertTime),
            new SqlParameter("@Note",sysLog.Note),
            new SqlParameter("@Operator",sysLog.Operator),
            new SqlParameter("@VarName",sysLog.VarName),
            new SqlParameter("@AlarmType",sysLog.AlarmType),
            };

            return SQLHelper.ExecuteNonQuery(sql, sqlParameters);
        }

        public DataTable QuerySysLogByCondition(string start, string end, string alarmType)
        {
            string sql = "Select InsertTime,Note,Operator,VarName,AlarmType from SysLog where InsertTime between @Start and @End";

            List<SqlParameter> sqlParameters = new List<SqlParameter>
        {
            new SqlParameter("@Start",start),
            new SqlParameter("@End",end)
        };

            if (alarmType.Length > 0)
            {
                sql += " and AlarmType=@AlarmType";
                sqlParameters.Add(new SqlParameter("@AlarmType", alarmType));
            }
            try
            {
                DataSet dataSet = SQLHelper.GetDataSet(sql, sqlParameters.ToArray());

                if (dataSet.Tables.Count > 0)
                {
                    return dataSet.Tables[0];
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                return null;
            }
           
        }
    }
}
