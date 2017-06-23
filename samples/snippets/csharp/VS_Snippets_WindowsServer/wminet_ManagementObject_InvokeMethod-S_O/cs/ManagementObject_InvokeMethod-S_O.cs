//<Snippet1>
using System;
using System.Management;

// This sample demonstrates invoking
// a WMI method using an array of arguments.
public class InvokeMethod 
{    
    public static void Main() 
    {

        // Get the object on which the
        // method will be invoked
        ManagementClass processClass = 
            new ManagementClass("Win32_Process");

        // Create an array containing all
        // arguments for the method
        object[] methodArgs = 
            {"notepad.exe", null, null, 0};

        //Execute the method
        object result = 
            processClass.InvokeMethod(
            "Create", methodArgs);

        //Display results
        Console.WriteLine(
            "Creation of process returned: " + result);
        Console.WriteLine("Process id: " + methodArgs[3]);
    }

}
//</Snippet1>