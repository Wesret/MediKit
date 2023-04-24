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
using MediKitLibrary;
using static MediKitLibrary.Equipos;

namespace MediKit
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class GestionEquipos : MetroWindow
    {

        private EquiposCollection _collection = new EquiposCollection();

        public GestionEquipos()
        {
            InitializeComponent();
            cboMarca.ItemsSource = Enum.GetValues(typeof(Marcas));

           // ThemeManager.Current.ChangeTheme(this, "Light.Purple");
        }
        public GestionEquipos(EquiposCollection collection)
        {
            this._collection = collection;
            InitializeComponent();
            cboMarca.ItemsSource = Enum.GetValues(typeof(Marcas));

            //ThemeManager.Current.ChangeTheme(this, "Light.Purple");
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            //recopilar los datos agregados
            string producto = txtProducto.Text;
            int precio = 0;

            if (int.TryParse(txtPrecio.Text, out precio) == false)
            {
                MessageBox.Show("Ingrese solo numeros porfavor", "ERROR");
                return;
            }

            int cantidad = 0;
            if (int.TryParse(txtCantidad.Text, out cantidad) == false)
            {
                MessageBox.Show("Ingrese solo numeros porfavor", "ERROR");
                return;
            }

            int lote = 0;
            if (int.TryParse(txtLote.Text, out lote) == false)
            {
                MessageBox.Show("Ingrese solo numeros porfavor", "ERROR");
                return;
            }

            //crear la instancia del equipo medico
            Equipos equipo = new Equipos();
            equipo.Producto = producto;
            equipo.Marca = (Marcas)cboMarca.SelectedIndex;
            equipo.Precio = precio;
            equipo.Cantidad = cantidad;
            equipo.Lote = lote;

            //guardar los datos en la coleccion
            if (_collection.GuardarEquipo(equipo))
            {
                MessageBox.Show("Equipo Guardado Correctamente");
            }


        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            string producto = txtProducto.Text;

            if (producto.Trim() == "")
            {
                MessageBox.Show("Debes ingresar un producto");
                return;
            }

            if (_collection.EliminarEquipo(producto))
            {
                MessageBox.Show("Eliminado Correctamente");
            }
            else
            {
                MessageBox.Show("No se ha encontrado el producto");
            }

        }

        private void dgInventario_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            //recopilar los datos agregados
            string producto = txtProducto.Text;
            int precio = 0;

            if (int.TryParse(txtPrecio.Text, out precio) == false)
            {
                MessageBox.Show("Ingrese solo numeros porfavor", "ERROR");
                return;
            }

            int cantidad = 0;
            if (int.TryParse(txtCantidad.Text, out cantidad) == false)
            {
                MessageBox.Show("Ingrese solo numeros porfavor", "ERROR");
                return;
            }

            int lote = 0;
            if (int.TryParse(txtLote.Text, out lote) == false)
            {
                MessageBox.Show("Ingrese solo numeros porfavor", "ERROR");
                return;
            }

            try
            {
                //crear la instancia del equipo medico
                Equipos equipo = _collection.BuscarEquipo(producto);

                if(equipo == null)
                {
                    MessageBox.Show("No se ha encontrado el equipo");
                    return;
                }

                equipo.Producto = producto;
                equipo.Precio = precio;
                equipo.Marca = (Marcas)cboMarca.SelectedIndex;
                equipo.Cantidad = cantidad;
                equipo.Lote = lote;

                MessageBox.Show("Equipo Modificado correctamente");


            }
            catch(ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
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
            Application.Current.Shutdown();
        }
    }
}
