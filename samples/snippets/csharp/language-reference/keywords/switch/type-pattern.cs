// <Snippet1>
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

class Example
{
    static void Main(string[] args)
    {
        int[] values = { 2, 4, 6, 8, 10 };
        ShowCollectionInformation(values);
        
        var names = new List<string>();
        names.AddRange( new string[] { "Adam", "Abigail", "Bertrand", "Bridgette" } );
        ShowCollectionInformation(names);

        List<int> numbers = null;
        ShowCollectionInformation(numbers);
    }
   
    private static void ShowCollectionInformation(object coll)
    {
        switch (coll)
        {
            case Array arr:
               Console.WriteLine($"An array with {arr.Length} elements.");
               break;
            case IEnumerable<int> ieInt:
               Console.WriteLine($"Average: {ieInt.Average(s => s)}");
               break;   
            case IList list:
               Console.WriteLine($"{list.Count} items");
               break;
            case IEnumerable ie:
               string result = "";
               foreach (var item in ie) 
                  result += "${e} ";
               Console.WriteLine(result);
               break;   
            case null:
               // Do nothing for a null.
               break;
            default:
               Console.WriteLine($"A instance of type {coll.GetType().Name}");
               break;   
        }
    }
}
// The example displays the following output:
//     An array with 5 elements.
//     4 items
// </Snippet1>


