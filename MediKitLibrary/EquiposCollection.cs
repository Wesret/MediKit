using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Equipos BuscarEquipo(int Lote) 
        {
            foreach (Equipos e in equipamiento)
            {
                if (e.Lote == Lote)
                {
                    return e;
                }
            }

            return null;
        }

        public bool EliminarEquipo(int Lote)
        {
            Equipos equipo = this.BuscarEquipo(Lote);

            if (Lote == 0)
            {
                return false;
            }

            equipo.Cantidad--;
            return true;
        }
    }
}
