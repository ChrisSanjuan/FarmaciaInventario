using ProyectoFinal.COMMON.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoFinal.COMMON.Entidades;

namespace ProyectoFinal.BIZ
{
    public class ManejadorEmpleado : IManejadorEmpleado
    {
        IRepositorio<Empleado> repositorio;
        public ManejadorEmpleado(IRepositorio<Empleado> repo)
        {
            repositorio = repo;
        }
        public List<Empleado> Listar => repositorio.Leer;

        public bool Agregar(Empleado entidad)
        {
            return repositorio.Crear(entidad);
        }

        public Empleado BuscarId(string id)
        {
            return Listar.Where(e => e.Id == id).SingleOrDefault();
        }

        public bool Eliminar(string id)
        {
            return repositorio.Eliminar(id);
        }

        public bool Modificar(Empleado entidad)
        {
            return repositorio.Editar(entidad);
        }
    }
}
