using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace VideoTapes
{
    public partial class Utils
    {
        #region Time units
        /// <summary>
        /// Number of MilliSeconds in a second.
        /// </summary>
        /// <remarks>
        /// This constant may be useful for calculations
        /// </remarks>
        public const long MILLISECONDS = (1000);            // 10 ^ 3
        /// <summary>
        /// Number of NanoSeconds in a second.
        /// </summary>
        /// <remarks>
        /// This constant may be useful for calculations
        /// </remarks>
        public const long NANOSECONDS = (1000000000);       // 10 ^ 9
        /// <summary>
        /// Number of 100NS in a second.
        /// </summary>
        /// <remarks>
        /// To convert from seconds to 100NS 
        /// units (used by most DES function), multiply the seconds by UNITS.
        /// </remarks>
        public const long UNITS = (NANOSECONDS / 100);      // 10 ^ 7
        /// <summary>
        /// Frame Length in NanoSeconds for Pal.
        /// </summary>
        /// <remarks>
        /// </remarks>
        public const long PALUNITS = (UNITS / 25);      // 10 ^ 7
        #endregion
        /// <summary>
        /// Necessary for DV frames
        /// </summary>
        /// <param name="data"></param>
        /// <param name="start"></param>
        /// <returns></returns>
        public static DateTime[] ComputeCodeAndStampFrame(byte[] data, int start)
        {
            DateTime[] result = new DateTime[2];
            if ((data[start] == 0x62) && (data[start + 5] == 0x63))
            {
                int a1 = 0;
                int a2 = 0;
                //Day
                a1 = (int)data[start + 2] & 0x0F;
                a2 = ((int)data[start + 2] & 0x30) / 16;
                int jour = 10 * a2 + a1;
                a1 = (int)data[start + 3] & 0x0F;
                a2 = ((int)data[start + 3] & 0x10) / 16;
                // Month
                int mois = 10 * a2 + a1;
                a1 = (int)data[start + 4] & 0x0F;
                a2 = ((int)data[start + 4] & 0x30) / 16;
                int an = 10 * a2 + a1;
                if (an < 30) an += 2000;
                // Hour
                a1 = (int)data[start + 9] & 0x0F;
                a2 = ((int)data[start + 9] & 0x30) / 16;
                int hour = 10 * a2 + a1;
                // Minutes
                a1 = (int)data[start + 8] & 0x0F;
                a2 = ((int)data[start + 8] & 0x70) / 16;
                int min = 10 * a2 + a1;
                // Seconds
                a1 = (int)data[start + 7] & 0x0F;
                a2 = ((int)data[start + 7] & 0x70) / 16;
                int sec = 10 * a2 + a1;
                // Frames
                a1 = (int)data[start + 6] & 0x0F;
                a2 = ((int)data[start + 6] & 0x30) / 16;
                int millis = (10 * a2 + a1) * 40;
                result[0] = new DateTime(an, mois, jour, hour, min, sec);
            }
            else
            {
                result[0] = DateTime.MinValue;
            }
            int debut = start - 0x15C;
            if (data[debut] == 0x13)
            {
                int[] d = new int[9];
                d[1] = (int)data[debut + 1] & 0x0F;
                d[2] = ((int)data[debut + 1] & 0x30) / 16;
                d[3] = (int)data[debut + 2] & 0x0F;
                d[4] = ((int)data[debut + 2] & 0x70) / 16;
                d[5] = (int)data[debut + 3] & 0x0F;
                d[6] = ((int)data[debut + 3] & 0x70) / 16;
                d[7] = (int)data[debut + 4] & 0x0F;
                d[8] = ((int)data[debut + 4] & 0x30) / 16;
                int h = 10 * d[8] + d[7];
                int m = 10 * d[6] + d[5];
                int s = 10 * d[4] + d[3];
                int f = 10 * d[2] + d[1];
                result[1] = new DateTime(1, 1, 1, h, m, s, f * 40);
            }
            else
            {
                result[1] = DateTime.MinValue;
            }
            return result;
        }
        #region Utility functions
        public static string ToTime(double f)
        {
            double AvgTimeFrame = 0.04;
            int dur = (int)f / 25;

            int hour = 0;
            int mn = 0;
            int fr = (int)(f - dur * 25);
            if (dur > 3599)
            {
                hour = dur / 3600;
                dur -= hour * 3600;
            }
            if (dur > 59)
            {
                mn = dur / 60;
                dur -= mn * 60;
            }
            double le = f - hour * 3600 - mn * 60 - dur;
            double fps = 1 / AvgTimeFrame;
            return "T" + hour.ToString("00") + ":" + mn.ToString("00") + ":" + dur.ToString("00")
                + ":" + fr.ToString("00") + "F" + fps.ToString("00");
        }
        public static string ToTime(double f, double AvgTimeFrame)
        {
            int dur = (int)f;
            int hour = 0;
            int mn = 0;
            if (dur > 3599)
            {
                hour = dur / 3600;
                dur -= hour * 3600;
            }
            if (dur > 59)
            {
                mn = dur / 60;
                dur -= mn * 60;
            }
            double le = f - hour * 3600 - mn * 60 - dur;
            double frame = le / AvgTimeFrame;
            double fps = 1 / AvgTimeFrame;
            return "T" + hour.ToString("00") + ":" + mn.ToString("00") + ":" + dur.ToString("00")
                + ":" + frame.ToString("00") + "F" + fps.ToString("00");
        }
        public static string ByteToString(byte[] c)
        {
            string ret = "";
            for (int i = 0; i < c.Length; i++)
            {
                ret += (char)c[i];
            }
            return ret;
        }
        public static string ByteToHex(byte[] c)
        {
            string ret = "";
            for (int i = 0; i < c.Length; i++)
            {
                ret += c[i].ToString("x2");
            }
            return ret;
        }
        public static long ByteToInt(byte[] c)
        {
            long taille = 0;
            for (int w = 0; w < c.Length; w++)
            {
                taille = 256 * taille + (uint)c[c.Length - 1 - w];
            }
            return taille;
        }
        #endregion
    }    

}
