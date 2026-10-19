public static class UnionPatternMatchingScenario
{
    public static void Run()
    {
        // <PropertyMatching>
        Pet pet = new Dog("Rex");
        Console.WriteLine(pet is Dog { Name: "Rex" });          // output: True
        Console.WriteLine(pet is { Value: Dog { Name: "Rex" } }); // output: True
        // </PropertyMatching>

        // <NullAndCapture>
        Pet empty = default;
        Console.WriteLine(empty is { });       // output: True
        Console.WriteLine(empty is not null);  // output: False
        if (empty is var captured)
        {
            Console.WriteLine(captured.Value is null); // output: True
        }
        // </NullAndCapture>
    }
}
