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
            command.CommandType = CommandType.StoredProcedure;

            command.CommandText = "update_user";

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
        private readonly string username;
        private readonly string password;

        public LoginUserStatement(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public override void Prepare(SqlConnection connection)
        {
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;

            command.CommandText = "check_user_login";

            SqlParameter usernameParam = new SqlParameter("@user_name", SqlDbType.VarChar, 30);
            usernameParam.Value = username;
            SqlParameter passwordParam = new SqlParameter("@password", SqlDbType.VarChar, 30);
            passwordParam.Value = password;

            command.Parameters.Add(usernameParam);
            command.Parameters.Add(passwordParam);

            command.Prepare();
        }
    }

    public class CreateUserStatement : IPreparedStatement
    {
        private readonly string username;
        private readonly string password;
        private readonly DateTime birthday;
        private readonly string residence;

        public CreateUserStatement(string username, string password, DateTime birthday, string residence)
        {
            this.username = username;
            this.password = password;
            this.birthday = birthday;
            this.residence = residence;
        }
        public override void Prepare(SqlConnection connection)
        {
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;

            command.CommandText = "create_user";

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
}
