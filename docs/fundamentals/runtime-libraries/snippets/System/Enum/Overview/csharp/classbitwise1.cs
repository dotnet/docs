using System;

// <Snippet13>
[Flags]
public enum Pets
{
    None = 0, Dog = 1, Cat = 2, Bird = 4, Rodent = 8,
    Reptile = 16, Other = 32
};

// </Snippet13>

public class Example2
{
    public static void Main()
    {
        // <Snippet14>
        Pets familyPets = Pets.Dog | Pets.Cat;
        Console.WriteLine($"Pets: {familyPets:G} ({familyPets:D})");
        // The example displays the following output:
        //       Pets: Dog, Cat (3)
        // </Snippet14>

        ShowHasFlag();
        ShowIfSet();
        TestForNone();
    }

    private static void ShowHasFlag()
    {
        // <Snippet15>
        Pets familyPets = Pets.Dog | Pets.Cat;
        if (familyPets.HasFlag(Pets.Dog))
            Console.WriteLine("The family has a dog.");
        // The example displays the following output:
        //       The family has a dog.
        // </Snippet15>
    }

    private static void ShowIfSet()
    {
        // <Snippet16>
        Pets familyPets = Pets.Dog | Pets.Cat;
        if ((familyPets & Pets.Dog) == Pets.Dog)
            Console.WriteLine("The family has a dog.");
        // The example displays the following output:
        //       The family has a dog.
        // </Snippet16>
    }

    private static void TestForNone()
    {
        // <Snippet17>
        Pets familyPets = Pets.Dog | Pets.Cat;
        if (familyPets == Pets.None)
            Console.WriteLine("The family has no pets.");
        else
            Console.WriteLine("The family has pets.");
        // The example displays the following output:
        //       The family has pets.
        // </Snippet17>
    }
}
