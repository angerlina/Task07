using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Ratnovskaia_Angelina_Task07
{
    class Program
    {
        static void Main(string[] args)
        {
            var driver = new FileSystem();

            string s = "";

            do
            {               
                s = Console.ReadLine().ToLower();
                string[] param = s.Split(' ');

                switch (param[0])
                {
                    case "md": driver.CreateCatalog(param[1], (param[2]));
                        break;

                    case "mf": driver.CreateFile(param[1], param[2]);
                        break;

                    case "remove": driver.Remove(param[1]);
                        break;

                    case "copy": driver.Copy(param[1], param[2]);
                        break;

                    case "move": driver.Move(param[1], param[2]);
                        break;

                    case "rename": driver.Rename(param[1], param[2]);
                        break;

                    case "show":

                        var itemList = driver.GetAllItemsByPath(param[1]);
                        var list = new List<string>();
                        foreach (var element in itemList)
                        {
                            list.Add(element.Name);
                        }
                        foreach (var element in list)
                        {
                            Console.WriteLine(element);
                        }
                        break;

                    default:
                        Console.WriteLine(("Некорректная команда!"));
                        break;
                }             
            }

            while (s != "exit");

            Console.ReadLine();


        }
    }
}
