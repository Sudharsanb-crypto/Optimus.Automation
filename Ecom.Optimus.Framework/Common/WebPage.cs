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

        /// </summary>
        public void Refresh()
        {
            Driver.Navigate().Refresh();
            //WaitForAjax();
        }

        public void Click(IWebElement element)
        {
            element.Click();
        }

        public void SendKeys(IWebElement element, string text)
        {
            SendKeys(element, text, false);
        }

        public void SendKeys(IWebElement element, string text, bool clearText)
        {
            if (clearText)
            {
                element.Clear();
            }

            element.SendKeys(text);
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
    }
}
