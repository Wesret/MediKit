﻿using ControlzEx.Theming;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using MediKit.BC;

namespace MediKit
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : MetroWindow
    {

        public Login()
        {
            InitializeComponent();

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        BD.MEDIKITDBEntities bd = new BD.MEDIKITDBEntities();
        private void btnIngresar_Click(object sender, RoutedEventArgs e)
        {
            User user = new User();

            string username = txtUser.Text;
            string password = txtPass.Password;

            var rec = bd.User.Where(a => a.Username == username && a.Password == password).FirstOrDefault();

            if (rec != null)
            {
                MessageBox.Show("Bienvenido/a " + txtUser.Text);
                Menu Menu = new Menu();
                this.Close();
                Menu.Show();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña erróneo");
                txtUser.Text = string.Empty;
                txtPass.Password = string.Empty;
            }

            
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