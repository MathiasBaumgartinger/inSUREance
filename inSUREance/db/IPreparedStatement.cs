using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inSUREance.db
{
    public abstract class IPreparedStatement
    {
        protected SqlCommand command = new SqlCommand();

        public abstract void Prepare(SqlConnection connection);

        public SqlCommand GetCommand()
        {
            return command;
        }
    }
}
