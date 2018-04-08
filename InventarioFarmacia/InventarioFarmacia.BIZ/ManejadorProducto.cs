using InventarioFarmacia.COMMON.Entidades;
using InventarioFarmacia.COMMON.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioFarmacia.BIZ
{
    public class ManejadorProducto : IManejadorProducto
    {
        IRepositorio<Producto> repositorio;
        public ManejadorProducto(IRepositorio<Producto> repo)
        {
            repositorio = repo;
        }

        public List<Producto> Listar => repositorio.Leer;

        public bool Agregar(Producto entidad)
        {
            return repositorio.Crear(entidad);
        }

        public Producto BuscarId(string id)
        {
            return Listar.Where(e => e.Id == id).SingleOrDefault();
        }

        public bool Eliminar(string id)
        {
            return repositorio.Eliminar(id);
        }

        public bool Modificar(Producto entidad)
        {
            return repositorio.Editar(entidad);
        }
    }
}
