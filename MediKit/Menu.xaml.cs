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
using MediKit.BC;

namespace MediKit
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : MetroWindow
    {
        private User user;
        public Menu(User user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void GestionEquipos(object sender, RoutedEventArgs e)
        {
            GestionEquipos gestion = new GestionEquipos();
            gestion.Owner = this;
            gestion.ShowDialog();
        }

        private void ListadoEquipos(object sender, RoutedEventArgs e)
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

        private void VerPerfil(object sender, RoutedEventArgs e)
        {
            Perfil perfil = new Perfil(user);
            perfil.Owner = this;
            perfil.ShowDialog();
        }
    }
}
