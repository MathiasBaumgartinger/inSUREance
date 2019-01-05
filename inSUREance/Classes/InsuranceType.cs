using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using inSUREance.db;

namespace inSUREance.Classes
{
    class InsuranceType
    {
        public int id { get; }
        public string category { get; }

        public InsuranceType(int id, string category)
        {
            this.id = id;
            this.category = category;
        }

        public static class InsurTypeManager
        {
            public static List<InsuranceType> GetTypes()
            {
                List<InsuranceType> insuranceTypes = new List<InsuranceType>();

                using (var connection = new InsuranceDataBaseAccess(GlobalVariables.DATABASE.SERVERNAME,
                    GlobalVariables.DATABASE.USERNAME, GlobalVariables.DATABASE.PASSWORD))
                {
                    if (connection.Open())
                    {
                        ListCategoryStatement stmt = new ListCategoryStatement();
                        stmt.Prepare();

                        using (var reader = connection.ExecutePreparedStatementReader(stmt))
                        {
                            if (reader != null && reader.HasRows)
                            {
                                int id;
                                string category;

                                while (reader.Read())
                                {
                                    id = reader.GetInt32(0);
                                    category = reader.GetString(1);

                                    insuranceTypes.Add(new InsuranceType(id, category));
                                }
                            }
                        }
                    }
                }

                return insuranceTypes;
            }
        }
    }
}
