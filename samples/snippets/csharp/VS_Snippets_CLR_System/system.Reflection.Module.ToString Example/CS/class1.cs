//<snippet1>
using System;
using System.Reflection;

namespace ReflectionModule_Examples
{
    class MyMainClass
    {
        static void Main()
        {
            Module[] moduleArray;
            
            moduleArray = typeof(MyMainClass).Assembly.GetModules(false);
            
            //In a simple project with only one module, the module at index
            // 0 will be the module containing this class.
            Module myModule = moduleArray[0];

            Console.WriteLine("myModule.ToString returns: {0}", myModule.ToString());
        }
    }
}
//</snippet1>
