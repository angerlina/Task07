using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ratnovskaia_Angelina_Task07
{
    public class File
    {
        public File(string name)
        {
            Name = name;

        }

        public string Name { get; set; }
        public Catalog Parent { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
