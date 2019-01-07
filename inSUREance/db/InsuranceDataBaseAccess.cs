using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Diagnostics;
using Windows.UI.ViewManagement;

namespace inSUREance.db
{
    public class InsuranceDataBaseAccess : IDataBaseAccess, IDisposable
    {
        private string connectionString;
        public SqlConnection connection { get; }

        public InsuranceDataBaseAccess(string server, string user, string pwd)
        {
            connectionString = "";
            connectionString += "Data Source=" + server + ";";
            connectionString += "Initial Catalog=VersicherungsDB;";
            connectionString += "User id=" + user + ";";
            connectionString += "Password=" + pwd + ";";

            connection = new SqlConnection(connectionString);
        }

        public bool Open()
        {
            if (connection.State == ConnectionState.Open) return false;

            try
            {
                connection.Open();
                Debug.WriteLine("Connected to database");

                return true;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine("Error while connecting to database");
                Debug.WriteLine(ex.ToString());
                return false;
            }
        }

        public bool Close()
        {
            if (connection.State != ConnectionState.Open) return false;

            try
            {
                connection.Close();

                Debug.WriteLine("Disconnected from database");

                return true;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine("Error while disconnecting from database");
                return false;
            }
        }

        public int ExecutePreparedStatementNonQuery(IPreparedStatement stmt)
        {
            SqlCommand command = stmt.GetCommand();

            try
            {
                int rows = command.ExecuteNonQuery();
                return rows;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return -1;
            }
        }

        public int ExecutePreparedStatementNonQuery(IPreparedStatement stmt,
            IsolationLevel isolationLevel)
        {
            SqlCommand command = stmt.GetCommand();

            SqlTransaction transaction = connection.BeginTransaction(isolationLevel);
            command.Transaction = transaction;

            try
            {
                int rows = command.ExecuteNonQuery();
                transaction.Commit();

                return rows;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());

                try
                {
                    transaction.Rollback();
                }
                catch (Exception ex2)
                {
                    Debug.WriteLine(ex2.ToString());
                    return -1;
                }

                return -1;
            }
        }

        public SqlDataReader ExecutePreparedStatementReader(IPreparedStatement stmt)
        {
            SqlCommand command = stmt.GetCommand();

            try
            {
                SqlDataReader reader = command.ExecuteReader();

                return reader;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return null;
            }
        }

        public SqlDataReader ExecutePreparedStatementReader(IPreparedStatement stmt, IsolationLevel isolationLevel)
        {
            SqlCommand command = stmt.GetCommand();

            SqlTransaction transaction = connection.BeginTransaction(isolationLevel);
            command.Transaction = transaction;

            SqlDataReader reader;

            try
            {
                reader = command.ExecuteReader();
                //transaction.Commit();

                return reader;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());

                try
                {
                   //transaction.Rollback();
                }
                catch (Exception ex2)
                {
                    Debug.WriteLine(ex2.ToString());
                    return null;
                }

                return null;
            }
        }

        public void Dispose()
        {
            Close();
        }
    }
}
