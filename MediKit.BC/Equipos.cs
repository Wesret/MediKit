using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediKit.BC
{
    public class Equipos
    {
        public int Id { get; set; }
        public string Producto { get; set; }
        public int Precio { get; set; }
        public int Cantidad { get; set; }
        public int Lote { get; set; }
        public int MarcaID { get; set; }

        public Equipos()
        {
            this.init();
        }

        private void init()
        {
            Id = 0;
            Producto = string.Empty;
            Precio = 0;
            Cantidad = 0;
            Lote = 0;
            MarcaID = 0;

        }

        /// <summary>
        /// Método para ingresar equipos a la BD
        /// </summary>
        /// <returns></returns>
        public bool Create()
        {
            BD.MEDIKITDBEntities bbdd = new BD.MEDIKITDBEntities();
            BD.Equipos equipo = new BD.Equipos();
            try
            {
                CommonBC.Syncronize(this, equipo);
                bbdd.Equipos.Add(equipo);
                bbdd.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Read()
        {
            BD.MEDIKITDBEntities bbdd = new BD.MEDIKITDBEntities();
            try
            {
                BD.Equipos equipo = bbdd.Equipos.First(e=>e.Id == Id);
                CommonBC.Syncronize(equipo, this);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update()
        {
            BD.MEDIKITDBEntities bbdd = new BD.MEDIKITDBEntities();
            try
            {
                BD.Equipos equipo = bbdd.Equipos.First(e => e.Id == Id);
                CommonBC.Syncronize(this, equipo);

                bbdd.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete()
        {
            BD.MEDIKITDBEntities bbdd = new BD.MEDIKITDBEntities();
            try
            {
                BD.Equipos equipo = bbdd.Equipos.First(e => e.Id == Id);
                bbdd.Equipos.Remove(equipo);
                bbdd.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
