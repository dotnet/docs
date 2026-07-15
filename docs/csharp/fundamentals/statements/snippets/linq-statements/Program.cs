namespace LinqStatements;

public static class Program
{
    public static void Main()
    {
        QuerySyntaxExample();
        MethodSyntaxExample();
        QuerySyntaxClearerExample();
        MethodSyntaxClearerExample();
        LambdaExpressionsExample();
        QuerySyntaxLambdaExample();
        CommonOperatorsExample();
        GroupByExample();
        DeferredExecutionExample();
        ImmediateExecutionExample();
        ComposeQuerySyntaxExample();
        ComposeMethodSyntaxExample();
        ComposeWithCachingExample();
    }

    private static void QuerySyntaxExample()
    {
        // <QuerySyntax>
        string[] names = ["Ana", "Ben", "Cleo", "Dara"];

        IEnumerable<string> query =
            from name in names
            where name.Length >= 4
            orderby name
            select name;

        foreach (string name in query)
        {
            Console.WriteLine(name); // => Cleo, then Dara
        }
        // </QuerySyntax>
    }

    private static void MethodSyntaxExample()
    {
        // <MethodSyntax>
        string[] names = ["Ana", "Ben", "Cleo", "Dara"];

        IEnumerable<string> query = names
            .Where(name => name.Length >= 4)
            .OrderBy(name => name)
            .Select(name => name);

        foreach (string name in query)
        {
            Console.WriteLine(name); // => Cleo, then Dara
        }
        // </MethodSyntax>
    }

    private static void QuerySyntaxClearerExample()
    {
        // <QuerySyntaxClearer>
        (string Area, int Priority)[] workItems =
        [
            ("docs", 2),
            ("tests", 1),
            ("deploy", 4),
            ("api", 1)
        ];

        IEnumerable<string> nextItems =
            from item in workItems
            let label = $"{item.Area}: P{item.Priority}"
            where item.Priority <= 2
            orderby item.Priority, item.Area
            select label;

        foreach (string item in nextItems)
        {
            Console.WriteLine(item); // => api: P1, then tests: P1, then docs: P2
        }
        // </QuerySyntaxClearer>
    }

    private static void MethodSyntaxClearerExample()
    {
        // <MethodSyntaxClearer>
        List<string> workItems = ["design", "docs", "deploy", "review"];

        int count = workItems.Count(item => item.StartsWith('d'));

        Console.WriteLine($"Starts with d: {count}"); // => Starts with d: 3
        // </MethodSyntaxClearer>
    }

    private static void LambdaExpressionsExample()
    {
        // <LambdaExpressions>
        string[] names = ["Ana", "Ben", "Cleo"];

        IEnumerable<string> shortNames = names
            .Where(name => name.Length == 3)
            .Select(name => name.ToUpperInvariant());

        foreach (string name in shortNames)
        {
            Console.WriteLine(name); // => ANA, then BEN
        }
        // </LambdaExpressions>
    }

    private static void QuerySyntaxLambdaExample()
    {
        // <QuerySyntaxLambda>
        string[] workItems = ["docs", "test", "deploy"];

        IEnumerable<string> querySyntax =
            from item in workItems
            where item.Length == 4
            select item;

        IEnumerable<string> methodSyntax =
            workItems.Where(item => item.Length == 4);

        foreach (string item in querySyntax)
        {
            Console.WriteLine($"Query syntax: {item}"); // => Query syntax: docs, then Query syntax: test
        }

        foreach (string item in methodSyntax)
        {
            Console.WriteLine($"Method syntax: {item}"); // => Method syntax: docs, then Method syntax: test
        }
        // </QuerySyntaxLambda>
    }

