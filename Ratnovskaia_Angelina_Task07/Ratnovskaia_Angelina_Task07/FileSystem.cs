using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ratnovskaia_Angelina_Task07 
{
   public class FileSystem : IVirtualFileSystem
    {
        public File CreateFile(string name, Catalog folder)
        {
            var file = new File(name) { Parent =  folder};
            folder.List.Add(file);
            return file;
        }

        public Catalog CreateCatalog(string name, Catalog folder)
        {
            var newCatalog = new Catalog(name) { Parent = folder };
            folder.List.Add(newCatalog);
            return newCatalog;
        }

        public void Remove(FileSystemItem item)
        {
            item.Parent.List.Remove(item);
            item.Parent = null;
        }

        public FileSystemItem Copy(FileSystemItem file, Catalog receiver)
        {
                var fileCopy = file.DeepCopy();
            if (receiver == file.Parent)
            {
                file.Name += "_copy";
            }
                receiver.List.Add(fileCopy);
                fileCopy.Parent = receiver;
                return fileCopy;
          
        }

        public void Move(FileSystemItem item, Catalog receiver)
        {
            Copy(item, receiver);
            Remove(item);
        }

    }
}
