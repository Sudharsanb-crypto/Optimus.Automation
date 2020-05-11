using Ecom.Optimus.Framework.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        public WebElement cartitem = new WebElement(By.CssSelector("#shopify-section-cart-template > div > div:nth-child(1) > form > table > tbody > tr > td.cart__meta.small--text-left > div > div:nth-child(2) > div > a"));

        public void ReturntoHome()
        {
            Hometab.Click();
        }

       public string itemtext()
        {
            return cartitem.Text;
        }

        public void ValidateItem()
        {
            Assert.AreEqual(ItemPage.itemtext(),itemtext(),"Item selected and added to cart mismatches");
        }
    }
}
