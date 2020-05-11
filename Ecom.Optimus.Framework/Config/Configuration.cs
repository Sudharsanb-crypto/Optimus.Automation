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

    }
}
