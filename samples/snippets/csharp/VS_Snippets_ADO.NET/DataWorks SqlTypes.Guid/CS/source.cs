using System;
using System.Data;
using System.Collections;
using System.Data.SqlTypes;

class Program
{
    static void Main()
    {
        WorkWithGuids();
        Console.ReadLine();
    }
    // <Snippet1>
    private static void WorkWithGuids()
    {
        // Create an ArrayList and fill it with Guid values.
        ArrayList guidList = new ArrayList();
        guidList.Add(new Guid("3AAAAAAA-BBBB-CCCC-DDDD-2EEEEEEEEEEE"));
        guidList.Add(new Guid("2AAAAAAA-BBBB-CCCC-DDDD-1EEEEEEEEEEE"));
        guidList.Add(new Guid("1AAAAAAA-BBBB-CCCC-DDDD-3EEEEEEEEEEE"));

        // Display the unsorted Guid values.
        Console.WriteLine("Unsorted Guids:");
        foreach (Guid guidValue in guidList)
        {
            Console.WriteLine(" {0}", guidValue);
        }
        Console.WriteLine("");

        // Sort the Guids.
        guidList.Sort();

        // Display the sorted Guid values.
        Console.WriteLine("Sorted Guids:");
        foreach (Guid guidSorted in guidList)
        {
            Console.WriteLine(" {0}", guidSorted);
        }
        Console.WriteLine("");

        // Create an ArrayList of SqlGuids.
        ArrayList sqlGuidList = new ArrayList();
        sqlGuidList.Add(new SqlGuid("3AAAAAAA-BBBB-CCCC-DDDD-2EEEEEEEEEEE"));
        sqlGuidList.Add(new SqlGuid("2AAAAAAA-BBBB-CCCC-DDDD-1EEEEEEEEEEE"));
        sqlGuidList.Add(new SqlGuid("1AAAAAAA-BBBB-CCCC-DDDD-3EEEEEEEEEEE"));

        // Sort the SqlGuids. The unsorted SqlGuids are in the same order
        // as the unsorted Guid values.
        sqlGuidList.Sort();

        // Display the sorted SqlGuids. The sorted SqlGuid values are ordered
        // differently than the Guid values.
        Console.WriteLine("Sorted SqlGuids:");
        foreach (SqlGuid sqlGuidValue in sqlGuidList)
        {
            Console.WriteLine(" {0}", sqlGuidValue);
        }
    }
    // </Snippet1>
}
