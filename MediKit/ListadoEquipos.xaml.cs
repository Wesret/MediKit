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
using MediKit.BC;

namespace MediKit
{
    /// <summary>
    /// Interaction logic for ListadoEquipos.xaml
    /// </summary>
    public partial class ListadoEquipos : MetroWindow
    {


        public ListadoEquipos()
        {
            InitializeComponent();
            CargarEquipos();
            CargarMarcas();
           // ThemeManager.Current.ChangeTheme(this, "Light.Purple");

        }

        private void CargarEquipos()
        {
            Equipos equipo = new Equipos();
            dgEquipos.ItemsSource = equipo.ReadAll();
        }

        private void CargarMarcas()
        {
            //Se cargan los equipos
            Marcas marca = new Marcas();
            cboMarca.ItemsSource = marca.ReadAll();

            cboMarca.DisplayMemberPath = "Nombre";
            cboMarca.SelectedValuePath = "Id";
            cboMarca.SelectedIndex = 0;

        }

        private void dgEquipos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void txtProducto_TextChanged(object sender, TextChangedEventArgs e)
        {

        }


        private void txtProducto_KeyUp(object sender, KeyEventArgs e)
        {
            Equipos equipos = new Equipos();
            string producto = txtProducto.Text;

            dgEquipos.ItemsSource = equipos.BuscarProducto(producto);
        }

        private void btnFiltrar_Click(object sender, RoutedEventArgs e)
        {
            Equipos equipos = new Equipos();
            int marcaId = int.Parse(cboMarca.SelectedValue.ToString());

            dgEquipos.ItemsSource = equipos.BuscarMarca(marcaId);
            txtProducto.Text = string.Empty;
        }

        private void btnRefrescar_Click(object sender, RoutedEventArgs e)
        {
            Equipos equipo = new Equipos();
            dgEquipos.ItemsSource = equipo.ReadAll();
            txtProducto.Text = string.Empty;
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
            this.Close();
        }
    }
}
