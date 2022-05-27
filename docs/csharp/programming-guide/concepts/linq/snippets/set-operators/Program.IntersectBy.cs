namespace SolarSystem;

public static partial class Program
{
    internal static void IntersectByExample()
    {
        Console.WriteLine("IntersectBy:");

        // <Planets>
        Planet[] firstFivePlanetsFromTheSun =
        {
            Planet.Mercury,
            Planet.Venus,
            Planet.Earth,
            Planet.Mars,
            Planet.Jupiter
        };

        Planet[] lastFivePlanetsFromTheSun =
        {
            Planet.Mars,
            Planet.Jupiter,
            Planet.Saturn,
            Planet.Uranus,
            Planet.Neptune
        };
        // </Planets>

        // <IntersectBy>
        foreach (Planet planet in
            firstFivePlanetsFromTheSun.IntersectBy(
                lastFivePlanetsFromTheSun, planet => planet))
        {
            Console.WriteLine(planet);
        }

        // This code produces the following output:
        //     Planet { Name = Mars, Type = Rock, OrderFromSun = 4 }
        //     Planet { Name = Jupiter, Type = Gas, OrderFromSun = 5 }
        // </IntersectBy>

        Console.WriteLine();
    }
}
