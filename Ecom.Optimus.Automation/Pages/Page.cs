using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Optimus.Automation.Pages
{
    public class Page : Ecom.Optimus.Framework.Basic.Page
    {
        public static LoginPage _loginpage;

        public static LoginPage loginpage => _loginpage ?? (_loginpage = new LoginPage());

        public  static void Reset()
        {
            _loginpage = null;

        }

    }
}
