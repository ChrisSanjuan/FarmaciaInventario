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
    public class RepositorioPaquete : IRepositorio<Paquete>
    {
        private string DBName = "Inventario.db";
        private string TableName = "Paquetes";
        public List<Paquete> Leer
        {
            get
            {
                List<Paquete> datos = new List<Paquete>();
                using (var db = new LiteDatabase(DBName))
                {
                    datos = db.GetCollection<Paquete>(TableName).FindAll().ToList();
                }
                return datos;
            }
        }

        public bool Crear(Paquete entidad)
        {
            entidad.Id = Guid.NewGuid().ToString();
            try
            {
                using (var db = new LiteDatabase(DBName))
                {
                    var coleccion = db.GetCollection<Paquete>(TableName);
                    coleccion.Insert(entidad);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Editar(Paquete entidadModificada)
        {
            try
            {
                using (var db = new LiteDatabase(DBName))
                {
                    var coleccion = db.GetCollection<Paquete>(TableName);
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
                    var coleccion = db.GetCollection<Paquete>(TableName);
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
