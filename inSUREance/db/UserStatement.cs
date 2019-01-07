using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inSUREance.db
{
    public class UpdateUserStatement : IPreparedStatement
    {
        private readonly string username;
        private readonly string password;
        private readonly DateTime birthday;
        private readonly string residence;

        public UpdateUserStatement(string username, string password, DateTime birthday, string residence)
        {
            this.username = username;
            this.password = password;
            this.birthday = birthday;
            this.residence = residence;
        }

        public override void Prepare(SqlConnection connection)
        {
            command.Connection = connection;

            command.CommandText = "EXEC update_user @user_name, @password, @birthday, @wohnort, @is_admin, @is_berater";

            SqlParameter usernameParam = new SqlParameter("@user_name", SqlDbType.VarChar, 30);
            usernameParam.Value = username;
            SqlParameter passwordParam = new SqlParameter("@password", SqlDbType.VarChar, 30);
            passwordParam.Value = password;
            SqlParameter birthdayParam = new SqlParameter("@birthday", SqlDbType.Date);
            birthdayParam.Value = birthday.Date.ToString("yyyy-M-d");
            SqlParameter residenceParam = new SqlParameter("@wohnort", SqlDbType.VarChar, 50);
            residenceParam.Value = residence;
            SqlParameter adminParam = new SqlParameter("@is_admin", SqlDbType.Bit);
            adminParam.Value = 0;
            SqlParameter consultantParam = new SqlParameter("@is_berater", SqlDbType.Bit);
            consultantParam.Value = 0;

            command.Parameters.Add(usernameParam);
            command.Parameters.Add(passwordParam);
            command.Parameters.Add(birthdayParam);
            command.Parameters.Add(residenceParam);
            command.Parameters.Add(adminParam);
            command.Parameters.Add(consultantParam);

            command.Prepare();
        }
    }

    public class LoginUserStatement : IPreparedStatement
    {
        public override void Prepare(SqlConnection connection)
        {
            
        }
    }
}
