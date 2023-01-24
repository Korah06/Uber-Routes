using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.MVVM.Model
{
    public class Route
    {
        public string _id { get; set; }
        public DateTime fecha { get; set; }
        public string nombre { get; set; }
        public string categoria { get; set; }
        public float distancia { get; set; }
        public string dificultad { get; set; }
        public int duracion { get; set; }
        public string descripcion { get; set; }
        public string empresa { get; set; }
        public string usuario { get; set; }
        public string url { get; set; }
    }
}
