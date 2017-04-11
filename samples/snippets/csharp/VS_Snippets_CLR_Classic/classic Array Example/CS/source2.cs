// <snippet3>
using System;
using System.Collections;

public class ExampleClass
{
    public sealed class Path
    {
        private Path(){}

        private static char[] badChars = {'\"', '<', '>'};

        public static char[] GetInvalidPathChars()
        {
            return badChars;
        }
    }

    public static void Main()
    {
        // The following code displays the elements of the
        // array as expected.
        foreach(char c in Path.GetInvalidPathChars())
        {
            Console.Write(c);
        }
        Console.WriteLine();

        // The following code sets all the values to A.
        Path.GetInvalidPathChars()[0] = 'A';
        Path.GetInvalidPathChars()[1] = 'A';
        Path.GetInvalidPathChars()[2] = 'A';

        // The following code displays the elements of the array to the
        // console. Note that the values have changed.
        foreach(char c in Path.GetInvalidPathChars())
        {
            Console.Write(c);
        }
    }
}
// </snippet3>

public class DummyColl
{
    public ArrayList myObj;

    public DummyColl()
    {
        myObj = new ArrayList(0);
    }
}

public class Path2
{
    private static char[] badChars = {'\"', '<', '>'};

    // <snippet4>
    public static char[] GetInvalidPathChars()
    {
        return (char[])badChars.Clone();
    }
    // </snippet4>

    public static void DoSomething(object objItem)
    {
    }

    public static void Dummy(DummyColl obj)
    {
        // <snippet5>
        for (int i = 0; i < obj.myObj.Count; i++)
        {
            DoSomething(obj.myObj[i]);
        }
        // </snippet5>
    }
}

public class ExampleClass2
{
    // <snippet6>
    public sealed class Path
    {
        private Path(){}
        public static readonly char[] InvalidPathChars = {'\"', '<', '>','|'};
    }
    // </snippet6>

    public class PathTester
    {
        public void Dummy()
        {
            // <snippet7>
            //The following code can be used to change the values in the array.
            Path.InvalidPathChars[0] = 'A';
            // </snippet7>
        }

        public string SomeOtherFunc()
        {
            return new string('A', 128);
        }

        // <snippet8>
        public void DoSomething()
        {
            string s = SomeOtherFunc();
            if (s.Length > 0)
            {
                // Do something else.
            }
        }
        // </snippet8>
    }
}
