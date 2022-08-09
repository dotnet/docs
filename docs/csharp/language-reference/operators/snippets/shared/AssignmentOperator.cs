namespace operators;

public static class AssignmentOperator
{
    public static void Examples()
    {
        Simple();
        RefAssignment();
    }

    private static void Simple()
    {
        // <SnippetSimple>
        var numbers = new List<double>() { 1.0, 2.0, 3.0 };

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
}
