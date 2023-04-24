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
using ControlzEx.Theming;
using MahApps.Metro.Controls;
using MediKitLibrary;
using static MediKitLibrary.Equipos;

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

        private void Windows_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }


        public ListadoEquipos()
        {
            InitializeComponent();

           // ThemeManager.Current.ChangeTheme(this, "Light.Purple");

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

            ThemeManager.Current.ChangeTheme(this, "Light.Purple");
            dgEquipos.ItemsSource = this.Collection.equipamiento;

            cboMarca.ItemsSource = Enum.GetValues(typeof(Marcas));
        }

        private void txtProducto_KeyUp(object sender, KeyEventArgs e)
        {
            string producto = txtProducto.Text;

            List<Equipos> equipos = this.Collection.BuscarProducto(producto);

            dgEquipos.ItemsSource = null;
            dgEquipos.ItemsSource = equipos;

        }

        private void btnFiltrar_Click(object sender, RoutedEventArgs e)
        {
            Marcas marca = (Marcas)cboMarca.SelectedIndex;

            List<Equipos> equipos = this.Collection.BuscarPorMarca(marca);

            dgEquipos.ItemsSource = null;
            dgEquipos.ItemsSource = equipos;
        }

        private void btnRefrescar_Click(object sender, RoutedEventArgs e)
        {
            dgEquipos.ItemsSource = null;
            dgEquipos.ItemsSource = this.Collection.equipamiento;
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
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
