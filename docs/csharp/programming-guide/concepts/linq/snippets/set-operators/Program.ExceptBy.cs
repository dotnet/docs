namespace SolarSystem;

public static partial class Program
{
    internal static void ExceptByExample()
    {
        Console.WriteLine("ExceptBy:");

        // <Planets>
        Planet[] planets =
        {
            Planet.Mercury,
            Planet.Venus,
            Planet.Earth,
            Planet.Jupiter
        };

        Planet[] morePlanets =
        {
            Planet.Mercury,
            Planet.Earth,
            Planet.Mars,
            Planet.Jupiter
        };
        // </Planets>

        // <ExceptBy>
        // A shared "keySelector"
        static string PlanetNameSelector(Planet planet) => planet.Name;

        foreach (Planet planet in
            planets.ExceptBy(
                morePlanets.Select(PlanetNameSelector), PlanetNameSelector))
        {
            Console.WriteLine(planet);
        }

        // This code produces the following output:
        //     Planet { Name = Venus, Type = Rock, OrderFromSun = 2 }
        // </ExceptBy>

        Console.WriteLine();
    }
}
