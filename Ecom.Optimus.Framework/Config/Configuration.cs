using Ecom.Optimus.Framework.Basic;
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

        /// <summary>
        /// Get and set browser value
        /// </summary>
        public string Browser
        {
            get
            {
                _browser = ConfigurationManager.AppSettings["browser"].ToString();
                if (!string.IsNullOrEmpty(_browser))
                    return _browser;
                else
                    Console.WriteLine("\t\tMissing browser info.");
                    throw new TestConfigBrowserEmptyException();
               
            }
            set
            {
                _browser = value;
   
            }
        }
        public static string _browser;

        /// <summary>
        /// Get and set the Url 
        /// </summary>
        public string Url
        {
            get
            {
                _url = ConfigurationManager.AppSettings["Url"].ToString();
                if (!string.IsNullOrEmpty(_url))
                    return _url;
                else
                    Console.WriteLine("\t\tMissing Url info.");
                throw new TestConfigUrlEmptyException();
            }
            set
            {
                _url = value;

            }
        }
        public static string _url;

        /// <summary>
        /// Get and set Password value
        /// </summary>
        public string Password
        {
            get
            {
                _password = ConfigurationManager.AppSettings["Password"].ToString();
                if (!string.IsNullOrEmpty(_password))
                    return _password;
                else
                    Console.WriteLine("\t\tMissing Password info.");
                throw new TestConfigPasswordEmptyException();
            }
            set
            {
                _password = value;

            }
        }
        public static string _password;

        /// <summary>
        /// Get and set Page load time value
        /// </summary>
        public int PageLoadTime
        {
            get
            {
                _pageloadtime = Convert.ToInt32(ConfigurationManager.AppSettings["PageLoadTime"]);
                if (_pageloadtime!=0)
                    return _pageloadtime;
                else
                    Console.WriteLine("\t\tMissing page load time info.");
                throw new TestConfigPageLoadTimeEmptyException();
            }
            set
            {
                _pageloadtime = value;

            }
        }
        public static int _pageloadtime;

        /// <summary>
        /// Get and set Implilicit wait 
        /// </summary>
        public int ImpilicitWait
        {
            get
            {
                try
                {
                    _impilicitwait = Convert.ToInt32(ConfigurationManager.AppSettings["ImpilicitWait"]);
                }
                catch(Exception)
                {
                    throw new Exception ("Incorrect input format provided in impilicit wait. Input should be integer type");
                }
                if (_impilicitwait != 0)
                    return _impilicitwait;
                else
                    Console.WriteLine("\t\tMissing impilicit wait info.");
                throw new TestConfigImpilicitWaitEmptyException();
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
                throw new TestConfigDefaultTimeEmptyException();
            }
            set
            {
                _defaultTimeSpan = value;
                Console.WriteLine(@"\t\tMissing defaultTimeSpan info. Default to {_defaultTimeSpan}");
            }
        }
        private static TimeSpan _defaultTimeSpan;

        /// <summary>
        /// Get and set Test Report File path
        /// </summary>
        public string TestReportFilePath
        {
            get
            {
                _reportfilepath = ConfigurationManager.AppSettings["TestReportsPath"].ToString();
                if (!string.IsNullOrEmpty(_reportfilepath))
                    return _reportfilepath;
                else
                    Console.WriteLine("\t\tMissing Test report path info.");
                throw new TestConfigTestReportPathEmptyException();
            }
            set
            {
                _reportfilepath = value;

            }
        }
        public static string _reportfilepath;
    }
}
