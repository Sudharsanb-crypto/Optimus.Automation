using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace Ecom.Optimus.Automation.Steps
{
    [Binding]
    public sealed class CartSteps
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

       
        private readonly ScenarioContext context;

        public CartSteps(ScenarioContext injectedContext)
        {
            context = injectedContext;
        }

        [Then(@"I return to home page")]
        public void ThenIReturnToHomePage()
        {
            Pages.Page.cartpage.ReturntoHome();
        }

        [Then(@"I validate correct item is added")]
        public void ThenIValidateCorrectItemIsAdded()
        {
            Pages.Page.cartpage.PageNavigation();
            Pages.Page.cartpage.ValidateItem();

        }


    }
}
