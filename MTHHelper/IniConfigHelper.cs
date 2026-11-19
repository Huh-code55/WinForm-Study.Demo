using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MTHHelper
{
    /// <summary>
    /// INI 配置文件读写帮助类（托管实现，兼容 UTF-8 与 ANSI/GBK）
    /// </summary>
    public static class IniConfigHelper
    {
        /// <summary>
        /// 写入 INI 文件，返回是否写入成功
        /// </summary>
        public static bool WriteIniData(string section, string key, string value, string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                return false;

            try
            {
                string dir = Path.GetDirectoryName(filePath);
                if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }

                List<string> lines = ReadAllLines(filePath);
                int sectionIdx = -1;
                int keyIdx = -1;
                int sectionEnd = lines.Count;

                for (int i = 0; i < lines.Count; i++)
                {
                    string line = lines[i].Trim();
                    if (line.StartsWith("[") && line.EndsWith("]") && line.Length >= 2)
                    {
                        string sec = line.Substring(1, line.Length - 2).Trim();
                        if (sectionIdx >= 0)
                        {
                            sectionEnd = i;
                            break;
                        }
                        if (sec == section)
                        {
                            sectionIdx = i;
                            sectionEnd = lines.Count;
                        }
                    }
                    else if (sectionIdx >= 0 && keyIdx < 0)
                    {
                        int eq = line.IndexOf('=');
                        if (eq > 0)
                        {
                            string k = line.Substring(0, eq).Trim();
                            if (k == key)
                            {
                                keyIdx = i;
                            }
                        }
                    }
                }

                string newLine = key + "=" + (value ?? string.Empty);
                if (keyIdx >= 0)
                {
                    lines[keyIdx] = newLine;
                }
                else if (sectionIdx >= 0)
                {
                    lines.Insert(sectionIdx + 1, newLine);
                }
                else
                {
                    lines.Add("[" + section + "]");
                    lines.Add(newLine);
                }

                //统一用 UTF-8（无 BOM）写回，与 Device.ini 现有编码一致
                File.WriteAllLines(filePath, lines.ToArray(), new UTF8Encoding(false));
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 读取 INI 文件的值；文件或键不存在时返回 defaultValue
        /// </summary>
        public static string ReadIniData(string section, string key, string defaultValue, string filePath)
        {
            if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
                return defaultValue;

            try
            {
                List<string> lines = ReadAllLines(filePath);
                string curSection = string.Empty;
                foreach (string raw in lines)
                {
                    string line = raw.Trim();
                    if (line.Length == 0 || line.StartsWith(";") || line.StartsWith("#"))
                        continue;

                    if (line.StartsWith("[") && line.EndsWith("]") && line.Length >= 2)
                    {
                        curSection = line.Substring(1, line.Length - 2).Trim();
                        continue;
                    }

                    if (curSection == section)
                    {
                        int eq = line.IndexOf('=');
                        if (eq > 0)
                        {
                            string k = line.Substring(0, eq).Trim();
                            if (k == key)
                            {
                                string v = line.Substring(eq + 1).Trim();
                                return string.IsNullOrEmpty(v) ? defaultValue : v;
                            }
                        }
                    }
                }
            }
            catch
            {
            }
            return defaultValue;
        }

        /// <summary>
        /// 删除 INI 文件中的整个节，返回是否删除成功
        /// </summary>
        public static bool DeleteIniSection(string section, string filePath)
        {
            if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
                return false;

            try
            {
                List<string> lines = ReadAllLines(filePath);
                List<string> result = new List<string>();
                bool inTarget = false;
                foreach (string raw in lines)
                {
                    string line = raw.Trim();
                    if (line.StartsWith("[") && line.EndsWith("]") && line.Length >= 2)
                    {
                        string sec = line.Substring(1, line.Length - 2).Trim();
                        inTarget = (sec == section);
                    }
                    if (!inTarget)
                        result.Add(raw);
                }
                File.WriteAllLines(filePath, result.ToArray(), new UTF8Encoding(false));
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 读取 ini 所有行。优先按 UTF-8 严格解码，失败时回退到系统默认编码（GBK）。
        /// </summary>
        private static List<string> ReadAllLines(string filePath)
        {
            //文件不存在时返回空列表（用于新建场景）
            if (!File.Exists(filePath))
                return new List<string>();

            byte[] bytes = File.ReadAllBytes(filePath);
            string text;
            if (bytes.Length >= 3 && bytes[0] == 0xEF && bytes[1] == 0xBB && bytes[2] == 0xBF)
            {
                text = new UTF8Encoding(false).GetString(bytes, 3, bytes.Length - 3);
            }
            else
            {
                try
                {
                    text = new UTF8Encoding(false, true).GetString(bytes);
                }
                catch (DecoderFallbackException)
                {
                    text = Encoding.Default.GetString(bytes);
                }
            }
            return new List<string>(text.Replace("\r\n", "\n").Replace('\r', '\n').Split('\n'));
        }
    }
}
