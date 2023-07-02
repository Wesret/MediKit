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
        
        private void BtnAgregar_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtProducto.Text) || string.IsNullOrEmpty(txtPrecio.Text) || string.IsNullOrEmpty(txtLote.Text) || string.IsNullOrEmpty(txtCantidad.Text))
            {
                MessageBox.Show("Por favor rellene los campos", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
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
        }

        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtLote.Text))
            {
                MessageBox.Show("Por favor ingrese el Nro de Lote", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                LimpiarControles();
            }
            else
            {
                Equipos equipo = new Equipos()
                {
                    Lote = int.Parse(txtLote.Text)
                };

                if (equipo.Read())
                {
                    txtProducto.Text = equipo.Producto;
                    cboMarca.SelectedValue = equipo.MarcaID;
                    txtPrecio.Text = equipo.Precio.ToString();
                    txtCantidad.Text = equipo.Cantidad.ToString();
                    txtLote.Text = equipo.Lote.ToString();

                    MessageBox.Show("Equipo Encontrado", "Información", MessageBoxButton.OK, MessageBoxImage.Information);

                }
                else
                {
                    MessageBox.Show("No se encontró el equipo", "Atención", MessageBoxButton.OK, MessageBoxImage.Information);
                    LimpiarControles();
                }
            }

            
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtLote.Text))
            {
                MessageBox.Show("Por favor ingrese el Nro de Lote", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                LimpiarControles();
            }
            else
            {
                Equipos equipo = new Equipos()
                {
                    Lote = int.Parse(txtLote.Text)
                };

                if (MessageBox.Show("¿Está seguro/a de eliminar el equipo?",
                        "Borrar Equipo",
                        MessageBoxButton.YesNo,
                        MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
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
            }

        }

        private void dgInventario_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnModificar_Click(object sender, RoutedEventArgs e)
        {
            // Crear una instancia del objeto Equipos con los datos recopilados
            Equipos equipo = new Equipos()
            {
                Producto = txtProducto.Text,
                MarcaID = (int)cboMarca.SelectedValue,
                Precio = int.Parse(txtPrecio.Text),
                Cantidad = int.Parse(txtCantidad.Text),
                Lote = int.Parse(txtLote.Text)
            };

            // Actualizar el equipo en la base de datos
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

        private void BtnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Windows_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void BtnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
