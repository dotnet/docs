//<snippet1>
using System;
using System.Diagnostics;

class InstDataCopyToMod
{

    //<snippet7>
    private static string categoryName;
    //</snippet7>

    public static void Main()
    {
        string catNumStr;
        int categoryNum;

        PerformanceCounterCategory[] categories = PerformanceCounterCategory.GetCategories();

        // Create and sort an array of category names.
        string[] categoryNames = new string[categories.Length];
        int catX;
        for(catX=0; catX<categories.Length; catX++)
        {
            categoryNames[catX] = categories[catX].CategoryName;
        }
        Array.Sort(categoryNames);

        Console.WriteLine("These categories are registered on this computer:");

        for(catX=0; catX<categories.Length; catX++)
        {
            Console.WriteLine("{0,4} - {1}", catX+1, categoryNames[catX]);
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
            categoryName = categoryNames[(categoryNum-1)];

        }
        catch(Exception ex)
        {
            Console.WriteLine("\"{0}\" is not a valid category number." +
                "\r\n{1}", catNumStr, ex.Message);
            return;
        }
        //<snippet5>
        //<snippet6>

        // Process the InstanceDataCollectionCollection for this category.
        PerformanceCounterCategory pcc = new PerformanceCounterCategory(categoryName);
        InstanceDataCollectionCollection idColCol = pcc.ReadCategory();
        InstanceDataCollection[] idColArray = new InstanceDataCollection[idColCol.Count];

        Console.WriteLine("InstanceDataCollectionCollection for \"{0}\" " +
            "has {1} elements.", categoryName, idColCol.Count);
        //</snippet6>

        // Copy and process the InstanceDataCollection array.
        idColCol.CopyTo(idColArray, 0);

        foreach ( InstanceDataCollection idCol in idColArray )
        {
            ProcessInstanceDataCollection(idCol);
        }
        //</snippet5>
    }

    //<snippet4>
    // Display the contents of an InstanceDataCollection.
    public static void ProcessInstanceDataCollection(InstanceDataCollection idCol)
    {

        InstanceData[] instDataArray = new InstanceData[idCol.Count];

        Console.WriteLine("  InstanceDataCollection for \"{0}\" " +
            "has {1} elements.", idCol.CounterName, idCol.Count);

        // Copy and process the InstanceData array.
        idCol.CopyTo(instDataArray, 0);

        int idX;
        for(idX=0; idX<instDataArray.Length; idX++)
        {
            ProcessInstanceDataObject(instDataArray[idX].InstanceName, instDataArray[idX].Sample);
        }
    }
    //</snippet4>

    //<snippet3>
    //<snippet2>
    // Display the contents of an InstanceData object.
    public static void ProcessInstanceDataObject(string name, CounterSample CSRef)
    {

        InstanceData instData = new InstanceData(name, CSRef);
        Console.WriteLine("    Data from InstanceData object:\r\n" +
            "      InstanceName: {0,-31} RawValue: {1}", instData.InstanceName, instData.RawValue);
        //</snippet2>

        CounterSample sample = instData.Sample;
        Console.WriteLine("    Data from CounterSample object:\r\n" +
            "      CounterType: {0,-32} SystemFrequency: {1}\r\n" +
            "      BaseValue: {2,-34} RawValue: {3}\r\n" +
            "      CounterFrequency: {4,-27} CounterTimeStamp: {5}\r\n" +
            "      TimeStamp: {6,-34} TimeStamp100nSec: {7}", sample.CounterType, sample.SystemFrequency, sample.BaseValue, sample.RawValue, sample.CounterFrequency, sample.CounterTimeStamp, sample.TimeStamp, sample.TimeStamp100nSec);
        //<snippet8>
    }
    //</snippet8>
    //</snippet3>
}
//</snippet1>



