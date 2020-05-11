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

namespace Ecom.Optimus.Automation.Pages
{
    public class ItemPage : WebPage
    {
        public WebElement Item = new WebElement(By.XPath("//*[@id='MainContent']/ul[1]/li[1]/div/a"));
        public WebElement Addtocartbtn = new WebElement(By.Name("add"));
        public WebElement Viewcart = new WebElement(By.CssSelector("body > div.cart-popup-wrapper > div > a"));
       
        public WebElement Cartclose = new WebElement(By.CssSelector("body > div.cart-popup-wrapper > div > div.cart-popup__dismiss"));
        
        public void Selectitem()
        {
            
            Item.Click();
        }

        /// <summary>
        /// Adding items to cart
        /// </summary>
        public void Addtocart()
        {
            Addtocartbtn.Click();
            
        }

        public void ViewCart()
        {
            Viewcart.JavaScriptClick();
        }

        public IWebElement Size; 

        public void Additemstocart(int countno)
        {
            Size = Collective.driver.FindElement(By.Id("SingleOptionSelector-1"));
             Random rnd = new Random();

            string[] sizes = { "XS", "S", "M", "L", "XL", "2XL", "3XL", "4XL" };
            int i = 1;

            do
            {
                SelectElement ss = new SelectElement(Size);
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
