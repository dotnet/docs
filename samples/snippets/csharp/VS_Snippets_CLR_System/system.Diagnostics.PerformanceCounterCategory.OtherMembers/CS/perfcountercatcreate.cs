//<snippet1>
using System;
using System.Diagnostics;
using Microsoft.VisualBasic;

class PerfCounterCatCreateMod
{

    //<snippet2>
    public static void Main(string[] args)
    {
        string categoryName = "";
        string counterName = "";
        string categoryHelp = "";
        string counterHelp = "";
        PerformanceCounterCategory pcc;

        // Copy the supplied arguments into the local variables.
        try
        {
            categoryName = args[0];
            counterName = args[1];
            categoryHelp = args[2];
            counterHelp = args[3];
        }
        catch(Exception ex)
        {
            // Ignore the exception from non-supplied arguments.
        }

        Console.WriteLine("Category name: \"{0}\"", categoryName);
        Console.WriteLine("Category help: \"{0}\"", categoryHelp);
        Console.WriteLine("Counter name:  \"{0}\"", counterName);
        Console.WriteLine("Counter help:  \"{0}\"", counterHelp);

        // Use the Create overload that creates a single counter.
        try
        {
            pcc = PerformanceCounterCategory.Create(categoryName, categoryHelp, counterName, counterHelp);
            Console.WriteLine("Category \"{0}\" created.", pcc.CategoryName);

        }
        catch(Exception ex)
        {
            Console.WriteLine("Unable to create the above category and counter:" + "\n" + ex.Message);
        }
    }
    //</snippet2>
}
//</snippet1>






