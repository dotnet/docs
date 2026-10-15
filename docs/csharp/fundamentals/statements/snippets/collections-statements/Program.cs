namespace CollectionStatements;

public static class Program
{
    public static void Main()
    {
        ChooseCollectionExample();
        ArraysExample();
        ArrayElementUpdateExample();
        ListChangesExample();
        ListInsertRemoveExample();
        DictionaryLookupExample();
        DictionaryUpdatesExample();
        CollectionExpressionsExample();
        IndexesAndRangesExample();
    }

    private static void ChooseCollectionExample()
    {
        // <ChooseCollection>
        string[] sprintPlan = ["design", "code", "test"];
        List<string> backlog = ["design", "code"];
        Dictionary<string, int> priorities = new()
        {
            ["docs"] = 2,
            ["tests"] = 1
        };

        backlog.Add("test");

        Console.WriteLine($"Array: {string.Join(", ", sprintPlan)}");
        Console.WriteLine($"List count: {backlog.Count}");
        Console.WriteLine($"Priority for docs: {priorities["docs"]}");
        // This example produces the following output:
        //
        //    Array: design, code, test
        //    List count: 3
        //    Priority for docs: 2
        //
        // </ChooseCollection>
    }

    private static void ArraysExample()
    {
        // <Arrays>
        string[] stages = ["design", "code", "test", "review"];

        Console.WriteLine($"First: {stages[0]}");
        Console.WriteLine($"test index: {Array.IndexOf(stages, "test")}");
        // This example produces the following output:
        //
        //    First: design
        //    test index: 2
        //
        // </Arrays>
    }

    private static void ArrayElementUpdateExample()
    {
        // <ArrayElementUpdate>
        string[] stages = ["design", "code", "test"];

        stages[0] = "plan";

        Console.WriteLine(string.Join(", ", stages));
        Console.WriteLine($"Length: {stages.Length}");
        // This example produces the following output:
        //
        //    plan, code, test
        //    Length: 3
        //
        // </ArrayElementUpdate>
    }

    private static void ListChangesExample()
    {
        // <ListChanges>
        List<string> workItems = ["design", "code", "test"];

        workItems.Add("review");
        workItems.Remove("code");
        workItems[1] = "verify";

        Console.WriteLine(string.Join(", ", workItems));
        Console.WriteLine($"Has review: {workItems.Contains("review")}");
        Console.WriteLine($"Index of verify: {workItems.IndexOf("verify")}");
        // This example produces the following output:
        //
        //    design, verify, review
        //    Has review: True
        //    Index of verify: 1
        //
        // </ListChanges>
    }

    private static void ListInsertRemoveExample()
    {
        // <ListInsertRemove>
        List<string> workItems = ["design", "test"];

        workItems.Insert(1, "code");
        Console.WriteLine($"Insert middle: {string.Join(", ", workItems)}");

        workItems.Insert(0, "plan");
        Console.WriteLine($"Insert front: {string.Join(", ", workItems)}");

        workItems.InsertRange(workItems.Count, ["review", "deploy"]);
        Console.WriteLine($"Insert range at end: {string.Join(", ", workItems)}");

        workItems.RemoveAt(workItems.Count - 1);
        Console.WriteLine($"Remove end: {string.Join(", ", workItems)}");

        workItems.RemoveAt(2);
        Console.WriteLine($"Remove middle: {string.Join(", ", workItems)}");

        workItems.RemoveAt(0);
        Console.WriteLine($"Remove front: {string.Join(", ", workItems)}");
        // This example produces the following output:
        //
        //    Insert middle: design, code, test
        //    Insert front: plan, design, code, test
        //    Insert range at end: plan, design, code, test, review, deploy
        //    Remove end: plan, design, code, test, review
        //    Remove middle: plan, design, test, review
        //    Remove front: design, test, review
        //
        // </ListInsertRemove>
    }

    private static void DictionaryLookupExample()
    {
        // <DictionaryLookup>
        Dictionary<string, int> priorities = new()
        {
            ["docs"] = 2,
            ["tests"] = 1
        };

        priorities["review"] = 3;
        priorities.Remove("review");

        if (priorities.TryGetValue("docs", out int docsPriority))
        {
            Console.WriteLine($"docs priority: {docsPriority}");
        }
        else
        {
            Console.WriteLine("docs missing");
        }

        if (priorities.TryGetValue("deploy", out int deployPriority))
        {
            Console.WriteLine($"deploy priority: {deployPriority}");
        }
        else
        {
            Console.WriteLine("deploy missing");
        }

        Console.WriteLine($"count: {priorities.Count}");
        // This example produces the following output:
        //
        //    docs priority: 2
        //    deploy missing
        //    count: 2
        //
        // </DictionaryLookup>
    }

    private static void DictionaryUpdatesExample()
    {
        // <DictionaryUpdates>
        Dictionary<string, int> priorities = new()
        {
            ["docs"] = 2,
            ["tests"] = 1
        };

        priorities["docs"] = 1;

        if (priorities.TryGetValue("tests", out int testsPriority))
        {
            priorities["tests"] = testsPriority + 1;
        }

        priorities["deploy"] = 3;

        Console.WriteLine($"docs priority: {priorities["docs"]}");
        Console.WriteLine($"tests priority: {priorities["tests"]}");
        Console.WriteLine($"deploy priority: {priorities["deploy"]}");
        // This example produces the following output:
        //
        //    docs priority: 1
        //    tests priority: 2
        //    deploy priority: 3
        //
        // </DictionaryUpdates>
    }

    private static void CollectionExpressionsExample()
    {
        // <CollectionExpressions>
        string[] planned = ["design", "code"];
        // The spread element .. planned copies each element from planned.
        string[] upcoming = [.. planned, "test"];
        List<string> blocked = ["docs"];

        Console.WriteLine($"Upcoming: {string.Join(", ", upcoming)}");
        Console.WriteLine($"Blocked: {string.Join(", ", blocked)}");
        // This example produces the following output:
        //
        //    Upcoming: design, code, test
        //    Blocked: docs
        //
        // </CollectionExpressions>
    }

    private static void IndexesAndRangesExample()
    {
        // <IndexesAndRanges>
        string[] phases = ["design", "code", "test", "deploy"];
        List<string> checklist = ["design", "test", "review"];

        Console.WriteLine($"Last: {phases[^1]}");
        Console.WriteLine($"Middle: {string.Join(", ", phases[1..3])}");
        Console.WriteLine($"Last two: {string.Join(", ", phases[^2..])}");
        Console.WriteLine($"Without ends: {string.Join(", ", phases[1..^1])}");
        Console.WriteLine($"First two: {string.Join(", ", phases[..2])}");
        Console.WriteLine($"From third: {string.Join(", ", phases[2..])}");
        Console.WriteLine($"All phases: {string.Join(", ", phases[..])}");
        Console.WriteLine($"List last: {checklist[^1]}");
        Console.WriteLine($"List first two: {string.Join(", ", checklist[0..2])}");
        // This example produces the following output:
        //
        //    Last: deploy
        //    Middle: code, test
        //    Last two: test, deploy
        //    Without ends: code, test
        //    First two: design, code
        //    From third: test, deploy
        //    All phases: design, code, test, deploy
        //    List last: review
        //    List first two: design, test
        //
        // </IndexesAndRanges>
    }
}
