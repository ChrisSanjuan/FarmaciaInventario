using ProyectoFinal.COMMON.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoFinal.COMMON.Entidades;

namespace ProyectoFinal.BIZ
{
    public class ManejadorTicket : IManejadorTicket
    {
        IRepositorio<InventarioVenta> repositorio;
        public ManejadorTicket(IRepositorio<InventarioVenta> repo)
        {
            repositorio = repo;
        }
        public List<InventarioVenta> Listar => repositorio.Leer;

        public bool Agregar(InventarioVenta entidad)
        {
            return repositorio.Crear(entidad);
        }

        public InventarioVenta BuscarId(string id)
        {
            return Listar.Where(e => e.Id == id).SingleOrDefault();
        }

        public bool Eliminar(string id)
        {
            return repositorio.Eliminar(id);
        }

        public bool Modificar(InventarioVenta entidad)
        {
            return repositorio.Editar(entidad);
        }
    }
}
