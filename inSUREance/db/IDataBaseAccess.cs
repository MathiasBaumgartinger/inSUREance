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

        int ExecutePreparedStatementNonQuery(IPreparedStatement stmt,
            IsolationLevel isolationLevel = IsolationLevel.Serializable);

        SqlDataReader ExecutePreparedStatementReader(IPreparedStatement stmt, IsolationLevel isolationLevel = IsolationLevel.Serializable);
    }
}
