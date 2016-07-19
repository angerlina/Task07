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


        //public string GetParent()
        //{
        //    return Parent == null ? "" : Parent.Name;
        //}


        //public string GetPath()
        //{
        //     List<string> path = new List<string>();
        //    File c = this;
        //    while (c != null)
        //    {
        //        path.Add(c.Name);
        //       c = c.Parent;
        //    }

        //    path.Reverse();
        //    return string.Join("/", path);
        //}


        //public string GetCatalogs()
        //{
        //    string c = "";
        //    foreach (File catalog in List )
        //    {
        //        c += catalog.Name + " ";
        //    }

        //    return c != "" ? c : "empty";
        //}


    }
}
