using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ratnovskaia_Angelina_Task07
{
    interface IVirtualFileSystem
    {
         Catalog CreateCatalog(string name, Catalog folder);
         File CreateFile(string name, Catalog folder);
         void Remove(FileSystemItem item);
         FileSystemItem Copy(FileSystemItem item, Catalog receiver);
         void Move(FileSystemItem item, Catalog receiver);




    }
}
