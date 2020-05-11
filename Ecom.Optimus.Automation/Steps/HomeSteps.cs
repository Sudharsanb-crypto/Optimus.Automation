using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Ecom.Optimus.Automation.Pages;
using Ecom.Optimus.Framework.Basic;

namespace Ecom.Optimus.Automation.Steps
{
    [Binding]
    public sealed class HomeSteps
    {
      
        private readonly ScenarioContext context;

        public HomeSteps(ScenarioContext injectedContext)
        {
            context = injectedContext;
        }


        [When(@"I search for item (.*)")]
        public void WhenISearchForItemRoundNeckShirts(string item)
        {
            Pages.Page.homepage.SearchItem(item);
        }

        [Given(@"I scroll down to collections")]
        public void GivenIScrollDownToCollections()
        {
            Pages.Page.homepage.ScrollSelectcollection();
        }

    }
}
