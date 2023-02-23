using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.MVVM.Model
{
    public  class User
    {
        public string _id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public List<string> following { get; set; }
        public List<string> followers { get; set; }
        public string picture { get; set; }
        public string register { get; set; }
        public string web { get; set; }
        public Boolean admin { get; set; }

    }

}
