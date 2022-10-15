using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;
using System.Data.Common;
using System.ComponentModel;
using System.Threading;
using System.Collections;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace University_ModernProgrammingTechnologies_Lab1
{
    internal class DBManager
    {
        public readonly SqlConnection connection = null;

        public DBManager()
        {
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Bearings"].ConnectionString);
            connection.Open();
        }

        public void FillTableWithRandomValues(int count)
        {
            connection.Open();
            string query = "INSERT INTO RadialBearings (Designation, Din, Dex, B, C, C0)";
            query += "VALUES (@Designation, @Din, @Dex, @B, @C, @C0)";
            Random rnd = new Random();

            for (int i = 0; i < count; i++)
            {
                SqlCommand myCommand = new SqlCommand(query, connection);
                myCommand.Parameters.AddWithValue("@Designation", i);
                myCommand.Parameters.AddWithValue("@Din", rnd.Next(10000));
                myCommand.Parameters.AddWithValue("@Dex", rnd.Next(10000));
                myCommand.Parameters.AddWithValue("@B", rnd.Next(10000));
                myCommand.Parameters.AddWithValue("@C", rnd.Next(10000));
                myCommand.Parameters.AddWithValue("@C0", rnd.Next(10000));
                myCommand.ExecuteNonQuery();
            }            
            connection.Close();
        }

        public void FillTableWithRandomValues(int count, BackgroundWorker worker, DoWorkEventArgs e)
        {
            connection.Open();
            string query = "INSERT INTO RadialBearings (Designation, Din, Dex, B, C, C0)";
            query += "VALUES (@Designation, @Din, @Dex, @B, @C, @C0)";
            Random rnd = new Random();

            for (int i = 1; i <= count; i++)
            {
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }

                SqlCommand myCommand = new SqlCommand(query, connection);
                myCommand.Parameters.AddWithValue("@Designation", i);
                myCommand.Parameters.AddWithValue("@Din", rnd.Next(10000));
                myCommand.Parameters.AddWithValue("@Dex", rnd.Next(10000));
                myCommand.Parameters.AddWithValue("@B", rnd.Next(10000));
                myCommand.Parameters.AddWithValue("@C", rnd.Next(10000));
                myCommand.Parameters.AddWithValue("@C0", rnd.Next(10000));
                myCommand.ExecuteNonQuery();
                worker.ReportProgress(i * 100 / count);
            }
            connection.Close();
        }

        public void DeleteRecordsFromTable(int count)
        {
            connection.Open();
            for (int i = 0; i < count; i++)
            {
                string query = $"DELETE FROM RadialBearings WHERE ID in(SELECT MAX(ID) FROM RadialBearings)";
                SqlCommand myCommand = new SqlCommand(query, connection);
                myCommand.ExecuteNonQuery();
            }
            connection.Close();
        }

        public void DeleteRecordsFromTable(int count, BackgroundWorker worker, DoWorkEventArgs e)
        {
            connection.Open();
            for (int i = 1; i <= count; i++)
            {
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }

                string query = $"DELETE FROM RadialBearings WHERE ID in(SELECT MAX(ID) FROM RadialBearings)";
                SqlCommand myCommand = new SqlCommand(query, connection);
                myCommand.ExecuteNonQuery();
                worker.ReportProgress(i * 100 / count);
            }
            connection.Close();
        }

        public int GetRecordsCount()
        {
            connection.Open();
            string query = "SELECT COUNT(*) FROM RadialBearings";
            SqlCommand myCommand = new SqlCommand(query, connection);
            Int32 count = (Int32)myCommand.ExecuteScalar();
            connection.Close();
            return count; 
        }

        public void RunStoredSQLProcedures(params string[] paths)
        {
            connection.Open();

            for (int i = 0; i < paths.Length; i++)
            {
                try
                {
                    string script = File.ReadAllText(paths[i]);

                    IEnumerable<string> commandStrings = script.Split('\n');

                    foreach (string commandString in commandStrings)
                    {
                        if (!string.IsNullOrWhiteSpace(commandString.Trim()))
                        {
                            using (var command = new SqlCommand(commandString, connection))
                            {
                                command.ExecuteNonQuery();
                            }
                        }
                    }
                }
                catch { continue; }   
            }

            connection.Close();
        }
    }
}
