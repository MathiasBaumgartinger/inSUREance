﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inSUREance.db
{
    public class ProductStatements : IPreparedStatement
    {
        private int categoryid;

        public ProductStatements(int categoryid)
        {
            this.categoryid = categoryid;
        }

        public override void Prepare()
        {
            command.CommandText = "EXEC list_products_by_category @categoryid";

            SqlParameter categoryidParam = new SqlParameter("@categoryid", SqlDbType.Int);
            categoryidParam.Value = categoryid;

            command.Parameters.Add(categoryidParam);
        }
    }

    public class ListCategoryStatement : IPreparedStatement
    {
        public override void Prepare()
        {
            command.CommandText = "SELECT * FROM PRODUKT_KATEGORIE";
        }
    }
}
