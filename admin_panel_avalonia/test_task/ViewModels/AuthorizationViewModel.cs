using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test_task.Commands;
using test_task.Models;

namespace test_task.ViewModels
{
    class AuthorizationViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler? PropertyChanged;

        private UserModel _current_user;
        public UserModel CurrentUser
        {
            get
            {
                return _current_user;
            }
            set
            {
                this._current_user = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CurrentUser"));
            }
        }

        public UserCommand AuthCommand {get;set; }
 
        public AuthorizationViewModel()
        {
            CurrentUser = new UserModel();

            AuthCommand = new UserCommand("auth");

            CurrentUser.PropertyChanged += (object? sender, PropertyChangedEventArgs args) =>
            {
                AuthCommand.CheckChange();
            };
        }

    }
}
