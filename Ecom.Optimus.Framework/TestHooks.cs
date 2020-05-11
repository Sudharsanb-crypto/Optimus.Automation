using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecom.Optimus.Framework.Basic;
using Ecom.Optimus.Framework.Config;

namespace Ecom.Optimus.Framework
{
    public class TestHooks
    {
        public static void Before_Scenario()
        {

            TestHooks.TestInitializeSetup();

        }

        public static void After_Scenario()
        {
            if(Collective.driver!=null)
            {
                Collective.driver.Dispose();
                KillScript();
            }


        }


        /// <summary>
        /// To validate the configuration values before initiating the test
        /// </summary>
        public static void CheckconfigInputs()
        {
            if (Configuration.GetInfo().Browser != null)
            { }
            if (Configuration.GetInfo().Url != null)
            { }
            if (Configuration.GetInfo().Password != null)
            { }
            if (Configuration.GetInfo().PageLoadTime !=0)
            { }
            if (Configuration.GetInfo().ImpilicitWait != 0)
            { }
            if (Configuration.GetInfo().TestReportFilePath != null)
            { }
        }

        /// <summary>
        /// Inorder to initialize a test verifying basic info are provided
        /// </summary>
        public static void TestInitializeSetup()
        {
            Collective.configreader();
            Collective.driver = new SeleniumDriverFactory().GetDriver();
        }

        /// <summary>
        /// To kill the instance of the chrome driver post execution
        /// </summary>
        private static void KillScript()
        {
                Process KillScriptProcess = new Process();
                string location = Path.Combine(AppDomain.CurrentDomain.BaseDirectory) + @"\SessionKiller.bat";
                KillScriptProcess.StartInfo.FileName = location;
                KillScriptProcess.Start();
                KillScriptProcess.WaitForExit();
        }
    }
}
