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

        Console.WriteLine(
            processClass.GetText(
            TextFormat.Mof));
    }
}
//</Snippet1>