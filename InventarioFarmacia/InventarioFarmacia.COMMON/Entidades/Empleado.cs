using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioFarmacia.COMMON.Entidades
{
    public class Empleado : Base
    {
        public string NombreEmpleado { get; set; }
        public string ApellidosEmpleado { get; set; }
        public override string ToString()
        {
            return NombreEmpleado+ " "+ ApellidosEmpleado;
        }
    }
}
