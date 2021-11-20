using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using test_task.Models;

namespace test_task.Commands
{
    public class UserCommand : ICommand
    {
        private string _current_type;

        public string Current_Type
        {
            get { return this._current_type; }
            set { this._current_type = value; }
        }

        public UserCommand(string type)
        {
            this.Current_Type = type;
        }

        public event EventHandler? CanExecuteChanged;

        public void CheckChange()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
        public bool CanExecute(object? parameter)
        {
            var user = (parameter as UserModel);

            if (user != null)
            {
                switch (Current_Type)
                {
                    case "create":
                        if (user.Password.Length > 8 &&
                           user.ConfirmPassword == user.Password &&
                           user.Email.IndexOf("@") > -1 &&
                           user.Email.IndexOf(".") > -1)
                        {
                            return true;
                        }
                        break;
                     case "auth":
                        if (user.Password.Length > 8 &&
                            user.Email.IndexOf("@") > -1 &&
                            user.Email.IndexOf(".") > -1)
                        {
                            return true;
                        }
                        break;
                    default:
                        return false;
                }
            }
            return false;
        }

        public void Execute(object? parameter)
        {
            var user = (parameter as UserModel);

            if (user != null)
            {
                switch (Current_Type)
                {
                    case "create":
                        CreateUser(user);
                        break;
                    case "auth":
                        AuthUser(user);
                        break;
                    default:
                        return;
                }
            }
        }

        public void CreateUser(UserModel user)
        {
            var new_user_command = new System.Data.SqlClient.SqlCommand("create_user");
            SqlParameter email = new SqlParameter()
            {
                Direction = System.Data.ParameterDirection.Input,
                ParameterName = "@email",
                DbType = System.Data.DbType.String,
                Value= user.Email
            };
            SqlParameter password = new SqlParameter()
            {
                Direction = System.Data.ParameterDirection.Input,
                ParameterName = "@passw",
                DbType = System.Data.DbType.String,
                Value = user.Password
            };
            new_user_command.Parameters.AddRange(new SqlParameter[] {email,password});
            new_user_command.CommandType = System.Data.CommandType.StoredProcedure;

            try
            {
                user.Id = (int)DBContext.SQLQueryInsert(new_user_command);
            }
            catch (Exception ex)
            {

            }
        }
        public void AuthUser(UserModel user)
        {
            var new_user_command = new System.Data.SqlClient.SqlCommand("user_id_by_credentials");
            SqlParameter email = new SqlParameter()
            {
                Direction = System.Data.ParameterDirection.Input,
                ParameterName = "@email",
                DbType = System.Data.DbType.String,
                Value = user.Email
            };
            SqlParameter password = new SqlParameter()
            {
                Direction = System.Data.ParameterDirection.Input,
                ParameterName = "@passw",
                DbType = System.Data.DbType.String,
                Value = user.Password
            };
            new_user_command.Parameters.AddRange(new SqlParameter[] { email, password });
            new_user_command.CommandType = System.Data.CommandType.StoredProcedure;

            try
            {
                user.Id = (int)DBContext.SQLQueryInsert(new_user_command);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
