using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inSUREance
{
    class GlobalVariables
    {

        public static class User
        {
            private static string name;
            private static DateTime birthday;
            private static string address;

            public static string Name { get { return name; } set { name = value; } }
            public static DateTime Birthday { get { return birthday; } set { birthday = value; } }
            public static string Address { get { return address; } set { address = value; } }
        
            // TODO: make database stuff
        }
    }
}
