using System.Xml.Linq;

WriteSeparator(nameof(PartsOfAQuery));
PartsOfAQuery();
Console.WriteLine();

WriteSeparator(nameof(Linq.GetStarted.Basics.Basics1));
Linq.GetStarted.Basics.Basics1();
WriteSeparator(nameof(Linq.GetStarted.Basics.Basics2));
Linq.GetStarted.Basics.Basics2();
WriteSeparator(nameof(Linq.GetStarted.Basics.Basics3));
Linq.GetStarted.Basics.Basics3();
WriteSeparator(nameof(Linq.GetStarted.Basics.Basics4));
Linq.GetStarted.Basics.Basics4();
WriteSeparator(nameof(Linq.GetStarted.Basics.Basics5));
Linq.GetStarted.Basics.Basics5();
WriteSeparator(nameof(Linq.GetStarted.Basics.Basics6));
Linq.GetStarted.Basics.Basics6();
WriteSeparator(nameof(Linq.GetStarted.Basics.Basics7));
Linq.GetStarted.Basics.Basics7();
WriteSeparator(nameof(Linq.GetStarted.Basics.Basics7a));
Linq.GetStarted.Basics.Basics7a();
WriteSeparator(nameof(Linq.GetStarted.Basics.Basics8));
Linq.GetStarted.Basics.Basics8();
WriteSeparator(nameof(Linq.GetStarted.Basics.Basics9));
Linq.GetStarted.Basics.Basics9();
WriteSeparator(nameof(Linq.GetStarted.Basics.Basics10));
Linq.GetStarted.Basics.Basics10();
WriteSeparator(nameof(Linq.GetStarted.Basics.Basics11));
Linq.GetStarted.Basics.Basics11();
WriteSeparator(nameof(Linq.GetStarted.Basics.Basics12));
Linq.GetStarted.Basics.Basics12();
WriteSeparator(nameof(Linq.GetStarted.Basics.Basics13));
Linq.GetStarted.Basics.Basics13();
WriteSeparator(nameof(Linq.GetStarted.Basics.Basics14));
Linq.GetStarted.Basics.Basics14();
WriteSeparator(nameof(Linq.GetStarted.Basics.Basics15));
Linq.GetStarted.Basics.Basics15();
WriteSeparator(nameof(Linq.GetStarted.Basics.Basics16));
Linq.GetStarted.Basics.Basics16();
WriteSeparator(nameof(Linq.GetStarted.Basics.Basics17));
Linq.GetStarted.Basics.Basics17();
WriteSeparator(nameof(Linq.GetStarted.Basics.Basics18));
Linq.GetStarted.Basics.Basics18();
Console.WriteLine();
WriteSeparator(nameof(Linq.GetStarted.Basics.Basics19));
Linq.GetStarted.Basics.Basics19();

WriteSeparator(nameof(Linq.GetStarted.WriteLinqQueries.MethodSyntax));
Linq.GetStarted.WriteLinqQueries.MethodSyntax();
WriteSeparator(nameof(Linq.GetStarted.WriteLinqQueries.WriteLinqQueries1));
Linq.GetStarted.WriteLinqQueries.WriteLinqQueries1();
WriteSeparator(nameof(Linq.GetStarted.WriteLinqQueries.WriteLinqQueries2));
Linq.GetStarted.WriteLinqQueries.WriteLinqQueries2();
WriteSeparator(nameof(Linq.GetStarted.WriteLinqQueries.WriteLinqQueries3));
Linq.GetStarted.WriteLinqQueries.WriteLinqQueries3();
WriteSeparator(nameof(Linq.GetStarted.WriteLinqQueries.WriteLinqQueries4));
Linq.GetStarted.WriteLinqQueries.WriteLinqQueries4();
WriteSeparator(nameof(Linq.GetStarted.WriteLinqQueries.WriteLinqQueries5));
Linq.GetStarted.WriteLinqQueries.WriteLinqQueries5();
WriteSeparator(nameof(Linq.GetStarted.WriteLinqQueries.WriteLinqQueries5a));
Linq.GetStarted.WriteLinqQueries.WriteLinqQueries5a();
WriteSeparator(nameof(Linq.GetStarted.WriteLinqQueries.WriteLinqQueries5b));
Linq.GetStarted.WriteLinqQueries.WriteLinqQueries5b();

WriteSeparator(nameof(Linq.GetStarted.TypeRelationships.ExplicitType));
Linq.GetStarted.TypeRelationships.ExplicitType();
WriteSeparator(nameof(Linq.GetStarted.TypeRelationships.ImplicitType));
Linq.GetStarted.TypeRelationships.ImplicitType();

WriteSeparator(nameof(Linq.GetStarted.TypeRelationships.ImplicitType));
LinqSamples.ReturnQueryFromMethod.ReturnQueryFromMethod1();

WriteSeparator(nameof(LinqSamples.RuntimeFiltering));
LinqSamples.RuntimeFiltering.RuntimeFiltering1();
LinqSamples.RuntimeFiltering.RuntimeFiltering2();

WriteSeparator(nameof(LinqSamples.NullValues));
LinqSamples.NullValues.NullValues1();

WriteSeparator(nameof(LinqSamples.Exceptions));
LinqSamples.Exceptions.Exceptions1();
LinqSamples.Exceptions.Exceptions2();

void WriteSeparator(string symbol) => Console.WriteLine($"==========  {symbol} ==========");

// This won't work, but we want to make sure it compiles.
#pragma warning disable CS8321 // Local function is declared but never used
void DontCallThis()
{ 
    // <LoadXML>
    // Create a data source from an XML document.
    // using System.Xml.Linq;
    XElement contacts = XElement.Load(@"c:\myContactList.xml");
    // </LoadXML>
}
#pragma warning restore CS8321 // Local function is declared but never used

static void PartsOfAQuery()
{
    // <PartsOfAQuery>
    // The Three Parts of a LINQ Query:
    // 1. Data source.
    int[] numbers = [ 0, 1, 2, 3, 4, 5, 6 ];

    // 2. Query creation.
    // numQuery is an IEnumerable<int>
    var numQuery = from num in numbers
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
    var evenNumQuery = from num in numbers
                       where (num % 2) == 0
                       select num;

    int evenNumCount = evenNumQuery.Count();
    //</EagerEvaluation>

    //<MoreEagerEvaluation>
    List<int> numQuery2 = (from num in numbers
                           where (num % 2) == 0
                           select num).ToList();

    // or like this:
    // numQuery3 is still an int[]

    var numQuery3 = (from num in numbers
                     where (num % 2) == 0
                     select num).ToArray();
    //</MoreEagerEvaluation>
}
