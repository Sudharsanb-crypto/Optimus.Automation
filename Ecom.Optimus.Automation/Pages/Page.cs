using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Optimus.Automation.Pages
{
    public class Page : Ecom.Optimus.Framework.Basic.Page
    {
        private static LoginPage _loginpage;
        private static HomePage _homepage;
        private static ItemPage _itempage;
        private static CartPage _cartpage;

        public static LoginPage loginpage => _loginpage ?? (_loginpage = new LoginPage());

        public static HomePage homepage => _homepage ?? (_homepage = new HomePage());

        public static ItemPage itempage => _itempage ?? (_itempage = new ItemPage());

        public static CartPage cartpage => _cartpage ?? (_cartpage = new CartPage());


        public  static void Reset()
        {
            _loginpage = null;
            _homepage = null;
        }

    }
}
