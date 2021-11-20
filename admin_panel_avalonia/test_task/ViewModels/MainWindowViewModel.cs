using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Text;
using test_task.Models;

namespace test_task.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public string Greeting => "Welcome to Avalonia!";

        public ObservableCollection<WordSetModel> Models {get;set; }

        public void SetModels(UserModel user)
        {
            var sets_of_user = new System.Data.SqlClient.SqlCommand("get_sets");
            SqlParameter id = new SqlParameter()
            {
                Direction = System.Data.ParameterDirection.Input,
                ParameterName = "@user_id",
                DbType = System.Data.DbType.String,
                Value = user.Id
            };
            sets_of_user.Parameters.AddRange(new SqlParameter[] {id});
            sets_of_user.CommandType = System.Data.CommandType.StoredProcedure;

            DBContext.SQLGetTable(sets_of_user);
        }
    }
}
