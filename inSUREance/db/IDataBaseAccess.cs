using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inSUREance.db
{
    interface IDataBaseAccess
    {
        bool Open();
        bool Close();
    }
}
