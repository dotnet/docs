namespace operators;

public static class AssignmentOperator
{
    public static void Examples()
    {
        Simple();
        RefAssignment();
        // <Usage>
        string msg = "Hi";
        RefReassignAndModify(ref msg);
        Console.WriteLine(msg); // Output: Hi!
        // </Usage>
    }

    private static void Simple()
    {
        // <SnippetSimple>
        List<double> numbers = [1.0, 2.0, 3.0];

        Console.WriteLine(numbers.Capacity);
        numbers.Capacity = 100;
        Console.WriteLine(numbers.Capacity);
        // Output:
        // 4
        // 100

        int newFirstElement;
        double originalFirstElement = numbers[0];
        newFirstElement = 5;
        numbers[0] = newFirstElement;
        Console.WriteLine(originalFirstElement);
        Console.WriteLine(numbers[0]);
        // Output:
        // 1
        // 5
        // </SnippetSimple>
    }

    private static void RefAssignment()
    {
        // <SnippetRefAssignment>
        void Display(double[] s) => Console.WriteLine(string.Join(" ", s));

        double[] arr = { 0.0, 0.0, 0.0 };
        Display(arr);

        ref double arrayElement = ref arr[0];
        arrayElement = 3.0;
        Display(arr);

        arrayElement = ref arr[arr.Length - 1];
        arrayElement = 5.0;
        Display(arr);
        // Output:
        // 0 0 0
        // 3 0 0
        // 3 0 5
        // </SnippetRefAssignment>
    }

    // <SnippetRefReassignAndModify>
    private static void RefReassignAndModify(scoped ref string s)
    {
        string sLocal = "Hello";
        Console.WriteLine(sLocal);  // Output: Hello

        s = ref sLocal;
        s = "World";
        Console.WriteLine(s);  // Output: World
        // </SnippetRefReassignAndModify>
    }
}
