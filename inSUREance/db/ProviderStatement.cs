using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inSUREance.db
{
    class GetProviderIDStatement : IPreparedStatement
    {
        private readonly string name;

        public GetProviderIDStatement(string name)
        {
            this.name = name;
        }

        public override void Prepare(SqlConnection connection)
        {
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;

            command.CommandText = "select_providerId_by_name";

            SqlParameter providerNameParam = new SqlParameter("@provider", SqlDbType.VarChar, 30);
            providerNameParam.Value = name;

            command.Parameters.Add(providerNameParam);
            command.Prepare();
        }
    }
}
