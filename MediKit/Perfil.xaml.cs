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
using MediKit.BC;

namespace MediKit
{
    /// <summary>
    /// Interaction logic for Perfil.xaml
    /// </summary>
    public partial class Perfil : MetroWindow
    {
        private User usuario;
        public Perfil(User user)
        {
            InitializeComponent();
            this.usuario = user;
            DataContext = this.usuario;

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

        private void btnModificarContraseña_Click(object sender, RoutedEventArgs e)
        {
            string oldPassword = txtOldPass.Password;
            string newPassword = txtNewPass.Password;
            string confirmPassword = txtConfPass.Password;

            // Verificar que la contraseña antigua sea correcta
            if (usuario.Password != oldPassword)
            {
                MessageBox.Show("La contraseña antigua no es correcta.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Verificar que la nueva contraseña y la confirmación coincidan
            if (newPassword != confirmPassword)
            {
                MessageBox.Show("La nueva contraseña y la confirmación no coinciden.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Actualizar la contraseña del usuario en la base de datos
            using (BD.MEDIKITDBEntities bd = new BD.MEDIKITDBEntities())
            {
                var userUpdate = bd.User.FirstOrDefault(u => u.Username == usuario.Username);

                if (userUpdate != null)
                {
                    userUpdate.Password = newPassword;
                    bd.SaveChanges();

                    MessageBox.Show("La contraseña se ha cambiado correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                    usuario.Password = newPassword;
                    txtOldPass.Password = string.Empty;
                    txtNewPass.Password = string.Empty;
                    txtConfPass.Password = string.Empty;
                }
            }
        }
        
    }
}
