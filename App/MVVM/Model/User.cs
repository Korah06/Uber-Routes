using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.MVVM.Model
{
    public class User
    {
        public string _id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string surnames { get; set; }
        public int followers { get; set; }
    }
}
