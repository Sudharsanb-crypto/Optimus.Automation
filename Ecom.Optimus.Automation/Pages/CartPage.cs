using Ecom.Optimus.Framework.Common;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Optimus.Automation.Pages
{
    public class CartPage : WebPage
    {
        public WebElement Hometab = new WebElement(By.CssSelector("#SiteNav > li:nth-child(1) > a > span"));

        public void ReturntoHome()
        {
            Hometab.Click();
        }
    }
}
