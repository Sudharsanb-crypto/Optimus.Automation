using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecom.Optimus.Framework.Config;

namespace Ecom.Optimus.Framework
{
    public class TestHooks
    {
        public static void Before_Scenario()
        {
            // read the config files 
            Collective.configreader();
        }

        public static void After_Scenario()
        {

        }
    }
}
