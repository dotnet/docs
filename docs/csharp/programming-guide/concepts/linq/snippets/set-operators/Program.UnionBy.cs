namespace SolarSystem;

public static partial class Program
{
    internal static void UnionByExample()
    {
        Console.WriteLine("UnionBy:");

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

        // <UnionBy>
        foreach (Planet planet in
            firstFivePlanetsFromTheSun.UnionBy(
                lastFivePlanetsFromTheSun, planet => planet))
        {
            Console.WriteLine(planet);
        }

        // This code produces the following output:
        //     Planet { Name = Mercury, Type = Rock, OrderFromSun = 1 }
        //     Planet { Name = Venus, Type = Rock, OrderFromSun = 2 }
        //     Planet { Name = Earth, Type = Rock, OrderFromSun = 3 }
        //     Planet { Name = Mars, Type = Rock, OrderFromSun = 4 }
        //     Planet { Name = Jupiter, Type = Gas, OrderFromSun = 5 }
        //     Planet { Name = Saturn, Type = Gas, OrderFromSun = 6 }
        //     Planet { Name = Uranus, Type = Liquid, OrderFromSun = 7 }
        //     Planet { Name = Neptune, Type = Liquid, OrderFromSun = 8 }
        // </UnionBy>

        Console.WriteLine();
    }
}
