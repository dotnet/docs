// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

// <SequenceUsage>
string[] strings = ["a", "b", "c", "d", "e"];

var query5 = strings.AlternateElements();

foreach (var element in query5)
{
    Console.WriteLine(element);
}
// This code produces the following output:
//     a
//     c
//     e
// </SequenceUsage>
