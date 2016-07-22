using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ratnovskaia_Angelina_Task07
{
   public class Catalog : FileSystemItem
    {
       public Catalog(string name) : base(name) { List = new List<FileSystemItem>(); }


        public List<FileSystemItem> List { get; set; }


        public override FileSystemItem DeepCopy()
        {
            Catalog other = (Catalog)this.MemberwiseClone();
            other.Name = String.Copy(Name);
            
            other.List = new List<FileSystemItem>(this.List);

            return other;
        }


    }
}
