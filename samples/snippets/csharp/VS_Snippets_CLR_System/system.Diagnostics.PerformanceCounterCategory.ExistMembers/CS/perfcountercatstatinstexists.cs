//<snippet9>
using System;
using System.Diagnostics;
using Microsoft.VisualBasic;

class PerfCounterCatStatInstExistsMod
{

    //<Snippet10>
    public static void Main(string[] args)
    {
        string categoryName = "";
        string instanceName = "";
        string machineName = "";
        bool objectExists = false;
        const string SINGLE_INSTANCE_NAME = "systemdiagnosticsperfcounterlibsingleinstance";

        // Copy the supplied arguments into the local variables.
        try
        {
            categoryName = args[0];
            instanceName = args[1];
            machineName = args[2]=="."? "": args[2];
        }
        catch(Exception ex)
        {
            // Ignore the exception from non-supplied arguments.
        }

        // Use the given instance name or use the default single-instance name.
        if (instanceName.Length==0)
        {
            instanceName = SINGLE_INSTANCE_NAME;
        }

        try
        {
            // Check whether the specified instance exists.
            // Use the static forms of the InstanceExists method.
            if (machineName.Length==0)
            {
                objectExists = PerformanceCounterCategory.InstanceExists(instanceName, categoryName);
            }
            else
            {
                objectExists = PerformanceCounterCategory.InstanceExists(instanceName, categoryName, machineName);
            }

        }
        catch(Exception ex)
        {
            Console.WriteLine("Unable to check for the existence of " +
                "instance \"{0}\" in category \"{1}\" on " + 
                (machineName.Length>0? "computer \"{2}\":": "this computer:") + "\n" + 
                ex.Message, instanceName, categoryName, machineName);
            return;
        }

        // Tell the user whether the instance exists.
        Console.WriteLine("Instance \"{0}\" " + (objectExists? "exists": "does not exist") + 
            " in category \"{1}\" on " + (machineName.Length>0? "computer \"{2}\".": "this computer."), 
            instanceName, categoryName, machineName);
    }
    //</Snippet10>
}
//</snippet9>





