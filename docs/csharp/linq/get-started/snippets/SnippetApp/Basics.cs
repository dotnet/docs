namespace Linq.GetStarted;

public static class Basics
{

    static readonly int[] scores = [0]; // Max is called on this, so one value is needed

    // <SourceData>
    static readonly City[] cities = [
        new City("Tokyo", 37_833_000),
        new City("Delhi", 30_290_000),
        new City("Shanghai", 27_110_000),
        new City("São Paulo", 22_043_000),
        new City("Mumbai", 20_412_000),
        new City("Beijing", 20_384_000),
        new City("Cairo", 18_772_000),
        new City("Dhaka", 17_598_000),
        new City("Osaka", 19_281_000),
        new City("New York-Newark", 18_604_000),
        new City("Karachi", 16_094_000),
        new City("Chongqing", 15_872_000),
        new City("Istanbul", 15_029_000),
        new City("Buenos Aires", 15_024_000),
        new City("Kolkata", 14_850_000),
        new City("Lagos", 14_368_000),
        new City("Kinshasa", 14_342_000),
        new City("Manila", 13_923_000),
        new City("Rio de Janeiro", 13_374_000),
        new City("Tianjin", 13_215_000)
    ];

    static readonly Country[] countries = [
        new Country ("Vatican City", 0.44, 526, [new City("Vatican City", 826)]),
        new Country ("Monaco", 2.02, 38_000, [new City("Monte Carlo", 38_000)]),
        new Country ("Nauru", 21, 10_900, [new City("Yaren", 1_100)]),
        new Country ("Tuvalu", 26, 11_600, [new City("Funafuti", 6_200)]),
        new Country ("San Marino", 61, 33_900, [new City("San Marino", 4_500)]),
        new Country ("Liechtenstein", 160, 38_000, [new City("Vaduz", 5_200)]),
        new Country ("Marshall Islands", 181, 58_000, [new City("Majuro", 28_000)]),
        new Country ("Saint Kitts & Nevis", 261, 53_000, [new City("Basseterre", 13_000)])
    ];
    // </SourceData>

    public static void Basics1()
    {
        // <basics1>
        IEnumerable<int> highScoresQuery =
            from score in scores
            where score > 80
            orderby score descending
            select score;
        // </basics1>
    }

    public static void Basics2()
    {
        // <basics2>
        IEnumerable<string> highScoresQuery2 =
            from score in scores
            where score > 80
            orderby score descending
            select $"The score is {score}";
        // </basics2>
    }

    public static void Basics3()
    {
        // <basics3>
        var highScoreCount = (
            from score in scores
            where score > 80
            select score
        ).Count();
        // </basics3>
    }

    public static void Basics4()
    {
        // <basics4>
        IEnumerable<int> highScoresQuery3 =
            from score in scores
            where score > 80
            select score;

        var scoreCount = highScoresQuery3.Count();
        // </basics4>
    }

    public static void Basics5()
    {
        // <basics5>
        // Data source.
        int[] scores = [90, 71, 82, 93, 75, 82];

        // Query Expression.
        IEnumerable<int> scoreQuery = //query variable
            from score in scores //required
            where score > 80 // optional
            orderby score descending // optional
            select score; //must end with select or group

        // Execute the query to produce the results
        foreach (var testScore in scoreQuery)
        {
            Console.WriteLine(testScore);
        }

        // Output: 93 90 82 82
        // </basics5>
    }

    public static void Basics6()
    {
        // <basics6>
        City[] cities = [
            new City("Tokyo", 37_833_000),
            new City("Delhi", 30_290_000),
            new City("Shanghai", 27_110_000),
            new City("São Paulo", 22_043_000)
        ];

        //Query syntax
        IEnumerable<City> queryMajorCities =
            from city in cities
            where city.Population > 100000
            select city;

        // Execute the query to produce the results
        foreach (City city in queryMajorCities)
        {
            Console.WriteLine(city);
        }

        // Output:
        // City { Population = 120000 }
        // City { Population = 112000 }
        // City { Population = 150340 }

        // Method-based syntax
        IEnumerable<City> queryMajorCities2 = cities.Where(c => c.Population > 100000);
        // </basics6>
    }

