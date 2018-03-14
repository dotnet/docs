// <Snippet2>
using System;
using System.Reflection;
using System.ComponentModel;

// Assign some attributes to the module.
[module:Description("A sample description")]

// Set the module's CLSCompliant attribute to false
// The CLSCompliant attribute is applicable for /target:module.
[module:CLSCompliant(false)]

namespace CustAttrs2CS {
    class DemoClass {
        static void Main(string[] args) {
            Type clsType = typeof(DemoClass);
            // Get the Module type to access its metadata.
            Module module = clsType.Module;

            // Iterate through all the attributes for the module.
            foreach(Attribute attr in Attribute.GetCustomAttributes(module)) {
                // Check for the Description attribute.
                if (attr.GetType() == typeof(DescriptionAttribute))
                    Console.WriteLine("Module {0} has the description " +
                        "\"{1}\".", module.Name, 
                        ((DescriptionAttribute)attr).Description);
                // Check for the CLSCompliant attribute.
                else if (attr.GetType() == typeof(CLSCompliantAttribute))
                    Console.WriteLine("Module {0} {1} CLSCompliant.",
                        module.Name,
                        ((CLSCompliantAttribute)attr).IsCompliant ? 
                            "is" : "is not");
            }
        }
    }
}

/*
 * Output:
 * Module CustAttrs2CS.exe is not CLSCompliant.
 * Module CustAttrs2CS.exe has the description "A sample description".
 */
// </Snippet2>
