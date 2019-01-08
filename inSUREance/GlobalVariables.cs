using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.SqlServer.Metadata.Internal;

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

        public static class DATABASE
        {
#if USR_MATTHIAS
            public static readonly string SERVERNAME = ".\\SQLEXPRESS02";
            public static readonly string DBNAME = "VersicherungsDB";
            public static readonly string USERNAME = "ricopc";
            public static readonly string PASSWORD = "Password123";
#elif USR_MATHIAS
            public static readonly string SERVERNAME = ".\\SQLEXPRESS01";
            public static readonly string DBNAME = "VersicherungsDB";
            public static readonly string USERNAME = "mathias";
            public static readonly string PASSWORD = "pfad1234";
#elif USR_DAVID
            public static readonly string SERVERNAME = ".\\SQLEXPRESS02";
            public static readonly string DBNAME = "VersicherungsDB";
            public static readonly string USERNAME = "ricopc";
            public static readonly string PASSWORD = "Password123";
#elif USR_AGNES
            public static readonly string SERVERNAME = ".\\SQLEXPRESS02";
            public static readonly string DBNAME = "VersicherungsDB";
            public static readonly string USERNAME = "ricopc";
            public static readonly string PASSWORD = "Password123";
#endif
        }
    }
}
