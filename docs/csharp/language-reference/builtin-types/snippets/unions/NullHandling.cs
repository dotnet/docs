public static class NullHandlingScenario
{
    public static void Run()
    {
        NullHandling();
        NullableUnionExample();
    }

    // <NullHandling>
    static void NullHandling()
    {
        Pet pet = default;
        Console.WriteLine(pet.Value is null); // output: True

        var description = pet switch
        {
            Dog d => d.Name,
            Cat c => c.Name,
            Bird b => b.Name,
            null => "no pet",
        };
        Console.WriteLine(description); // output: no pet
    }
    // </NullHandling>

    // <NullableUnionExample>
    static void NullableUnionExample()
    {
        Pet? maybePet = new Dog("Buddy");
        Pet? noPet = null;

        Console.WriteLine(Describe(maybePet)); // output: Dog: Buddy
        Console.WriteLine(Describe(noPet));    // output: no pet

        static string Describe(Pet? pet) => pet switch
        {
            Dog d => d.Name,
            Cat c => c.Name,
            Bird b => b.Name,
            null => "no pet",
        };
    }
    // </NullableUnionExample>
}
