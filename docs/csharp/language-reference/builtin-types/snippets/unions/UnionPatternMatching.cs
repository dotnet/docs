public static class UnionPatternMatchingScenario
{
    // <UnionWithProperty>
    public union Pet(Cat, Dog)
    {
        public string Name => this switch
        {
            Cat cat => cat.Name,
            Dog dog => dog.Name,
            null => "",
        };
    }
    // </UnionWithProperty>

    public static void Run()
    {
        // <PropertyMatching>
        Pet pet = new Dog("Rex", "Labrador");
        Console.WriteLine(pet is Dog { Breed: "Labrador" }); // output: True
        Console.WriteLine(pet is { Name: "Rex" });           // output: True
        pet = new Cat("Rex");
        Console.WriteLine(pet is Dog { Breed: "Labrador" }); // output: False
        Console.WriteLine(pet is { Name: "Rex" });           // output: True
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
