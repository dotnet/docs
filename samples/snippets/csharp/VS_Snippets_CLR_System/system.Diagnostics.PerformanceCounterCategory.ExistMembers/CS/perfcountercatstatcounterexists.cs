//<snippet7>
using System;
using System.Diagnostics;
using Microsoft.VisualBasic;

class PerfCounterCatStatCountExistsMod
{

    //<snippet8>
    public static void Main(string[] args)
    {
        string categoryName = "";
        string counterName = "";
        string machineName = "";
        bool objectExists = false;

        // Copy the supplied arguments into the local variables.
        try
        {
            categoryName = args[0];
            counterName = args[1];
            machineName = args[2]=="."? "": args[2];
        }
        catch(Exception ex)
        {
            // Ignore the exception from non-supplied arguments.
        }

        try
        {
            // Check whether the specified counter exists.
            // Use the static forms of the CounterExists method.
            if (machineName.Length==0)
            {
                objectExists = PerformanceCounterCategory.CounterExists(counterName, categoryName);
            }
            else
            {
                objectExists = PerformanceCounterCategory.CounterExists(counterName, categoryName, machineName);
            }

        }
        catch(Exception ex)
        {
            Console.WriteLine("Unable to check for the existence of " +
                "counter \"{0}\" in category \"{1}\" on " + 
                (machineName.Length>0? "computer \"{2}\".": "this computer.") + "\n" + 
                ex.Message, counterName, categoryName, machineName);
            return;
        }

        // Tell the user whether the counter exists.
        Console.WriteLine("Counter \"{0}\" "+ (objectExists? "exists": "does not exist") + 
            " in category \"{1}\" on " + (machineName.Length>0? "computer \"{2}\".": "this computer."), 
            counterName, categoryName, machineName);
    }
    //</snippet8>
}
//</snippet7>