    public static void Basics7()
    {
        // <basics7>
        var highestScore = (
            from score in scores
            select score
        ).Max();

        // or split the expression
        IEnumerable<int> scoreQuery =
            from score in scores
            select score;

        var highScore = scoreQuery.Max();
        // the following returns the same result
        highScore = scores.Max();
        // </basics7>
    }

    public static void Basics7a()
    {
        // <basics7a>
        var largeCitiesList = (
            from country in countries
            from city in country.Cities
            where city.Population > 10000
            select city
        ).ToList();

        // or split the expression
        IEnumerable<City> largeCitiesQuery =
            from country in countries
            from city in country.Cities
            where city.Population > 10000
            select city;
        var largeCitiesList2 = largeCitiesQuery.ToList();
        // </basics7a>
    }

    public static void Basics8()
    {
        // <basics8>
        var queryCities =
            from city in cities
            where city.Population > 100000
            select city;
        // </basics8>
    }

    public static void Basics9()
    {
        // <basics9>
        IEnumerable<Country> countryAreaQuery =
            from country in countries
            where country.Area > 500000 //sq km
            select country;
        // </basics9>
    }

    public static void Basics10()
    {
        // <basics10>
        IEnumerable<City> cityQuery =
            from country in countries
            from city in country.Cities
            where city.Population > 10000
            select city;
        // </basics10>
    }

    public static void Basics11()
    {
        // <basics11>
        var queryCountryGroups =
            from country in countries
            group country by country.Name[0];
        // </basics11>
    }

    public static void Basics12()
    {
        // <basics12>
        IEnumerable<Country> sortedQuery =
            from country in countries
            orderby country.Area
            select country;
        // </basics12>
    }

    public static void Basics13()
    {
        // <basics13>
        var queryNameAndPop =
            from country in countries
            select new
            {
                Name = country.Name,
                Pop = country.Population
            };
        // </basics13>
    }

    public static void Basics14()
    {
        // <basics14>
        // percentileQuery is an IEnumerable<IGrouping<int, Country>>
        var percentileQuery =
            from country in countries
            let percentile = (int)country.Population / 10_000_000
            group country by percentile into countryGroup
            where countryGroup.Key >= 20
            orderby countryGroup.Key
            select countryGroup;

        // grouping is an IGrouping<int, Country>
        foreach (var grouping in percentileQuery)
        {
            Console.WriteLine(grouping.Key);
            foreach (var country in grouping)
            {
                Console.WriteLine(country.Name + ":" + country.Population);
            }
        }
        // </basics14>
    }

    public static void Basics15()
    {
        // <basics15>
        IEnumerable<City> queryCityPop =
            from city in cities
            where city.Population is < 200000 and > 100000
            select city;
        // </basics15>
    }

    public static void Basics16()
    {
        // <basics16>
        IEnumerable<Country> querySortedCountries =
            from country in countries
            orderby country.Area, country.Population descending
            select country;
        // </basics16>
    }

    public static void Basics17()
    {
        string[] categories = [];
        Product[] products = [];

        // <basics17>
        var categoryQuery =
            from cat in categories
            join prod in products on cat equals prod.Category
            select new
            {
                Category = cat,
                Name = prod.Name
            };
        // </basics17>
    }

    public static void Basics18()
    {
        // <basics18>
        string[] names = ["Svetlana Omelchenko", "Claire O'Donnell", "Sven Mortensen", "Cesar Garcia"];
        IEnumerable<string> queryFirstNames =
            from name in names
            let firstName = name.Split(' ')[0]
            select firstName;

        foreach (var s in queryFirstNames)
        {
            Console.Write(s + " ");
        }

        //Output: Svetlana Claire Sven Cesar
        // </basics18>
    }

    public static void Basics19()
    {
        var students = Student.students;

        // <basics19>
        var queryGroupMax =
            from student in students
            group student by student.Year into studentGroup
            select new
            {
                Level = studentGroup.Key,
                HighestScore = (
                    from student2 in studentGroup
                    select student2.ExamScores.Average()
                ).Max()
            };
        // </basics19>
    }
}
