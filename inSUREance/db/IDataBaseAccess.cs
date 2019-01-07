using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inSUREance.db
{
    interface IDataBaseAccess
    {
        bool Open();
        bool Close();

        //without transaction, returns num of rows changed
        int ExecutePreparedStatementNonQuery(IPreparedStatement stmt);

        //with transaction, returns num of rows changed
        int ExecutePreparedStatementNonQuery(IPreparedStatement stmt,
            IsolationLevel isolationLevel);

        //without transaction, returns sqlreader or null
        SqlDataReader ExecutePreparedStatementReader(IPreparedStatement stmt);

        //with transaction, returns sqlreader or null
        SqlDataReader ExecutePreparedStatementReader(IPreparedStatement stmt, IsolationLevel isolationLevel);
    }
}
