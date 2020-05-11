using Ecom.Optimus.Framework.Basic;
using Ecom.Optimus.Framework.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Ecom.Optimus.Framework.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ecom.Optimus.Automation.Pages
{
    public class ItemPage : WebPage
    {
        public WebElement Item = new WebElement(By.XPath("//*[@id='MainContent']/ul[1]/li[1]/div/a"));
        public WebElement Addtocartbtn = new WebElement(By.Name("add"));
        public WebElement Viewcart = new WebElement(By.CssSelector("body > div.cart-popup-wrapper > div > a"));
        public WebElement Cartclose = new WebElement(By.CssSelector("body > div.cart-popup-wrapper > div > div.cart-popup__dismiss"));
        public static WebElement ItemTitle = new WebElement(By.CssSelector("#ProductSection-product-template > div > div:nth-child(2) > div.product-single__meta > h1"));

        #region IWebElements
        private string SizeIdvalue = "SingleOptionSelector-1";
        #endregion

        public static string itemtitle ;

        public void Selectitem()
        {
            itemtitle = Item.Text;
            Item.Click();
        }

        /// <summary>
        /// Adding items to cart
        /// </summary>
        public void Addtocart()
        {
            Addtocartbtn.Click();
            
        }

      

        public static string itemtext()
        {
            
            return itemtitle;
        }

        public void ViewCart()
        {
            Viewcart.JavaScriptClick();

        }

        public IWebElement Size; 

        public void Additemstocart(int countno)
        {
           

            Size = Collective.driver.FindElement(By.Id(SizeIdvalue));
             Random rnd = new Random();

            string[] sizes = { "XS", "S", "M", "L", "XL", "2XL", "3XL", "4XL" };
            int i = 1;

            do
            {
                SelectElement ss = Size.ComboBox();
                var size = rnd.Next(0, sizes.Length);
                Console.WriteLine("selected size is " + sizes[size]);
                ss.SelectByValue(sizes[size]);

                Addtocartbtn.Waitforsec();

                Addtocartbtn.Click();

                Cartclose.Waitforsec();

                Cartclose.JavaScriptClick();

               i++;

            } while (i <= countno);
        }

    }
}
