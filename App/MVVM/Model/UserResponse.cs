using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.MVVM.Model
{
    internal class UserResponse
    {
        public string status  { get; set; }
        public List<User> data { get; set; }
    }
}
