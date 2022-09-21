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
        public readonly SqlConnection connection = null;

        public DBManager()
        {
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Bearings"].ConnectionString);
        }

        public void OpenConnection() => connection.Open();
        public void CloseConnection() => connection.Close();
    }
}
