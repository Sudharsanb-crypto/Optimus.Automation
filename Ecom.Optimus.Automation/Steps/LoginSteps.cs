using Ecom.Optimus.Automation.Pages;
using Ecom.Optimus.Framework.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace Ecom.Optimus.Automation
{
    [Binding]
    public sealed class LoginSteps
    {
        private readonly ScenarioContext context;

        public LoginSteps(ScenarioContext injectedContext)
        {
            context = injectedContext;
        }

        [Given(@"I login to application")]
        public void GivenILoginToApplication()
        {
            Pages.Page.loginpage.Login();
        }
    }
}
