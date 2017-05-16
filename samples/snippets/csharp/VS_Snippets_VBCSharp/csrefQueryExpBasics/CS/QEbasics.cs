using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

// From Query Expression Basics in C# Programming Guide > LINQ Query Expressions

namespace QEbasics
{        
    class QueryExpressionBasics1
    {
        static void Main()
        {
            // Data source.
            int[] scores = { 90, 71, 82, 93, 75, 82 };

            //<snippet45>
            IEnumerable<int> highScoresQuery =
                from score in scores
                where score > 80
                orderby score descending
                select score;
            //</snippet45>

            //<snippet46>
            IEnumerable<string> highScoresQuery2 =
                from score in scores
                where score > 80
                orderby score descending
                select String.Format("The score is {0}", score);
            //</snippet46>

            //<snippet47>
            int highScoreCount =
                (from score in scores
                 where score > 80
                 select score)
                 .Count();
            //</snippet47>

            //<snippet48>
            IEnumerable<int> highScoresQuery3 =
                from score in scores
                where score > 80
                select score;

            int scoreCount = highScoresQuery3.Count();
            //</snippet48>            
        }
    }

    
    class QueryExpressionBasics2
    {
        //<snippet49>
        static void Main()
        {
            // Data source.
            int[] scores = { 90, 71, 82, 93, 75, 82 };

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
        }
        // Outputs: 93 90 82 82      
        //</snippet49>
        #region ForCompilationOnly
        class City
        {
            public int Population { get; set; }
        }
        class Country
        {
            public List<City> Cities = new List<City>();
            public int Area { get; set; }
            public string Name { get; set; }
            public int Population { get; set; }
        }
        static List<City> cities = new List<City>();
        static List<Country> countries = new List<Country>();

        // Specify the first data source.
        static string[] categories = new string[] { "Beverages", "Condiments", "Vegetables" };

        // Specify the second data source.
        static List<Product> products = new List<Product>()
           {
              new Product{Name="Cola", Category="Beverages"},
              new Product{Name="Tea", Category="Beverages"},
              new Product{Name="Mustard", Category="Condiments"},
              new Product{Name="Pickles", Category="Condiments"},
              new Product{Name="Carrots", Category="Vegetables"},
              new Product{Name="Bok Choy", Category="Vegetables"},
              new Product{Name="Peaches", Category="Fruits"},
              new Product{Name="Melons", Category="Fruits"},
            };
        class Product
        {
            public string Name { get; set; }
            public string Category { get; set; }
        }

        public class Student
        {
            public string First { get; set; }
            public string Last { get; set; }
            public int ID { get; set; }
            public List<int> Scores;
            public int GradeLevel { get; set; }
        }

        
            // Use a collection initializer to create the data source. Note that each element
            //  in the list contains an inner sequence of scores.
            static List<Student> students = new List<Student>
            {
               new Student {First="Svetlana", Last="Omelchenko", ID=111, Scores= new List<int> {97, 72, 81, 60}},
               new Student {First="Claire", Last="O'Donnell", ID=112, Scores= new List<int> {75, 84, 91, 39}},
               new Student {First="Sven", Last="Mortensen", ID=113, Scores= new List<int> {88, 94, 65, 85}},
               new Student {First="Cesar", Last="Garcia", ID=114, Scores= new List<int> {97, 89, 85, 82}},
               new Student {First="Debra", Last="Garcia", ID=115, Scores= new List<int> {35, 72, 91, 70}} 
            };

#endregion

        static void Method()
        {
            //<snippet50>
            //Query syntax
            IEnumerable<City> queryMajorCities =
                from city in cities
                where city.Population > 100000
                select city;

            
            // Method-based syntax
            IEnumerable<City> queryMajorCities2 = cities.Where(c => c.Population > 100000);
            //</snippet50>

            int[] scores = { 90, 71, 82, 93, 75, 82 };

            //<snippet51>
            int highestScore =
                (from score in scores
                 select score)
                .Max();

            // or split the expression
            IEnumerable<int> scoreQuery =
                from score in scores
                select score;

            int highScore = scoreQuery.Max();

            List<City> largeCitiesList =
                (from country in countries
                 from city in country.Cities
                 where city.Population > 10000
                 select city)
                   .ToList();

            // or split the expression
            IEnumerable<City> largeCitiesQuery =
                from country in countries
                from city in country.Cities
                where city.Population > 10000
                select city;

            List<City> largeCitiesList2 = largeCitiesQuery.ToList();
            //</snippet51>

            //<snippet52>
            // Use of var is optional here and in all queries.
            // queryCities is an IEnumerable<City> just as 
            // when it is explicitly typed.
            var queryCities =
                from city in cities
                where city.Population > 100000
                select city;
            //</snippet52>

            //<snippet53>
            IEnumerable<Country> countryAreaQuery =
                from country in countries
                where country.Area > 500000 //sq km
                select country;
            //</snippet53>

            //<snippet54>
            IEnumerable<City> cityQuery =
                from country in countries
                from city in country.Cities
                where city.Population > 10000
                select city;
            //</snippet54>

            //<snippet55>
            var queryCountryGroups =
                from country in countries
                group country by country.Name[0];
            //</snippet55>
           
            //<snippet56>
            IEnumerable<Country> sortedQuery =
                from country in countries
                orderby country.Area
                select country;
            //</snippet56>

            //<snippet57>
            // Here var is required because the query
            // produces an anonymous type.
            var queryNameAndPop =
                from country in countries
                select new { Name = country.Name, Pop = country.Population };
            //</snippet57>

            //<snippet58>
            // percentileQuery is an IEnumerable<IGrouping<int, Country>>
            var percentileQuery =
                from country in countries
                let percentile = (int) country.Population / 10000000
                group country by percentile into countryGroup
                where countryGroup.Key >= 20
                orderby countryGroup.Key
                select countryGroup;

            // grouping is an IGrouping<int, Country>
            foreach (var grouping in percentileQuery)
            {
                Console.WriteLine(grouping.Key);
                foreach (var country in grouping)
                    Console.WriteLine(country.Name + ":" + country.Population);
            }
            //</snippet58>

            //<snippet59>
            IEnumerable<City> queryCityPop =
                from city in cities
                where city.Population < 200000 && city.Population > 100000
                select city;
            //</snippet59>

            //<snippet60>
            IEnumerable<Country> querySortedCountries =
                from country in countries
                orderby country.Area, country.Population descending
                select country;
            //</snippet60>

            //<snippet61>            
            var categoryQuery =
                from cat in categories
                join prod in products on cat equals prod.Category
                select new { Category = cat, Name = prod.Name };
            //</snippet61>

            //<snippet62>
            string[] names = { "Svetlana Omelchenko", "Claire O'Donnell", "Sven Mortensen", "Cesar Garcia" };
            IEnumerable<string> queryFirstNames =
                from name in names
                let firstName = name.Split(new char[] { ' ' })[0]
                select firstName;

            foreach (string s in queryFirstNames)
                Console.Write(s + " ");
            //Output: Svetlana Claire Sven Cesar
            //</snippet62>

            //<snippet63>
            var queryGroupMax =
                from student in students
                group student by student.GradeLevel into studentGroup
                select new
                {
                    Level = studentGroup.Key,
                    HighestScore =
                        (from student2 in studentGroup
                         select student2.Scores.Average())
                         .Max()
                };
            //</snippet63>
        }        
    }  
}
