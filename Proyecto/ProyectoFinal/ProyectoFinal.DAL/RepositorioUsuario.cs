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
    public class RepositorioUsuario : IRepositorio<Usuario>
    {
        private string DBName = "Inventario.db";
        private string TableName = "Usuarios";
        public List<Usuario> Leer
        {
            get
            {
                List<Usuario> datos = new List<Usuario>();
                using (var db = new LiteDatabase(DBName))
                {
                    datos = db.GetCollection<Usuario>(TableName).FindAll().ToList();
                }
                return datos;
            }
        }

        public bool Crear(Usuario entidad)
        {
            entidad.Id = Guid.NewGuid().ToString();
            try
            {
                using (var db = new LiteDatabase(DBName))
                {
                    var coleccion = db.GetCollection<Usuario>(TableName);
                    coleccion.Insert(entidad);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Editar(Usuario entidadModificada)
        {
            try
            {
                using (var db = new LiteDatabase(DBName))
                {
                    var coleccion = db.GetCollection<Usuario>(TableName);
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
                    var coleccion = db.GetCollection<Usuario>(TableName);
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
