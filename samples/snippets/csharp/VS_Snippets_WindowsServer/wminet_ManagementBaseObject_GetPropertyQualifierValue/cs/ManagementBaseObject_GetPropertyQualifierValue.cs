//<Snippet1>
using System;
using System.Management;

public class Sample 
{    
    public static void Main() 
    {

        // Get the WMI class
        ManagementClass processClass = 
            new ManagementClass("Win32_Process");
        processClass.Options.UseAmendedQualifiers = true;

        // Get the properties in the class
        PropertyDataCollection properties =
            processClass.Properties;

        // display the properties
        Console.WriteLine("Win32_Process Property Names: ");
        foreach (PropertyData property in properties)
        {
            Console.WriteLine(property.Name);

            foreach (QualifierData q in property.Qualifiers)
            {
                if(q.Name.Equals("Description"))
                {
                    Console.WriteLine(
                        processClass.GetPropertyQualifierValue(
                        property.Name, q.Name));
                }

            }
            Console.WriteLine();

        }
    }
}
//</Snippet1>