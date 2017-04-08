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
            //Get only MySimpleAttribute attributes for this module.
            attributes = myModule.GetCustomAttributes(
                myModule.GetType("ReflectionModule_Examples.MySimpleAttribute", false, false),
                true);
            foreach(Object o in attributes)
            {
                Console.WriteLine("Found this attribute on myModule: {0}", o.ToString());
            }
        }
    }

    // Define a very simple custom attribute
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
