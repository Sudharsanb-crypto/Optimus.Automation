using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Optimus.Framework.Extensions
{
    public static class IWebElementExtension
    {
        /// <summary>
        /// Extension method in instantating Select Element
        /// </summary>
        /// <param name="webElement"></param>
        /// <returns></returns>
        public static SelectElement ComboBox(this IWebElement webElement)
        {
            try
            {
                return new SelectElement(webElement);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Extension method to instantiate Actions to move element
        /// </summary>
        /// <param name="webElement"></param>
        /// <returns></returns>
        public static Actions Actions(this IWebElement webElement)
        {
            try
            {
                var driver = ((IWrapsDriver)webElement).WrappedDriver;
                var actions = new Actions(driver);
                actions.MoveToElement(webElement);
                return actions;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Extension method to instantiate Actions to right click on element
        /// </summary>
        /// <param name="webElement"></param>
        /// <returns></returns>
        public static Actions ContextClick(this IWebElement webElement)
        {
            try
            {
                var driver = ((IWrapsDriver)webElement).WrappedDriver;
                var actions = new Actions(driver);
                actions.MoveToElement(webElement).ContextClick().Perform();
                return actions;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Extension method to select options
        /// </summary>
        /// <param name="dropdown"></param>
        /// <param name="subText"></param>
        /// <returns></returns>
        public static string SelectByTextOrSubText(this SelectElement dropdown, string subText)
        {
            foreach (var items in dropdown.Options.Where(items => items.Text.Contains(subText)))
            {
                var optionText = items.Text;
                items.Click();
                return optionText;
            }
            dropdown.SelectByText(subText);
            return subText;
        }
    }
}
