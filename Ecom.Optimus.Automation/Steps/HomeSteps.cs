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
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext context;

        public HomeSteps(ScenarioContext injectedContext)
        {
            context = injectedContext;
        }

        [When(@"I search for round neck shirt item")]
        public void WhenISearchForRoundNeckShirtItem()
        {
            Pages.Page.homepage.SearchItem("round neck shirts");
            
        }


    }
}
