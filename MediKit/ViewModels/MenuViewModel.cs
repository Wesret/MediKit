using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using MediKit.Models;
using MediKit.Repositories;

namespace MediKit.ViewModels
{
    public class MenuViewModel: ViewModelBase
    {
        //campos
        private UserAccountModel _currentUserAccount;
        private IUserRepository userRepository;

        public UserAccountModel CurrentUserAccount 
        {
            get 
            { 
                return _currentUserAccount; 
            }
            set 
            { 
                _currentUserAccount = value;
                OnPropertyChanged(nameof(CurrentUserAccount));
            }
        }

        public MenuViewModel()
        {
            userRepository = new UserRepository();
            CurrentUserAccount = new UserAccountModel();
            LoadCurrentUserData();
        }

        private void LoadCurrentUserData()
        {
            var user = userRepository.GetByUsername(Thread.CurrentPrincipal.Identity.Name);
            if(user != null)
            {
                    CurrentUserAccount.Username = user.Username;
                    CurrentUserAccount.DisplayName = $"Bienvenido/a {user.Name}";
                    CurrentUserAccount.ProfilePicture = null;
            }
            else
            {
                CurrentUserAccount.DisplayName = "Usuario no valido";
                Application.Current.Shutdown();
            }
        }
    }
}
