using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecom.Optimus.Framework.Basic;

namespace Ecom.Optimus.Framework
{
    public class TestHooks
    {
        public static void Before_Scenario()
        {
            // read the config files 
          
            // driver initialised
            

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
        /// Inorder to initialize a test verifying basic info are provided
        /// </summary>
        public static void TestInitializeSetup()
        {
            Collective.configreader();
            Collective.driver = new SeleniumDriverFactory().GetDriver();
        }

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
