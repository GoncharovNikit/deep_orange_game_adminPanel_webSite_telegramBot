using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using test_task.Commands;
using test_task.Models;

namespace test_task.ViewModels
{
    class CreateNewAccountViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler? PropertyChanged;

        private UserModel _current_user;
        public UserModel CurrentUser { 
            get 
            {
                return _current_user;
            }
            set
            {
                this._current_user = value;
                PropertyChanged?.Invoke(this,new PropertyChangedEventArgs("CurrentUser"));
            }
        }

        public UserCommand CreateCommand {get;set; }

        public bool _isEnableCreateButton;

        public bool IsEnableCreateButton { get {return _isEnableCreateButton; } set { _isEnableCreateButton= value; PropertyChanged?.Invoke(this,new PropertyChangedEventArgs("IsEnableCreateButton")); } }

        public CreateNewAccountViewModel()
        {
            CurrentUser = new UserModel();

            CreateCommand = new UserCommand("create");

            CurrentUser.PropertyChanged += (object? sender,PropertyChangedEventArgs args) =>
            {
                CreateCommand.CheckChange();
                //IsEnableCreateButton =  CreateCommand.CanExecute(CurrentUser);
            };
        }

    }
}
