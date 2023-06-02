using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediKit.BD;

namespace MediKit.BC
{
    public class User
    {
        public System.Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public bool Read()
        {
            //Creamos la conexion al Entities
            MEDIKITDBEntities bd = new MEDIKITDBEntities();
            try
            {
                //se busca por el ID
                BD.User user =
                    bd.User.First(e => e.Id.Equals(this.Id));
                CommonBC.Syncronize(user, this);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<User> ReadAll()
        {
            //crear una conexión con el Entities
            MEDIKITDBEntities bd = new MEDIKITDBEntities();
            try
            {
                //Crear una lista de DATOS
                List<BD.User> listaUser = bd.User.ToList();
                //Crear una lista de NEGOCIO
                List<User> listaNegocio = GenerarListado(listaUser);
                return listaNegocio;
            }
            catch (Exception ex)
            {
                return new List<User>();
            }
        }

        private List<User> GenerarListado(List<BD.User> listaUser)
        {
            List<User> listaNegocio = new List<User>();
            foreach (BD.User user in listaUser)
            {
                User negocio = new User();
                CommonBC.Syncronize(user, negocio);
                listaNegocio.Add(negocio);
            }
            return listaNegocio;
        }
    }
}
