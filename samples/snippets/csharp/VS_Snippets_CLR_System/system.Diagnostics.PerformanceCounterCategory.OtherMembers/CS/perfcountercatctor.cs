//<snippet3>
using System;
using System.Diagnostics;
using Microsoft.VisualBasic;

class PerfCounterCatCtorMod
{

    //<snippet4>
    public static void Main(string[] args)
    {
        string categoryName = "";
        string machineName = "";
        PerformanceCounterCategory pcc;

        // Copy the supplied arguments into the local variables.
        try
        {
            categoryName = args[0];
            machineName = args[1]=="."? "": args[1];
        }
        catch(Exception ex)
        {
            // Ignore the exception from non-supplied arguments.
        }

        // Create a PerformanceCounterCategory object using 
        // the appropriate constructor.
        if (categoryName.Length==0)
        {
            pcc = new PerformanceCounterCategory();
        }
        else if(machineName.Length==0)
        {
            pcc = new PerformanceCounterCategory(categoryName);
        }
        else
        {
            pcc = new PerformanceCounterCategory(categoryName, machineName);
        }

        // Display the properties of the PerformanceCounterCategory object.
        try
        {
            Console.WriteLine("  Category:  {0}", pcc.CategoryName);
            Console.WriteLine("  Computer:  {0}", pcc.MachineName);
            Console.WriteLine("  Help text: {0}", pcc.CategoryHelp);
        }
        catch(Exception ex)
        {
            Console.WriteLine("Error getting the properties of the " +
                "PerformanceCounterCategory object:");
            Console.WriteLine(ex.Message);
        }
    }
    //</snippet4>
}
//</snippet3>
