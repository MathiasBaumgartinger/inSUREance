using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
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

        public override void Prepare()
        {
            command.CommandText = "EXEC add_rating_for_vendor @userid, @vendorid, @stars";

            SqlParameter useridParam = new SqlParameter("@userid", SqlDbType.Int);
            useridParam.Value = userid;

            SqlParameter vendoridParam = new SqlParameter("@vendorid", SqlDbType.Int);
            vendoridParam.Value = vendorid;

            SqlParameter starsParam = new SqlParameter("@stars", SqlDbType.Int);
            starsParam.Value = stars;

            command.Parameters.Add(useridParam);
            command.Parameters.Add(vendoridParam);
            command.Parameters.Add(starsParam);
        }
    }
}
