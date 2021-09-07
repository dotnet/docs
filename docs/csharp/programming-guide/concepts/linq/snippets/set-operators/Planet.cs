namespace SolarSystem;

record Planet(
    string Name,
    PlanetType Type,
    int OrderFromSun)
{
    public static Planet Mercury =
        new(nameof(Mercury), PlanetType.Rock, 1);

    public static Planet Venus =
        new(nameof(Venus), PlanetType.Rock, 2);

    public static Planet Earth =
        new(nameof(Earth), PlanetType.Rock, 3);

    public static Planet Mars =
        new(nameof(Mars), PlanetType.Rock, 4);

    public static Planet Jupiter =
        new(nameof(Jupiter), PlanetType.Gas, 5);

    public static Planet Saturn =
        new(nameof(Saturn), PlanetType.Gas, 6);

    public static Planet Uranus =
        new(nameof(Uranus), PlanetType.Liquid, 7);

    public static Planet Neptune =
        new(nameof(Neptune), PlanetType.Liquid, 8);

    // Yes, I know... not techically a planet anymore
    public static Planet Pluto =
        new(nameof(Pluto), PlanetType.Ice, 9);
}
