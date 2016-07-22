using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ratnovskaia_Angelina_Task07
{
    interface IVirtualFileSystem
    {
         Catalog CreateCatalog(string name, string path);
         File CreateFile(string name, string path);
         void Remove(string path);
         FileSystemItem Copy(string itemPath, string receiverPath);
         void Move(string itemPath, string receiverPath);
         void Rename(string newName, string path);
         List<FileSystemItem> GetAllItemsByPath(string path);





    }
}
