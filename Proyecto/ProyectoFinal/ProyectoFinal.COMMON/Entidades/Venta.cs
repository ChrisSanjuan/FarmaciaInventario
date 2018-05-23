using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.COMMON.Entidades
{
    public class Venta
    {
        public string ProductoVenta { get; set; }
        public string CategoriaVenta { get; set; }
        public string DescripcionVenta { get; set; }
        public float PrecioVenta { get; set; }
        public float CantidadVenta { get; set; }
        public float TotalVenta { get; set; }
    }
}
