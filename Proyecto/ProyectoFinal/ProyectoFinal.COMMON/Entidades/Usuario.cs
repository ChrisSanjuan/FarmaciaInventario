using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.COMMON.Entidades
{
    public class Usuario : Base
    {
        public string NombreUsuario { get; set; }
        public string UsuarioTipo { get; set; }
        public string Contrasenia { get; set; }
        public override string ToString()
        {
            return NombreUsuario;
        }
    }
}
