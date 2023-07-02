using ControlzEx.Theming;
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
using System.Security.Cryptography;
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

        private void btnIngresar_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUser.Text;
            string password = txtPass.Password;

            // Realiza la autenticación del usuario y verifica si las credenciales son correctas
            bool autenticado = AutenticarUsuario(username, password);

            if (autenticado)
            {
                User user = ObtenerDatosUsuario(username);

                // Autenticación exitosa
                MessageBox.Show("Bienvenido/a " + username, "Login", MessageBoxButton.OK, MessageBoxImage.Information);
                Menu menu = new Menu(user);
                this.Close();
                menu.Show();
            }
            else
            {
                // Autenticación fallida
                MessageBox.Show("Usuario o contraseña incorrectos", "Login", MessageBoxButton.OK, MessageBoxImage.Error);
                txtUser.Text = string.Empty;
                txtPass.Password = string.Empty;
            }
        }

        private User ObtenerDatosUsuario(string username)
        {
            // Establecer una conexión segura con la base de datos
            using (BD.MEDIKITDBEntities bd = new BD.MEDIKITDBEntities())
            {
                // Buscar al usuario en la base de datos por el nombre de usuario
                var user = bd.User.FirstOrDefault(a => a.Username == username);

                if (user != null)
                {
                    // Crear una instancia de Usuario y asignar los datos
                    User usuario = new User
                    {
                        Username = user.Username,
                        Name = user.Name,
                        LastName = user.LastName,
                        Email = user.Email,
                        Password = user.Password
                    };

                    return usuario;
                }
            }

            return null;
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

        private bool AutenticarUsuario(string username, string password)
        {
            // Establecer una conexión segura con la base de datos
            using (BD.MEDIKITDBEntities bd = new BD.MEDIKITDBEntities())
            {
                //Buscar al usuario en la base de datos
                var user = bd.User.FirstOrDefault(a => a.Username == username && a.Password == password);

                // Verificar si se encontró un usuario
                if (user != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }

}