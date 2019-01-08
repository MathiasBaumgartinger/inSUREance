using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.Security.Authentication.OnlineId;

namespace inSUREance.db
{
    public class VendorRatingStatement : IPreparedStatement
    {
        private readonly int userid;
        private readonly int vendorid;
        private readonly int stars;

        public VendorRatingStatement(int userid, int vendorid, int stars)
        {
            this.userid = userid;
            this.vendorid = vendorid;
            this.stars = stars;
        }

        public override void Prepare(SqlConnection connection)
        {
            command.CommandText = "add_rating_for_vendor";

            SqlParameter useridParam = new SqlParameter("@user_id", SqlDbType.Int);
            useridParam.Value = userid;

            SqlParameter vendoridParam = new SqlParameter("@vendor_id", SqlDbType.Int);
            vendoridParam.Value = vendorid;

            SqlParameter starsParam = new SqlParameter("@stars", SqlDbType.Int);
            starsParam.Value = stars;

            command.Parameters.Add(useridParam);
            command.Parameters.Add(vendoridParam);
            command.Parameters.Add(starsParam);

            command.Connection = connection;
            
            command.Prepare();
        }
    }
}
