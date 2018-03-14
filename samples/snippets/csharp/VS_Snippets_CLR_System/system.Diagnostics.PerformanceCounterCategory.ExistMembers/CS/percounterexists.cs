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
        catch(Exception ex)
        {
        }

        // Delete the specified category.
        try
        {
            PerformanceCounterCategory.Delete(categoryName);
            Console.WriteLine("Category \"{0}\" deleted from this computer.", categoryName);

        }
        catch(Exception ex)
        {
            Console.WriteLine("Unable to delete " +
                "category \"{0}\" from this computer:"+ "\n" + ex.Message, categoryName);
        }
    }
    //</snippet6>
}
//</snippet5>









