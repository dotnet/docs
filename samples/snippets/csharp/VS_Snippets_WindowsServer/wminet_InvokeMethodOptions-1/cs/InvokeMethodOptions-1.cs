//<Snippet1>
using System;
using System.Management;

// This sample demonstrates invoking 
// a WMI method using parameter objects
public class InvokeMethod 
{    
    public static void Main() 
    {

        // Get the object on which the method will be invoked
        ManagementClass processClass = 
            new ManagementClass("Win32_Process");

        // Get an input parameters object for this method
        ManagementBaseObject inParams =
            processClass.GetMethodParameters("Create");

        // Fill in input parameter values
        inParams["CommandLine"] = "calc.exe";

        // Method Options
        InvokeMethodOptions methodOptions = new 
            InvokeMethodOptions();
        methodOptions.Timeout = 
            System.TimeSpan.MaxValue;

        // Execute the method
        ManagementBaseObject outParams =
            processClass.InvokeMethod("Create",
            inParams, methodOptions);

        // Display results
        // Note: The return code of the method is
        // provided in the "returnValue" property
        // of the outParams object
        Console.WriteLine(
            "Creation of calculator process returned: "
            + outParams["returnValue"]);
        Console.WriteLine("Process ID: " 
            + outParams["processId"]);
    }
}
//</Snippet1>