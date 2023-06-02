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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ControlzEx.Theming;
using MahApps.Metro.Controls;
using MediKit;
using MediKit.BC;

namespace MediKit
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class GestionEquipos : MetroWindow
    {

        public GestionEquipos()
        {
            InitializeComponent();
            LimpiarControles();

        }

        private void LimpiarControles()
        {
            //Limpia los controles de texto

            txtProducto.Text = string.Empty;
            txtPrecio.Text = string.Empty;
            txtLote.Text = string.Empty;
            txtCantidad.Text = string.Empty;

            CargarMarcas();

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

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        
        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            //recopilar los datos agregados
            Equipos equipo = new Equipos()
            {
                Producto = txtProducto.Text,
                Precio = int.Parse(txtPrecio.Text),
                MarcaID = (int)cboMarca.SelectedValue,
                Lote = int.Parse(txtLote.Text),
                Cantidad = int.Parse(txtCantidad.Text)

            };

            if (equipo.Create())
            {
                MessageBox.Show("Equipo ingresado con exito", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                LimpiarControles();
            }
            else
            {
                MessageBox.Show("No se pudo ingresar el equipo", "Alerta", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }


        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            Equipos equipo = new Equipos()
            {
                Lote = int.Parse(txtLote.Text)
            };

            if (equipo.Delete())
            {
                MessageBox.Show("Equipo eliminado", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                LimpiarControles();
            }
            else
            {
                MessageBox.Show("El equipo no pudo ser eliminado", "Atención", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void dgInventario_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            //recopilar los datos agregados
            Equipos equipo = new Equipos()
            {
                Producto = txtProducto.Text,
                Precio = int.Parse(txtPrecio.Text),
                MarcaID = (int)cboMarca.SelectedValue,
                Lote = int.Parse(txtLote.Text),
                Cantidad = int.Parse(txtCantidad.Text)

            };

            if (equipo.Update())
            {
                MessageBox.Show("Equipo modificado", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                LimpiarControles();
            }
            else
            {
                MessageBox.Show("No se pudo modificar el equipo", "Alerta", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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
            this.Close();
        }
    }
}
