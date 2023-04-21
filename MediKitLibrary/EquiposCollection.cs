using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MediKitLibrary.Equipos;

namespace MediKitLibrary
{
    public class EquiposCollection
    {

        public List<Equipos> equipamiento = new List<Equipos>();

        public bool GuardarEquipo(Equipos equipo)
        {
            foreach (Equipos e in equipamiento)
            {
                if (e.Lote == equipo.Lote)
                {
                    e.Cantidad = e.Cantidad + equipo.Cantidad;
                }
            }
            this.equipamiento.Add(equipo);
            return true;
            
        }

        public Equipos BuscarEquipo(String Producto) 
        {
            foreach (Equipos e in equipamiento)
            {
                if (e.Producto == Producto)
                {
                    return e;
                }
            }

            return null;
        }

        public bool EliminarEquipo(String Producto)
        {
            Equipos equipo = this.BuscarEquipo(Producto);

            if (Producto == null)
            {
                return false;
            }

            this.equipamiento.Remove(equipo);
            return true;
        }

        public List<Equipos> BuscarProducto (string producto)
        {
            List<Equipos> equipos = (from e in this.equipamiento
                                     where e.Producto.ToLower().Contains(producto) || e.Producto.ToUpper().Contains(producto)
                                     select e).ToList();

            return equipos;
        }

        public List<Equipos> BuscarPorMarca(Marcas marca)
        {
            List<Equipos> equipos = (from e in this.equipamiento
                                     where e.Marca == marca
                                     select e).ToList();

            return equipos;
        }

    }
}
