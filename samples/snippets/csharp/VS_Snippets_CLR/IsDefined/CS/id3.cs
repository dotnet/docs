//<Snippet3>
using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace IsDef3CS 
{
    // Assign a Guid attribute to a class.
    [Guid("BF235B41-52D1-46cc-9C55-046793DB363F")]
    public class TestClass 
    {
    }

    public class DemoClass 
    {
        static void Main(string[] args) 
        {
            // Get the class type to access its metadata.
            Type clsType = typeof(TestClass);
            // See if the Guid attribute is defined for the class.
            bool isDef = Attribute.IsDefined(clsType, typeof(GuidAttribute));
            // Display the result.
            Console.WriteLine("The Guid attribute {0} defined for class {1}.",
                isDef ? "is" : "is not", clsType.Name);
            // If it's defined, display the GUID.
            if (isDef) 
            {
                GuidAttribute guidAttr = 
                    (GuidAttribute)Attribute.GetCustomAttribute(clsType, 
                        typeof(GuidAttribute));
                if (guidAttr != null)
                    Console.WriteLine("GUID: {" + guidAttr.Value + "}.");
                else
                    Console.WriteLine("The Guid attribute could " + 
                        "not be retrieved.");
            }
        }
    }
}

/*
 * Output:
 * The Guid attribute is defined for class TestClass.
 * GUID: {BF235B41-52D1-46cc-9C55-046793DB363F}.
 */
//</Snippet3>
