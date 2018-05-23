using ProyectoFinal.COMMON.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoFinal.COMMON.Entidades;

namespace ProyectoFinal.BIZ
{
    public class ManejadorCliente : IManejadorCliente
    {
        IRepositorio<Cliente> repositorio;
        public ManejadorCliente(IRepositorio<Cliente> repo)
        {
            repositorio = repo;
        }
        public List<Cliente> Listar => repositorio.Leer;

        public bool Agregar(Cliente entidad)
        {
            return repositorio.Crear(entidad);
        }

        public Cliente BuscarId(string id)
        {
            return Listar.Where(e => e.Id == id).SingleOrDefault();
        }

        public bool Eliminar(string id)
        {
            return repositorio.Eliminar(id);
        }

        public bool Modificar(Cliente entidad)
        {
            return repositorio.Editar(entidad);
        }
    }
}
