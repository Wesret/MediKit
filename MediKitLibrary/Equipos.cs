using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediKitLibrary
{
    public class Equipos
    {
        public enum Marcas { Medtronic, Fresenius, Abbott, Stryker, QuestDiagnostics};


        private string _producto;
        private Marcas _marca;
        private int _precio;
        private int _cantidad;
        private int _lote;


        public int Lote
        {
            get { return _lote; }
            set { _lote = value; }
        }


        public Marcas Marca
        {
            get { return _marca; }
            set { _marca = value; }
        }


        public int Cantidad
        {
            get { return _cantidad; }
            set { _cantidad = value; }
        }


        public int Precio
        {
            get { return _precio; }
            set { _precio = value; }
        }


        public string Producto
        {
            get { return _producto; }
            set { _producto = value; }
        }

    }
}
