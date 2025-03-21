using System;

public class Example6
{
    public static void Main()
    {
        GetEnumByName();
        Console.WriteLine("-----");
        GetEnumByValue();
    }

    private static void GetEnumByName()
    {
        // <Snippet11>
        string[] names = Enum.GetNames(typeof(ArrivalStatus));
        Console.WriteLine($"Members of {typeof(ArrivalStatus).Name}:");
        Array.Sort(names);
        foreach (var name in names)
        {
            ArrivalStatus status = (ArrivalStatus)Enum.Parse(typeof(ArrivalStatus), name);
            Console.WriteLine($"   {status} ({status:D})");
        }
        // The example displays the following output:
        //       Members of ArrivalStatus:
        //          Early (1)
        //          Late (-1)
        //          OnTime (0)
        //          Unknown (-3)
        // </Snippet11>
    }

    private static void GetEnumByValue()
    {
        // <Snippet12>
        var values = Enum.GetValues(typeof(ArrivalStatus));
        Console.WriteLine($"Members of {typeof(ArrivalStatus).Name}:");
        foreach (ArrivalStatus status in values)
        {
            Console.WriteLine($"   {status} ({status:D})");
        }
        // The example displays the following output:
        //       Members of ArrivalStatus:
        //          OnTime (0)
        //          Early (1)
        //          Unknown (-3)
        //          Late (-1)
        // </Snippet12>
    }
}
