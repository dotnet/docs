public class Example3
{
    // <Snippet1>
    public static void Main()
    {
        var (city, population, area) = QueryCityData("New York City");

        // Do something with the data.
    }
    // </Snippet1>

    private static (string, int, double) QueryCityData(string name)
    {
        if (name == "New York City")
            return (name, 8175133, 468.48);

        return ("", 0, 0);
    }
}
