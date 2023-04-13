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
                    equipo.Cantidad = equipo.Cantidad+ equipo.Cantidad;
                }
            }

            this.equipamiento.Add(equipo);
            return true;
        }

    }
}
