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
        private readonly SqlConnection connection;

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

        public int ExecutePreparedStatementNonQuery(IPreparedStatement stmt,
            IsolationLevel isolationLevel = IsolationLevel.Serializable)
        {
            SqlCommand command = stmt.GetCommand();
            command.Connection = connection;

            SqlTransaction transaction = connection.BeginTransaction(isolationLevel);
            command.Transaction = transaction;

            command.Prepare();

            try
            {
                int rows = command.ExecuteNonQuery();
                transaction.Commit();

                return rows;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                return -1;
            }
        }

        public SqlDataReader ExecutePreparedStatementReader(IPreparedStatement stmt, IsolationLevel isolationLevel = IsolationLevel.Serializable)
        {
            SqlCommand command = stmt.GetCommand();
            command.Connection = connection;

            SqlTransaction transaction = connection.BeginTransaction(isolationLevel);
            command.Transaction = transaction;

            command.Prepare();

            try
            {
                SqlDataReader reader = command.ExecuteReader();
                transaction.Commit();

                return reader;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                return null;
            }
        }

        public void Dispose()
        {
            Close();
        }
    }
}
