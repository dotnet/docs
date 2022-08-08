//using System;  prefer to fully qualified all but the most extremely long references

//<Snippet1>
class TempRecord
{
    // Array of temperature values
    private float[] temps = new float[10] { 56.2F, 56.7F, 56.5F, 56.9F, 58.8F,
                                            61.3F, 65.9F, 62.1F, 59.2F, 57.5F };

    // To enable client code to validate input
    // when accessing your indexer.
    public int Length
    {
        get { return temps.Length; }
    }
    // Indexer declaration.
    // If index is out of range, the temps array will throw the exception.
    public float this[int index]
    {
        get
        {
            return temps[index];
        }

        set
        {
            temps[index] = value;
        }
    }
}

class MainClass
{
    static void Main()
    {
        TempRecord tempRecord = new TempRecord();
        // Use the indexer's set accessor
        tempRecord[3] = 58.3F;
        tempRecord[5] = 60.1F;

        // Use the indexer's get accessor
        for (int i = 0; i < 10; i++)
        {
            System.Console.WriteLine("Element #{0} = {1}", i, tempRecord[i]);
        }

        // Keep the console window open in debug mode.
        System.Console.WriteLine("Press any key to exit.");
        System.Console.ReadKey();
    }
}
/* Output:
        Element #0 = 56.2
        Element #1 = 56.7
        Element #2 = 56.5
        Element #3 = 58.3
        Element #4 = 58.8
        Element #5 = 60.1
        Element #6 = 65.9
        Element #7 = 62.1
        Element #8 = 59.2
        Element #9 = 57.5
    */
//</Snippet1>

//<Snippet2>
// Using a string as an indexer value
class DayCollection
{
    string[] days = { "Sun", "Mon", "Tues", "Wed", "Thurs", "Fri", "Sat" };

    // Indexer with only a get accessor with the expression-bodied definition:
    public int this[string day] => FindDayIndex(day);

    private int FindDayIndex(string day)
    {
        for (int j = 0; j < days.Length; j++)
        {
            if (days[j] == day)
            {
                return j;
            }
        }
        throw new System.ArgumentOutOfRangeException(
            nameof(day),
            $"Day {day} is not supported. Day input must be in the form \"Sun\", \"Mon\", etc");
    }
}

class Program
{
    static void Main()
    {
        var week = new DayCollection();
        System.Console.WriteLine(week["Fri"]);

        try
        {
            System.Console.WriteLine(week["Made-up day"]);
        }
        catch (System.ArgumentOutOfRangeException e)
        {
            System.Console.WriteLine($"Not supported input: {e.Message}");
        }
    }
    // Output:
    // 5
    // Not supported input: Day Made-up day is not supported. Day input must be in the form "Sun", "Mon", etc (Parameter 'day')
}
//</Snippet2>

namespace WrapProgram
{
    //<Snippet9>
    class SampleCollection<T>
    {
        // Declare an array to store the data elements.
        private T[] arr = new T[100];

        // Define the indexer, which will allow client code
        // to use [] notation on the class instance itself.
        // (See line 2 of code in Main below.)
        public T this[int i]
        {
            get
            {
                // This indexer is very simple, and just returns or sets
                // the corresponding element from the internal array.
                return arr[i];
            }
            set
            {
                arr[i] = value;
            }
        }
    }

    // This class shows how client code uses the indexer.
    class Program
    {
        static void Main(string[] args)
        {
            // Declare an instance of the SampleCollection type.
            SampleCollection<string> stringCollection = new SampleCollection<string>();

            // Use [] notation on the type.
            stringCollection[0] = "Hello, World";
            System.Console.WriteLine(stringCollection[0]);
        }
    }
    // Output:
    // Hello, World.
    //</Snippet9>
}
