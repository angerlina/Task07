using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ratnovskaia_Angelina_Task07
{
    interface IVirtualFileSystem
    {
         Catalog CreateCatalog(string name);
         File CreateFile(string name);
            

        
    }
}
