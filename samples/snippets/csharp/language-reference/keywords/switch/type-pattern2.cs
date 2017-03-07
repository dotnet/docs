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
        if (coll is Array) {
           Array arr = (Array) coll;
           Console.WriteLine($"An array with {arr.Length} elements.");
        }
        else if (coll is IEnumerable<int>) {
            IEnumerable<int> ieInt = (IEnumerable<int>) coll;
            Console.WriteLine($"Average: {ieInt.Average(s => s)}");
        }
        else if (coll is IList) {
            IList list = (IList) coll;
            Console.WriteLine($"{list.Count} items");
        }
        else if (coll is IEnumerable) { 
            IEnumerable ie = (IEnumerable) coll;
            string result = "";
            foreach (var item in ie) 
               result += "${e} ";
            Console.WriteLine(result);
        }
        else if (coll == null) { 
            // Do nothing. 
        }
        else {
            Console.WriteLine($"An instance of type {coll.GetType().Name}");
        }   
    }
}
// The example displays the following output:
//     An array with 5 elements.
//     4 items
// </Snippet1>


