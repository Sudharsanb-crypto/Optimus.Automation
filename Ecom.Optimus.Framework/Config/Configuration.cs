using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Optimus.Framework.Config
{
    public class Configuration
    {
        private static Configuration _config;

        public static Configuration GetInfo()
        {
            if (_config == null)
            {
                return _config = new Configuration();
            }

            return _config;
        }

        public string Browser
        {
            get
            {
                _browser = ConfigurationManager.AppSettings["browser"].ToString();
                if (!string.IsNullOrEmpty(_browser))
                    return _browser;
                else
                    Console.WriteLine("\t\tMissing browser info.");

                return _browser;
            }
            set
            {
                _browser = value;
   
            }
        }
        public static string _browser;

        public string Url
        {
            get
            {
                _url = ConfigurationManager.AppSettings["Url"].ToString();
                if (!string.IsNullOrEmpty(_url))
                    return _url;
                else
                    Console.WriteLine("\t\tMissing Url info.");
                return _url;
            }
            set
            {
                _url = value;

            }
        }
        public static string _url;

        public string Password
        {
            get
            {
                _password = ConfigurationManager.AppSettings["Password"].ToString();
                if (!string.IsNullOrEmpty(_password))
                    return _password;
                else
                    Console.WriteLine("\t\tMissing Password info.");
                return _password;
            }
            set
            {
                _password = value;

            }
        }
        public static string _password;

        public int PageLoadTime
        {
            get
            {
                _pageloadtime = Convert.ToInt32(ConfigurationManager.AppSettings["PageLoadTime"]);
                if (_pageloadtime!=0)
                    return _pageloadtime;
                else
                    Console.WriteLine("\t\tMissing page load time info.");
                return _pageloadtime;
            }
            set
            {
                _pageloadtime = value;

            }
        }
        public static int _pageloadtime;

        public int ImpilicitWait
        {
            get
            {
                _impilicitwait = Convert.ToInt32(ConfigurationManager.AppSettings["ImpilicitWait"]);
                if (_impilicitwait != 0)
                    return _impilicitwait;
                else
                    Console.WriteLine("\t\tMissing impilicit wait info.");
                return _impilicitwait;
            }
            set
            {
                _impilicitwait = value;

            }
        }
        public static int _impilicitwait;


        /// <summary>
        /// Get and set for defaultTimeSpan
        /// </summary>
        public TimeSpan DefaultTimeSpan
        {
            get
            {
                _defaultTimeSpan = new TimeSpan(0, 0, ImpilicitWait);
                if (ImpilicitWait != 0)
                    return _defaultTimeSpan;
                else
                    Console.WriteLine("\t\tMissing defaultTimeSpan info.");
                return _defaultTimeSpan;
            }
            set
            {
                _defaultTimeSpan = value;
                Console.WriteLine(@"\t\tMissing defaultTimeSpan info. Default to {_defaultTimeSpan}");
            }
        }
        private static TimeSpan _defaultTimeSpan;


        public string TestReportFilePath
        {
            get
            {
                _reportfilepath = ConfigurationManager.AppSettings["TestReportsPath"].ToString();
                if (!string.IsNullOrEmpty(_reportfilepath))
                    return _reportfilepath;
                else
                    Console.WriteLine("\t\tMissing Test report path info.");
                return _reportfilepath;
            }
            set
            {
                _reportfilepath = value;

            }
        }
        public static string _reportfilepath;
    }
}
