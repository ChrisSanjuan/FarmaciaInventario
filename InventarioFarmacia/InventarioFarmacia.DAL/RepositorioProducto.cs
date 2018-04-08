using InventarioFarmacia.COMMON.Entidades;
using InventarioFarmacia.COMMON.Interfaces;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioFarmacia.DAL
{
    public class RepositorioProducto : IRepositorio<Producto>
    {
        private string DBName = "Inventario.db";
        private string TableName = "Productos";
        public List<Producto> Leer
        {
            get
            {
                List<Producto> datos = new List<Producto>();
                using (var db = new LiteDatabase(DBName))
                {
                    datos = db.GetCollection<Producto>(TableName).FindAll().ToList();
                }
                return datos;
            }
        }

        public bool Crear(Producto entidad)
        {
            entidad.Id = Guid.NewGuid().ToString();
            try
            {
                using (var db = new LiteDatabase(DBName))
                {
                    var coleccion = db.GetCollection<Producto>(TableName);
                    coleccion.Insert(entidad);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Editar(Producto entidadModificada)
        {
            try
            {
                using (var db = new LiteDatabase(DBName))
                {
                    var coleccion = db.GetCollection<Producto>(TableName);
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
                    var coleccion = db.GetCollection<Producto>(TableName);
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
