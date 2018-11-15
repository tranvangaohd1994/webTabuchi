using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public class CommonFuntion
    {
        public int calcuTotalMinuteDay(String f1, String t1, String f2, String t2, String f3, String t3, String f4, String t4, String f5, String t5, String f6, String t6)
        {
            int totalTime, ts1, ts2, ts3, ts4, ts5, ts6 = 0;
            if ("".Equals(f1) && "".Equals(t1))
            {
                ts1 = 0;
            }
            else
            {
                ts1 = (int)(TimeSpan.Parse(t1).TotalMinutes - TimeSpan.Parse(f1).TotalMinutes);
            }
            if ("".Equals(f2) && "".Equals(t2))
            {
                ts2 = 0;
            }
            else
            {
                ts2 = (int)(TimeSpan.Parse(t2).TotalMinutes - TimeSpan.Parse(f2).TotalMinutes);
            }
            if ("".Equals(f3) && "".Equals(t3))
            {
                ts3 = 0;
            }
            else
            {
                ts3 = (int)(TimeSpan.Parse(t3).TotalMinutes - TimeSpan.Parse(f3).TotalMinutes);
            }
            if ("".Equals(f4) && "".Equals(t4))
            {
                ts4 = 0;
            }
            else
            {
                ts4 = (int)(TimeSpan.Parse(t4).TotalMinutes - TimeSpan.Parse(f4).TotalMinutes);
            }
            if ("".Equals(f5) && "".Equals(t5))
            {
                ts5 = 0;
            }
            else
            {
                ts5 = (int)(TimeSpan.Parse(t5).TotalMinutes - TimeSpan.Parse(f5).TotalMinutes);
            }
            if ("".Equals(f6) && "".Equals(t6))
            {
                ts6 = 0;
            }
            else
            {
                ts6 = (int)(TimeSpan.Parse(t6).TotalMinutes - TimeSpan.Parse(f6).TotalMinutes);
            }
            totalTime = ts1 + ts2 + ts3 + ts4 + ts5 + ts6;
            return totalTime; ;
        }
        public float calcuTactTime(int TM, int Plan)
        {
            float tactTime = 0;
            tactTime = (float)(TM * 60) / Plan;
            return tactTime;
        }
        public string convertIntLess10(int value)
        {
            if (value >= 10)
            {
                return value.ToString();
            }
            else
                return "0" + value;
        }

        public int calcuTotalMinuteNight(String f1, String t1, String f2, String t2,
       String f3, String t3, String f4, String t4, String f5, String t5, String f6, String t6)
        {
            double ts1, ts2, ts3, ts4, ts5, ts6 = 0;
            if ("".Equals(f1) && "".Equals(t1))
            {
                ts1 = 0;
            }
            else
            {
                ts1 = (int)(TimeSpan.Parse(t1).TotalMinutes - TimeSpan.Parse(f1).TotalMinutes);
            }
            if ("".Equals(f2) && "".Equals(t2))
            {
                ts2 = 0;
            }
            else
            {
                ts2 = (int)(TimeSpan.Parse(t2).TotalMinutes - TimeSpan.Parse(f2).TotalMinutes);
            }
            if ("".Equals(f3) && "".Equals(t3))
            {
                ts3 = 0;
            }
            else
            {
                ts3 = (int)(TimeSpan.Parse(t3).TotalMinutes - TimeSpan.Parse(f3).TotalMinutes);
            }
            if ("".Equals(f4) && "".Equals(t4))
            {
                ts4 = 0;
            }
            else
            {
                ts4 = (int)(TimeSpan.Parse(t4).TotalMinutes - TimeSpan.Parse(f4).TotalMinutes);
            }
            if ("".Equals(f5) && "".Equals(t5))
            {
                ts5 = 0;
            }
            else
            {
                ts5 = (int)(TimeSpan.Parse(t5).TotalMinutes - TimeSpan.Parse(f5).TotalMinutes);
            }
            if ("".Equals(f6) && "".Equals(t6))
            {
                ts6 = 0;
            }
            else
            {
                ts6 = (int)(TimeSpan.Parse(t6).TotalMinutes - TimeSpan.Parse(f6).TotalMinutes);
            }
            if (ts1 < 0)
            {
                ts1 = ts1 + 60 * 24;
            }
            if (ts2 < 0)
            {
                ts2 = ts2 + 60 * 24;
            }
            if (ts3 < 0)
            {
                ts3 = ts3 + 60 * 24;
            }
            if (ts4 < 0)
            {
                ts4 = ts4 + 60 * 24;
            }
            if (ts5 < 0)
            {
                ts5 = ts5 + 60 * 24;
            }
            int totalTime = (int)(ts1 + ts2 + ts3 + ts4 + ts5 + ts6);
            return totalTime;
        }

        public int ConvertInt(String str)
        {
            int i;
            if (!int.TryParse(str, out i))
            {
                i = 0;
            }
            return i;
        }

        public float ConvertFloat(String str)
        {
            float i;
            if (!float.TryParse(str, out i))
            {
                i = 0;
            }
            return i;
        }

        public double ConvertDouble(String str)
        {
            double i;
            if (!double.TryParse(str, out i))
            {
                i = 0;
            }
            return i;
        }
        public static byte[] encryptData(string data)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider md5Hasher = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] hashedBytes;
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            hashedBytes = md5Hasher.ComputeHash(encoder.GetBytes(data));
            return hashedBytes;
        }
        public static string md5(string data)
        {
            return BitConverter.ToString(encryptData(data)).Replace("-", "").ToLower();
        }

        public int ConvertInt2(string p)
        {
            int i;
            if (!int.TryParse(p, out i))
            {
                i = -1;
            }
            return i;
        }
    }
}
