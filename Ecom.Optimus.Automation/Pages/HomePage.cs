using Ecom.Optimus.Framework.Basic;
using Ecom.Optimus.Framework.Common;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Optimus.Automation.Pages
{
    public class HomePage : WebPage
    {

        public WebElement Searchicon = new WebElement(By.CssSelector("#shopify-section-header > div:nth-child(2) > header > div > div.grid__item.medium-up--one-quarter.text-right.site-header__icons > div > button.btn--link.site-header__icon.site-header__search-toggle.js-drawer-open-top > svg"));
        public WebElement Searchedit = new WebElement(By.Name("q"));
        public WebElement Enterbtn = new WebElement(By.CssSelector("#login_form > div > span > button"));

        public WebElement Srch = new WebElement(By.CssSelector("#SearchDrawer > div > div > form > button > svg"));

        public WebElement Hometab = new WebElement(By.CssSelector("#SiteNav > li:nth-child(1) > a > span"));

        public WebElement Carticon = new WebElement(By.CssSelector("#shopify-section-header > div:nth-child(2) > header > div > div.grid__item.medium-up--one-quarter.text-right.site-header__icons > div > a > svg"));


        public void SearchItem(string itemname)
        {
            Searchicon.Click();
            Searchedit.Click();
            Searchedit.SendKeys(itemname);
            Srch.Click();
        }





    }
}
