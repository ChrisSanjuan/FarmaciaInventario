using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioFarmacia.COMMON.Entidades
{
    public class InventarioVentas:Base
    {
        public string Fecha { get; set; }
        public string Folio { get; set; }
        public string Nombre_Empleado { get; set; }
        public string Nombre_Cliente { get; set; }
        public List<Venta> Producto_Venta { get; set; }
        public float Subtotal_Pago { get; set; }
        public float Iva_Pago { get; set; }
        public float Total_Pago { get; set; }
    }
}
