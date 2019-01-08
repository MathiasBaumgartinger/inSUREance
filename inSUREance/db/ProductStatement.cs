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
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;

            command.CommandText = "list_products_by_category";

            SqlParameter categoryidParam = new SqlParameter("@category_id", SqlDbType.Int);
            categoryidParam.Value = categoryid;

            command.Parameters.Add(categoryidParam);

            command.Prepare();
        }
    }

    public class ListCategoryStatement : IPreparedStatement
    {
        public override void Prepare(SqlConnection connection)
        {
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;

            command.CommandText = "list_all_categories";

            command.Prepare();
        }
    }
}
