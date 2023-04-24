using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MediKit
{
    /// <summary>
    /// Lógica de interacción para App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected void ApplicationStart(object sender, StartupEventArgs e)
        {
            var login = new Login();
            login.Show();
            login.IsVisibleChanged += (s, ev) =>
            {
                if (login.IsVisible == false && login.IsLoaded)
                {
                    var main = new Menu();
                    main.Show();
                    login.Close();
                }
            };
        }
    }
}
