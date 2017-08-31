using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//<Snippet1>
public static class LINQExtension
{
    public static double Median(this IEnumerable<double> source)
    {
        if (source.Count() == 0)
        {
            throw new InvalidOperationException("Cannot compute median for an empty set.");
        }

        var sortedList = from number in source
                         orderby number
                         select number;

        int itemIndex = (int)sortedList.Count() / 2;

        if (sortedList.Count() % 2 == 0)
        {
            // Even number of items.
            return (sortedList.ElementAt(itemIndex) + sortedList.ElementAt(itemIndex - 1)) / 2;
        }
        else
        {
            // Odd number of items.
            return sortedList.ElementAt(itemIndex);
        }
    }
}
//</Snippet1>

public static class MoreLINQExtensions
{
    //<Snippet4>
    //int overload

    public static double Median(this IEnumerable<int> source)
    {
        return (from num in source select (double)num).Median();
    }
    //</Snippet4>

    //<Snippet7>
    // Generic overload.

    public static double Median<T>(this IEnumerable<T> numbers,
                           Func<T, double> selector)
    {
        return (from num in numbers select selector(num)).Median();
    }
    //</Snippet7>

    //<Snippet9>
    // Extension method for the IEnumerable<T> interface. 
    // The method returns every other element of a sequence.

    public static IEnumerable<T> AlternateElements<T>(this IEnumerable<T> source)
    {
        List<T> list = new List<T>();

        int i = 0;

        foreach (var element in source)
        {
            if (i % 2 == 0)
            {
                list.Add(element);
            }

            i++;
        }

        return list;
    }
    //</Snippet9>
}


class App
{
    static void Main()
    {
        //<Snippet2>
        double[] numbers1 = { 1.9, 2, 8, 4, 5.7, 6, 7.2, 0 };

        var query1 = numbers1.Median();

        Console.WriteLine("double: Median = " + query1);

        //</Snippet2>

        //<Snippet3>
        /*
         This code produces the following output:
        
         Double: Median = 4.85
        */
        //</Snippet3>

        //<Snippet5>
        int[] numbers2 = { 1, 2, 3, 4, 5 };

        var query2 = numbers2.Median();

        Console.WriteLine("int: Median = " + query2);

        //</Snippet5>

        //<Snippet6>
        /*
         This code produces the following output:
        
         Double: Median = 4.85
         Integer: Median = 3
        */
        //</Snippet6>

        //<Snippet8>
        int[] numbers3 = { 1, 2, 3, 4, 5 };

        /* 
          You can use the num=>num lambda expression as a parameter for the Median method 
          so that the compiler will implicitly convert its value to double.
          If there is no implicit conversion, the compiler will display an error message.          
        */

        var query3 = numbers3.Median(num => num);

        Console.WriteLine("int: Median = " + query3);

        string[] numbers4 = { "one", "two", "three", "four", "five" };

        // With the generic overload, you can also use numeric properties of objects.

        var query4 = numbers4.Median(str => str.Length);

        Console.WriteLine("String: Median = " + query4);

        /*
         This code produces the following output:
        
         Integer: Median = 3
         String: Median = 4
        */
        //</Snippet8>

        //<Snippet10>
        string[] strings = { "a", "b", "c", "d", "e" };

        var query = strings.AlternateElements();

        foreach (var element in query)
        {
            Console.WriteLine(element);
        }
        /*
         This code produces the following output:
        
         a
         c
         e
        */
        //</Snippet10>

        Console.ReadKey();
    }
}
