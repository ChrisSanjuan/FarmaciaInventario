using InventarioFarmacia.COMMON.Entidades;
using InventarioFarmacia.COMMON.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioFarmacia.BIZ
{
    public class ManejadorTicket: IManejadorTick
    {
        IRepositorio<InventarioVentas> repositorio;
        public ManejadorTicket(IRepositorio<InventarioVentas> repo)
        {
            repositorio = repo;
        }

        public List<InventarioVentas> Listar => repositorio.Leer;

        public bool Agregar(InventarioVentas entidad)
        {
            return repositorio.Crear(entidad);
        }

        public InventarioVentas BuscarId(string id)
        {
            return Listar.Where(e => e.Id== id).SingleOrDefault();
        }

        public bool Eliminar(string id)
        {
            return repositorio.Eliminar(id);
        }

        public bool Modificar(InventarioVentas entidad)
        {
            return repositorio.Editar(entidad);
        }
    }
}
