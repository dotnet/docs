


//<Snippet8>
// Declare the collection:
public class SampleCollection
{
    public int[] items;

    public SampleCollection()
    {
        items = new int[5] { 5, 4, 7, 9, 3 };
    }

    public System.Collections.IEnumerable BuildCollection()
    {
        for (int i = 0; i < items.Length; i++)
        {
            yield return items[i];
        }
    }
}

class MainClass
{
    static void Main()
    {
        SampleCollection col = new SampleCollection();

        // Display the collection items:
        System.Console.WriteLine("Values in the collection are:");
        foreach (int i in col.BuildCollection())
        {
            System.Console.Write(i + " ");
        }

        // Keep the console window open in debug mode.
        System.Console.WriteLine("Press any key to exit.");
        System.Console.ReadKey();
    }
}
/* Output:
    Values in the collection are:
    5 4 7 9 3        
*/
//</Snippet8>


public class ListClass : System.Collections.IEnumerable
{
   // private int max = 0;

    //<Snippet2>
    public System.Collections.IEnumerator GetEnumerator()
    {
        for (int i = 0; i < 10; i++)
        {
            yield return i;
        }
    }
    //</Snippet2>


    //<Snippet3>
    static void Main()
    {
        ListClass listClass1 = new ListClass();

        foreach (int i in listClass1)
        {
            System.Console.Write(i + " ");
        }
        // Output: 0 1 2 3 4 5 6 7 8 9
    }
    //</Snippet3>


    //<Snippet4>
    // Implementing the enumerable pattern
    public System.Collections.IEnumerable SampleIterator(int start, int end)
    {
        for (int i = start; i <= end; i++)
        {
            yield return i;
        }
    }
    //</Snippet4>


    void test()
    {
        //<Snippet5>
        ListClass test = new ListClass();

        foreach (int n in test.SampleIterator(1, 10))
        {
            System.Console.Write(n + " ");
        }
        // Output: 1 2 3 4 5 6 7 8 9 10
        //</Snippet5>
    }
}


public class TestClass : System.Collections.IEnumerable
{
    //<Snippet6>
    public System.Collections.IEnumerator GetEnumerator()
    {
        yield return "With an iterator, ";
        yield return "more than one ";
        yield return "value can be returned";
        yield return ".";
    }
    //</Snippet6>


    void test()
    {
        //<Snippet7>
        foreach (string element in new TestClass())
        {
            System.Console.Write(element);
        }
        // Output: With an iterator, more than one value can be returned.
        //</Snippet7>
    }
}


//<Snippet1>
public class DaysOfTheWeek : System.Collections.IEnumerable
{
    string[] days = { "Sun", "Mon", "Tue", "Wed", "Thr", "Fri", "Sat" };

    public System.Collections.IEnumerator GetEnumerator()
    {
        for (int i = 0; i < days.Length; i++)
        {
            yield return days[i];
        }
    }
}

class TestDaysOfTheWeek
{
    static void Main()
    {
        // Create an instance of the collection class
        DaysOfTheWeek week = new DaysOfTheWeek();

        // Iterate with foreach
        foreach (string day in week)
        {
            System.Console.Write(day + " ");
        }
    }
}
// Output: Sun Mon Tue Wed Thr Fri Sat
//</Snippet1>

//<Snippet10>
namespace UsingIterators
{
    class Program
    {
        static void Main()
        {
            // Using a simple iterator.
            ListClass listClass1 = new ListClass();

            foreach (int i in listClass1)
            {
                System.Console.Write(i + " ");
            }
            // Output: 0 1 2 3 4 5 6 7 8 9
            System.Console.WriteLine();


            // Using a named iterator.
            ListClass test = new ListClass();

            foreach (int n in test.SampleIterator(1, 10))
            {
                System.Console.Write(n + " ");
            }
            // Output: 1 2 3 4 5 6 7 8 9 10
            System.Console.WriteLine();


            // Using multiple yield statements.
            foreach (string element in new TestClass())
            {
                System.Console.Write(element);
            }
            // Output: With an iterator, more than one value can be returned.
            System.Console.WriteLine();

        }
    }

    class ListClass : System.Collections.IEnumerable
    {

        public System.Collections.IEnumerator GetEnumerator()
        {
            for (int i = 0; i < 10; i++)
            {
                yield return i;
            }
        }

        // Implementing the enumerable pattern
        public System.Collections.IEnumerable SampleIterator(int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                yield return i;
            }
        }
    }

    class TestClass : System.Collections.IEnumerable
    {
        public System.Collections.IEnumerator GetEnumerator()
        {
            yield return "With an iterator, ";
            yield return "more than one ";
            yield return "value can be returned";
            yield return ".";
        }
    }
}
//</Snippet10>
