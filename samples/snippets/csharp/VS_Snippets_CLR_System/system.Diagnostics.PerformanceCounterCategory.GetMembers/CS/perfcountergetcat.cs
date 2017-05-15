//<snippet1>
using System;
using System.Diagnostics;

class PerfCounterCatGetCatMod
{

    //<snippet2>
    public static void Main(string[] args)
    {
        string machineName = "";
        PerformanceCounterCategory[] categories;

        // Copy the machine name argument into the local variable.
        try
        {
            machineName = args[0]=="."? "": args[0];
        }
        catch
        {
        }

        // Generate a list of categories registered on the specified computer.
        try
        {
            if (machineName.Length > 0)
            {
                categories = PerformanceCounterCategory.GetCategories(machineName);
            }
            else
            {
                categories = PerformanceCounterCategory.GetCategories();
            }
        }
        catch(Exception ex)
        {
            Console.WriteLine("Unable to get categories on " + 
                (machineName.Length > 0 ? "computer \"{0}\":": "this computer:"), machineName);
            Console.WriteLine(ex.Message);
            return;
        }

        Console.WriteLine("These categories are registered on " + 
            (machineName.Length > 0 ? "computer \"{0}\":": "this computer:"), machineName);

        // Create and sort an array of category names.
        string[] categoryNames = new string[categories.Length];
        int objX;
        for(objX = 0; objX < categories.Length; objX++)
        {
            categoryNames[objX] = categories[objX].CategoryName;
        }
        Array.Sort(categoryNames);

        for(objX = 0; objX < categories.Length; objX++)
        {
            Console.WriteLine("{0,4} - {1}", objX + 1, categoryNames[objX]);
        }
    }
    //</snippet2>
}
//</snippet1>



