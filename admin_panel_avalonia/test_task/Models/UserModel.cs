using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_task.Models
{
    public class UserModel : INotifyPropertyChanged
    {
        public int _id;
        public string _email;
        public string _password;
        public string _confirmPassword;

        public event PropertyChangedEventHandler? PropertyChanged;

        public int Id { get {return _id; } set {_id=value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Id")); } }
        public string Email { get {return _email; } set {_email = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Email")); } }
        public string Password { get { return _password; } set {_password = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Password")); } }
        public string ConfirmPassword { get { return _confirmPassword; } set {_confirmPassword = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ConfirmPassword")); } }


        public UserModel()
        {
            Email ="";
            Password="";
            ConfirmPassword="";
            Id = -1;
        }
        public bool CheckData()
        {
            if (Email.Length > 3 && Email.IndexOf("@") > -1 && Email.IndexOf(".") > -1 && Password.Length > 8)
            {
                return true;
            }
            return false;
        }

        public void SetData(DataRow row)
        {
            this.Id = (int)row["Id"];
            this.Email = (string)row["Email"];
            this.Password = (string)row["Password"];
        }

    }
}
