using System.Collections.Generic;
using System.Linq;

namespace Ratnovskaia_Angelina_Task07 
{
   public class FileSystem : IVirtualFileSystem
    {

        internal static Catalog Root = new Catalog("root");

        private static bool IsValidName (string name, List<FileSystemItem> list)
        {
            return list.All(element => element.Name != name);
        }

        public bool CreateFile(string name, string path)
        {
            var folder = (Catalog)GetItemByPath(path);
            if (!IsValidName(name, folder.List)) return false;
            var newFile = new File(name) { Parent = folder };
            folder.List.Add(newFile);
            return true;
        }

        private static FileSystemItem GetItemByPath(string path)
        {
            if (path == "root")
            {
                return Root;
            }
            path = path.Replace("root/", "");
            var arr = path.Split('/').ToList();
            var current = Root;
            do
            { 
                var folder = current.List.Find(element => element.Name == arr[0]);
                if(folder.GetType() == typeof(File) && folder.GetType() != typeof(Catalog)) return folder;
                current = (Catalog)folder;
                arr.RemoveAt(0);
            }

            while (arr.Count > 0);
            return current;           
        }

        
        public bool CreateCatalog(string name, string path)
        {
            var folder = (Catalog)GetItemByPath(path);
            if (!IsValidName(name, folder.List)) return false;
            var newCatalog = new Catalog(name) { Parent = folder };
            folder.List.Add(newCatalog);
            return true;
        }

        public bool Remove(string path)
        {
            var item = GetItemByPath(path);
            if (!item.Parent.List.Contains(item)) return false;
            item.Parent.List.Remove(item);
            item.Parent = null;
            return true;
        }

        public bool Copy(string itemPath, string receiverPath)
        {
            var receiver = (Catalog)GetItemByPath(receiverPath);
            var file = GetItemByPath(itemPath);
            var fileCopy = file.DeepCopy();
            if (receiver == file.Parent)
            {
                file.Name += "_copy";
            }
            if (IsValidName(file.Name, receiver.List))
            {
                receiver.List.Add(fileCopy);
                fileCopy.Parent = receiver;
                return true;
            }

            return false;
        }

        public bool Move(string itemPath, string receiverPath)
        {
            return Copy(itemPath, receiverPath) && Remove(itemPath);
        }

       public bool Rename(string newName, string path)
        {
            var item = GetItemByPath(path);
           if (!IsValidName(newName, item.Parent.List)) return false;
           item.Name = newName;
           return true;
        }
        public List<FileSystemItem> GetAllItemsByPath(string path)
        {
            var folder = (Catalog)GetItemByPath(path);
            return folder.List;
        }



    }
}
