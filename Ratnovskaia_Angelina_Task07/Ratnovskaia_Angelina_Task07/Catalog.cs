using System.Collections.Generic;

namespace Ratnovskaia_Angelina_Task07
{
   public class Catalog : FileSystemItem
    {
       public Catalog(string name) : base(name) { List = new List<FileSystemItem>(); }

        public List<FileSystemItem> List { get; set; }

        public override FileSystemItem DeepCopy()
        {
            var other = (Catalog)MemberwiseClone();
            other.Name = string.Copy(Name);
            
            other.List = new List<FileSystemItem>(List);

            return other;
        }


    }
}
