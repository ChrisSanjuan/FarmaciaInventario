using LiteDB;
using ProyectoFinal.COMMON.Entidades;
using ProyectoFinal.COMMON.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.DAL
{
    public class RepositorioArticulo : IRepositorio<Articulo>
    {
        private string DBName = "Inventario.db";
        private string TableName = "Articulos";
        public List<Articulo> Leer
        {
            get
            {
                List<Articulo> datos = new List<Articulo>();
                using (var db = new LiteDatabase(DBName))
                {
                    datos = db.GetCollection<Articulo>(TableName).FindAll().ToList();
                }
                return datos;
            }
        }

        public bool Crear(Articulo entidad)
        {
            entidad.Id = Guid.NewGuid().ToString();
            try
            {
                using (var db = new LiteDatabase(DBName))
                {
                    var coleccion = db.GetCollection<Articulo>(TableName);
                    coleccion.Insert(entidad);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Editar(Articulo entidadModificada)
        {
            try
            {
                using (var db = new LiteDatabase(DBName))
                {
                    var coleccion = db.GetCollection<Articulo>(TableName);
                    coleccion.Update(entidadModificada);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Eliminar(string id)
        {
            try
            {
                int r;
                using (var db = new LiteDatabase(DBName))
                {
                    var coleccion = db.GetCollection<Articulo>(TableName);
                    r = coleccion.Delete(e => e.Id == id);
                }
                return r > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
