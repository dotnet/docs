namespace SolarSystem;

public static partial class Program
{
    internal static void ExceptByExample()
    {
        Console.WriteLine("ExceptBy:");

        // <Planets>
        Planet[] planets =
        [
            Planet.Mercury,
            Planet.Venus,
            Planet.Earth,
            Planet.Jupiter
        ];

        int[] planetsToExclude =
        [
            1, // Mercury
            2, // Venus
            5, // Jupiter
        ];
        // </Planets>

        // <ExceptBy>
        foreach (Planet planet in
            planets.ExceptBy(
                planetsToExclude, static planet => planet.OrderFromSun))
        {
            Console.WriteLine(planet);
        }

        // This code produces the following output:
        //     Planet { Name = Venus, Type = Rock, OrderFromSun = 2 }
        // </ExceptBy>

        Console.WriteLine();
    }
}
