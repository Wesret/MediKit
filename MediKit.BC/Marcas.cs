using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediKit.BD;

namespace MediKit.BC
{
    public class Marcas
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public bool Read()
        {
            //Crear una conexion al Entities
            MEDIKITDBEntities bd = new MEDIKITDBEntities();
            try
            {
                //se busca por el id el contenido de la entidad
                BD.Marcas Marcas =
                    bd.Marcas.First(e => e.Id.Equals(this.Id));
                CommonBC.Syncronize(Marcas, this);

                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Marcas> ReadAll()
        {
            //crear una conexión con el Entities
            MEDIKITDBEntities bd = new MEDIKITDBEntities();
            try
            {
                //Crear una lista de DATOS
                List<BD.Marcas> listaMarcas = bd.Marcas.ToList();
                //Crear una lista de NEGOCIO
                List<Marcas> listaNegocio = GenerarListado(listaMarcas);
                return listaNegocio;
            }
            catch (Exception ex)
            {
                return new List<Marcas>();
            }
        }

        private List<Marcas> GenerarListado(List<BD.Marcas> listaMarcas)
        {
            List<Marcas> listaNegocio = new List<Marcas>();
            foreach (BD.Marcas marcas in listaMarcas)
            {
                Marcas negocio = new Marcas();
                CommonBC.Syncronize(marcas, negocio);
                listaNegocio.Add(negocio);
            }
            return listaNegocio;
        }




    }
}
