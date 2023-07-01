using dnlib.DotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotatoObf
{
    public class renamer:Potato
    {
        public override void initalize(ModuleDefMD module)
        {
            foreach(var type in module.Types)
            {
                module.Name = "°º¤ø,¸¸,ø¤º°`°º¤ø,¸,ø |  Waves  |,¸,ø¤ø,¸¸,ø¤º°`°º¤";

                type.Namespace = "Sword -> ()==[:::::::::::::>";
                type.Name = RandomString(15);

                foreach(var method in type.Methods)
                {
                    if(!method.IsRuntimeSpecialName && !method.DeclaringType.IsForwarder)
                    {
                        method.Name= RandomString(25);
                    }
                }

                foreach(var field in type.Fields)
                {
                    field.Name = RandomString(25);
                }

            }
        }

        private static string RandomString(int length)
        {
            var characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz123456789";
            var stringChars = new char[length];
            var random = new Random();

            for(int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = characters[random.Next(characters.Length)];
            }

            return new string(stringChars);
            
        }
    }
}
