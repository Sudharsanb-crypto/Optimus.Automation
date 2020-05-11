﻿using Ecom.Optimus.Framework.Basic;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ecom.Optimus.Framework.Common
{
    public class WebElement
    {
        protected IWebDriver Driver = Collective.driver;
        protected By By;
        public WebElement(By element)
        {
            By = element;
        }


        /// <summary>
        /// Clears the content of this element.
        /// </summary>
        public void Clear()
        {
            FindElement(By).Clear();
        }

        /// <summary>
        /// Clicks this element.
        /// </summary>
        public void Click()
        {
            FindElement(By).Click();
        }

        /// <summary>
        /// Finds the first OpenQA.Selenium.IWebElement using the given method.
        /// </summary>
        /// <param name="by"></param>
        /// <param name="interval"></param>
        /// <returns>IWebElement</returns>
        private IWebElement FindElement(By by, int interval = 500)
        {
            IWebElement webElement = null;
            var tick = 0;
            Stopwatch stopWatch = Stopwatch.StartNew();
            try
            {
                do
                {
                    try
                    {
                        webElement = Driver.FindElement(by);
                        return webElement;
                    }
                    catch (Exception)
                    {
                        Thread.Sleep(interval);
                        tick += interval;
                    }
                } while (webElement == null && tick < (Collective.ImplicitWaitTimeOut * 1000));

                if (webElement == null)
                {
                    throw new TimeoutException(
                        "\t\tElement: " + by + " was not found within " + Collective.ImplicitWaitTimeOut + " sec.");
                }

                stopWatch.Stop();
                TimeSpan ts = stopWatch.Elapsed;
                // Format and display the TimeSpan value.
                var elapsedTime = $"{ts.Hours:00}:{ts.Minutes:00}:{ts.Seconds:00}.{ts.Milliseconds / 10:00}";
                Console.WriteLine("\t\tFindElement - Time spent: " + elapsedTime);
                return webElement;
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Simulates typing text into the element.
        /// </summary>
        /// <param name="text"></param>
        public void SendKeys(string text)
        {
            SendKeys(text, false);
        }
        /// <summary>
        /// Send key with option on clear the field first
        /// </summary>
        /// <param name="text"></param>
        /// <param name="clearText"></param>
        public void SendKeys(string text, bool clearText)
        {
            if (clearText)
            {
                FindElement(By).Clear();
            }
            FindElement(By).SendKeys(text);

        }
    }
}
