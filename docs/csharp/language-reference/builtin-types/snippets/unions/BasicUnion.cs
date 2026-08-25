// <CaseTypes>
public record class Cat(string Name);
public record class Dog(string Name);
public record class Bird(string Name);
// </CaseTypes>

// <BasicDeclaration>
public union Pet(Cat, Dog, Bird);
// </BasicDeclaration>

public static class BasicUnionScenario
{
    public static void Run()
    {
        BasicConversion();
        PatternMatching();
    }

    // <BasicConversion>
    static void BasicConversion()
    {
        Pet pet = new Dog("Rex");
        Console.WriteLine(pet.Value); // output: Dog { Name = Rex }

        Pet pet2 = new Cat("Whiskers");
        Console.WriteLine(pet2.Value); // output: Cat { Name = Whiskers }
    }
    // </BasicConversion>

    // <PatternMatching>
    static void PatternMatching()
    {
        Pet pet = new Dog("Rex");

        var name = pet switch
        {
            Dog d => d.Name,
            Cat c => c.Name,
            Bird b => b.Name,
        };
        Console.WriteLine(name); // output: Rex
    }
    // </PatternMatching>
}
