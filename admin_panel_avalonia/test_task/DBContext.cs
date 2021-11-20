using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_task
{
    public static class DBContext
    {
        public static SqlConnection SqlConnection { get; set; }

        public static DataSet data { get; set; }

        public static SqlDataAdapter adapter { get; set; }

    public static SqlConnectionStringBuilder Builder { get; set; }

        public delegate void ShMessage(string Message);
        public static event ShMessage ShowMessage;

        static DBContext()
        {
            SqlConnection = new SqlConnection();
            Builder = new SqlConnectionStringBuilder();

            Builder.DataSource = "tcp:deep-orange-sql-server.database.windows.net,1433";
            Builder.InitialCatalog = "game_db";
            Builder.IntegratedSecurity = false;
            Builder.UserID = "do_admin";
            Builder.Password = "Orange123go";
            Builder.MultipleActiveResultSets = false;
            Builder.Encrypt = true;
            Builder.TrustServerCertificate = false;
            Builder.ConnectTimeout = 30;

            SqlConnection.ConnectionString = Builder.ConnectionString;
            try
            {
                SqlConnection.Open();

            }
            catch (Exception ex)
            {
                ShowMessage?.Invoke("Couldn't connect to database. Error cod: " + ex.Message);
            }
        }
        public static object SQLQueryInsert(SqlCommand sqlCommand)
        {
            sqlCommand.Connection = SqlConnection;

            return sqlCommand.ExecuteScalar();
        }
        public static void SQLGetTable(SqlCommand sqlCommand)
        {
            sqlCommand.Connection = SqlConnection;

            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand.CommandText, SqlConnection);

            data = new DataSet();

            dataAdapter.Fill(data);
        }
        public static void Close()
        {
            SqlConnection.Close();
        }
    }
}
