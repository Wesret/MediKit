using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediKit.BD;

namespace MediKit.BC
{
    public class Equipos
    {
        string _descripcionMarca;
        public int Id { get; set; }
        public string Producto { get; set; }
        public int Precio { get; set; }
        public int Cantidad { get; set; }
        public int Lote { get; set; }
        public int MarcaID { get; set; }
        public string DescripcionMarca { get => _descripcionMarca; }

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

        public bool Update()
        {
            using (var dbContext = new BD.MEDIKITDBEntities())
            {
                try
                {
                    var equipo = dbContext.Equipos.FirstOrDefault(a => a.Lote == this.Lote);

                    if (equipo != null)
                    {
                        // Actualizar las propiedades del equipo en la base de datos
                        equipo.Producto = this.Producto;
                        equipo.MarcaID = this.MarcaID;
                        equipo.Precio = this.Precio;
                        equipo.Cantidad = this.Cantidad;

                        dbContext.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false; // El equipo no existe en la base de datos
                    }
                }
                catch (Exception ex)
                {
                    // Manejar la excepción o registrar el error en algún lugar
                    return false;
                }
            }
        }

        public bool Delete()
        {
            BD.MEDIKITDBEntities bbdd = new BD.MEDIKITDBEntities();
            try
            {
                BD.Equipos equipo = bbdd.Equipos.First(e => e.Lote == Lote);
                bbdd.Equipos.Remove(equipo);
                bbdd.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void LeerDescripcionEquipo()
        {
            Marcas marcas = new Marcas() { Id = MarcaID };
            if (marcas.Read())
            {
                _descripcionMarca = marcas.Nombre;
            }
            else
            {
                _descripcionMarca = string.Empty;
            }
        }

        public bool Read()
        {
            //crear una conexion al Entities
            BD.MEDIKITDBEntities bd = new BD.MEDIKITDBEntities();
            try
            {
                //se busca por el Lote el contenido de la entidad
                BD.Equipos Equipos =
                    bd.Equipos.First(e => e.Lote.Equals(this.Lote));
                CommonBC.Syncronize(Equipos, this);
                //se agrega la lectura de la propiedad customizada
                LeerDescripcionEquipo();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Equipos> ReadAll()
        {
            //crear una conexion al Entities
            BD.MEDIKITDBEntities bd = new BD.MEDIKITDBEntities();
            try
            {
                //crear una lista de DATOS
                List<BD.Equipos> listaEquipos = bd.Equipos.ToList();
                //crear una lista de NEGOCIO
                List<Equipos> listaNegocio = GenerarListado(listaEquipos);
                return listaNegocio;
            }
            catch (Exception)
            {
                return new List<Equipos>();
            }
        }

        private List<Equipos> GenerarListado(List<BD.Equipos> listaEquipos)
        {
            List<Equipos> listaNegocio = new List<Equipos>();
            foreach (BD.Equipos equipos in listaEquipos)
            {
                Equipos negocio = new Equipos();
                CommonBC.Syncronize(equipos, negocio);
                //rescatar la lectura de la marca
                negocio.LeerDescripcionEquipo();
                listaNegocio.Add(negocio);
            }
            return listaNegocio;
        }

        public List<Equipos> BuscarMarca(int marcaID)
        {
            BD.MEDIKITDBEntities bd = new BD.MEDIKITDBEntities();

            List<Equipos> equipo = (from a in bd.Equipos
                                    where a.Marcas.Id == marcaID
                                    select new Equipos
                                    {
                                        Id = a.Id,
                                        Producto = a.Producto,
                                        Precio = a.Precio,
                                        Cantidad = a.Cantidad,
                                        Lote = a.Lote,
                                        MarcaID = a.Marcas.Id,
                                        _descripcionMarca = a.Marcas.Nombre
                                    }).ToList();
            return equipo;
        }

        public List<Equipos> BuscarProducto(string producto)
        {
            BD.MEDIKITDBEntities bd = new BD.MEDIKITDBEntities();

            List<Equipos> equipo = (from a in bd.Equipos
                                    where a.Producto.ToLower().Contains(producto)
                                    select new Equipos
                                    {
                                        Id = a.Id,
                                        Producto = a.Producto,
                                        Precio = a.Precio,
                                        Cantidad = a.Cantidad,
                                        Lote = a.Lote,
                                        MarcaID = a.Marcas.Id,
                                        _descripcionMarca = a.Marcas.Nombre
                                    }).ToList();
            return equipo;
        }

    }
}
