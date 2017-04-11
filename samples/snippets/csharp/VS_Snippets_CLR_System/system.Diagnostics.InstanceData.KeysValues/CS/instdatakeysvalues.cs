//<snippet1>
using System;
using System.Diagnostics;
using System.Collections;

class InstDataKeysValuesMod
{

    //<snippet5>
    private static string categoryName;
    //</snippet5>

    public static void Main()
    {
        string catNumStr;
        int categoryNum;

        PerformanceCounterCategory[] categories = PerformanceCounterCategory.GetCategories();

        Console.WriteLine("These categories are registered on this computer:");

        int catX;
        for(catX=0; catX<categories.Length; catX++)
        {
            Console.WriteLine("{0,4} - {1}", catX+1, categories[catX].CategoryName);
        }

        // Ask the user to choose a category.
        Console.Write("Enter the category number from the above list: ");
        catNumStr = Console.ReadLine();

        // Validate the entered category number.
        try
        {
            categoryNum = int.Parse(catNumStr);
            if (categoryNum<1||categoryNum>categories.Length)
            {
                throw new Exception(String.Format("The category number must be in the " +
                    "range 1..{0}.", categories.Length));
            }
            categoryName = categories[(categoryNum - 1)].CategoryName;

        }
        catch(Exception ex)
        {
            Console.WriteLine("\"{0}\" is not a valid category number." +
                "\r\n{1}", catNumStr, ex.Message);
            return;
        }
        //<snippet4>

        // Process the InstanceDataCollectionCollection for this category.
        PerformanceCounterCategory pcc = new PerformanceCounterCategory(categoryName);
        InstanceDataCollectionCollection idColCol = pcc.ReadCategory();

        ICollection idColColKeys = idColCol.Keys;
        string[] idCCKeysArray = new string[idColColKeys.Count];
        idColColKeys.CopyTo(idCCKeysArray, 0);

        ICollection idColColValues = idColCol.Values;
        InstanceDataCollection[] idCCValuesArray = new InstanceDataCollection[idColColValues.Count];
        idColColValues.CopyTo(idCCValuesArray, 0);

        Console.WriteLine("InstanceDataCollectionCollection for \"{0}\" " +
            "has {1} elements.", categoryName, idColCol.Count);

        // Display the InstanceDataCollectionCollection Keys and Values.
        // The Keys and Values collections have the same number of elements.
        int index;
        for(index=0; index<idCCKeysArray.Length; index++)
        {
            Console.WriteLine("  Next InstanceDataCollectionCollection " +
                "Key is \"{0}\"", idCCKeysArray[index]);
            ProcessInstanceDataCollection(idCCValuesArray[index]);
        }
        //</snippet4>
    }

    //<snippet3>
    //<snippet2>
    // Display the contents of an InstanceDataCollection.
    public static void ProcessInstanceDataCollection(InstanceDataCollection idCol)
    {
        //</snippet2>

        ICollection idColKeys = idCol.Keys;
        string[] idColKeysArray = new string[idColKeys.Count];
        idColKeys.CopyTo(idColKeysArray, 0);

        ICollection idColValues = idCol.Values;
        InstanceData[] idColValuesArray = new InstanceData[idColValues.Count];
        idColValues.CopyTo(idColValuesArray, 0);
        //<snippet6>

        Console.WriteLine("  InstanceDataCollection for \"{0}\" " +
            "has {1} elements.", idCol.CounterName, idCol.Count);
        //</snippet6>

        // Display the InstanceDataCollection Keys and Values.
        // The Keys and Values collections have the same number of elements.
        int index;
        for(index=0; index<idColKeysArray.Length; index++)
        {
            Console.WriteLine("    Next InstanceDataCollection " +
                "Key is \"{0}\"", idColKeysArray[index]);
            ProcessInstanceDataObject(idColValuesArray[index]);
        }
        //<snippet7>
    }
    //</snippet7>
    //</snippet3>

    // Display the contents of an InstanceData object.
    public static void ProcessInstanceDataObject(InstanceData instData)
    {
        CounterSample sample = instData.Sample;

        Console.WriteLine("    From InstanceData:\r\n      " +
            "InstanceName: {0,-31} RawValue: {1}", instData.InstanceName, instData.Sample.RawValue);
        Console.WriteLine("    From CounterSample:\r\n      " +
            "CounterType: {0,-32} SystemFrequency: {1}\r\n" +
            "      BaseValue: {2,-34} RawValue: {3}\r\n" +
            "      CounterFrequency: {4,-27} CounterTimeStamp: {5}\r\n" +
            "      TimeStamp: {6,-34} TimeStamp100nSec: {7}", sample.CounterType, sample.SystemFrequency, sample.BaseValue, sample.RawValue, sample.CounterFrequency, sample.CounterTimeStamp, sample.TimeStamp, sample.TimeStamp100nSec);
    }
}
//</snippet1>
