using LinqSamples.QueryExpressionBasics;

namespace LinqSamples;

public static class Basics
{
    // We're not displaying the output, so these could be filled with dummy data
    static readonly int[] scores = [0]; // Max is called on this, so one value is needed
    static readonly City[] cities = [];
    static readonly Country[] countries = [];

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
        int highScoreCount = (
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

        int scoreCount = highScoresQuery3.Count();
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
        foreach (int testScore in scoreQuery)
        {
            Console.WriteLine(testScore);
        }

        // Output: 93 90 82 82
        // </basics5>
    }

    public static void Basics6()
    {
        // <basics6>
        //Query syntax
        IEnumerable<City> queryMajorCities =
            from city in cities
            where city.Population > 100000
            select city;

        // Method-based syntax
        IEnumerable<City> queryMajorCities2 = cities.Where(c => c.Population > 100000);
        // </basics6>
    }

    public static void Basics7()
    {
        // <basics7>
        int highestScore = (
            from score in scores
            select score
        ).Max();

        // or split the expression
        IEnumerable<int> scoreQuery =
            from score in scores
            select score;

        int highScore = scoreQuery.Max();
        // the following returns the same result
        highScore = scores.Max();
        // </basics7>
    }

    public static void Basics7a()
    {
        // <basics7a>
        List<City> largeCitiesList = (
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

        List<City> largeCitiesList2 = largeCitiesQuery.ToList();
        // </basics7a>
    }

    public static void Basics8()
    {
        // <basics8>
        // Use of var is optional here and in all queries.
        // queryCities is an IEnumerable<City> just as
        // when it is explicitly typed.
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
        // Here var is required because the query
        // produces an anonymous type.
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
            where city.Population < 200000 && city.Population > 100000
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
        string[] names = { "Svetlana Omelchenko", "Claire O'Donnell", "Sven Mortensen", "Cesar Garcia" };
        IEnumerable<string> queryFirstNames =
            from name in names
            let firstName = name.Split(' ')[0]
            select firstName;

        foreach (string s in queryFirstNames)
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
