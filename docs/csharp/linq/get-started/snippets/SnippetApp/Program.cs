using System.Xml.Linq;

PartsOfAQuery();

/*
// <LoadXML>
// Create a data source from an XML document.
// using System.Xml.Linq;
XElement contacts = XElement.Load(@"c:\myContactList.xml");
// </LoadXML>
*/

static void PartsOfAQuery()
{
    // <PartsOfAQuery>
    // The Three Parts of a LINQ Query:
    // 1. Data source.
    int[] numbers = [ 0, 1, 2, 3, 4, 5, 6 ];

    // 2. Query creation.
    // numQuery is an IEnumerable<int>
    var numQuery =
        from num in numbers
        where (num % 2) == 0
        select num;

    // 3. Query execution.
    foreach (int num in numQuery)
    {
        Console.Write("{0,1} ", num);
    }
    // </PartsOfAQuery>
    Console.WriteLine();
    // <QueryExecution>
    foreach (int num in numQuery)
    {
        Console.Write("{0,1} ", num);
    }
    // </QueryExecution>

    // <EagerEvaluation>
    var evenNumQuery =
        from num in numbers
        where (num % 2) == 0
        select num;

    int evenNumCount = evenNumQuery.Count();
    //</EagerEvaluation>

    //<MoreEagerEvaluation>
    List<int> numQuery2 =
        (from num in numbers
            where (num % 2) == 0
            select num).ToList();

    // or like this:
    // numQuery3 is still an int[]

    var numQuery3 =
        (from num in numbers
            where (num % 2) == 0
            select num).ToArray();
    //</MoreEagerEvaluation>
}
