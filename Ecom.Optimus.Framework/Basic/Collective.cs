using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecom.Optimus.Framework.Config;

namespace Ecom.Optimus.Framework.Basic
{
    public class Collective
    {
        public static IWebDriver driver; 

        public static string Browser{ get; set; }

        public static string Url { get; set; }

        public static string Password { get; set; }

        public static int PageLoadTime { get; set; }

        public static int ImplicitWaitTimeOut { get; set; }

        public static TimeSpan DefaultTimeSpan { get; set; }

        public static void configreader()
        {
            Browser = Configuration.GetInfo().Browser;
            Url = Configuration.GetInfo().Url;
            Password = Configuration.GetInfo().Password;
            PageLoadTime = Configuration.GetInfo().PageLoadTime;
            DefaultTimeSpan = Configuration.GetInfo().DefaultTimeSpan;
        }
    }
}
