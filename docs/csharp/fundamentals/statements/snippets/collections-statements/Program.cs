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

    private static void ArrayElementUpdateExample()
    {
        // <ArrayElementUpdate>
        string[] stages = ["design", "code", "test"];

        stages[0] = "plan";

        Console.WriteLine(string.Join(", ", stages)); // => plan, code, test
        Console.WriteLine($"Length: {stages.Length}"); // => Length: 3
        // </ArrayElementUpdate>
    }

    private static void ListChangesExample()
    {
        // <ListChanges>
        List<string> workItems = ["design", "code", "test"];

        workItems.Add("review");
        workItems.Remove("code");
        workItems[1] = "verify";

        Console.WriteLine(string.Join(", ", workItems)); // => design, verify, review
        Console.WriteLine($"Has review: {workItems.Contains("review")}"); // => Has review: True
        Console.WriteLine($"Index of verify: {workItems.IndexOf("verify")}"); // => Index of verify: 1
        // </ListChanges>
    }

    private static void ListInsertRemoveExample()
    {
        // <ListInsertRemove>
        List<string> workItems = ["design", "test"];

        workItems.Insert(1, "code");
        Console.WriteLine($"Insert middle: {string.Join(", ", workItems)}"); // => Insert middle: design, code, test

        workItems.Insert(0, "plan");
        Console.WriteLine($"Insert front: {string.Join(", ", workItems)}"); // => Insert front: plan, design, code, test

        workItems.InsertRange(workItems.Count, ["review", "deploy"]);
        Console.WriteLine($"Insert range at end: {string.Join(", ", workItems)}"); // => Insert range at end: plan, design, code, test, review, deploy

        workItems.RemoveAt(workItems.Count - 1);
        Console.WriteLine($"Remove end: {string.Join(", ", workItems)}"); // => Remove end: plan, design, code, test, review

        workItems.RemoveAt(2);
        Console.WriteLine($"Remove middle: {string.Join(", ", workItems)}"); // => Remove middle: plan, design, test, review

        workItems.RemoveAt(0);
        Console.WriteLine($"Remove front: {string.Join(", ", workItems)}"); // => Remove front: design, test, review
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

    private static void DictionaryUpdatesExample()
    {
        // <DictionaryUpdates>
        Dictionary<string, int> priorities = new()
        {
            ["docs"] = 2,
            ["tests"] = 1
        };

        priorities["docs"] = 1;
        Console.WriteLine($"docs priority: {priorities["docs"]}"); // => docs priority: 1

        string key = "deploy";
        if (priorities.TryGetValue(key, out int oldPriority))
        {
            Console.WriteLine($"{key} changed from {oldPriority} to 3");
        }
        else
        {
            Console.WriteLine($"{key} didn't have a priority yet"); // => deploy didn't have a priority yet
        }

        priorities[key] = 3;
        Console.WriteLine($"deploy priority: {priorities[key]}"); // => deploy priority: 3
        // </DictionaryUpdates>
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
        Console.WriteLine($"Last two: {string.Join(", ", phases[^2..])}"); // => Last two: test, deploy
        Console.WriteLine($"Without ends: {string.Join(", ", phases[1..^1])}"); // => Without ends: code, test
        Console.WriteLine($"First two: {string.Join(", ", phases[..2])}"); // => First two: design, code
        Console.WriteLine($"From third: {string.Join(", ", phases[2..])}"); // => From third: test, deploy
        Console.WriteLine($"All phases: {string.Join(", ", phases[..])}"); // => All phases: design, code, test, deploy
        Console.WriteLine($"List last: {checklist[^1]}"); // => List last: review
        Console.WriteLine($"List first two: {string.Join(", ", checklist.GetRange(0, 2))}"); // => List first two: design, test
        // </IndexesAndRanges>
    }
}
