namespace LinqStatements;

public static class Program
{
    public static void Main()
    {
        QuerySyntaxExample();
        MethodSyntaxExample();
        LambdaExpressionsExample();
        CommonOperatorsExample();
        GroupByExample();
        DeferredExecutionExample();
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
}

