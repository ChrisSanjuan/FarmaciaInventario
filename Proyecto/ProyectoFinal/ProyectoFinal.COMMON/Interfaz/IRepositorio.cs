using ProyectoFinal.COMMON.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.COMMON.Interfaz
{
    public interface IRepositorio<T> where T : Base
    {
        bool Crear(T entidad);
        List<T> Leer { get; }
        bool Editar(T entidadModificada);
        bool Eliminar(string id);
    }
}
