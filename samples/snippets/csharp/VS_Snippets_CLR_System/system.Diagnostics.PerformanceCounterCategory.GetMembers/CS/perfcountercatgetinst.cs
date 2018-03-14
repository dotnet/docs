//<snippet5>
using System;
using System.Diagnostics;

class PerfCounterCatGetInstMod
{

    //<snippet6>
    public static void Main(string[] args)
    {
        string categoryName = "";
        string machineName = "";
        PerformanceCounterCategory pcc;
        string[] instances;

        // Copy the supplied arguments into the local variables.
        try
        {
            categoryName = args[0];
            machineName = args[1]=="."? "": args[1];
        }
        catch
        {
            // Ignore the exception from non-supplied arguments.
        }

        try
        {
            // Create the appropriate PerformanceCounterCategory object.
            if (machineName.Length>0)
            {
                pcc = new PerformanceCounterCategory(categoryName, machineName);
            }
            else
            {
                pcc = new PerformanceCounterCategory(categoryName);
            }

            // Get the instances associated with this category.
            instances = pcc.GetInstanceNames();

        }
        catch(Exception ex)
        {
            Console.WriteLine("Unable to get instance information for " +
                "category \"{0}\" on " + 
                (machineName.Length>0? "computer \"{1}\":": "this computer:"), 
                categoryName, machineName);
            Console.WriteLine(ex.Message);
            return;
        }

        //If an empty array is returned, the category has a single instance.
        if (instances.Length==0)
        {
            Console.WriteLine("Category \"{0}\" on " + 
                (machineName.Length>0? "computer \"{1}\"": "this computer") + 
                " is single-instance.", pcc.CategoryName, pcc.MachineName);
        }
        else
        {
            // Otherwise, display the instances.
            Console.WriteLine("These instances exist in category \"{0}\" on " + 
                (machineName.Length>0? "computer \"{1}\".": "this computer:"), 
                pcc.CategoryName, pcc.MachineName);

            Array.Sort(instances);
            int objX;
            for(objX=0; objX<instances.Length; objX++)
            {
                Console.WriteLine("{0,4} - {1}", objX+1, instances[objX]);
            }
        }
    }
    //</snippet6>
}
//</snippet5>
