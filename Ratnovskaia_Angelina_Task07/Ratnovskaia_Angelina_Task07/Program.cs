using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ratnovskaia_Angelina_Task07
{
    class Program
    {
        static void Main(string[] args)
        {
            Catalog root = new Catalog("root");

            var catalog1 = root.CreateCatalog("cat1");
            
            var catalog2 = catalog1.CreateCatalog("cat2");

            var file = catalog2.CreateFile("file");

            var catalog3 = catalog2.CreateCatalog("cat3");

            var catalog4 = catalog3.CreateCatalog("cat4");

            //Console.WriteLine(catalog2.GetPath());
            Console.WriteLine(catalog2.GetCatalogs());
            catalog2.RemoveFile("cat3");
            Console.WriteLine(catalog2.GetCatalogs());
            var sss = catalog2.CreateCatalog("sss");
            catalog2.Copy(sss, catalog1);
            //Console.WriteLine(catalog1.GetCatalogs());
            //     var  catalog3 = catalog2.CreateCatalog("3");
            //     var file = catalog3.CreateFile("fd");
            //     Console.WriteLine(file.);

            Console.ReadKey();



        }
    }
}
