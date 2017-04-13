//<snippet5>
using System;
using System.Diagnostics;
using Microsoft.VisualBasic;

class PerfCounterCatDeleteMod
{

    //<snippet6>
    public static void Main(string[] args)
    {
        string categoryName = "";

        // Copy the supplied argument into the local variable.
        try
        {
            categoryName = args[0];
        }
        catch (Exception ex)
        {
            Console.WriteLine("Missing argument identifying category to be deleted.");
        }

        // Delete the specified category.
        try
        {
            if (PerformanceCounterCategory.Exists(categoryName))
            {
                PerformanceCounterCategory.Delete(categoryName);
                Console.WriteLine("Category \"{0}\" deleted from this computer.", categoryName);
            }
            else
            {
                Console.WriteLine("Category name not found");
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine("Unable to delete " +
                "category \"{0}\" from this computer:" + "\n" + ex.Message, categoryName);
        }
    }
    //</snippet6>
}
//</snippet5>

