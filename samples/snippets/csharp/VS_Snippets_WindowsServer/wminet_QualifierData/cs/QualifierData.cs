//<Snippet1>
using System;
using System.Management;

public class Sample 
{    
    public static void Main() 
    {
        // Get the WMI class
        ManagementClass mClass = 
            new ManagementClass("Win32_Service");

        mClass.Options.UseAmendedQualifiers = true;

        // Get the Qualifiers for the class
        QualifierDataCollection qualifiers =
            mClass.Qualifiers;

        // display the Qualifier names
        Console.WriteLine(mClass.ClassPath.ClassName +
            " Qualifiers: ");
        foreach (QualifierData q in qualifiers)
        {
            Console.WriteLine(q.Name);
        }
        Console.WriteLine();
        
        Console.WriteLine("Class Description: ");
        Console.WriteLine(
            mClass.Qualifiers["Description"].Value);
    }
}
//</Snippet1>