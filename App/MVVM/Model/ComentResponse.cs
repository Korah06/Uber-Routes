using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.MVVM.Model
{
    internal class ComentResponse
    {
        public string status { get; set; }
        public List<Coment> data { get; set; }
    }
}
