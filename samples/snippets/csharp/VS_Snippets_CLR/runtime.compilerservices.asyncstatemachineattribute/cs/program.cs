//<snippet1>
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace ConsoleApplication1
{

    // This class is used by the code below to discover method attributes.
    public class TheClass
    {
        public async Task<int> AsyncMethod()
        {
            await Task.Delay(5);
            return 1;
        }

        public int RegularMethod()
        {
            return 0;
        }
    }

    class Program
    {
        private static bool IsAsyncMethod(Type classType, string methodName)
        {
            // Obtain the method with the specified name.
            MethodInfo method = classType.GetMethod(methodName);

            Type attType = typeof(AsyncStateMachineAttribute);

            // Obtain the custom attribute for the method.
            // The value returned contains the StateMachineType property.
            // Null is returned if the attribute isn't present for the method.
            var attrib = (AsyncStateMachineAttribute)method.GetCustomAttribute(attType);

            return (attrib != null);
        }

        private static void ShowResult(Type classType, string methodName)
        {
            Console.Write((methodName + ": ").PadRight(16));

            if (IsAsyncMethod(classType, methodName))
                Console.WriteLine("Async method");
            else
                Console.WriteLine("Regular method");
        }

        static void Main(string[] args)
        {
            ShowResult(classType: typeof(TheClass), methodName: "AsyncMethod");
            ShowResult(classType: typeof(TheClass), methodName: "RegularMethod");

            // Note: The IteratorStateMachineAttribute applies to Visual Basic methods
            // but not C# methods.

            Console.ReadKey();
        }

        // Output:
        //   AsyncMethod:    Async method
        //   RegularMethod:  Regular method
    }
}

//</snippet1>