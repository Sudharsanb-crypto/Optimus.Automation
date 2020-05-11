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
       
        private readonly ScenarioContext context;

        public ItemSteps(ScenarioContext injectedContext)
        {
            context = injectedContext;
        }

        [When(@"I select an item from results")]
        public void WhenISelectAnItemFromResults()
        {
            Pages.Page.itempage.Waitforitem();
            Pages.Page.itempage.Selectitem();
           
        }

        [When(@"I click Add to cart button")]
        public void WhenIClickAddToCartButton()
        {
            Pages.Page.itempage.Addtocart();
            Pages.Page.itempage.WaitforItempopup();
        }


        [Then(@"I click on view cart button")]
        public void ThenIClickOnViewCartButton()
        {
            Pages.Page.itempage.ViewCart();
            Pages.Page.cartpage.PageNavigation();
        }

        [When(@"I select pick random (.*) sizes of item")]
        public void WhenISelectPickRandomSizesOfItem(int countno)
        {
            Pages.Page.itempage.Additemstocart(countno);
        }
    }
}
