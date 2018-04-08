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
    public class RepositorioCliente : IRepositorio<Cliente>
    {
        private string DBName = "Inventario.db";
        private string TableName = "Clientes";
        public List<Cliente> Leer
        {
            get
            {
                List<Cliente> datos = new List<Cliente>();
                using (var db = new LiteDatabase(DBName))
                {
                    datos = db.GetCollection<Cliente>(TableName).FindAll().ToList();
                }
                return datos;
            }
        }

        public bool Crear(Cliente entidad)
        {
            entidad.Id = Guid.NewGuid().ToString();
            try
            {
                using (var db = new LiteDatabase(DBName))
                {
                    var coleccion = db.GetCollection<Cliente>(TableName);
                    coleccion.Insert(entidad);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Editar(Cliente entidadModificada)
        {
            try
            {
                using (var db = new LiteDatabase(DBName))
                {
                    var coleccion = db.GetCollection<Cliente>(TableName);
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
                    var coleccion = db.GetCollection<Cliente>(TableName);
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
