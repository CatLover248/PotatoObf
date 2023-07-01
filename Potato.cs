using dnlib.DotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotatoObf
{
    public abstract class Potato
    {
        public abstract void initalize(ModuleDefMD module);

        public static void init()
        {
            Console.WriteLine("PotatoObf");
            Console.WriteLine("A simple multi-platform obfuscator/renamer");
            Console.WriteLine("Thank you to Tasky/bofffa for the help");
            Console.WriteLine("Developed by Taskmgr.lol team!");
            Console.Write("Enter Executable: ");
            string path = Console.ReadLine();
            if (path == null)
            {
                throw new Exception("Path was null");    
            }
            var module = ModuleDefMD.Load(path);

            var features = new List<Potato>
            {
                new renamer()
            };

            foreach( var f in features)
            {
                f.initalize(module);
            }

            module.Write(path.Remove(path.Length - 4) + "-opt.exe");

        }
    }
}
