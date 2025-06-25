// Main program to run all the samples for the
// standard query operators section of the LINQ learning series.

using StandardQueryOperators;

Console.WriteLine("==========          Left Outer Joins Test   ==========");
try 
{
    LeftOuterJoins.RunAllSnippets();
}
catch (Exception ex)
{
    Console.WriteLine($"Exception caught: {ex.GetType().Name}: {ex.Message}");
    Console.WriteLine(ex.StackTrace);
}
return; // Stop after testing left outer joins

Console.WriteLine("==========          Index snippets          ==========");
IndexExamples.RunAllSnippets();
Console.WriteLine("==========          Order Join results      ==========");
OrderResultsOfJoin.RunAllSnippets();

Console.WriteLine("==========          Where filter            ==========");
WhereFilter.RunAllSnippets();
Console.WriteLine("==========          Select projection       ==========");
SelectProjectionExamples.RunAllSnippets();

Console.WriteLine("==========          Set operations          ==========");
SetOperations.RunAllSnippets();

Console.WriteLine("==========          Sort Examples           ==========");
SortExamples.RunAllSnippets();

Console.WriteLine("==========          Quantifier Examles      ==========");
QuantifierExamples.RunAllSnippets();

Console.WriteLine("==========          Partitionss             ==========");
PartitionExamples.RunAllSnippets();

Console.WriteLine("==========          Conversions             ==========");
ConversionExamples.RunAllSnippets();

Console.WriteLine("==========          Join Overview           ==========");
JoinOverviewExamples.RunAllSnippets();
Console.WriteLine("==========          Inner Join              ==========");
InnerJoins.RunAllSnippets();
Console.WriteLine("==========          Group Join              ==========");
GroupJoins.RunAllSnippets();
Console.WriteLine("==========          Left Outer Joins        ==========");
LeftOuterJoins.RunAllSnippets();

Console.WriteLine("==========          Grouping overview       ==========");
GroupOverview.RunAllSnippets();
Console.WriteLine("==========          Group Query             ==========");
GroupQueryResults.RunAllSnippets();
Console.WriteLine("==========          Nested Groups           ==========");
NestedGroups.RunAllSnippets();
Console.WriteLine("==========          Subquery on Group       ==========");
SubqueryOnGroup.RunAllSnippets();
