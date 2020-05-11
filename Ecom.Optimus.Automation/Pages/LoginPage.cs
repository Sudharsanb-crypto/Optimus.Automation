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
    public class LoginPage : WebPage
    {

        public WebElement Enterusingpwdbtn = new WebElement(By.CssSelector("body > div.password-page > header > div > div > a"));
        public WebElement Passwordedtbox = new WebElement(By.Id("Password"));
        public WebElement Enterbtn = new WebElement(By.CssSelector("#login_form > div > span > button"));
        public By logotxt = By.CssSelector("#shopify-section-password-header > div > h1 > span");
        public By passwordtxt = By.CssSelector("#password-modal-heading");

        public void Login()
        {
            Enterusingpwdbtn.WaitForElementPresent(logotxt);
            Enterusingpwdbtn.Click();
            Passwordedtbox.WaitForElementPresent(passwordtxt);
            Passwordedtbox.Click();
            Passwordedtbox.SendKeys(Collective.Password);
            Enterbtn.Click();

        }



    }
}
