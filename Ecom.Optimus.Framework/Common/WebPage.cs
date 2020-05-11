using Ecom.Optimus.Framework.Basic;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Optimus.Framework.Common
{
    public class WebPage 
    {
        public WebPage()
        {
        }
        public IWebDriver Driver = Collective.driver;

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
    }
}
