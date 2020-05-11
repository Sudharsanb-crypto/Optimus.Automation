using BoDi;
using Ecom.Optimus.Framework.Config;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Optimus.Framework.Basic
{
    public class SeleniumDriverFactory
    {
       
        public IWebDriver driver;
        public IObjectContainer _objectcontainer;

        public void SetWindowSize(Boolean? isMobile = null, Boolean? isipad = null)
        {
            if (isMobile == true)
                driver.Manage().Window.Size = new Size(400, 1200);
            else if (isipad == true)
                driver.Manage().Window.Size = new Size(768, 1024);
            else
            {
                driver.Manage().Window.Size = new Size(600, 1024);
            }
        }

        public IWebDriver GetDriver()
        {
          
            var browser = Collective.Browser;

            switch(browser.ToLower())
            {
                case "chrome":
                    var options = new ChromeOptions();
                    options.AddArgument("--disable-web-security");
                    options.AddArgument("--allow-running-insecure-content");
                    options.AddArgument("--ignore-ssl-errors");
                    options.AddArgument("disable-extensions");
                    driver = new ChromeDriver(options);
                    break;

                case "firefox":
                    driver = new FirefoxDriver();
                    break;

                case "headless":
                    var chromeOptions = new ChromeOptions();
                    chromeOptions.AddArguments("headless");
                    driver = new ChromeDriver(chromeOptions);
                    break;

                default:
                    throw new IncorrectBrowserException();
                   
            }

            SetWindowSize(); // setting window size for mobile ipad
            driver.Manage().Timeouts().ImplicitWait = (TimeSpan.FromSeconds(0));
            driver.Manage().Timeouts().PageLoad = (TimeSpan.FromSeconds(Collective.PageLoadTime));
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Manage().Window.Maximize();
            driver.Url = Collective.Url;

            return driver;
        }

        public void GoToUrl(string url)
        {
           driver.Url = url;
        }


    }
}
