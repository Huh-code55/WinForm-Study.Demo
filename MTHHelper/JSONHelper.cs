using Newtonsoft.Json;
using System;

namespace MTHHelper
{
    /// <summary>
    /// JSON 帮助类
    /// </summary>
    public class JSONHelper
    {
        /// <summary>
        /// 使用 Newtonsoft 方式将实体对象转换成 JSON 字符串
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="x">对象</param>
        /// <returns>JSON 字符串</returns>
        public static string EntityToJSON<T>(T x)
        {
            string result = string.Empty;

            try
            {
                result = JsonConvert.SerializeObject(x);
            }
            catch (Exception)
            {
                result = string.Empty;
            }
            return result;
        }

        /// <summary>
        /// 使用 Newtonsoft 方式将 JSON 字符串转换成实体类
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="json">JSON 字符串</param>
        /// <returns>对象</returns>
        public static T JSONToEntity<T>(string json)
        {
            T t = default(T);

            try
            {
                t = (T)JsonConvert.DeserializeObject(json, typeof(T));
            }
            catch (Exception)
            {
                t = default(T);
            }
            return t;
        }
    }
}
