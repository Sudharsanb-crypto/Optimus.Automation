using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace Ecom.Optimus.Automation.Steps
{
    [Binding]
    public sealed class ItemSteps
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext context;

        public ItemSteps(ScenarioContext injectedContext)
        {
            context = injectedContext;
        }

        [When(@"I select an item from results")]
        public void WhenISelectAnItemFromResults()
        {
            Pages.Page.itempage.WaitForElementPresent(By.XPath("//*[@id='MainContent']/ul[1]/li[1]/div/a"),60);
            Pages.Page.itempage.Selectitem();
           
        }

        [When(@"I click Add to cart button")]
        public void WhenIClickAddToCartButton()
        {
            Pages.Page.itempage.Addtocart();
            Pages.Page.itempage.WaitForElementPresent(By.CssSelector("body > div.cart-popup-wrapper > div"),500);
        }


        [Then(@"I click on view cart button")]
        public void ThenIClickOnViewCartButton()
        {
            Pages.Page.itempage.ViewCart();
        }

        [When(@"I select pick random (.*) sizes of item")]
        public void WhenISelectPickRandomSizesOfItem(int countno)
        {
            Pages.Page.itempage.Additemstocart(countno);
        }





    }
}
