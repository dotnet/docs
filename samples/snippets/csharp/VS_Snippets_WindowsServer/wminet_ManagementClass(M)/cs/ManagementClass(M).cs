//<Snippet1>
using System;
using System.Management;

public class Sample 
{    
    public static void Main() 
    {

        // Get the WMI class
        ManagementClass c = new ManagementClass(
            new ManagementPath("Win32_LogicalDisk"));

        // Get the methods in the class
        MethodDataCollection methods =
            c.Methods;

        // display the methods
        Console.WriteLine("Method Names: ");
        foreach (MethodData method in methods)
        {
            Console.WriteLine(method.Name);
        }
        Console.WriteLine();

        // Get the properties in the class
        PropertyDataCollection properties =
            c.Properties;

        // display the properties
        Console.WriteLine("Property Names: ");
        foreach (PropertyData property in properties)
        {
            Console.WriteLine(property.Name);
        }
        Console.WriteLine();

        // Get the Qualifiers in the class
        QualifierDataCollection qualifiers =
            c.Qualifiers;

        // display the qualifiers
        Console.WriteLine("Qualifier Names: ");
        foreach (QualifierData qualifier in qualifiers)
        {
            Console.WriteLine(qualifier.Name);
        }

    }
}
//</Snippet1>