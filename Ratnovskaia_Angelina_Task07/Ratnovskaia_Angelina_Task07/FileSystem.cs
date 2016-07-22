using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ratnovskaia_Angelina_Task07 
{
   public class FileSystem : IVirtualFileSystem
    {

        internal static Catalog root = new Catalog("root");

        private bool IsValidName (string name, List<FileSystemItem> list)
        {
            return !list.Any(element => element.Name == name);
        }


        public File CreateFile(string name, string path)
        {
            Catalog folder = (Catalog)GetItemByPath(path);
            if (IsValidName(name, folder.List))
            {
                var newFile = new File(name) { Parent = folder };
                folder.List.Add(newFile);
                return newFile;
            }
            else throw new Exception();
        }

        internal FileSystemItem GetItemByPath(string path)
        {
            if (path == "root")
            {
                return root;
            }
            path = path.Replace("root/", "");
            var arr = path.Split('/').ToList();
            Catalog current = root;
            do
            { 
                FileSystemItem folder = current.List.Find(element => element.Name == arr[0]);
                if(folder.GetType() == typeof(File) && folder.GetType() != typeof(Catalog)) return folder;
                else
                current = (Catalog)folder;
                arr.RemoveAt(0);
            }

            while (arr.Count > 0);
            return current;           
        }

        
        public Catalog CreateCatalog(string name, string path)
        {
            Catalog folder = (Catalog)GetItemByPath(path);
            if (IsValidName(name, folder.List))
            {
                var newCatalog = new Catalog(name) { Parent = folder };
                folder.List.Add(newCatalog);
                return newCatalog;
            }
            else throw new Exception();           
        }

        public void Remove(string path)
        {
            FileSystemItem item = GetItemByPath(path);
            item.Parent.List.Remove(item);
            item.Parent = null;
        }

        public FileSystemItem Copy(string itemPath, string receiverPath)
        {
            Catalog receiver = (Catalog)GetItemByPath(receiverPath);
            FileSystemItem file = GetItemByPath(itemPath);
            var fileCopy = file.DeepCopy();
            if (receiver == file.Parent)
            {
                file.Name += "_copy";
            }
            if (IsValidName(file.Name, receiver.List))
            {
                receiver.List.Add(fileCopy);
                fileCopy.Parent = receiver;
                return fileCopy;
            }

            else throw new Exception();
        }

        public void Move(string itemPath, string receiverPath)
        {           
            Copy(itemPath, receiverPath);
            Remove(itemPath);
        }

       public void Rename(string newName, string path)
        {
            FileSystemItem item = GetItemByPath(path);
            if (IsValidName(newName, item.Parent.List))
            {
                item.Name = newName;
            }
            else throw new Exception();           
        }
        public List<FileSystemItem> GetAllItemsByPath(string path)
        {
            var folder = (Catalog)GetItemByPath(path);
            return folder.List;
        }



    }
}
