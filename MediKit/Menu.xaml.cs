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

        public Menu()
        {
            InitializeComponent();
        }


        private void Tile_Click(object sender, RoutedEventArgs e)
        {
            GestionEquipos gestion = new GestionEquipos();
            gestion.Owner = this;
            gestion.ShowDialog();
        }

        private void Tile_Click_1(object sender, RoutedEventArgs e)
        {
            ListadoEquipos listado = new ListadoEquipos();
            listado.Owner = this;
            listado.ShowDialog();
        }

        private void Windows_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
