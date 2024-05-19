using System;
using System.Reflection;
using System.Resources;

namespace ca1810
{
    //<snippet1>
    public class StaticConstructor
    {
        static int someInteger;
        static string? resourceString;

        static StaticConstructor()
        {
            someInteger = 3;
            ResourceManager stringManager =
               new ResourceManager("strings", Assembly.GetExecutingAssembly());
            resourceString = stringManager.GetString("string");
        }

        public void Print()
        {
            Console.WriteLine(someInteger);
        }
    }

    public class NoStaticConstructor
    {
        static int someInteger = 3;
        static string? resourceString = InitializeResourceString();

        static string? InitializeResourceString()
        {
            ResourceManager stringManager =
               new ResourceManager("strings", Assembly.GetExecutingAssembly());
            return stringManager.GetString("string");
        }

        public void Print()
        {
            Console.WriteLine(someInteger);
        }
    }
    //</snippet1>
}
