// <snippet1>
using System;
using System.Reflection;
//Define a module-level attribute.
[module: ReflectionModule_Examples.MySimpleAttribute("module-level")]
namespace ReflectionModule_Examples
{
    class MyMainClass
    {
        static void Main()
        {
            Module[] moduleArray;
            moduleArray = typeof(MyMainClass).Assembly.GetModules(false);
            // In a simple project with only one module, the module at index
            // 0 will be the module containing these classes.
            Module myModule = moduleArray[0];
            object[] attributes;
            attributes = myModule.GetCustomAttributes(true);
            foreach(Object o in attributes)
            {
                Console.WriteLine("Found this attribute on myModule: {0}.", o.ToString());
            }
        }
    }
    //A very simple custom attribute.
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Module)]
    public class MySimpleAttribute : Attribute
    {
        private string name;

        public MySimpleAttribute(string newName)
        {
            name = newName;
        }
    }
}
// </snippet1>
