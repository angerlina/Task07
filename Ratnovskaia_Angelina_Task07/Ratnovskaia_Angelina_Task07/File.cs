using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ratnovskaia_Angelina_Task07
{
    public class File : FileSystemItem
    {
        public File(string name) : base(name) { }

        public override FileSystemItem DeepCopy()
        {
            File other = (File)this.MemberwiseClone();
            other.Name = String.Copy(Name);
            return other;
        }
        
    }
}
