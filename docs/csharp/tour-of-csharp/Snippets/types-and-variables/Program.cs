using System;
class BoxingExample
{
    // <EnumDeclaration>
    // A traditional enumeration of some root vegetables.
    public enum SomeRootVegetables
    {
        HorseRadish,
        Radish,
        Turnip
    }
    // </EnumDeclaration>

    // <FlagsEnumDeclaration>
    // A bit field or flag enumeration of harvesting seasons.
    [Flags]
    public enum Seasons
    {
        None = 0,
        Summer = 1,
        Autumn = 2,
        Winter = 4,
        Spring = 8,
        All = Summer | Autumn | Winter | Spring
    }
    // </FlagsEnumDeclaration>

    static void Main()
    {
        // <Boxing>
        int i = 123;
        Console.WriteLine($"Value of i: {i}");
        object o = i;    // Boxing
        Console.WriteLine($"Initial value of o: {o}");
        o = 456;
        Console.WriteLine($"Modified value of o: {o}");
        int j = (int)o;  // Unboxing
        Console.WriteLine($"Value of unboxed j: {j}");
        Console.WriteLine($"Final value of i: {i}");
        // </Boxing>

        // <UsingEnums>
        var turnip = SomeRootVegetables.Turnip;

        var spring = Seasons.Spring;
        var startingOnEquinox = Seasons.Spring | Seasons.Autumn;
        var theYear = Seasons.All;
        // </UsingEnums>
    }
}
