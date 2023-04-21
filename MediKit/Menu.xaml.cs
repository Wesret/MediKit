using MahApps.Metro.Controls;
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
using MediKitLibrary;

namespace MediKit
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : MetroWindow
    {

        private EquiposCollection _collection = new EquiposCollection();

        public Menu()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Tile_Click(object sender, RoutedEventArgs e)
        {
            GestionEquipos gestion = new GestionEquipos(this._collection);
            gestion.Show();
        }

        private void Tile_Click_1(object sender, RoutedEventArgs e)
        {
            ListadoEquipos listado = new ListadoEquipos(this._collection);
            listado.Show();
        }
    }
}
