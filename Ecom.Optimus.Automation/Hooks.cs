﻿using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
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
        private readonly FeatureContext _featureContext;
        private readonly ScenarioContext _scenarioContext;
        private ExtentTest _currentScenarioName;


        public Hooks(FeatureContext featureContext, ScenarioContext scenarioContext)
        {
            _featureContext = featureContext;
            _scenarioContext = scenarioContext;
        }

        private static ExtentTest featureName;
        private static ExtentReports extent;
        private static ExtentKlovReporter klov;


        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            //Initialize Extent report before test starts
            var htmlReporter = new ExtentHtmlReporter(@"E:\Reports\ExtentReport.html");
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            //Attach report to reporter
            extent = new ExtentReports();
            klov = new ExtentKlovReporter();
            extent.AttachReporter(htmlReporter);
        }

        [BeforeScenario]
        public  void BeforeSCenario()
        {
            //Get feature Name
            featureName = extent.CreateTest<Feature>(_featureContext.FeatureInfo.Title);

            //Create dynamic scenario name
            _currentScenarioName = featureName.CreateNode<Scenario>(_scenarioContext.ScenarioInfo.Title);

           
            Before_Scenario();

        }

        [AfterScenario]
        public static void AfterScenario()
        {
            After_Scenario();
            Pages.Page.Reset();
        }

 

        [AfterStep]
        public  void AfterEachStep()
        {
            var stepType = _scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();

            if (_scenarioContext.TestError == null)
            {
                if (stepType == "Given")
                    _currentScenarioName.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text);
                else if (stepType == "When")
                    _currentScenarioName.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text);
                else if (stepType == "Then")
                    _currentScenarioName.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text);
                else if (stepType == "And")
                    _currentScenarioName.CreateNode<And>(_scenarioContext.StepContext.StepInfo.Text);
            }
            else if (_scenarioContext.TestError != null)
            {
                if (stepType == "Given")
                    _currentScenarioName.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message);
                else if (stepType == "When")
                    _currentScenarioName.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message);
                else if (stepType == "Then")
                    _currentScenarioName.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message);
                else if (stepType == "And")
                    _currentScenarioName.CreateNode<And>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message);

            }
            else if (_scenarioContext.ScenarioExecutionStatus.ToString() == "StepDefinitionPending")
            {
                if (stepType == "Given")
                    _currentScenarioName.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                else if (stepType == "When")
                    _currentScenarioName.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                else if (stepType == "Then")
                    _currentScenarioName.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                else if (stepType == "And")
                    _currentScenarioName.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");

            }

        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            extent.Flush();
        }

    }
}
