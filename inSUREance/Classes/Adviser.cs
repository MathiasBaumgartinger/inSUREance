using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace inSUREance.Classes
{
    public class Adviser
    {
        public string Name;
        public string Picture;
        public Adviser(string name)
        {
            this.Name = name;
            this.Picture = Directory.GetCurrentDirectory() + "\\Assets\\Pictures\\" + Name + ".jpg";
        }

        public class AdviserManager
        {
            public static List<Adviser> GetTypes()
            {
                List<Adviser> advisers = new List<Adviser>();

                // TODO: Database stuff
                advisers.Add(new Adviser("Hubert Goisern"));
                advisers.Add(new Adviser("Andreas Gabeldieyeah"));
                advisers.Add(new Adviser("Austrosepp hans"));
                advisers.Add(new Adviser("Wiener Slanggang"));

                return advisers;
            }
        }
    }
}
