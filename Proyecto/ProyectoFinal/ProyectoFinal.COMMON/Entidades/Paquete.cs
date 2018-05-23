using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.COMMON.Entidades
{
    public class Paquete : Base
    {
        public string EmpleadoSolicitante { get; set; }
        public string ProductoSolicitado { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public DateTime FechaEntrega { get; set; }
        public string CantidadSolicitado { get; set; }
        public string FirmaSolicitante { get; set; }
        public string FirmaEncargado { get; set; }
    }
}
