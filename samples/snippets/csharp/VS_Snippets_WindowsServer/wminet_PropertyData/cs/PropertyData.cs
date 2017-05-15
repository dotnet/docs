//<Snippet1>
using System;
using System.Management;

public class Sample 
{    
    public static void Main() 
    {

        // Get the WMI class
        ManagementClass osClass = 
            new ManagementClass("Win32_OperatingSystem");

        osClass.Options.UseAmendedQualifiers = true;

        // Get the Properties in the class
        PropertyDataCollection properties =
            osClass.Properties;

        // display the Property names
        Console.WriteLine("Property Name: ");
        foreach (PropertyData property in properties)
        {
            Console.WriteLine(
                "---------------------------------------");
            Console.WriteLine(property.Name);
            Console.WriteLine("Description: " +
                property.Qualifiers["Description"].Value);
            Console.WriteLine();

            Console.WriteLine("Type: ");               
            Console.WriteLine(property.Type);

            Console.WriteLine();

            Console.WriteLine("Qualifiers: ");
            foreach(QualifierData q in 
                property.Qualifiers)
            {
                Console.WriteLine(q.Name);
            }
            Console.WriteLine();

            foreach (ManagementObject c in osClass.GetInstances())
            {
                Console.WriteLine("Value: ");
                Console.WriteLine(
                    c.Properties[property.Name.ToString()].Value);
        
                Console.WriteLine();
            }
        }    
    }
}
//</Snippet1>