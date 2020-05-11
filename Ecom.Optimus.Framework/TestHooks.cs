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
            Collective.configreader();
            // driver initialised
            Collective.driver = new SelDriverFactory().GetDriver();

        }

        public static void After_Scenario()
        {
            if(Collective.driver!=null)
            {
                Collective.driver.Dispose();
                KillScript();
            }


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
