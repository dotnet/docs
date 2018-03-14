//<snippet3>
using System;
using System.Diagnostics;
using Microsoft.VisualBasic;

class PerfCounterCatObjCountExistsMod
{

    //<snippet4>
    public static void Main(string[] args)
    {
        string categoryName = "";
        string counterName = "";
        string machineName = "";
        bool objectExists = false;
        PerformanceCounterCategory pcc;

        // Copy the supplied arguments into the local variables.
        try
        {
            categoryName = args[0];
            counterName = args[1];
            machineName = (args[2]=="."? "": args[2]);
        }
        catch(Exception ex)
        {
            // Ignore the exception from non-supplied arguments.
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

            // Check whether the specified counter exists.
            // Use the per-instance overload of CounterExists.
            objectExists = pcc.CounterExists(counterName);

        }
        catch(Exception ex)
        {
            Console.WriteLine("Unable to check for the existence of " +
                "counter \"{0}\" in category \"{1}\" on "+
                (machineName.Length>0? "computer \"{2}\".": "this computer.")+ "\n" + 
                ex.Message, counterName, categoryName, machineName);
            return;
        }

        // Tell the user whether the counter exists.
        Console.WriteLine("Counter \"{0}\" " + (objectExists? "exists": "does not exist") + 
            " in category \"{1}\" on " + (machineName.Length>0? "computer \"{2}\".": "this computer."), 
            counterName, pcc.CategoryName, pcc.MachineName);
    }
    //</snippet4>
}
//</snippet3>



