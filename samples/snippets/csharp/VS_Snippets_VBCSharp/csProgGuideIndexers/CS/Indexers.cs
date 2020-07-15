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

namespace Wrap2
{
    //<Snippet5>
    public class BaseClass
    {
        private string _name = "Name-BaseClass";
        private string _id = "ID-BaseClass";

        public string Name
        {
            get { return _name; }
            set { }
        }

        public string Id
        {
            get { return _id; }
            set { }
        }
    }

    public class DerivedClass : BaseClass
    {
        private string _name = "Name-DerivedClass";
        private string _id = "ID-DerivedClass";

        new public string Name
        {
            get
            {
                return _name;
            }

            // Using "protected" would make the set accessor not accessible.
            set
            {
                _name = value;
            }
        }

        // Using private on the following property hides it in the Main Class.
        // Any assignment to the property will use Id in BaseClass.
        new private string Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }
    }

    class MainClass
    {
        static void Main()
        {
            BaseClass b1 = new BaseClass();
            DerivedClass d1 = new DerivedClass();

            b1.Name = "Mary";
            d1.Name = "John";

            b1.Id = "Mary123";
            d1.Id = "John123";  // The BaseClass.Id property is called.

            System.Console.WriteLine("Base: {0}, {1}", b1.Name, b1.Id);
            System.Console.WriteLine("Derived: {0}, {1}", d1.Name, d1.Id);

            // Keep the console window open in debug mode.
            System.Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }
    }
    /* Output:
        Base: Name-BaseClass, ID-BaseClass
        Derived: John, ID-BaseClass
    */
    //</Snippet5>
}

class Test
{

    //<Snippet6>
    private string _name = "Hello";

    public string Name
    {
        get
        {
            return _name;
        }
        protected set
        {
            _name = value;
        }
    }
    //</Snippet6>
}

//<Snippet7>
public class Parent
{
    public virtual int TestProperty
    {
        // Notice the accessor accessibility level.
        protected set { }

        // No access modifier is used here.
        get { return 0; }
    }
}
public class Kid : Parent
{
    public override int TestProperty
    {
        // Use the same accessibility level as in the overridden accessor.
        protected set { }

        // Cannot use access modifier here.
        get { return 0; }
    }
}
//</Snippet7>

namespace WrapISomeInterface
{
    //<Snippet8>
    public interface ISomeInterface
    {
        int TestProperty
        {
            // No access modifier allowed here
            // because this is an interface.
            get;
        }
    }

    public class TestClass : ISomeInterface
    {
        public int TestProperty
        {
            // Cannot use access modifier here because
            // this is an interface implementation.
            get { return 10; }

            // Interface property does not have set accessor,
            // so access modifier is allowed.
            protected set { }
        }
    }
    //</Snippet8>
}

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
