namespace operators;

public static class SubtractionOperator
{
    public static void Examples()
    {
        DelegateRemoval();
        DelegateRemovalNoChange();
        DelegateRemovalAndNull();
        SubtractAndAssign();
    }

    private static void DelegateRemoval()
    {
        // <SnippetDelegateRemoval>
        Action a = () => Console.Write("a");
        Action b = () => Console.Write("b");

        var abbaab = a + b + b + a + a + b;
        abbaab();  // output: abbaab
        Console.WriteLine();

        var ab = a + b;
        var abba = abbaab - ab;
        abba();  // output: abba
        Console.WriteLine();

        var nihil = abbaab - abbaab;
        Console.WriteLine(nihil is null);  // output: True
        // </SnippetDelegateRemoval>
    }

    private static void DelegateRemovalNoChange()
    {
        // <SnippetDelegateRemovalNoChange>
        Action a = () => Console.Write("a");
        Action b = () => Console.Write("b");

        var abbaab = a + b + b + a + a + b;
        var aba = a + b + a;

        var first = abbaab - aba;
        first();  // output: abbaab
        Console.WriteLine();
        Console.WriteLine(object.ReferenceEquals(abbaab, first));  // output: True

        Action a2 = () => Console.Write("a");
        var changed = aba - a;
        changed();  // output: ab
        Console.WriteLine();
        var unchanged = aba - a2;
        unchanged();  // output: aba
        Console.WriteLine();
        Console.WriteLine(object.ReferenceEquals(aba, unchanged));  // output: True
        // </SnippetDelegateRemovalNoChange>
    }

    private static void DelegateRemovalAndNull()
    {
        // <SnippetDelegateRemovalAndNull>
        Action a = () => Console.Write("a");

        var nothing = null - a;
        Console.WriteLine(nothing is null);  // output: True

        var first = a - null;
        a();  // output: a
        Console.WriteLine();
        Console.WriteLine(object.ReferenceEquals(first, a));  // output: True
        // </SnippetDelegateRemovalAndNull>
    }

    private static void SubtractAndAssign()
    {
        // <SnippetSubtractAndAssign>
        int i = 5;
        i -= 9;
        Console.WriteLine(i);
        // Output: -4

        Action a = () => Console.Write("a");
        Action b = () => Console.Write("b");
        var printer = a + b + a;
        printer();  // output: aba

        Console.WriteLine();
        printer -= a;
        printer();  // output: ab
        // </SnippetSubtractAndAssign>
        Console.WriteLine();
    }
}
