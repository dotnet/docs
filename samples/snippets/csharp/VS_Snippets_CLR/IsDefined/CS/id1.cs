//<Snippet1>
using System;
using System.Reflection;

// Add an AssemblyDescription attribute
[assembly: AssemblyDescription("A sample description")]
namespace IsDef1CS
{
    public class DemoClass
    {
        static void Main(string[] args)
        {
            // Get the class type to access its metadata.
            Type clsType = typeof(DemoClass);
            // Get the assembly object.
            Assembly assy = clsType.Assembly;
            // Store the assembly's name.
            String assyName = assy.GetName().Name;
            // See if the Assembly Description is defined.
            bool isdef = Attribute.IsDefined(assy, 
                typeof(AssemblyDescriptionAttribute));
            if (isdef)
            {
                // Affirm that the attribute is defined.
                Console.WriteLine("The AssemblyDescription attribute " +
                    "is defined for assembly {0}.", assyName);
                // Get the description attribute itself.
                AssemblyDescriptionAttribute adAttr = 
                    (AssemblyDescriptionAttribute)Attribute.GetCustomAttribute(
                    assy, typeof(AssemblyDescriptionAttribute));
                // Display the description.
                if (adAttr != null)
                    Console.WriteLine("The description is \"{0}\".", 
                        adAttr.Description);
                else
                    Console.WriteLine("The description could not " +
                        "be retrieved.");            
            }
            else
                Console.WriteLine("The AssemblyDescription attribute is not " +
                    "defined for assembly {0}.", assyName);
        }
    }
}

/*
 * Output:
 * The AssemblyDescription attribute is defined for assembly IsDef1CS.
 * The description is "A sample description".
 */
//</Snippet1>
