using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.COMMON.Entidades
{
    public class Empleado : Base
    {
        public string NombreEmpleado { get; set; }
        public string ApellidosEmpleado { get; set; }
        public string Cargo { get; set; }
        public string DireccionEmpleado { get; set; }
        public string TelefonoEmpleado { get; set; }
        public string CorreoEmpleado { get; set; }
        public override string ToString()
        {
            return NombreEmpleado + " " + ApellidosEmpleado;
        }
    }
}
