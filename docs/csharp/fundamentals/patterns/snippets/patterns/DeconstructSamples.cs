static class DeconstructSamples
{
    public static void Run()
    {
        ShowTupleMemberAccess();
        ShowTypedTupleDeconstruction();
        ShowVarTupleDeconstruction();
        ShowMixedDeconstruction();
        ShowTupleDiscards();
        ShowPersonDeconstruction();
        ShowPersonDeconstructionWithDiscards();
        ShowRecordDeconstruction();
        ShowUriDeconstruction();
        ShowKeyValuePairDeconstruction();
    }

    static void ShowTupleMemberAccess()
    {
        // <TupleMemberAccess>
        var cityData = QueryCityData("New York City");
        var city = cityData.City;
        var population = cityData.Population;
        var area = cityData.Area;
        // </TupleMemberAccess>

        Console.WriteLine($"{city}: population {population:N0}, area {area:F2}");
    }

    static void ShowTypedTupleDeconstruction()
    {
        // <TupleTypedDeclaration>
        (string city, int population, double area) = QueryCityData("New York City");
        // </TupleTypedDeclaration>

        Console.WriteLine($"{city}: population {population:N0}, area {area:F2}");
    }

    static void ShowVarTupleDeconstruction()
    {
        // <TupleVarDeconstruction>
        var (city, population, area) = QueryCityData("New York City");
        // </TupleVarDeconstruction>

        Console.WriteLine($"{city}: population {population:N0}, area {area:F2}");
    }

    static void ShowMixedDeconstruction()
    {
        string city = "Raleigh";

        // <MixedDeconstruction>
        (city, var population, _) = QueryCityData("New York City");
        // </MixedDeconstruction>

        Console.WriteLine($"{city}: population {population:N0}");
    }

    static void ShowTupleDiscards()
    {
        // <TupleDiscards>
        var (_, _, population1960, _, population2010) = QueryPopulationDataForYears(
            "New York City", 1960, 2010);
        // </TupleDiscards>

        Console.WriteLine($"Population change: {population2010 - population1960:N0}");
    }

    static (string City, int Population, double Area) QueryCityData(string name) =>
        name switch
        {
            "New York City" => (name, 8_175_133, 468.48),
            "Raleigh" => (name, 458_880, 149.60),
            _ => (name, 0, 0)
        };

    static (string City, int Year1, int PopulationYear1, int Year2, int PopulationYear2) QueryPopulationDataForYears(
        string name, int year1, int year2) =>
        (name, year1, year2) switch
        {
            ("New York City", 1960, 2010) => (name, year1, 7_781_984, year2, 8_175_133),
            _ => (name, year1, 0, year2, 0)
        };

    static void ShowPersonDeconstruction()
    {
        var passenger = new Person("John", "Quincy", "Adams", "Boston", "MA");

        // <PersonDeconstructUse>
        var (firstName, middleName, lastName) = passenger;
        // </PersonDeconstructUse>

        Console.WriteLine($"{firstName} {middleName} {lastName}");
    }

    static void ShowPersonDeconstructionWithDiscards()
    {
        var passenger = new Person("John", "Quincy", "Adams", "Boston", "MA");

        // <PersonDeconstructDiscards>
        var (firstName, _, city, _) = passenger;
        // </PersonDeconstructDiscards>

        Console.WriteLine($"{firstName} from {city}");
    }

    static void ShowRecordDeconstruction()
    {
        var forecast = new Forecast("Redmond", 18, 9);

        // <RecordDeconstruction>
        var (city, highTempC, lowTempC) = forecast;
        // </RecordDeconstruction>

        Console.WriteLine($"{city}: {highTempC}C / {lowTempC}C");
    }

    static void ShowUriDeconstruction()
    {
        var docsSite = new Uri("https://learn.microsoft.com:443/dotnet/csharp/");
        var (scheme, host, port) = docsSite;
        Console.WriteLine($"{scheme}://{host}:{port}");
    }

    static void ShowKeyValuePairDeconstruction()
    {
        Dictionary<string, int> repoCommitCounts = new(StringComparer.OrdinalIgnoreCase)
        {
            ["https://github.com/dotnet/docs"] = 16_465,
            ["https://github.com/dotnet/runtime"] = 114_223,
            ["https://github.com/dotnet/roslyn"] = 79_484,
        };

        // <KeyValuePair>
        foreach (var (repo, commitCount) in repoCommitCounts)
        {
            Console.WriteLine($"{repo} had {commitCount:N0} commits in this snapshot.");
        }
        // </KeyValuePair>
    }
}

sealed class Person
{
    public Person(string firstName, string middleName, string lastName, string city, string state)
    {
        FirstName = firstName;
        MiddleName = middleName;
        LastName = lastName;
        City = city;
        State = state;
    }

    public string FirstName { get; }

    public string MiddleName { get; }

    public string LastName { get; }

    public string City { get; }

    public string State { get; }

    // <PersonDeconstructMethod>
    public void Deconstruct(out string firstName, out string middleName, out string lastName)
    {
        firstName = FirstName;
        middleName = MiddleName;
        lastName = LastName;
    }
    // </PersonDeconstructMethod>

    public void Deconstruct(out string firstName, out string lastName, out string city, out string state)
    {
        firstName = FirstName;
        lastName = LastName;
        city = City;
        state = State;
    }
}

readonly record struct Forecast(string City, int HighTempC, int LowTempC);

sealed class Traveler
{
    public Traveler(string firstName, string middleName, string lastName, string city, string state)
    {
        FirstName = firstName;
        MiddleName = middleName;
        LastName = lastName;
        City = city;
        State = state;
    }

    public string FirstName { get; }

    public string MiddleName { get; }

    public string LastName { get; }

    public string City { get; }

    public string State { get; }

    // <PersonDeconstructOverloads>
    public void Deconstruct(out string firstName, out string lastName)
    {
        firstName = FirstName;
        lastName = LastName;
    }

    public void Deconstruct(out string firstName, out string middleName, out string lastName)
    {
        firstName = FirstName;
        middleName = MiddleName;
        lastName = LastName;
    }

    public void Deconstruct(out string firstName, out string lastName, out string city, out string state)
    {
        firstName = FirstName;
        lastName = LastName;
        city = City;
        state = State;
    }
    // </PersonDeconstructOverloads>
}

// <UriDeconstructExample>
static class UriExtensions
{
    public static void Deconstruct(this Uri uri, out string scheme, out string host, out int port)
    {
        scheme = uri.Scheme;
        host = uri.Host;
        port = uri.Port;
    }
}
// </UriDeconstructExample>
