//<Snippet2>
using System;
using System.Diagnostics;

// Add the Debuggable attribute to the module.
[module:Debuggable(true, false)]
namespace IsDef2CS
{
    public class DemoClass
    {
        static void Main(string[] args)
        {
            // Get the class type to access its metadata.
            Type clsType = typeof(DemoClass);
            // See if the Debuggable attribute is defined for this module.
            bool isDef = Attribute.IsDefined(clsType.Module, 
                typeof(DebuggableAttribute));
            // Display the result.
            Console.WriteLine("The Debuggable attribute {0} " +
                "defined for Module {1}.",
                isDef ? "is" : "is not",
                clsType.Module.Name);
            // If the attribute is defined, display the JIT settings.
            if (isDef)
            {
                // Retrieve the attribute itself.
                DebuggableAttribute dbgAttr = (DebuggableAttribute)
                    Attribute.GetCustomAttribute(clsType.Module, 
                    typeof(DebuggableAttribute));
                if (dbgAttr != null)
                {
                    Console.WriteLine("JITTrackingEnabled is {0}.",
                        dbgAttr.IsJITTrackingEnabled);
                    Console.WriteLine("JITOptimizerDisabled is {0}.",
                        dbgAttr.IsJITOptimizerDisabled);
                }
                else
                    Console.WriteLine("The Debuggable attribute " +
                        "could not be retrieved.");
            }
        }
    }
}

/*
 * Output:
 * The Debuggable attribute is defined for Module IsDef2CS.exe.
 * JITTrackingEnabled is True.
 * JITOptimizerDisabled is False.
 */
//</Snippet2>
