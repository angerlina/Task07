using System.Collections.Generic;

namespace Ratnovskaia_Angelina_Task07
{
    interface IVirtualFileSystem
    {
         bool CreateCatalog(string name, string path);
         bool CreateFile(string name, string path);
         bool Remove(string path);
         bool Copy(string itemPath, string receiverPath);
         bool Move(string itemPath, string receiverPath);
         bool Rename(string newName, string path);
         List<FileSystemItem> GetAllItemsByPath(string path);





    }
}
