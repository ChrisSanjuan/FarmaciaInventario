using ProyectoFinal.COMMON.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoFinal.COMMON.Entidades;

namespace ProyectoFinal.BIZ
{
    public class ManejadorArticulo : IManejadorArticulo
    {
        IRepositorio<Articulo> repositorio;
        public ManejadorArticulo(IRepositorio<Articulo> repo)
        {
            repositorio = repo;
        }
        public List<Articulo> Listar => repositorio.Leer;

        public bool Agregar(Articulo entidad)
        {
            return repositorio.Crear(entidad);
        }

        public Articulo BuscarId(string id)
        {
            return Listar.Where(e => e.Id == id).SingleOrDefault();
        }

        public bool Eliminar(string id)
        {
            return repositorio.Eliminar(id);
        }

        public bool Modificar(Articulo entidad)
        {
            return repositorio.Editar(entidad);
        }
    }
}
