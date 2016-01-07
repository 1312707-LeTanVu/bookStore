using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Entity
{
    public class DataProvider
    {
        protected static string connectionString;

        public static string ConnectionString
        {
            get { return connectionString; }
            set { connectionString = value; }
        }

        protected SqlConnection connect;
        protected SqlCommand command;
        protected SqlDataReader reader;

        public void Connect()
        {
            connect = new SqlConnection(connectionString);
            connect.Open();
        }

        public void Disconnect()
        {
            connect.Close();
        }


        public SqlDataReader ExecuteReader(string stringQuery)
        {
            Connect();
            command = new SqlCommand(stringQuery, connect);
            return command.ExecuteReader();
        }

        public void ExecuteNonQuery(string stringQuery)
        {
            Connect();
            command = new SqlCommand(stringQuery, connect);
            command.ExecuteNonQuery();
        }
    }
}
