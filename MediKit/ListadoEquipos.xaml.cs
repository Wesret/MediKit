using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using MediKitLibrary;

namespace MediKit
{
    /// <summary>
    /// Interaction logic for ListadoEquipos.xaml
    /// </summary>
    public partial class ListadoEquipos : MetroWindow
    {

        private EquiposCollection _collection;

        public EquiposCollection Collection
        {
            get { return _collection; }
            set { _collection = value; }
        }


        public ListadoEquipos()
        {
            InitializeComponent();
        }

        private void dgEquipos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void txtProducto_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        public ListadoEquipos(EquiposCollection collection)
        {
            this.Collection = collection;
            InitializeComponent();
            dgEquipos.ItemsSource = this.Collection.equipamiento;
        }
    }
}
