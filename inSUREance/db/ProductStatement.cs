using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inSUREance.db
{
    public class ListProductStatement : IPreparedStatement
    {
        private int categoryid;

        public ListProductStatement(int categoryid)
        {
            this.categoryid = categoryid;
        }

        public override void Prepare(SqlConnection connection)
        {
            command.CommandText = "EXEC list_products_by_category @categoryid";

            SqlParameter categoryidParam = new SqlParameter("@categoryid", SqlDbType.Int);
            categoryidParam.Value = categoryid;

            command.Parameters.Add(categoryidParam);

            command.Connection = connection;

            command.Prepare();
        }
    }

    public class ListCategoryStatement : IPreparedStatement
    {
        public override void Prepare(SqlConnection connection)
        {
            command.CommandText = "EXEC list_all_categories";

            command.Connection = connection;

            command.Prepare();
        }
    }
}
