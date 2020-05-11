using AventStack.ExtentReports;
using Ecom.Optimus.Framework.Basic;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Ecom.Optimus.Framework.Common
{
    public class Screenshot
    {
        private readonly ScenarioInfo _scenarioinfo;
        public Screenshot(ScenarioInfo ScenarioInfo)
        {
            _scenarioinfo = ScenarioInfo;
        }


        public  MediaEntityModelProvider TakeScreenshot(string title)
        {
            var screenshot = ((ITakesScreenshot)Collective.driver).GetScreenshot().AsBase64EncodedString;
            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot,title).Build();
        }
    }
}
