using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class Productos
    {
        public int id { get; set; }
        public string Nombre { get; set; }
        public int Stock { get; set; }
        public double Precio { get; set; }
        public string Descripcion { get; set; }
    }
}