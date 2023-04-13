﻿using System;
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
using MahApps.Metro.Controls;
using MediKit;
using MediKitLibrary;

namespace MediKit
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {

        private EquiposCollection _collection = new EquiposCollection();

        public MainWindow()
        {
            InitializeComponent();
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
            equipo.Precio = precio;
            equipo.Cantidad = cantidad;
            equipo.Lote = lote;

            //guardar los datos en la coleccion
            if (_collection.GuardarEquipo(equipo))
            {
                MessageBox.Show("Equipo Guardado Correctamente");
            }

            //mostrar equipos en la grilla
            CargarGrilla();

        }

        private void CargarGrilla()
        {
            dgInventario.ItemsSource = null;
            dgInventario.ItemsSource = _collection.equipamiento;
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            //Se hace la busqueda del equipamiento por Lote
            int lote = 0;
            if (int.TryParse(txtLote.Text, out lote) == false)
            {
                MessageBox.Show("Debes ingresar un lote");
                return;
            }

            Equipos equipo = _collection.BuscarEquipo(lote);

            if (equipo == null)
            {
                MessageBox.Show("No se ha encontrado el equipamiento");
                return;
            }

            txtProducto.Text = equipo.Producto;
            txtPrecio.Text = equipo.Precio.ToString();
            txtCantidad.Text = equipo.Cantidad.ToString();
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void dgInventario_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}