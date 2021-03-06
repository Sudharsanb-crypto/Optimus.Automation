﻿using Ecom.Optimus.Framework.Config;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Optimus.Framework
{
    public class SelDriverFactory
    {
       
        public IWebDriver driver;

        public IWebDriver GetDriver()
        {
            var browser = Collective.Browser;

            switch(browser.ToLower())
            {
                case "chrome":
                    driver = new ChromeDriver();
                    break;

                case "firefox":
                    driver = new FirefoxDriver();
                    break;

                default:
                     // throw exception incorrect browser
                    break;

            }

            driver.Url = Collective.Url;
            driver.Manage().Timeouts().ImplicitWait = (TimeSpan.FromSeconds(0));
            driver.Manage().Timeouts().PageLoad = (TimeSpan.FromSeconds(Collective.PageLoadTime));
            driver.Manage().Cookies.DeleteAllCookies();

            return driver;
        }

    }
}
