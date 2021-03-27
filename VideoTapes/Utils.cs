using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VideoTapes
{
    public class Utils
    {
        private static string thumbsDirectory;
        private static string defaultDataBase;
        private static string diskBase;
        private static string hdBase;
        private static string connectionString;
        private static string currentCountry;
        #region Properties
        public static ImageCodecInfo jgpEncoder;
        public static EncoderParameters encoderParameters;
        public static Dictionary<string, string> parameters;
        public static string ThumbsDirectory
        {
            get
            {
                parameters.TryGetValue("[ThumbsDirectory]", out thumbsDirectory);
                return thumbsDirectory;
            }
            set { Utils.thumbsDirectory = value; }
        }
        public static string DefaultDataBase
        {
            get
            {
                parameters.TryGetValue("[DefaultDataBase]", out defaultDataBase);
                return Utils.defaultDataBase;
            }
            set { Utils.defaultDataBase = value; }
        }
        public static string DiskBase
        {
            get
            {
                parameters.TryGetValue("[DiskBase]", out diskBase);
                return Utils.diskBase;
            }
            set { Utils.diskBase = value; }
        }
        public static string HDBase
        {
            get
            {
                parameters.TryGetValue("[HDBase]", out hdBase);
                return Utils.hdBase;
            }
            set { Utils.hdBase = value; }
        }
        public static string ConnectionString
        {
            get
            {
                parameters.TryGetValue("[ConnectionString]", out connectionString);
                return Utils.connectionString;
            }
            set { Utils.connectionString = value; }
        }
        public static string CurrentCountry
        {
            get
            {
                parameters.TryGetValue("[CurrentCountry]", out currentCountry);
                return Utils.currentCountry;
            }
            set { Utils.currentCountry = value; }
        }
        public static Color vid_color = Color.LightYellow;
        public static Color aud_color = Color.LightBlue;
        public static Color trans_color = Color.LightGray;
        #endregion
        public static void SetEncoding()
        {
            jgpEncoder = GetEncoder(ImageFormat.Jpeg);
            // Create an Encoder object based on the GUID
            // for the Quality parameter category.
            System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
            // Create an EncoderParameters object.
            // An EncoderParameters object has an array of EncoderParameter
            // objects. In this case, there is only one
            // EncoderParameter object in the array.
            encoderParameters = new EncoderParameters(1);
            EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 75L);
            encoderParameters.Param[0] = myEncoderParameter;
        }
        public static ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }
        public static bool SetDefaults()
        {
            ReadParams();
            SetEncoding();
            return true;
        }
        public static void SaveParams()
        {
            StreamWriter sw = new StreamWriter("VideoIndex.Ini");
            foreach (string k in parameters.Keys)
            {
                sw.WriteLine(k);
                string data;
                parameters.TryGetValue(k, out data);
                sw.WriteLine(data);
            }
            sw.Close();
        }
        public static void ReadParams()
        {
            string iniName = "VideoIndex.Ini";
            if (!File.Exists(iniName))
            {
                OpenFileDialog opfd = new OpenFileDialog();
                if (opfd.ShowDialog() == DialogResult.OK)
                {
                    iniName = opfd.FileName;
                }
                else
                {
                    ThumbsDirectory = @"E:\VideoThumbs\";
                    DefaultDataBase = "Videos V2.mdb";
                    DiskBase = @"G:\DVVideo\";
                    HDBase = @"G:\HDWRITER";
                    ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=";
                    CurrentCountry = "France";
                    return;
                }
            }
            StreamReader sp = new StreamReader(iniName);
            parameters = new Dictionary<string, string>();
            while (!sp.EndOfStream)
            {
                string key = sp.ReadLine();
                string data = sp.ReadLine();
                parameters.Add(key, data);
            }
            sp.Close();
        }
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
                dur = dur - hour * 3600;
            }
            if (dur > 59)
            {
                mn = dur / 60;
                dur = dur - mn * 60;
            }
            double le = f - hour * 3600 - mn * 60 - dur;
            double frame = le / AvgTimeFrame;
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
                dur = dur - hour * 3600;
            }
            if (dur > 59)
            {
                mn = dur / 60;
                dur = dur - mn * 60;
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
                ret = ret + (char)c[i];
            }
            return ret;
        }
        public static string ByteToHex(byte[] c)
        {
            string ret = "";
            for (int i = 0; i < c.Length; i++)
            {
                ret = ret + c[i].ToString("x2");
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
    }     /// <summary

}
