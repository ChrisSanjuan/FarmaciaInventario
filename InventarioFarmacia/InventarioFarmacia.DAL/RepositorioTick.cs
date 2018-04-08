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
    public class RepositorioTick : IRepositorio<InventarioVentas>
    {

        private string DBName = "Inventario.db";
        private string TableName = "InventarioAlmacen";
        public List<InventarioVentas> Leer
        {
            get
            {
                List<InventarioVentas> datos = new List<InventarioVentas>();
                using (var db = new LiteDatabase(DBName))
                {
                    datos = db.GetCollection<InventarioVentas>(TableName).FindAll().ToList();
                }
                return datos;
            }
        }

        public bool Crear(InventarioVentas entidad)
        {
            entidad.Id = Guid.NewGuid().ToString();
            try
            {
                using (var db = new LiteDatabase(DBName))
                {
                    var coleccion = db.GetCollection<InventarioVentas>(TableName);
                    coleccion.Insert(entidad);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Editar(InventarioVentas entidadModificada)
        {
            try
            {
                using (var db = new LiteDatabase(DBName))
                {
                    var coleccion = db.GetCollection<InventarioVentas>(TableName);
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
                    var coleccion = db.GetCollection<InventarioVentas>(TableName);
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
