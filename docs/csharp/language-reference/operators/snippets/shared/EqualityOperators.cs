namespace operators;

public static class EqualityOperators
{
    public static void Examples()
    {
        Console.WriteLine("Value types:");
        ValueTypesEquality();

        Console.WriteLine("Strings:");
        StringEquality();

        Console.WriteLine("Reference types:");
        ReferenceTypesEquality.Main();

        Console.WriteLine("Record types:");
        RecordTypesEquality.Main();

        Console.WriteLine("Delegate types:");
        DelegateEquality();
        IdenticalLambdasNotEqual();

        Console.WriteLine("Non equality:");
        NonEquality();
    }

    private static void ValueTypesEquality()
    {
        // <SnippetValueTypesEquality>
        int a = 1 + 2 + 3;
        int b = 6;
        Console.WriteLine(a == b);  // output: True

        char c1 = 'a';
        char c2 = 'A';
        Console.WriteLine(c1 == c2);  // output: False
        Console.WriteLine(c1 == char.ToLower(c2));  // output: True
        // </SnippetValueTypesEquality>
    }

    private static void StringEquality()
    {
        // <SnippetStringEquality>
        string s1 = "hello!";
        string s2 = "HeLLo!";
        Console.WriteLine(s1 == s2.ToLower());  // output: True

        string s3 = "Hello!";
        Console.WriteLine(s1 == s3);  // output: False
        // </SnippetStringEquality>
    }

    // Rationale for the structure of the next snippet.
    // A method cannot contain a class definition. Thus, a standard way to include snippet doesn't work.
    // We want snippets to be interactive. Thus, the whole snippet has a structure of the console program.
    // (Running the code without the ReferenceTypesEquality class doesn't produce any output in the interactive Output control.)

    // <SnippetReferenceTypesEquality>
    public class ReferenceTypesEquality
    {
        public class MyClass
        {
            private int id;

            public MyClass(int id) => this.id = id;
        }

        public static void Main()
        {
            var a = new MyClass(1);
            var b = new MyClass(1);
            var c = a;
            Console.WriteLine(a == b);  // output: False
            Console.WriteLine(a == c);  // output: True
        }
    }
    // </SnippetReferenceTypesEquality>

    private static void NonEquality()
    {
        // <SnippetNonEquality>
        int a = 1 + 1 + 2 + 3;
        int b = 6;
        Console.WriteLine(a != b);  // output: True

        string s1 = "Hello";
        string s2 = "Hello";
        Console.WriteLine(s1 != s2);  // output: False

        object o1 = 1;
        object o2 = 1;
        Console.WriteLine(o1 != o2);  // output: True
        // </SnippetNonEquality>
    }

    private static void DelegateEquality()
    {
        // <SnippetDelegateEquality>
        Action a = () => Console.WriteLine("a");

        Action b = a + a;
        Action c = a + a;
        Console.WriteLine(object.ReferenceEquals(b, c));  // output: False
        Console.WriteLine(b == c);  // output: True
        // </SnippetDelegateEquality>

        // <SnippetCheckReceiver>
        var o1 = new object();
        var o2 = new object();
        var d1 = o1.ToString;
        var d2 = o2.ToString;
        Console.WriteLine(object.ReferenceEquals(d1, d2));  // output: False
        Console.WriteLine(d1 == d2);  // output: False (different receivers)
        // </SnippetCheckReceiver>
    }

    private static void IdenticalLambdasNotEqual()
    {
        // <SnippetIdenticalLambdas>
        Action a = () => Console.WriteLine("a");
        Action b = () => Console.WriteLine("a");

        Console.WriteLine(a == b);  // output: False
        Console.WriteLine(a + b == a + b);  // output: True
        Console.WriteLine(b + a == a + b);  // output: False
        // </SnippetIdenticalLambdas>
    }

    // <RecordTypesEquality>
    public class RecordTypesEquality
    {
        public record Point(int X, int Y, string Name);
        public record TaggedNumber(int Number, List<string> Tags);

        public static void Main()
        {
            var p1 = new Point(2, 3, "A");
            var p2 = new Point(1, 3, "B");
            var p3 = new Point(2, 3, "A");

            Console.WriteLine(p1 == p2);  // output: False
            Console.WriteLine(p1 == p3);  // output: True

            var n1 = new TaggedNumber(2, new List<string>() { "A" });
            var n2 = new TaggedNumber(2, new List<string>() { "A" });
            Console.WriteLine(n1 == n2);  // output: False
        }
    }
    // </RecordTypesEquality>
}
