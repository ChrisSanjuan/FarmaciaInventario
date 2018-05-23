using ProyectoFinal.COMMON.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoFinal.COMMON.Entidades;

namespace ProyectoFinal.BIZ
{
    public class ManejadorPaquete : IManejadorPaquete
    {
        IRepositorio<Paquete> repositorio;
        public ManejadorPaquete(IRepositorio<Paquete> repo)
        {
            repositorio = repo;
        }
        public List<Paquete> Listar => repositorio.Leer;

        public bool Agregar(Paquete entidad)
        {
            return repositorio.Crear(entidad);
        }

        public Paquete BuscarId(string id)
        {
            return Listar.Where(e => e.Id == id).SingleOrDefault();
        }

        public bool Eliminar(string id)
        {
            return repositorio.Eliminar(id);
        }

        public bool Modificar(Paquete entidad)
        {
            return repositorio.Editar(entidad);
        }
    }
}
