//<snippet1>
using System;
using System.Diagnostics;
using Microsoft.VisualBasic;

class InstDataColItemContainsMod
{

    //<snippet2>
    public static void Main(string[] args)
    {
        // These values can be used as arguments.
        string categoryName = "Process";
        string counterName = "Private Bytes";
        string instanceName = "Explorer";

        InstanceDataCollection idCol;
        const string SINGLE_INSTANCE_NAME = "systemdiagnosticsperfcounterlibsingleinstance";

        // Copy the supplied arguments into the local variables.
        try
        {
            categoryName = args[0];
            counterName = args[1];
            instanceName = args[2];
        }
        catch
        {
            // Ignore the exception from non-supplied arguments.
        }

        try
        {
            // Get the InstanceDataCollectionCollection for this category.
            PerformanceCounterCategory pcc = new PerformanceCounterCategory(categoryName);
            InstanceDataCollectionCollection idColCol = pcc.ReadCategory();

            // Get the InstanceDataCollection for this counter.
            idCol = idColCol[counterName];
            if (idCol==null)
            {
                throw new Exception("Counter does not exist.");
            }
        }
        catch(Exception ex)
        {
            Console.WriteLine("An error occurred getting the InstanceDataCollection for " +
                "category \"{0}\", counter \"{1}\"." +  "\n" + ex.Message, categoryName, counterName);
            return;
        }

        // If the instance name is empty, use the single-instance name.
        if (instanceName.Length==0)
        {
            instanceName = SINGLE_INSTANCE_NAME;
        }

        //<snippet3>
        // Check if this instance name exists using the Contains
        // method of the InstanceDataCollection.
        if (!idCol.Contains(instanceName))
            //</snippet3>
        {
            Console.WriteLine("Instance \"{0}\" does not exist in counter \"{1}\", " +
                "category \"{2}\".", instanceName, counterName, categoryName);
            return;
        }
        else
        {
            //<snippet4>
            // The instance name exists, now get its InstanceData object
            // using the indexer (Item property) for the InstanceDataCollection.
            InstanceData instData = idCol[instanceName];
            //</snippet4>

            Console.WriteLine("CategoryName: {0}", categoryName);
            Console.WriteLine("CounterName:  {0}", counterName);
            Console.WriteLine("InstanceName: {0}", instData.InstanceName);
            Console.WriteLine("RawValue:     {0}", instData.RawValue);
        }
    }
    //</snippet2>
}
//</snippet1>

