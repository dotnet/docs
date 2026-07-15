namespace CollectionStatements;

public static class Program
{
    public static void Main()
    {
        ChooseCollectionExample();
        ArraysExample();
        ListChangesExample();
        DictionaryLookupExample();
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

        Console.WriteLine($"Array: {string.Join(", ", sprintPlan)}"); // => Array: design, code, test
        Console.WriteLine($"List count: {backlog.Count}"); // => List count: 3
        Console.WriteLine($"Priority for docs: {priorities["docs"]}"); // => Priority for docs: 2
        // </ChooseCollection>
    }

    private static void ArraysExample()
    {
        // <Arrays>
        string[] stages = ["design", "code", "test", "review"];

        Console.WriteLine($"First: {stages[0]}"); // => First: design
        Console.WriteLine($"test index: {Array.IndexOf(stages, "test")}"); // => test index: 2
        // </Arrays>
    }

    private static void ListChangesExample()
    {
        // <ListChanges>
        List<string> workItems = ["design", "code", "test"];

        workItems.Add("review");
        workItems.Remove("code");

        Console.WriteLine(string.Join(", ", workItems)); // => design, test, review
        Console.WriteLine($"Has review: {workItems.Contains("review")}"); // => Has review: True
        Console.WriteLine($"Index of test: {workItems.IndexOf("test")}"); // => Index of test: 1
        // </ListChanges>
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
            Console.WriteLine($"docs priority: {docsPriority}"); // => docs priority: 2
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
            Console.WriteLine("deploy missing"); // => deploy missing
        }

        Console.WriteLine($"count: {priorities.Count}"); // => count: 2
        // </DictionaryLookup>
    }

    private static void CollectionExpressionsExample()
    {
        // <CollectionExpressions>
        string[] planned = ["design", "code"];
        string[] upcoming = [.. planned, "test"];
        List<string> blocked = ["docs"];

        Console.WriteLine($"Upcoming: {string.Join(", ", upcoming)}"); // => Upcoming: design, code, test
        Console.WriteLine($"Blocked: {string.Join(", ", blocked)}"); // => Blocked: docs
        // </CollectionExpressions>
    }

    private static void IndexesAndRangesExample()
    {
        // <IndexesAndRanges>
        string[] phases = ["design", "code", "test", "deploy"];
        List<string> checklist = ["design", "test", "review"];

        Console.WriteLine($"Last: {phases[^1]}"); // => Last: deploy
        Console.WriteLine($"Middle: {string.Join(", ", phases[1..3])}"); // => Middle: code, test
        Console.WriteLine($"List last: {checklist[^1]}"); // => List last: review
        // </IndexesAndRanges>
    }
}

