//<snippet1>
using System;
using System.Diagnostics;
using Microsoft.VisualBasic;

class PerfCounterCatObjInstExistsMod
{

    //<snippet2>
    public static void Main(string[] args)
    {
        string categoryName = "";
        string instanceName = "";
        string machineName = "";
        bool objectExists = false;
        PerformanceCounterCategory pcc;
        const string SINGLE_INSTANCE_NAME = "systemdiagnosticsperfcounterlibsingleinstance";

        // Copy the supplied arguments into the local variables.
        try
        {
            categoryName = args[0];
            instanceName = args[1];
            machineName = (args[2]=="."? "": args[2]);
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
            if (machineName.Length==0)
            {
                pcc = new PerformanceCounterCategory(categoryName);
            }
            else
            {
                pcc = new PerformanceCounterCategory(categoryName, machineName);
            }

            // Check whether the instance exists.
            // Use the per-instance overload of InstanceExists.
            objectExists = pcc.InstanceExists(instanceName);

        }
        catch(Exception ex)
        {
            Console.WriteLine("Unable to check for the existence of " +
                "instance \"{0}\" in category \"{1}\" on " + 
                (machineName.Length>0? "computer \"{2}\":": "this computer:") + 
                "\n" + ex.Message, instanceName, categoryName, machineName);
            return;
        }

        // Tell the user whether the instance exists.
        Console.WriteLine("Instance \"{0}\" " + (objectExists? "exists": "does not exist") + 
            " in category \"{1}\" on " + (machineName.Length>0? "computer \"{2}\".": "this computer."), 
            instanceName, pcc.CategoryName, pcc.MachineName);
    }
    //</snippet2>
}
//</snippet1>






