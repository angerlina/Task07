using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ratnovskaia_Angelina_Task07
{
  public abstract class FileSystemItem
    {
        public FileSystemItem(string name)
        {
            Name = name;

        }

        public abstract FileSystemItem DeepCopy();
        public string Name { get; set; }
        public Catalog Parent { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
