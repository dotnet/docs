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

        // Get the methods in the class
        MethodDataCollection methods =
            processClass.Methods;

        // display the method names
        Console.WriteLine("Method Name: ");
        foreach (MethodData method in methods)
        {
            if(method.Name.Equals("Create"))
            {
                Console.WriteLine(method.Name);
                Console.WriteLine("Description: " +
                    method.Qualifiers["Description"].Value);
                Console.WriteLine();

                Console.WriteLine("In-parameters: ");
                foreach(PropertyData i in 
                    method.InParameters.Properties)
                {
                    Console.WriteLine(i.Name);
                }
                Console.WriteLine();

                Console.WriteLine("Out-parameters: ");
                foreach(PropertyData o in 
                    method.OutParameters.Properties)
                {
                    Console.WriteLine(o.Name);
                }
                Console.WriteLine();

                Console.WriteLine("Qualifiers: ");
                foreach(QualifierData q in 
                    method.Qualifiers)
                {
                    Console.WriteLine(q.Name);
                }
                Console.WriteLine();
  
            }
        } 
    }
}
//</Snippet1>