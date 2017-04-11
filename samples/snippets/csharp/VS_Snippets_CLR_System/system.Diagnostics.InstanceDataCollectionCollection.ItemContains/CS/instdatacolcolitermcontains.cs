//<snippet1>
using System;
using System.Diagnostics;
using System.Collections;
using Microsoft.VisualBasic;

class InstDataColColItemContainsMod
{

    //<snippet2>
    public static void Main(string[] args)
    {
        // The following values can be used as arguments.
        string categoryName = "Process";
        string counterName = "Private Bytes";

        InstanceDataCollectionCollection idColCol;

        // Copy the supplied arguments into the local variables.
        try
        {
            categoryName = args[0];
            counterName = args[1];
        }
        catch
        {
            // Ignore the exception from non-supplied arguments.
        }

        try
        {
            // Get the InstanceDataCollectionCollection for this category.
            PerformanceCounterCategory pcc = new PerformanceCounterCategory(categoryName);
            idColCol = pcc.ReadCategory();
        }
        catch(Exception ex)
        {
            Console.WriteLine("An error occurred getting the InstanceDataCollection for " +
                "category \"{0}\"."+ "\n" +ex.Message, categoryName);
            return;
        }

        //<snippet3>
        // Check if this counter name exists using the Contains
        // method of the InstanceDataCollectionCollection.
        if (!idColCol.Contains(counterName))
            //</snippet3>
        {
            Console.WriteLine("Counter \"{0}\" does not exist in category \"{1}\".", counterName, categoryName);
            return;
        }
        else
        {
            //<snippet4>
            // Now get the counter's InstanceDataCollection object using the
            // indexer (Item property) for the InstanceDataCollectionCollection.
            InstanceDataCollection countData = idColCol[counterName];
            //</snippet4>

            ICollection idColKeys = countData.Keys;
            string[] idColKeysArray = new string[idColKeys.Count];
            idColKeys.CopyTo(idColKeysArray, 0);

            Console.WriteLine("Counter \"{0}\" of category \"{1}\" " +
                "has {2} instances.", counterName, categoryName, idColKeys.Count);

            // Display the instance names for this counter.
            int index;
            for(index=0; index<idColKeysArray.Length; index++)
            {
                Console.WriteLine("{0,4} -- {1}", index+1, idColKeysArray[index]);
            }
        }
    }
    //</snippet2>
}
//</snippet1>

