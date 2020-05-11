using Ecom.Optimus.Framework.Basic;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
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
        /// To avoid coding thread sleep with different timings 
        /// For the sake of user to understand the flow of automation script 
        /// </summary>
        public void Waitforsec()
        {
            Thread.Sleep(3000);
        }


        /// <summary>
        /// Gets the innerText of this element, without any leading or trailing whitespace, and with other whitespace collapsed.
        /// </summary>
        public string Text => FindElement(By).Text;

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
                Printer.ConsoleWriter("\t\tFindElement - Time spent: " + elapsedTime);
                return webElement;
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        
        /// <summary>
        /// Wait for Element present
        /// </summary>
        /// <param name="by"></param>
        /// <param name="timeout"></param>
        public void WaitForElementPresent( By by,int timeout=0)
        {
            var wait = (timeout == 0) ? new WebDriverWait(Driver, Collective.DefaultTimeSpan) : new WebDriverWait(Driver, new TimeSpan(0, 0, timeout));
            try
            {
                wait.Until(d =>
                {
                    var e = FindElement(by);
                    return e.Displayed;
                }
              );
            }
            catch (Exception)
            {
                Printer.ConsoleWriter("\t\telement is not present.");
                throw new Exception("Timeout exception unable to identify element");
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

        /// <summary>
        /// Click on element using java script
        /// </summary>
        public void JavaScriptClick()
        {
            var element = FindElement(By);
            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].click();", element);
        }
        /// <summary>
        /// Java click on IWebElement
        /// </summary>
        /// <param name="element"></param>
        public void JavaScriptClick(IWebElement element)
        {
            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].click();", element);
        }

        /// <summary>
        /// get the locationOnScreenOnceScrolledIntoView
        /// </summary>
        public System.Drawing.Point LocationOnScreenOnceScrolledIntoView => ((ILocatable)FindElement(By)).LocationOnScreenOnceScrolledIntoView;


        /// <summary>
        /// Returns the css selector
        /// </summary>
        public By ElementCssBy => By;

        /// <summary>
        /// Perform scroll to up operation
        /// </summary>
        public void ScrollUp()
        {
            Actions builder = new Actions(Driver);
            IWebElement scroll = FindElement(By);

            int pixels = -20;
            for (int i = 200; i > 20; i = i + pixels)
            {
                builder.MoveToElement(scroll).ClickAndHold().MoveByOffset(0, pixels).Release().Perform();
                Thread.Sleep(100);
            }
        }

        /// <summary>
        /// Move a scroll to the bottom
        /// </summary>
        public void ScrollToTheBottom()
        {
            var element = FindElement(By);
            var executor = Driver as IJavaScriptExecutor;
            executor.ExecuteScript("$(arguments[0]).scrollTop($(arguments[0]).prop('scrollHeight'))", element);
        }

        /// <summary>
        /// Move a scroll until finds the element
        /// </summary>
        public void ScrollUntil()
        {
            var element = FindElement(By);
            var executor = Driver as IJavaScriptExecutor;
            executor.ExecuteScript("arguments[0].scrollIntoView(false);", element);
        }

        /// <summary>
        /// Move a scroll to the top
        /// </summary>
        public void ScrollToTheTop()
        {
            var element = FindElement(By);
            var executor = Driver as IJavaScriptExecutor;
            executor.ExecuteScript("$(arguments[0]).scrollTop(0)", element);
        }

        /// <summary>
        /// Wait for the element is not be present
        /// </summary>
        /// <param name="by"></param>
        /// <param name="timeout"></param>
        public void WaitForElementNotPresent(By by, int timeout = 0)
        {
            var wait = (timeout == 0) ? new WebDriverWait(Driver, Collective.DefaultTimeSpan) : new WebDriverWait(Driver, new TimeSpan(0, 0, timeout));
            Thread.Sleep(1000);
            try
            {
                wait.Until(d =>
                {
                    var e = FindElement(by);
                    return (e == null || !e.Displayed);
                }
                    );
            }
            catch (NoSuchElementException)
            {
                Printer.ConsoleWriter("\t\telement is not present.");
            }
            catch (ElementNotVisibleException)
            {
                Printer.ConsoleWriter("\t\telement is not present.");
            }
            catch (TimeoutException)
            {
                Printer.ConsoleWriter("\t\telement is not present.");
            }
        }
    }
}
