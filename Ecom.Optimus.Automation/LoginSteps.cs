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
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef


        [Given("I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredSomethingIntoTheCalculator(int number)
        {
            //TODO: implement arrange (precondition) logic
            // For storing and retrieving scenario-specific data see https://go.specflow.org/doc-sharingdata 
            // To use the multiline text or the table argument of the scenario,
            // additional string/Table parameters can be defined on the step definition
            // method. 

           
        }

        [Given(@"I login to application")]
        public void GivenILoginToApplication()
        {
            Pages.Page.loginpage.Enterusingpwdbtn.Click();
            Pages.Page.loginpage.Passwordedtbox.Click();
            Pages.Page.loginpage.Passwordedtbox.SendKeys(Collective.Password);
            Pages.Page.loginpage.Enterbtn.Click();

        }


        [When("I press add")]
        public void WhenIPressAdd()
        {
            //TODO: implement act (action) logic

           
        }

        [Then("the result should be (.*) on the screen")]
        public void ThenTheResultShouldBe(int result)
        {
            //TODO: implement assert (verification) logic

           
        }
    }
}
