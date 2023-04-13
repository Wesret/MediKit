using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediKitLibrary
{
    public class Equipos
    {
        private string _producto;
        private int _precio;
        private int _cantidad;
        private int _lote;
        private bool _nuevo;

        public bool Nuevo
        {
            get { return _nuevo; }
            set { _nuevo = value; }
        }


        public int Lote
        {
            get { return _lote; }
            set { _lote = value; }
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
