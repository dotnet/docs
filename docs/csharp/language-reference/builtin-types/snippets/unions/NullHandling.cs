public static class NullHandlingScenario
{
    public static void Run()
    {
        NullHandling();
        NullableUnionExample();
        Console.WriteLine(DescribeNullableCase(default)); // output: no pet
    }

    // <NullHandling>
    static void NullHandling()
    {
        Pet pet = default;
        var description = pet switch
        {
            Dog d => d.Name,
            Cat c => c.Name,
            Bird b => b.Name,
            null => "no pet",
        };
        Console.WriteLine(description); // output: no pet
        Console.WriteLine(pet.Value is null); // output: True
    }
    // </NullHandling>

    // <NullableUnionExample>
    static void NullableUnionExample()
    {
        Pet? maybePet = new Dog("Buddy");
        Pet? noPet = null;

        Console.WriteLine(Describe(maybePet)); // output: Buddy
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

    // <MaybeNullContents>
    public union NullablePet(Cat?, Dog, Bird);

    static string DescribeNullableCase(NullablePet pet) => pet switch
    {
        Cat cat => cat.Name,
        Dog dog => dog.Name,
        Bird bird => bird.Name,
        null => "no pet",
    };
    // </MaybeNullContents>
}
