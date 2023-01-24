using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.MVVM.Model
{
    internal class Coment
    {
        public int _id { get; set; }
        public string descripcion { get; set; }
        public string usuario { get; set; }
        public string publicacion { get; set; }
        public DateTime fecha { get; set; }
    }
}
