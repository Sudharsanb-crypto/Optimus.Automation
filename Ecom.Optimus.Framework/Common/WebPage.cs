using Ecom.Optimus.Framework.Basic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ecom.Optimus.Framework.Common
{
    public class WebPage 
    {
        public WebPage()
        {
        }
        public IWebDriver Driver = Collective.driver;
        private int _pollingIntervalInMilliSeconds = 500;

        /// <summary>
        /// To Refresh the page
        /// </summary>
        public void Refresh()
        {
            Driver.Navigate().Refresh();
         
        }

        /// <summary>
        /// Finds an element on the page
        /// </summary>
        /// <param name="by"></param>
        /// <returns>IWebElement</returns>
        public IWebElement FindElement(By @by)
        {
            IWebElement webElement = null;
            var tick = 0;
            do
            {
                try
                {
                    webElement = Driver.FindElement(@by);
                }
                catch
                {
                    Thread.Sleep(_pollingIntervalInMilliSeconds);
                    tick += _pollingIntervalInMilliSeconds;
                }
            } while (webElement == null && tick < Collective.ImplicitWaitTimeOut);

            if (webElement == null)
            {
                throw new TimeoutException(
                    "\t\tElement: " + by + " was not found within " + Collective.ImplicitWaitTimeOut + " sec.");

            }
            return webElement;

        }

        /// <summary>
        /// Navigates to the previous page
        /// </summary>
        public void GoBack()
        {
            try
            {
                Driver.Navigate().Back();
            }
            catch (Exception e)
            {
                Console.WriteLine(@"\t\tCannot go back. \r\nError: " + e);
            }
        }

        /// <summary>
        /// Navigates to next page
        /// </summary>
        public void GoForward()
        {
            try
            {
                Driver.Navigate().Forward();
            }
            catch (Exception e)
            {
                Console.WriteLine(@"\t\tCannot go forward not enough navigation. \r\nError: " + e);
            }
        }
    }
}
