using App.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core
{
    public class UserProvider
    {
        public static User userLogged { get; set; }

        public static string token { get; set; }

    }
}
