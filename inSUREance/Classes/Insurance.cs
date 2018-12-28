using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inSUREance.Classes
{
    public class Insurance
    {
        public String Name;
        public String Logo;
        public String Description;
        public DateTime RunTime;
        public String stringRunTime;
        public String Provider;
        public float Price; // Price per year
        public String stringPrice;
        public String PricePerMonth;
        public String InsuranceType;

        public Insurance(String name, String description, DateTime runTime, String provider, float price, String insuranceType)
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
            this.InsuranceType = insuranceType;
        }

        public class InsuranceManager
        {

            private List<Insurance> insurances = new List<Insurance>();
            
            public InsuranceManager()
            {
                // TODO: load Insurances dynamically from database 
                insurances.Add(new Insurance("test2", "desc2", new DateTime(2018, 1, 1), "generali", 1.99f, "typeA"));
                insurances.Add(new Insurance("test3",
                            "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet."
                            , new DateTime(2018, 1, 1), "donau", 2.99f, "typeA"));
                insurances.Add(new Insurance("test4", "desc4", new DateTime(2018, 1, 1), "oberoesterreichische", 2.99f, "typeB"));
                insurances.Add(new Insurance("test5", "desc4", new DateTime(2018, 1, 1), "zurich", 2.99f, "typeA"));
                insurances.Add(new Insurance("test2", "desc2", new DateTime(2018, 1, 1), "generali", 1.99f, "typeB"));
                insurances.Add(new Insurance("test3", "desc3", new DateTime(2018, 1, 1), "donau", 2.99f, "typeA"));
                insurances.Add(new Insurance("test4", "desc4", new DateTime(2018, 1, 1), "oberoesterreichische", 2.99f, "typeA"));
                insurances.Add(new Insurance("test5", "desc4", new DateTime(2018, 1, 1), "zurich", 2.99f, "typeA"));
                insurances.Add(new Insurance("test2", "desc2", new DateTime(2018, 1, 1), "generali", 1.99f, "typeA"));
                insurances.Add(new Insurance("test3", "desc3", new DateTime(2018, 1, 1), "donau", 2.99f, "typeA"));
                insurances.Add(new Insurance("test4", "desc4", new DateTime(2018, 1, 1), "oberoesterreichische", 2.99f, "typeA"));
                insurances.Add(new Insurance("test5", "desc4", new DateTime(2018, 1, 1), "zurich", 2.99f, "typeC"));
            }

            public List<Insurance> GetInsurances()
            {
                return insurances;
            }

            public List<Insurance> GetInsurances(string type)
            {
                List<Insurance> OnlyOfType = new List<Insurance>();
                foreach(Insurance insur in insurances)
                {
                    if(insur.InsuranceType == type)
                    {
                        OnlyOfType.Add(insur);
                    }
                }

                return OnlyOfType;
            }
        }
    } 
}

