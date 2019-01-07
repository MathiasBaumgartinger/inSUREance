using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using inSUREance.db;

namespace inSUREance.Classes
{
    public class Insurance
    {
        public String Name { get; }
        public String Logo { get; }
        public String Description { get; }
        public DateTime RunTime { get; }
        public String stringRunTime { get; }
        public String Provider { get; }
        public float Price { get; } // Price per year
        public String stringPrice { get; }
        public String PricePerMonth { get; }

        public Insurance(String name, String description, DateTime runTime, String provider, float price)
        {
            this.Name = name;
            this.Description = description;
            this.RunTime = runTime;
            this.stringRunTime = runTime.ToString();
            this.Provider = provider;
            this.Price = price;
            this.stringPrice = price.ToString();
            this.PricePerMonth = (price / 12).ToString();
            this.Logo = Directory.GetCurrentDirectory() + "\\Assets\\Logos\\" + provider + ".png";
        }

        public class InsuranceManager
        { 
            public List<Insurance> GetInsurances()
            {
                return GetInsurances(1);
            }

            public List<Insurance> GetInsurances(string category)
            {
                int type = 1;

                List<InsuranceType> types = InsuranceType.InsurTypeManager.GetTypes();

                foreach(InsuranceType t in types)
                {
                    if (t.category == category)
                    {
                        type = t.id;
                        break;
                    }
                }

                return GetInsurances(type);
            }

            public List<Insurance> GetInsurances(int type)
            {
                List<Insurance> insurances = new List<Insurance>();

                using (var db = new InsuranceDataBaseAccess(GlobalVariables.DATABASE.SERVERNAME, GlobalVariables.DATABASE.USERNAME, GlobalVariables.DATABASE.PASSWORD))
                {
                    if (db.Open())
                    {
                        ListProductStatement stmt = new ListProductStatement(type);
                        stmt.Prepare(db.connection);

                        using (var reader = db.ExecutePreparedStatementReader(stmt))
                        {
                            if (reader != null && reader.HasRows)
                            {
                                SqlParser parser = new SqlParser();
                                insurances = parser.ReadFromReader(reader);
                            }
                        }
                    }
                }

                return insurances;
            }
        }

        private sealed class SqlParser
        {
            public List<Insurance> ReadFromReader(SqlDataReader reader)
            {
                List<Insurance> res = new List<Insurance>();

                if (reader == null || !reader.HasRows) return res;

                string category, description, vendorname, address;
                float price;
                int duration;

                while (reader.Read())
                {
                    category = reader.GetString(0);
                    description = reader.GetString(1);
                    price = (float) reader.GetDecimal(2);
                    duration = (int) reader.GetDecimal(3);
                    vendorname = reader.GetString(4);
                    address = reader.GetString(5);

                    res.Add(new Insurance(category, description, DateTime.UtcNow.AddMonths(duration) , vendorname, price));
                }

                return res;
            }
        }
    } 
}

