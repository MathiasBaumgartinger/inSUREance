using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inSUREance.Classes
{
    class InsuranceType
    {
        public string Name;
        public InsuranceType(string insurType)
        {
            this.Name = insurType;
        }

        public class InsurTypeManager
        {
            public static List<InsuranceType> GetTypes()
            {
                // TODO: Database stuff
                List<InsuranceType> insuranceTypes = new List<InsuranceType>();

                insuranceTypes.Add(new InsuranceType("typeA"));
                insuranceTypes.Add(new InsuranceType("typeB"));
                insuranceTypes.Add(new InsuranceType("typeC"));
                insuranceTypes.Add(new InsuranceType("typeD"));

                return insuranceTypes;
            }
        }
    }
}
