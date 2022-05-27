namespace SolarSystem;

public static partial class Program
{
    internal static void DistinctByExample()
    {
        Console.WriteLine("DistinctBy:");

        // <Planets>
        Planet[] planets =
        {
            Planet.Mercury,
            Planet.Venus,
            Planet.Earth,
            Planet.Mars,
            Planet.Jupiter,
            Planet.Saturn,
            Planet.Uranus,
            Planet.Neptune,
            Planet.Pluto
        };
        // </Planets>

        // <DistinctBy>
        foreach (Planet planet in planets.DistinctBy(p => p.Type))
        {
            Console.WriteLine(planet);
        }

        // This code produces the following output:
        //     Planet { Name = Mercury, Type = Rock, OrderFromSun = 1 }
        //     Planet { Name = Jupiter, Type = Gas, OrderFromSun = 5 }
        //     Planet { Name = Uranus, Type = Liquid, OrderFromSun = 7 }
        //     Planet { Name = Pluto, Type = Ice, OrderFromSun = 9 }
        // </DistinctBy>

        Console.WriteLine();
    }
}
