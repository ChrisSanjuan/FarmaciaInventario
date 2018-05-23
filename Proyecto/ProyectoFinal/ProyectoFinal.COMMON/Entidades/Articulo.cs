using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.COMMON.Entidades
{
    public class Articulo : Base
    {
        public string NombreArticulo { get; set; }
        public string Categoria { get; set; }
        public string Descripcion { get; set; }
        public string PrecioArticulo { get; set; }
        public byte[] ImagenArticulo { get; set; }
        public override string ToString()
        {
            return string.Format("{0} {1}", NombreArticulo, Categoria);
        }
    }
}
