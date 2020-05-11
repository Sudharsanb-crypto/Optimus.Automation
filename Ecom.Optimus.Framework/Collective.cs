using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Optimus.Framework.Config
{
    public class Collective
    {
        public static string Browser{ get; set; }

        public static string Url { get; set; }

        public static string Password { get; set; }


        public static void configreader()
        {
            Browser = Configuration.GetInfo().Browser;
            Url = Configuration.GetInfo().Url;
            Password = Configuration.GetInfo().Password;

            Console.WriteLine(Browser + Url + Password);
        }
    }
}
