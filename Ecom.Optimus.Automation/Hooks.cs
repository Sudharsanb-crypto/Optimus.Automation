using Ecom.Optimus.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;


namespace Ecom.Optimus.Automation
{
    [Binding]
    public class Hooks :TestHooks
    {
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            
        }

        [BeforeScenario]
        public static void BeforeSCenario()
        {
            Before_Scenario();
        }

        [AfterScenario]
        public static void AfterScenario()
        {
            After_Scenario();
            Pages.Page.Reset();
        }

        [BeforeStep]
        public static void BeforeStep()
        {

        }

        [AfterStep]
        public static void AfterStep()
        {

        }

        [AfterTestRun]
        public static void AfterTestRun()
        {

        }

    }
}
