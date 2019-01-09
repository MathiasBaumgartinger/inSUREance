using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inSUREance.db
{
    class CreateFragenStatement : IPreparedStatement
    {
        //create_frage_user @fk_id_users INT, @frage VARCHAR(30)

        private readonly string frage;
        private readonly Int32 user_id;

        public CreateFragenStatement(string frage, int user_id)
        {
            this.frage = frage;
            this.user_id = user_id;
        }

        public override void Prepare(SqlConnection connection)
        {
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;

            command.CommandText = "create_frage_user";

            SqlParameter userIDParam = new SqlParameter("@fk_id_users", SqlDbType.Int);
            userIDParam.Value = user_id;
            SqlParameter questionParam = new SqlParameter("@frage", SqlDbType.VarChar, 30);
            questionParam.Value = user_id;

            command.Parameters.Add(userIDParam);
            command.Parameters.Add(questionParam);

            command.Prepare();
        }
    }
}
