//<snippet7>
using System;
using System.Diagnostics;
using Microsoft.VisualBasic;

class PerfCounterCatPropsMod
{

    //<snippet8>
    public static void Main(string[] args)
    {
        string categoryName = "";
        string machineName = "";
        PerformanceCounterCategory pcc = new PerformanceCounterCategory();

        // Prompt for fields and set the corresponding properties.
        while (categoryName.Length==0)
        {
            Console.Write("Please enter a non-blank category name: ");
            categoryName = Console.ReadLine().Trim();
            if (categoryName.Length>0)
            {
                pcc.CategoryName = categoryName;
            }
        }
        while (machineName.Length==0)
        {
            Console.Write("Enter a non-blank computer name ['.' for local]: ");
            machineName = Console.ReadLine().Trim();
            if (machineName.Length>0)
            {
                pcc.MachineName = machineName;
            }
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
    //</snippet8>
}
//</snippet7>



