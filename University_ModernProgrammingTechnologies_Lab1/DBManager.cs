using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace University_ModernProgrammingTechnologies_Lab1
{
    internal class DBManager
    {
        private SqlConnection _connection;

        public DBManager()
        {
            _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Bearings"].ConnectionString);
        }

        public void OpenConnection() => _connection.Open();
        public void CloseConnection() => _connection.Close();
    }
}
