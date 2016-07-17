using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ratnovskaia_Angelina_Task07
{
   public class Catalog : File, IVirtualFileSystem
    {
       public Catalog(string name) : base(name) { List = new List<File>(); }


        public List<File> List { get; set; }
       

       public File CreateFile(string name)
       {
           var file = new File(name) { Parent = this };
           List.Add(file);
           return file;
       }
       public Catalog CreateCatalog(string name)
       {
           var newCatalog = new Catalog(name) { Parent = this };
           List.Add(newCatalog);
           return newCatalog;
       }

       public string GetParent()
       {
           return Parent == null ? "" : Parent.Name;
       }

       public void RemoveFile(string name)
       {
           var remove = List.Find(file => file.Name == name);
           List.Remove(remove);
           remove.Parent = null;
       }

       public void Copy(File file, Catalog reciever)
       {
            if(file.GetType() == typeof(File))
           reciever.CreateFile(file.Name);
            if(file.GetType() == typeof(Catalog))
                reciever.CreateCatalog(file.Name);


        }

       public string GetPath()
       {
            List<string> path = new List<string>();
           File c = this;
           while (c != null)
           {
               path.Add(c.Name);
              c = c.Parent;
           }

           path.Reverse();
           return string.Join("/", path);
       }


       public override string ToString()
       {
           return Name;
       }

       public string GetCatalogs()
       {
           string c = "";
           foreach (File catalog in List )
           {
               c += catalog.Name + " ";
           }

           return c != "" ? c : "empty";
       }


    }
}