    private static void CommonOperatorsExample()
    {
        // <CommonOperators>
        Dictionary<string, int> priorities = new()
        {
            ["Docs"] = 2,
            ["Code"] = 1,
            ["Test"] = 3,
            ["Deploy"] = 4
        };

        IEnumerable<string> plannedWork = priorities
            .Where(workItem => workItem.Value <= 3)
            .OrderBy(workItem => workItem.Value)
            .Select(workItem => $"{workItem.Key}: {workItem.Value}");

        foreach (string item in plannedWork)
        {
            Console.WriteLine(item); // => Code: 1, then Docs: 2, then Test: 3
        }
        // </CommonOperators>
    }

    private static void GroupByExample()
    {
        // <GroupBy>
        string[] labels = ["api", "auth", "docs", "deploy"];

        IEnumerable<IGrouping<char, string>> groups = labels.GroupBy(label => label[0]);

        foreach (IGrouping<char, string> group in groups)
        {
            Console.WriteLine($"{group.Key}: {string.Join(", ", group)}"); // => a: api, auth, then d: docs, deploy
        }
        // </GroupBy>
    }

    private static void DeferredExecutionExample()
    {
        // <DeferredExecution>
        List<string> workItems = ["design", "docs"];

        IEnumerable<string> query = workItems.Where(item => item.StartsWith('d'));

        workItems.Add("deploy");

        foreach (string item in query)
        {
            Console.WriteLine(item); // => design, then docs, then deploy
        }
        // </DeferredExecution>
    }

    private static void ImmediateExecutionExample()
    {
        // <ImmediateExecution>
        List<string> workItems = ["design", "docs"];

        IEnumerable<string> query = workItems.Where(item => item.StartsWith('d'));

        int count = query.Count();
        Console.WriteLine($"Count before add: {count}"); // => Count before add: 2

        workItems.Add("deploy");

        Console.WriteLine($"Stored count: {count}"); // => Stored count: 2
        Console.WriteLine($"Current count: {query.Count()}"); // => Current count: 3
        // </ImmediateExecution>
    }

    private static void ComposeQuerySyntaxExample()
    {
        // <ComposeQuerySyntax>
        (string Title, int Priority, bool IsOpen)[] items =
        [
            ("docs", 2, true),
            ("tests", 1, true),
            ("deploy", 3, false),
            ("api", 1, true)
        ];

        IEnumerable<(string Title, int Priority, bool IsOpen)> openItems =
            from item in items
            where item.IsOpen
            select item;

        IEnumerable<string> topOpenItems =
            from item in openItems
            where item.Priority == 1
            orderby item.Title
            select item.Title;

        foreach (string title in topOpenItems)
        {
            Console.WriteLine(title); // => api, then tests
        }
        // </ComposeQuerySyntax>
    }

    private static void ComposeMethodSyntaxExample()
    {
        // <ComposeMethodSyntax>
        (string Title, string Area, bool IsOpen)[] items =
        [
            ("write docs", "docs", true),
            ("fix tests", "tests", true),
            ("deploy site", "deploy", false)
        ];

        bool onlyDocs = true;

        IEnumerable<(string Title, string Area, bool IsOpen)> query =
            items.Where(item => item.IsOpen);

        if (onlyDocs)
        {
            query = query.Where(item => item.Area == "docs");
        }

        foreach (string title in query.Select(item => item.Title))
        {
            Console.WriteLine(title); // => write docs
        }
        // </ComposeMethodSyntax>
    }

    private static void ComposeWithCachingExample()
    {
        // <ComposeWithCaching>
        List<(string Title, int Priority, bool IsOpen)> items =
        [
            ("docs", 2, true),
            ("tests", 1, true),
            ("deploy", 3, false)
        ];

        List<(string Title, int Priority, bool IsOpen)> openItems = items
            .Where(item => item.IsOpen)
            .ToList();

        items.Add(("api", 1, true));

        IEnumerable<string> cachedTopOpenItems = openItems
            .Where(item => item.Priority == 1)
            .OrderBy(item => item.Title)
            .Select(item => item.Title);

        foreach (string title in cachedTopOpenItems)
        {
            Console.WriteLine(title); // => tests
        }
        // </ComposeWithCaching>
    }
}
