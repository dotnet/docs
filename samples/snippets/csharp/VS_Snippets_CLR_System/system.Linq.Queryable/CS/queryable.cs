using System;
using System.Collections.Generic;
using System.Linq;

namespace QueryableExamples
{
    public class Program
    {
        // This part is just for testing the examples
        static void Main(string[] args)
        {
            All.AllEx1();
            All2.AllEx2();
        }

        #region Aggregate
        static void AggregateEx1()
        {
            // <Snippet1>
            string sentence = "the quick brown fox jumps over the lazy dog";

            // Split the string into individual words.
            string[] words = sentence.Split(' ');

            // Use Aggregate() to prepend each word to the beginning of the 
            // new sentence to reverse the word order.
            string reversed =
                words.AsQueryable().Aggregate(
                (workingSentence, next) => next + " " + workingSentence
                );

            Console.WriteLine(reversed);

            // This code produces the following output:
            //
            // dog lazy the over jumps fox brown quick the 

            // </Snippet1>
        }
        static void AggregateEx2()
        {
            // <Snippet2>
            int[] ints = { 4, 8, 8, 3, 9, 0, 7, 8, 2 };

            // Count the even numbers in the array, using a seed value of 0.
            int numEven =
                ints.AsQueryable().Aggregate(
                0,
                (total, next) => next % 2 == 0 ? total + 1 : total
                );

            Console.WriteLine("The number of even integers is: {0}", numEven);

            // This code produces the following output:
            //
            // The number of even integers is: 6 

            // </Snippet2>
        }
        static void AggregateEx3()
        {
            // <Snippet3>
            string[] fruits = { "apple", "mango", "orange", "passionfruit", "grape" };

            // Determine whether any string in the array is longer than "banana".
            string longestName =
                fruits.AsQueryable().Aggregate(
                "banana",
                (longest, next) => next.Length > longest.Length ? next : longest,
                // Return the final result as an uppercase string.
                fruit => fruit.ToUpper()
                );

            Console.WriteLine(
                "The fruit with the longest name is {0}.",
                longestName);

            // This code produces the following output:
            //
            // The fruit with the longest name is PASSIONFRUIT. 

            // </Snippet3>
        }
        #endregion

        #region All
        public static class All
        {
            // <Snippet4>
            class Pet
            {
                public string Name { get; set; }
                public int Age { get; set; }
            }

            public static void AllEx1()
            {
                // Create an array of Pets.
                Pet[] pets = { new Pet { Name="Barley", Age=10 },
                               new Pet { Name="Boots", Age=4 },
                               new Pet { Name="Whiskers", Age=6 } };

                // Determine whether all pet names in the array start with 'B'.
                bool allStartWithB =
                    pets.AsQueryable().All(pet => pet.Name.StartsWith("B"));

                Console.WriteLine(
                    "{0} pet names start with 'B'.",
                    allStartWithB ? "All" : "Not all");
            }

            // This code produces the following output:
            //
            //  Not all pet names start with 'B'. 

            // </Snippet4>
        }

        static class All2
        {
            // <Snippet134>
            class Pet
            {
                public string Name { get; set; }
                public int Age { get; set; }
            }
            class Person
            {
                public string LastName { get; set; }
                public Pet[] Pets { get; set; }
            }

            public static void AllEx2()
            {
                List<Person> people = new List<Person>
                    { new Person { LastName = "Haas",
                                   Pets = new Pet[] { new Pet { Name="Barley", Age=10 },
                                                      new Pet { Name="Boots", Age=14 },
                                                      new Pet { Name="Whiskers", Age=6 }}},
                      new Person { LastName = "Fakhouri",
                                   Pets = new Pet[] { new Pet { Name = "Snowball", Age = 1}}},
                      new Person { LastName = "Antebi",
                                   Pets = new Pet[] { new Pet { Name = "Belle", Age = 8} }},
                      new Person { LastName = "Philips",
                                   Pets = new Pet[] { new Pet { Name = "Sweetie", Age = 2},
                                                      new Pet { Name = "Rover", Age = 13}} }
                    };

                // Determine which people have pets that are all older than 5.
                IEnumerable<string> names = from person in people
                                            where person.Pets.AsQueryable().All(pet => pet.Age > 5)
                                            select person.LastName;

                foreach (string name in names)
                    Console.WriteLine(name);

                /* This code produces the following output:
                 * 
                 * Haas
                 * Antebi
                 */
            }
            // </Snippet134>
        }
        #endregion

        #region Any
        class Any1
        {
            public static void AnyEx1()
            {
                // <Snippet5>
                List<int> numbers = new List<int> { 1, 2 };

                // Determine if the list contains any elements.
                bool hasElements = numbers.AsQueryable().Any();

                Console.WriteLine("The list {0} empty.",
                    hasElements ? "is not" : "is");

                // This code produces the following output:
                //
                // The list is not empty. 

                // </Snippet5>
            }

            // <Snippet135>
            class Pet
            {
                public string Name { get; set; }
                public int Age { get; set; }
            }
            class Person
            {
                public string LastName { get; set; }
                public Pet[] Pets { get; set; }
            }

            public static void AnyEx2()
            {
                List<Person> people = new List<Person>
                    { new Person { LastName = "Haas",
                                   Pets = new Pet[] { new Pet { Name="Barley", Age=10 },
                                                      new Pet { Name="Boots", Age=14 },
                                                      new Pet { Name="Whiskers", Age=6 }}},
                      new Person { LastName = "Fakhouri",
                                   Pets = new Pet[] { new Pet { Name = "Snowball", Age = 1}}},
                      new Person { LastName = "Antebi",
                                   Pets = new Pet[] { }},
                      new Person { LastName = "Philips",
                                   Pets = new Pet[] { new Pet { Name = "Sweetie", Age = 2},
                                                      new Pet { Name = "Rover", Age = 13}} }
                    };

                // Determine which people have a non-empty Pet array.
                IEnumerable<string> names = from person in people
                                            where person.Pets.AsQueryable().Any()
                                            select person.LastName;

                foreach (string name in names)
                    Console.WriteLine(name);

                /* This code produces the following output:
                  
                   Haas
                   Fakhouri
                   Philips
                */
            }
            // </Snippet135>
        }

        static class Any2
        {
            // <Snippet6>
            class Pet
            {
                public string Name { get; set; }
                public int Age { get; set; }
                public bool Vaccinated { get; set; }
            }

            public static void AnyEx3()
            {
                // Create an array of Pet objects.
                Pet[] pets =
                    { new Pet { Name="Barley", Age=8, Vaccinated=true },
                      new Pet { Name="Boots", Age=4, Vaccinated=false },
                      new Pet { Name="Whiskers", Age=1, Vaccinated=false } };

                // Determine whether any pets over age 1 are also unvaccinated.
                bool unvaccinated =
                    pets.AsQueryable().Any(p => p.Age > 1 && p.Vaccinated == false);

                Console.WriteLine(
                    "There {0} unvaccinated animals over age one.",
                    unvaccinated ? "are" : "are not any");
            }

            // This code produces the following output:
            //
            //  There are unvaccinated animals over age one. 

            // </Snippet6>
        }
        #endregion

        #region AsQueryable
        static void AsQueryableEx1()
        {
            // <Snippet125>
            List<int> grades = new List<int> { 78, 92, 100, 37, 81 };

            // Convert the List to an IQueryable<int>.
            IQueryable<int> iqueryable = grades.AsQueryable();

            // Get the Expression property of the IQueryable object.
            System.Linq.Expressions.Expression expressionTree =
                iqueryable.Expression;

            Console.WriteLine("The NodeType of the expression tree is: "
                + expressionTree.NodeType.ToString());
            Console.WriteLine("The Type of the expression tree is: "
                + expressionTree.Type.Name);

            /*
                This code produces the following output:

                The NodeType of the expression tree is: Constant
                The Type of the expression tree is: EnumerableQuery`1
            */
            // </Snippet125>
        }

        #endregion

        #region Average
        static void AverageEx1()
        {
            // <Snippet8>
            List<int> grades = new List<int> { 78, 92, 100, 37, 81 };

            double average = grades.AsQueryable().Average();

            Console.WriteLine("The average grade is {0}.", average);

            // This code produces the following output:
            //
            // The average grade is 77.6. 

            // </Snippet8>
        }

        static void AverageEx2()
        {
            // <Snippet12>
            long?[] longs = { null, 10007L, 37L, 399846234235L };

            double? average = longs.AsQueryable().Average();

            Console.WriteLine("The average is {0}.", average);

            // This code produces the following output:
            //
            // The average is 133282081426.333. 

            // </Snippet12>
        }

        static void AverageEx3()
        {
            // <Snippet18>
            string[] fruits = { "apple", "banana", "mango", "orange", "passionfruit", "grape" };

            // Determine the average string length in the array.
            double average = fruits.AsQueryable().Average(s => s.Length);

            Console.WriteLine("The average string length is {0}.", average);

            // This code produces the following output:
            //
            // The average string length is 6.5. 

            // </Snippet18>
        }
        #endregion

        #region Cast
        // Not currently used in docs.
        static void CastEx1()
        {
            // Get a list of the methods available on the String type.
            List<System.Reflection.MethodInfo> methods = typeof(String).GetMethods().ToList();

            // Cast each MethodInfo object to a MemberInfo object.
            // Then select the names of those methods whose names
            // are less than 6 characters long.
            IQueryable<string> members =
                methods.AsQueryable()
                .Cast<System.Reflection.MemberInfo>()
                .Select(member => member.Name)
                .Where(name => name.Length < 6);

            foreach (string member in members)
                Console.WriteLine(member);

            /*  This code produces the following output:
            
                Join
                Join
                Split
                Split
                Split
                Split
                Split
                Split
                Trim
                Clone
                Trim
                Copy 
            */
        }

        static void CastEx2()
        {
            // <Snippet19>

            // Create a list of objects.
            List<object> words =
                new List<object> { "green", "blue", "violet" };

            // Cast the objects in the list to type 'string'
            // and project the first letter of each string.
            IEnumerable<string> query =
                words.AsQueryable()
                .Cast<string>()
                .Select(str => str.Substring(0, 1));

            foreach (string s in query)
                Console.WriteLine(s);

            /*  This code produces the following output:
            
                g
                b
                v
            */

            // </Snippet19>
        }
        #endregion

        #region Concat
        static class Concat
        {
            // <Snippet20>
            class Pet
            {
                public string Name { get; set; }
                public int Age { get; set; }
            }

            // This method creates and returns an array of Pet objects.
            static Pet[] GetCats()
            {
                Pet[] cats = { new Pet { Name="Barley", Age=8 },
                               new Pet { Name="Boots", Age=4 },
                               new Pet { Name="Whiskers", Age=1 } };
                return cats;
            }

            // This method creates and returns an array of Pet objects.
            static Pet[] GetDogs()
            {
                Pet[] dogs = { new Pet { Name="Bounder", Age=3 },
                               new Pet { Name="Snoopy", Age=14 },
                               new Pet { Name="Fido", Age=9 } };
                return dogs;
            }

            public static void ConcatEx1()
            {
                Pet[] cats = GetCats();
                Pet[] dogs = GetDogs();

                // Concatenate a collection of cat names to a
                // collection of dog names by using Concat().
                IEnumerable<string> query =
                    cats.AsQueryable()
                    .Select(cat => cat.Name)
                    .Concat(dogs.Select(dog => dog.Name));

                foreach (string name in query)
                    Console.WriteLine(name);
            }

            // This code produces the following output:
            //
            // Barley
            // Boots
            // Whiskers
            // Bounder
            // Snoopy
            // Fido

            // </Snippet20>

            public static void ConcatEx2()
            {
                // <Snippet112>
                Pet[] cats = GetCats();
                Pet[] dogs = GetDogs();

                // Concatenate a collection of cat names to a
                // collection of dog names by using SelectMany().
                IEnumerable<string> query =
                    new[] { cats.Select(cat => cat.Name), dogs.Select(dog => dog.Name) }
                    .AsQueryable().SelectMany(name => name);

                foreach (string name in query)
                    Console.WriteLine(name);

                // This code produces the following output:
                //
                // Barley
                // Boots
                // Whiskers
                // Bounder
                // Snoopy
                // Fido

                // </Snippet112>
            }
        }
        #endregion

        #region Contains
        static void ContainsEx1()
        {
            // <Snippet21>
            string[] fruits = { "apple", "banana", "mango", 
                                "orange", "passionfruit", "grape" };

            // The string to search for in the array.
            string mango = "mango";

            bool hasMango = fruits.AsQueryable().Contains(mango);

            Console.WriteLine(
                "The array {0} contain '{1}'.",
                hasMango ? "does" : "does not",
                mango);

            // This code produces the following output:
            //
            // The array does contain 'mango'. 

            // </Snippet21>
        }
        #endregion

        #region Count
        static void CountEx1()
        {
            // <Snippet22>
            string[] fruits = { "apple", "banana", "mango", 
                                "orange", "passionfruit", "grape" };

            int numberOfFruits = fruits.AsQueryable().Count();

            Console.WriteLine(
                "There are {0} items in the array.",
                numberOfFruits);

            // This code produces the following output:
            //
            // There are 6 items in the array. 

            // </Snippet22>
        }

        static class Count
        {
            // <Snippet23>
            class Pet
            {
                public string Name { get; set; }
                public bool Vaccinated { get; set; }
            }

            public static void CountEx2()
            {
                // Create an array of Pet objects.
                Pet[] pets = { new Pet { Name="Barley", Vaccinated=true },
                               new Pet { Name="Boots", Vaccinated=false },
                               new Pet { Name="Whiskers", Vaccinated=false } };

                // Count the number of unvaccinated pets in the array.
                int numberUnvaccinated =
                    pets.AsQueryable().Count(p => p.Vaccinated == false);

                Console.WriteLine(
                    "There are {0} unvaccinated animals.",
                    numberUnvaccinated);
            }

            // This code produces the following output:
            //
            // There are 2 unvaccinated animals.

            // </Snippet23>
        }
        #endregion

        #region DefaultIfEmpty
        static class DefaultIfEmpty1
        {
            // <Snippet24>
            class Pet
            {
                public string Name { get; set; }
                public int Age { get; set; }
            }

            public static void DefaultIfEmptyEx1()
            {
                // Create a list of Pet objects.
                List<Pet> pets =
                    new List<Pet>{ new Pet { Name="Barley", Age=8 },
                                   new Pet { Name="Boots", Age=4 },
                                   new Pet { Name="Whiskers", Age=1 } };

                // Call DefaultIfEmtpy() on the collection that Select()
                // returns, so that if the initial list is empty, there
                // will always be at least one item in the returned array.
                string[] names =
                    pets.AsQueryable()
                    .Select(pet => pet.Name)
                    .DefaultIfEmpty()
                    .ToArray();

                string first = names[0];
                Console.WriteLine(first);
            }

            /*
                This code produces the following output:

                Barley
            */
            // </Snippet24>

            public static void DefaultIfEmptyEx1a()
            {
                // <Snippet25>
                // Create a list of Pet objects.
                List<Pet> pets =
                    new List<Pet>{ new Pet { Name="Barley", Age=8 },
                                   new Pet { Name="Boots", Age=4 },
                                   new Pet { Name="Whiskers", Age=1 } };

                // This query selects only those pets that are 10 or older.
                // In case there are no pets that meet that criteria, call
                // DefaultIfEmpty(). This code passes an (optional) default
                // value to DefaultIfEmpty().
                string[] oldPets =
                    pets.AsQueryable()
                    .Where(pet => pet.Age >= 10)
                    .Select(pet => pet.Name)
                    .DefaultIfEmpty("[EMPTY]")
                    .ToArray();

                Console.WriteLine("First query: " + oldPets[0]);

                // This query selects only those pets that are 10 or older.
                // This code does not call DefaultIfEmpty().
                string[] oldPets2 =
                    pets.AsQueryable()
                    .Where(pet => pet.Age >= 10)
                    .Select(pet => pet.Name)
                    .ToArray();

                // There may be no elements in the array, so directly
                // accessing element 0 may throw an exception.
                try
                {
                    Console.WriteLine("Second query: " + oldPets2[0]);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Second query: An exception was thrown: " + e.Message);
                }

                /*
                    This code produces the following output:
            
                    First query: [EMPTY]
                    Second query: An exception was thrown: Index was outside the bounds of the array.
                */

                // </Snippet25>
            }
        }
        #endregion

        #region Distinct
        static void DistinctEx1()
        {
            // <Snippet27>
            List<int> ages = new List<int> { 21, 46, 46, 55, 17, 21, 55, 55 };

            IEnumerable<int> distinctAges = ages.AsQueryable().Distinct();

            Console.WriteLine("Distinct ages:");

            foreach (int age in distinctAges)
                Console.WriteLine(age);

            /*
                This code produces the following output:

                Distinct ages:
                21
                46
                55
                17
            */

            // </Snippet27>
        }
        #endregion

        #region ElementAt
        static void ElementAtEx1()
        {
            // <Snippet28>
            string[] names = { "Hartono, Tommy", "Adams, Terry", 
                               "Andersen, Henriette Thaulow", 
                               "Hedlund, Magnus", "Ito, Shu" };

            Random random = new Random(DateTime.Now.Millisecond);

            string name =
                names.AsQueryable().ElementAt(random.Next(0, names.Length));

            Console.WriteLine("The name chosen at random is '{0}'.", name);

            /*
                This code produces the following sample output.
                Yours may be different due to the use of Random.

                The name chosen at random is 'Ito, Shu'.
            */

            // </Snippet28>
        }
        #endregion

        #region ElementAtOrDefault
        static void ElementAtOrDefaultEx1()
        {
            // <Snippet29>
            string[] names = { "Hartono, Tommy", "Adams, Terry",
                               "Andersen, Henriette Thaulow",
                               "Hedlund, Magnus", "Ito, Shu" };

            int index = 20;

            string name = names.AsQueryable().ElementAtOrDefault(index);

            Console.WriteLine(
                "The name chosen at index {0} is '{1}'.",
                index,
                String.IsNullOrEmpty(name) ? "[NONE AT THIS INDEX]" : name);

            /*
                This code produces the following output:

                The name chosen at index 20 is '[NONE AT THIS INDEX]'.
            */

            // </Snippet29>
        }
        #endregion

        #region Except
        static void ExceptEx1()
        {
            // <Snippet34>
            double[] numbers1 = { 2.0, 2.1, 2.2, 2.3, 2.4, 2.5 };
            double[] numbers2 = { 2.2 };

            // Get the numbers from the first array that
            // are NOT in the second array.
            IEnumerable<double> onlyInFirstSet =
                numbers1.AsQueryable().Except(numbers2);

            foreach (double number in onlyInFirstSet)
                Console.WriteLine(number);

            /*
                This code produces the following output:

                2
                2.1
                2.3
                2.4
                2.5
            */

            // </Snippet34>
        }
        #endregion

        #region First
        static void FirstEx1()
        {
            // <Snippet35>
            int[] numbers = { 9, 34, 65, 92, 87, 435, 3, 54, 
                                83, 23, 87, 435, 67, 12, 19 };

            int first = numbers.AsQueryable().First();

            Console.WriteLine(first);

            /*
                This code produces the following output:

                9
            */

            // </Snippet35>
        }

        static void FirstEx2()
        {
            // <Snippet36>
            int[] numbers = { 9, 34, 65, 92, 87, 435, 3, 54, 
                              83, 23, 87, 435, 67, 12, 19 };

            // Get the first number in the array that is greater than 80.
            int first = numbers.AsQueryable().First(number => number > 80);

            Console.WriteLine(first);

            /*
                This code produces the following output:

                92
            */

            // </Snippet36>
        }
        #endregion

        #region FirstOrDefault
        static void FirstOrDefaultEx1()
        {
            // <Snippet37>
            // Create an empty array.
            int[] numbers = { };
            // Get the first item in the array, or else the 
            // default value for type int (0).
            int first = numbers.AsQueryable().FirstOrDefault();

            Console.WriteLine(first);

            /*
                This code produces the following output:

                0
            */

            // </Snippet37>
        }

        static void FirstOrDefaultEx2()
        {
            // <Snippet38>
            string[] names = { "Hartono, Tommy", "Adams, Terry", 
                                 "Andersen, Henriette Thaulow", 
                                 "Hedlund, Magnus", "Ito, Shu" };

            // Get the first string in the array that is longer
            // than 20 characters, or the default value for type
            // string (null) if none exists.
            string firstLongName =
                names.AsQueryable().FirstOrDefault(name => name.Length > 20);

            Console.WriteLine("The first long name is '{0}'.", firstLongName);

            // Get the first string in the array that is longer
            // than 30 characters, or the default value for type
            // string (null) if none exists.
            string firstVeryLongName =
                names.AsQueryable().FirstOrDefault(name => name.Length > 30);

            Console.WriteLine(
                "There is {0} name that is longer than 30 characters.",
                string.IsNullOrEmpty(firstVeryLongName) ? "NOT a" : "a");

            /*
                This code produces the following output:

                The first long name is 'Andersen, Henriette Thaulow'.
                There is NOT a name that is longer than 30 characters.
            */

            // </Snippet38>
        }

        static void FirstOrDefaultEx3()
        {
            // <Snippet131>
            List<int> months = new List<int> { };

            // Setting the default value to 1 after the query.
            int firstMonth1 = months.AsQueryable().FirstOrDefault();
            if (firstMonth1 == 0)
            {
                firstMonth1 = 1;
            }
            Console.WriteLine("The value of the firstMonth1 variable is {0}", firstMonth1);

            // Setting the default value to 1 by using DefaultIfEmpty() in the query.
            int firstMonth2 = months.AsQueryable().DefaultIfEmpty(1).First();
            Console.WriteLine("The value of the firstMonth2 variable is {0}", firstMonth2);

            /*
             This code produces the following output:
            
             The value of the firstMonth1 variable is 1
             The value of the firstMonth2 variable is 1
            */

            // </Snippet131>
        }
        #endregion

        #region GroupBy
        static class GroupBy
        {
            // <Snippet14>
            class Pet
            {
                public string Name { get; set; }
                public int Age { get; set; }
            }

            public static void GroupByEx1()
            {
                // Create a list of Pet objects.
                List<Pet> pets =
                    new List<Pet>{ new Pet { Name="Barley", Age=8 },
                                   new Pet { Name="Boots", Age=4 },
                                   new Pet { Name="Whiskers", Age=1 },
                                   new Pet { Name="Daisy", Age=4 } };

                // Group the pets using Pet.Age as the key.
                // Use Pet.Name as the value for each entry.
                var query = pets.AsQueryable().GroupBy(pet => pet.Age);

                // Iterate over each IGrouping in the collection.
                foreach (var ageGroup in query)
                {
                    Console.WriteLine("Age group: {0}  Number of pets: {1}", ageGroup.Key, ageGroup.Count());
                }
            }

            /*
                This code produces the following output:

                Age group: 8  Number of pets: 1
                Age group: 4  Number of pets: 2
                Age group: 1  Number of pets: 1
             
            */

            // </Snippet14>
        }

        static class GroupBy2
        {
            // <Snippet39>
            class Pet
            {
                public string Name { get; set; }
                public int Age { get; set; }
            }

            public static void GroupByEx2()
            {
                // Create a list of Pet objects.
                List<Pet> pets =
                    new List<Pet>{ new Pet { Name="Barley", Age=8 },
                                   new Pet { Name="Boots", Age=4 },
                                   new Pet { Name="Whiskers", Age=1 },
                                   new Pet { Name="Daisy", Age=4 } };

                // Group the pets using Pet.Age as the key.
                // Use Pet.Name as the value for each entry.
                IEnumerable<IGrouping<int, string>> query =
                    pets.AsQueryable().GroupBy(pet => pet.Age, pet => pet.Name);

                // Iterate over each IGrouping in the collection.
                foreach (IGrouping<int, string> petGroup in query)
                {
                    // Print the key value of the IGrouping.
                    Console.WriteLine(petGroup.Key);
                    // Iterate over each value in the 
                    // IGrouping and print the value.
                    foreach (string name in petGroup)
                        Console.WriteLine("  {0}", name);
                }
            }

            /*
                This code produces the following output:

                8
                  Barley
                4
                  Boots
                  Daisy
                1
                  Whiskers
            */

            // </Snippet39>
        }

        // Uses a resultSelector function.
        static class GroupBy3
        {
            // <Snippet15>
            class Pet
            {
                public string Name { get; set; }
                public double Age { get; set; }
            }

            public static void GroupByEx3()
            {
                // Create a list of pets.
                List<Pet> petsList =
                    new List<Pet>{ new Pet { Name="Barley", Age=8.3 },
                                   new Pet { Name="Boots", Age=4.9 },
                                   new Pet { Name="Whiskers", Age=1.5 },
                                   new Pet { Name="Daisy", Age=4.3 } };

                // Group Pet objects by the Math.Floor of their age.
                // Then project an anonymous type from each group
                // that consists of the key, the count of the group's
                // elements, and the minimum and maximum age in the group.
                var query = petsList.AsQueryable().GroupBy(
                    pet => Math.Floor(pet.Age),
                    (age, pets) => new
                    {
                        Key = age,
                        Count = pets.Count(),
                        Min = pets.Min(pet => pet.Age),
                        Max = pets.Max(pet => pet.Age)
                    });

                // Iterate over each anonymous type.
                foreach (var result in query)
                {
                    Console.WriteLine("\nAge group: " + result.Key);
                    Console.WriteLine("Number of pets in this age group: " + result.Count);
                    Console.WriteLine("Minimum age: " + result.Min);
                    Console.WriteLine("Maximum age: " + result.Max);
                }

                /*  This code produces the following output:
                 
                    Age group: 8
                    Number of pets in this age group: 1
                    Minimum age: 8.3
                    Maximum age: 8.3
                 
                    Age group: 4
                    Number of pets in this age group: 2
                    Minimum age: 4.3
                    Maximum age: 4.9
                 
                    Age group: 1
                    Number of pets in this age group: 1
                    Minimum age: 1.5
                    Maximum age: 1.5
                */
            }
            // </Snippet15>
        }

        // Uses a resultSelector function.
        static class GroupBy4
        {
            // <Snippet130>
            class Pet
            {
                public string Name { get; set; }
                public double Age { get; set; }
            }

            public static void GroupByEx4()
            {
                // Create a list of pets.
                List<Pet> petsList =
                    new List<Pet>{ new Pet { Name="Barley", Age=8.3 },
                                   new Pet { Name="Boots", Age=4.9 },
                                   new Pet { Name="Whiskers", Age=1.5 },
                                   new Pet { Name="Daisy", Age=4.3 } };

                // Group Pet.Age values by the Math.Floor of the age.
                // Then project an anonymous type from each group
                // that consists of the key, the count of the group's
                // elements, and the minimum and maximum age in the group.
                var query = petsList.AsQueryable().GroupBy(
                    pet => Math.Floor(pet.Age),
                    pet => pet.Age,
                    (baseAge, ages) => new
                    {
                        Key = baseAge,
                        Count = ages.Count(),
                        Min = ages.Min(),
                        Max = ages.Max()
                    });

                // Iterate over each anonymous type.
                foreach (var result in query)
                {
                    Console.WriteLine("\nAge group: " + result.Key);
                    Console.WriteLine("Number of pets in this age group: " + result.Count);
                    Console.WriteLine("Minimum age: " + result.Min);
                    Console.WriteLine("Maximum age: " + result.Max);
                }

                /*  This code produces the following output:
                 
                    Age group: 8
                    Number of pets in this age group: 1
                    Minimum age: 8.3
                    Maximum age: 8.3
                 
                    Age group: 4
                    Number of pets in this age group: 2
                    Minimum age: 4.3
                    Maximum age: 4.9
                 
                    Age group: 1
                    Number of pets in this age group: 1
                    Minimum age: 1.5
                    Maximum age: 1.5
                */
            }
            // </Snippet130>
        }
        #endregion

        #region GroupJoin
        static class GroupJoin
        {
            // <Snippet40>
            class Person
            {
                public string Name { get; set; }
            }

            class Pet
            {
                public string Name { get; set; }
                public Person Owner { get; set; }
            }

            public static void GroupJoinEx1()
            {
                Person magnus = new Person { Name = "Hedlund, Magnus" };
                Person terry = new Person { Name = "Adams, Terry" };
                Person charlotte = new Person { Name = "Weiss, Charlotte" };

                Pet barley = new Pet { Name = "Barley", Owner = terry };
                Pet boots = new Pet { Name = "Boots", Owner = terry };
                Pet whiskers = new Pet { Name = "Whiskers", Owner = charlotte };
                Pet daisy = new Pet { Name = "Daisy", Owner = magnus };

                List<Person> people = new List<Person> { magnus, terry, charlotte };
                List<Pet> pets = new List<Pet> { barley, boots, whiskers, daisy };

                // Create a list where each element is an anonymous 
                // type that contains a person's name and a collection 
                // of names of the pets that are owned by them.
                var query =
                    people.AsQueryable().GroupJoin(pets,
                                     person => person,
                                     pet => pet.Owner,
                                     (person, petCollection) =>
                                         new
                                         {
                                             OwnerName = person.Name,
                                             Pets = petCollection.Select(pet => pet.Name)
                                         });

                foreach (var obj in query)
                {
                    // Output the owner's name.
                    Console.WriteLine("{0}:", obj.OwnerName);
                    // Output each of the owner's pet's names.
                    foreach (string pet in obj.Pets)
                        Console.WriteLine("  {0}", pet);
                }
            }

            /*
                This code produces the following output:

                Hedlund, Magnus:
                  Daisy
                Adams, Terry:
                  Barley
                  Boots
                Weiss, Charlotte:
                  Whiskers
            */

            // </Snippet40>
        }
        #endregion

        #region Intersect
        static void IntersectEx1()
        {
            // <Snippet41>
            int[] id1 = { 44, 26, 92, 30, 71, 38 };
            int[] id2 = { 39, 59, 83, 47, 26, 4, 30 };

            // Get the numbers that occur in both arrays (id1 and id2).
            IEnumerable<int> both = id1.AsQueryable().Intersect(id2);

            foreach (int id in both)
                Console.WriteLine(id);

            /*
                This code produces the following output:

                26
                30
            */

            // </Snippet41>
        }
        #endregion

        #region Join
        static class Join
        {
            // <Snippet42>
            class Person
            {
                public string Name { get; set; }
            }

            class Pet
            {
                public string Name { get; set; }
                public Person Owner { get; set; }
            }

            public static void JoinEx1()
            {
                Person magnus = new Person { Name = "Hedlund, Magnus" };
                Person terry = new Person { Name = "Adams, Terry" };
                Person charlotte = new Person { Name = "Weiss, Charlotte" };

                Pet barley = new Pet { Name = "Barley", Owner = terry };
                Pet boots = new Pet { Name = "Boots", Owner = terry };
                Pet whiskers = new Pet { Name = "Whiskers", Owner = charlotte };
                Pet daisy = new Pet { Name = "Daisy", Owner = magnus };

                List<Person> people = new List<Person> { magnus, terry, charlotte };
                List<Pet> pets = new List<Pet> { barley, boots, whiskers, daisy };

                // Join the list of Person objects and the list of Pet objects 
                // to create a list of person-pet pairs where each element is 
                // an anonymous type that contains the name of pet and the name
                // of the person that owns the pet.
                var query = people.AsQueryable().Join(pets,
                                person => person,
                                pet => pet.Owner,
                                (person, pet) =>
                                    new { OwnerName = person.Name, Pet = pet.Name });

                foreach (var obj in query)
                {
                    Console.WriteLine(
                        "{0} - {1}",
                        obj.OwnerName,
                        obj.Pet);
                }
            }

            /*
                This code produces the following output:

                Hedlund, Magnus - Daisy
                Adams, Terry - Barley
                Adams, Terry - Boots
                Weiss, Charlotte - Whiskers
            */

            // </Snippet42>
        }
        #endregion

        #region Last
        static void LastEx1()
        {
            // <Snippet43>
            int[] numbers = { 9, 34, 65, 92, 87, 435, 3, 54, 
                                83, 23, 87, 67, 12, 19 };

            int last = numbers.AsQueryable().Last();

            Console.WriteLine(last);

            /*
                This code produces the following output:

                19
            */

            // </Snippet43>
        }

        static void LastEx2()
        {
            // <Snippet44>
            int[] numbers = { 9, 34, 65, 92, 87, 435, 3, 54, 
                                83, 23, 87, 67, 12, 19 };

            // Get the last number in the array that is greater than 80.
            int last = numbers.AsQueryable().Last(num => num > 80);

            Console.WriteLine(last);

            /*
                This code produces the following output:

                87
            */

            // </Snippet44>
        }
        #endregion

        #region LastOrDefault
        static void LastOrDefaultEx1()
        {
            // <Snippet45>
            // Create an empty array.
            string[] fruits = { };

            // Get the last item in the array, or else the default
            // value for type string (null).
            string last = fruits.AsQueryable().LastOrDefault();

            Console.WriteLine(
                String.IsNullOrEmpty(last) ? "[STRING IS NULL OR EMPTY]" : last);

            /*
                This code produces the following output:

                [STRING IS NULL OR EMPTY]
            */

            // </Snippet45>
        }

        static void LastOrDefaultEx2()
        {
            // <Snippet46>
            double[] numbers = { 49.6, 52.3, 51.0, 49.4, 50.2, 48.3 };

            // Get the last number in the array that rounds to 50.0,
            // or else the default value for type double (0.0).
            double last50 =
                numbers.AsQueryable().LastOrDefault(n => Math.Round(n) == 50.0);

            Console.WriteLine("The last number that rounds to 50 is {0}.", last50);

            // Get the last number in the array that rounds to 40.0,
            // or else the default value for type double (0.0).
            double last40 =
                numbers.AsQueryable().LastOrDefault(n => Math.Round(n) == 40.0);

            Console.WriteLine(
                "The last number that rounds to 40 is {0}.",
                last40 == 0.0 ? "[DOES NOT EXIST]" : last40.ToString());

            /*
                This code produces the following output:

                The last number that rounds to 50 is 50.2.
                The last number that rounds to 40 is [DOES NOT EXIST].
            */

            // </Snippet46>
        }

        static void LastOrDefaultEx3()
        {
            // <Snippet132>
            List<int> daysOfMonth = new List<int> { };

            // Setting the default value to 1 after the query.
            int lastDay1 = daysOfMonth.AsQueryable().LastOrDefault();
            if (lastDay1 == 0)
            {
                lastDay1 = 1;
            }
            Console.WriteLine("The value of the lastDay1 variable is {0}", lastDay1);

            // Setting the default value to 1 by using DefaultIfEmpty() in the query.
            int lastDay2 = daysOfMonth.AsQueryable().DefaultIfEmpty(1).Last();
            Console.WriteLine("The value of the lastDay2 variable is {0}", lastDay2);

            /*
             This code produces the following output:
             
             The value of the lastDay1 variable is 1
             The value of the lastDay2 variable is 1
            */
            // </Snippet132>
        }
        #endregion

        #region LongCount
        public static void LongCountEx1()
        {
            // <Snippet47>
            string[] fruits = { "apple", "banana", "mango", 
                                  "orange", "passionfruit", "grape" };

            long count = fruits.AsQueryable().LongCount();

            Console.WriteLine("There are {0} fruits in the collection.", count);

            /*
                This code produces the following output:

                There are 6 fruits in the collection.
            */

            // </Snippet47>
        }

        static class LongCount
        {
            // <Snippet48>
            class Pet
            {
                public string Name { get; set; }
                public int Age { get; set; }
            }

            public static void LongCountEx2()
            {
                Pet[] pets = { new Pet { Name="Barley", Age=8 },
                               new Pet { Name="Boots", Age=4 },
                               new Pet { Name="Whiskers", Age=1 } };

                const int Age = 3;

                // Count the number of Pet objects where Pet.Age is greater than 3.
                long count = pets.AsQueryable().LongCount(pet => pet.Age > Age);

                Console.WriteLine("There are {0} animals over age {1}.", count, Age);
            }

            /*
                This code produces the following output:

                There are 2 animals over age 3.
            */

            // </Snippet48>
        }
        #endregion

        #region Max
        static void MaxEx1()
        {
            // <Snippet52>
            List<long> longs = new List<long> { 4294967296L, 466855135L, 81125L };

            long max = longs.AsQueryable().Max();

            Console.WriteLine("The largest number is {0}.", max);

            /*
                This code produces the following output:

                The largest number is 4294967296.
            */

            // </Snippet52>
        }

        static class Max2 // with a selector
        {
            // <Snippet58>
            class Pet
            {
                public string Name { get; set; }
                public int Age { get; set; }
            }

            public static void MaxEx2()
            {
                Pet[] pets = { new Pet { Name="Barley", Age=8 },
                               new Pet { Name="Boots", Age=4 },
                               new Pet { Name="Whiskers", Age=1 } };

                // Add Pet.Age to the length of Pet.Name
                // to determine the "maximum" Pet object in the array.
                int max =
                    pets.AsQueryable().Max(pet => pet.Age + pet.Name.Length);

                Console.WriteLine(
                    "The maximum pet age plus name length is {0}.",
                    max);
            }

            /*
                This code produces the following output:

                The maximum pet age plus name length is 14.
            */

            // </Snippet58>
        }

        #endregion

        #region Min
        static void MinEx1()
        {
            // <Snippet60>
            double[] doubles = { 1.5E+104, 9E+103, -2E+103 };

            double min = doubles.AsQueryable().Min();

            Console.WriteLine("The smallest number is {0}.", min);

            /*
                This code produces the following output:

                The smallest number is -2E+103.
            */

            // </Snippet60>
        }

        static class Min2 // with a selector
        {
            // <Snippet68>
            class Pet
            {
                public string Name { get; set; }
                public int Age { get; set; }
            }

            public static void MinEx2()
            {
                Pet[] pets = { new Pet { Name="Barley", Age=8 },
                               new Pet { Name="Boots", Age=4 },
                               new Pet { Name="Whiskers", Age=1 } };

                // Get the Pet object that has the smallest Age value.
                int min = pets.AsQueryable().Min(pet => pet.Age);

                Console.WriteLine("The youngest animal is age {0}.", min);
            }

            /*
                This code produces the following output:

                The youngest animal is age 1.  
            */

            // </Snippet68>
        }
        #endregion

        #region OfType
        static void OfTypeEx1()
        {
            // <Snippet69>
            // Create a list of MemberInfo objects.
            List<System.Reflection.MemberInfo> members = typeof(String).GetMembers().ToList();

            // Return only those items that can be cast to type PropertyInfo.
            IQueryable<System.Reflection.PropertyInfo> propertiesOnly =
                members.AsQueryable().OfType<System.Reflection.PropertyInfo>();

            Console.WriteLine("Members of type 'PropertyInfo' are:");
            foreach (System.Reflection.PropertyInfo pi in propertiesOnly)
                Console.WriteLine(pi.Name);

            /*
                This code produces the following output:
             
                Members of type 'PropertyInfo' are:
                Chars
                Length
            */

            // </Snippet69>
        }
        #endregion

        #region OrderBy
        static class OrderBy
        {
            // <Snippet70>
            class Pet
            {
                public string Name { get; set; }
                public int Age { get; set; }
            }

            public static void OrderByEx1()
            {
                Pet[] pets = { new Pet { Name="Barley", Age=8 },
                               new Pet { Name="Boots", Age=4 },
                               new Pet { Name="Whiskers", Age=1 } };

                // Sort the Pet objects in the array by Pet.Age.
                IEnumerable<Pet> query =
                    pets.AsQueryable().OrderBy(pet => pet.Age);

                foreach (Pet pet in query)
                    Console.WriteLine("{0} - {1}", pet.Name, pet.Age);
            }

            /*
                This code produces the following output:

                Whiskers - 1
                Boots - 4
                Barley - 8
            */

            // </Snippet70>
        }
        #endregion

        #region OrderByDescending
        static class OrderByDescending
        {
            // <Snippet71>
            /// <summary>
            /// This IComparer class sorts by the fractional part of the decimal number.
            /// </summary>
            public class SpecialComparer : IComparer<decimal>
            {
                /// <summary>
                /// Compare two decimal numbers by their fractional parts.
                /// </summary>
                /// <param name="d1">The first decimal to compare.</param>
                /// <param name="d2">The second decimal to compare.</param>
                /// <returns>1 if the first decimal's fractional part 
                /// is greater than the second decimal's fractional part,
                /// -1 if the first decimal's fractional
                /// part is less than the second decimal's fractional part,
                /// or the result of calling Decimal.Compare()
                /// if the fractional parts are equal.</returns>
                public int Compare(decimal d1, decimal d2)
                {
                    decimal fractional1, fractional2;

                    // Get the fractional part of the first number.
                    try
                    {
                        fractional1 = decimal.Remainder(d1, decimal.Floor(d1));
                    }
                    catch (DivideByZeroException)
                    {
                        fractional1 = d1;
                    }
                    // Get the fractional part of the second number.
                    try
                    {
                        fractional2 = decimal.Remainder(d2, decimal.Floor(d2));
                    }
                    catch (DivideByZeroException)
                    {
                        fractional2 = d2;
                    }

                    if (fractional1 == fractional2)
                        return Decimal.Compare(d1, d2);
                    else if (fractional1 > fractional2)
                        return 1;
                    else
                        return -1;
                }
            }

            public static void OrderByDescendingEx1()
            {
                List<decimal> decimals =
                    new List<decimal> { 6.2m, 8.3m, 0.5m, 1.3m, 6.3m, 9.7m };

                // Sort the decimal values in descending order
                // by using a custom comparer.
                IEnumerable<decimal> query =
                    decimals.AsQueryable()
                    .OrderByDescending(num => num, new SpecialComparer());

                foreach (decimal num in query)
                    Console.WriteLine(num);
            }

            /*
                This code produces the following output:

                9.7
                0.5
                8.3
                6.3
                1.3
                6.2
            */

            // </Snippet71>
        }
        #endregion

        #region Reverse
        static void ReverseEx1()
        {
            // <Snippet74>
            char[] apple = { 'a', 'p', 'p', 'l', 'e' };

            // Reverse the order of the characters in the collection.
            IQueryable<char> reversed = apple.AsQueryable().Reverse();

            foreach (char chr in reversed)
                Console.Write(chr + " ");
            Console.WriteLine();

            /*
                This code produces the following output:

                e l p p a
            */

            // </Snippet74>
        }
        #endregion

        #region Select
        static void SelectEx1()
        {
            // <Snippet75>
            List<int> range =
                new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // Project the square of each int value.
            IEnumerable<int> squares =
                range.AsQueryable().Select(x => x * x);

            foreach (int num in squares)
                Console.WriteLine(num);

            /*
                This code produces the following output:

                1
                4
                9
                16
                25
                36
                49
                64
                81
                100
            */

            // </Snippet75>
        }

        static void SelectEx2()
        {
            // <Snippet76>
            string[] fruits = { "apple", "banana", "mango", "orange", 
                                  "passionfruit", "grape" };

            // Project an anonymous type that contains the
            // index of the string in the source array, and
            // a string that contains the same number of characters
            // as the string's index in the source array.
            var query =
                fruits.AsQueryable()
                .Select((fruit, index) =>
                            new { index, str = fruit.Substring(0, index) });

            foreach (var obj in query)
                Console.WriteLine("{0}", obj);

            /*
                This code produces the following output:

                { index = 0, str =  }
                { index = 1, str = b }
                { index = 2, str = ma }
                { index = 3, str = ora }
                { index = 4, str = pass }
                { index = 5, str = grape }
            */

            // </Snippet76>
        }
        #endregion

        #region SelectMany
        static class SelectMany1
        {
            // <Snippet77>
            class PetOwner
            {
                public string Name { get; set; }
                public List<String> Pets { get; set; }
            }

            public static void SelectManyEx1()
            {
                PetOwner[] petOwners = 
                    { new PetOwner { Name="Higa, Sidney", 
                          Pets = new List<string>{ "Scruffy", "Sam" } },
                      new PetOwner { Name="Ashkenazi, Ronen", 
                          Pets = new List<string>{ "Walker", "Sugar" } },
                      new PetOwner { Name="Price, Vernette", 
                          Pets = new List<string>{ "Scratches", "Diesel" } } };

                // Query using SelectMany().
                IEnumerable<string> query1 =
                    petOwners.AsQueryable().SelectMany(petOwner => petOwner.Pets);

                Console.WriteLine("Using SelectMany():");

                // Only one foreach loop is required to iterate through the
                // results because it is a one-dimensional collection.
                foreach (string pet in query1)
                    Console.WriteLine(pet);

                // This code shows how to use Select() instead of SelectMany().
                IEnumerable<List<String>> query2 =
                    petOwners.AsQueryable().Select(petOwner => petOwner.Pets);

                Console.WriteLine("\nUsing Select():");

                // Notice that two foreach loops are required to iterate through
                // the results because the query returns a collection of arrays.
                foreach (List<String> petList in query2)
                {
                    foreach (string pet in petList)
                    {
                        Console.WriteLine(pet);
                    }
                    Console.WriteLine();
                }
            }

            /*
                This code produces the following output:

                Using SelectMany():
                Scruffy
                Sam
                Walker
                Sugar
                Scratches
                Diesel

                Using Select():
                Scruffy
                Sam

                Walker
                Sugar

                Scratches
                Diesel
            */

            // </Snippet77>
        }

        static class SelectMany2
        {
            // <Snippet78>
            class PetOwner
            {
                public string Name { get; set; }
                public List<string> Pets { get; set; }
            }

            public static void SelectManyEx2()
            {
                PetOwner[] petOwners = 
                    { new PetOwner { Name="Higa, Sidney", 
                          Pets = new List<string>{ "Scruffy", "Sam" } },
                      new PetOwner { Name="Ashkenazi, Ronen", 
                          Pets = new List<string>{ "Walker", "Sugar" } },
                      new PetOwner { Name="Price, Vernette", 
                          Pets = new List<string>{ "Scratches", "Diesel" } },
                      new PetOwner { Name="Hines, Patrick", 
                          Pets = new List<string>{ "Dusty" } } };

                // For each PetOwner element in the source array,
                // project a sequence of strings where each string
                // consists of the index of the PetOwner element in the
                // source array and the name of each pet in PetOwner.Pets.
                IEnumerable<string> query =
                    petOwners.AsQueryable()
                    .SelectMany(
                    (petOwner, index) => petOwner.Pets.Select(pet => index + pet)
                    );

                foreach (string pet in query)
                    Console.WriteLine(pet);
            }

            // This code produces the following output:
            //
            // 0Scruffy
            // 0Sam
            // 1Walker
            // 1Sugar
            // 2Scratches
            // 2Diesel
            // 3Dusty

            // </Snippet78>
        }

        static class SelectMany3
        {
            // <Snippet124>
            class PetOwner
            {
                public string Name { get; set; }
                public List<Pet> Pets { get; set; }
            }

            class Pet
            {
                public string Name { get; set; }
                public string Breed { get; set; }
            }

            public static void SelectManyEx3()
            {
                PetOwner[] petOwners =
                    { new PetOwner { Name="Higa", 
                          Pets = new List<Pet>{
                              new Pet { Name="Scruffy", Breed="Poodle" },
                              new Pet { Name="Sam", Breed="Hound" } } },
                      new PetOwner { Name="Ashkenazi", 
                          Pets = new List<Pet>{
                              new Pet { Name="Walker", Breed="Collie" },
                              new Pet { Name="Sugar", Breed="Poodle" } } },
                      new PetOwner { Name="Price", 
                          Pets = new List<Pet>{
                              new Pet { Name="Scratches", Breed="Dachshund" },
                              new Pet { Name="Diesel", Breed="Collie" } } },
                      new PetOwner { Name="Hines", 
                          Pets = new List<Pet>{
                              new Pet { Name="Dusty", Breed="Collie" } } }
                    };

                // This query demonstrates how to obtain a sequence of
                // the names of all the pets whose breed is "Collie", while
                // keeping an association with the owner that owns the pet.
                var query =
                    petOwners.AsQueryable()
                    // Create a sequence of ALL the Pet objects. Then
                    // project an anonymous type that consists of each
                    // Pet in the new sequence and the PetOwner object
                    // from the initial array that corresponds to that pet.
                   .SelectMany(owner => owner.Pets,
                               (owner, pet) => new { owner, pet })
                    // Filter the sequence of anonymous types to only
                    // keep pets whose breed is "Collie".
                    .Where(ownerAndPet => ownerAndPet.pet.Breed == "Collie")
                    // Project an anonymous type that consists
                    // of the pet owner's name and the pet's name.
                    .Select(ownerAndPet => new
                    {
                        Owner = ownerAndPet.owner.Name,
                        Pet = ownerAndPet.pet.Name
                    });

                // Print the results.
                foreach (var obj in query)
                    Console.WriteLine(obj);
            }

            /* This code produces the following output:
            
                { Owner = Ashkenazi, Pet = Walker }
                { Owner = Price, Pet = Diesel }
                { Owner = Hines, Pet = Dusty }
            */

            // </Snippet124>
        }
        #endregion

        #region SequenceEqual
        static class SequenceEqual1
        {
            // <Snippet32>
            class Pet
            {
                public string Name { get; set; }
                public int Age { get; set; }
            }

            public static void SequenceEqualEx1()
            {
                Pet pet1 = new Pet { Name = "Turbo", Age = 2 };
                Pet pet2 = new Pet { Name = "Peanut", Age = 8 };

                // Create two lists of pets.
                List<Pet> pets1 = new List<Pet> { pet1, pet2 };
                List<Pet> pets2 = new List<Pet> { pet1, pet2 };

                // Determine if the lists are equal.
                bool equal = pets1.AsQueryable().SequenceEqual(pets2);

                Console.WriteLine(
                    "The lists {0} equal.",
                    equal ? "are" : "are not");
            }

            /*
                This code produces the following output:

                The lists are equal.
            */

            // </Snippet32>
        }

        static class SequenceEqual2
        {
            // <Snippet33>
            class Pet
            {
                public string Name { get; set; }
                public int Age { get; set; }
            }

            public static void SequenceEqualEx2()
            {
                Pet pet1 = new Pet() { Name = "Turbo", Age = 2 };
                Pet pet2 = new Pet() { Name = "Peanut", Age = 8 };

                // Create two lists of pets.
                List<Pet> pets1 = new List<Pet> { pet1, pet2 };
                List<Pet> pets2 = new List<Pet> { 
                    new Pet { Name = "Turbo", Age = 2 },
                    new Pet { Name = "Peanut", Age = 8 } 
                };

                // Determine if the lists are equal.
                bool equal = pets1.AsQueryable().SequenceEqual(pets2);

                Console.WriteLine("The lists {0} equal.", equal ? "are" : "are NOT");
            }

            /*
                This code produces the following output:

                The lists are NOT equal.
            */

            // </Snippet33>
        }
        #endregion

        #region Single
        static void SingleEx1()
        {
            // <Snippet79>
            // Create two arrays.
            string[] fruits1 = { "orange" };
            string[] fruits2 = { "orange", "apple" };
            
            // Get the only item in the first array.
            string fruit1 = fruits1.AsQueryable().Single();

            Console.WriteLine("First query: " + fruit1);

            try
            {
                // Try to get the only item in the second array.
                string fruit2 = fruits2.AsQueryable().Single();
                Console.WriteLine("Second query: " + fruit2);
            }
            catch (System.InvalidOperationException)
            {
                Console.WriteLine(
                    "Second query: The collection does not contain exactly one element."
                    );
            }

            /*
                This code produces the following output:

                First query: orange
                Second query: The collection does not contain exactly one element
            */

            // </Snippet79>
        }

        // TODO - Should I add exception handling to 
        // all the snippets whose operators are 
        // documented to throw those exceptions??
        static void SingleEx2()
        {
            // <Snippet81>
            string[] fruits = { "apple", "banana", "mango", 
                                  "orange", "passionfruit", "grape" };

            // Get the only string in the array whose length is greater than 10.
            string fruit1 = fruits.AsQueryable().Single(fruit => fruit.Length > 10);

            Console.WriteLine("First Query: " + fruit1);

            try
            {
                // Try to get the only string in the array
                // whose length is greater than 15.
                string fruit2 = fruits.AsQueryable().Single(fruit => fruit.Length > 15);
                Console.WriteLine("Second Query: " + fruit2);
            }
            catch (System.InvalidOperationException)
            {
                Console.Write("Second Query: The collection does not contain ");
                Console.WriteLine("exactly one element whose length is greater than 15.");
            }

            /*
                This code produces the following output:

                First Query: passionfruit
                Second Query: The collection does not contain exactly one 
                element whose length is greater than 15.
             */

            // </Snippet81>
        }
        #endregion

        #region SingleOrDefault
        static void SingleOrDefaultEx1()
        {
            // <Snippet83>
            // Create two arrays. The second is empty.
            string[] fruits1 = { "orange" };
            string[] fruits2 = { };

            // Get the only item in the first array, or else
            // the default value for type string (null).
            string fruit1 = fruits1.AsQueryable().SingleOrDefault();
            Console.WriteLine("First Query: " + fruit1);

            // Get the only item in the second array, or else
            // the default value for type string (null). 
            string fruit2 = fruits2.AsQueryable().SingleOrDefault();
            Console.WriteLine("Second Query: " +
                (String.IsNullOrEmpty(fruit2) ? "No such string!" : fruit2));

            /*
                This code produces the following output:

                First Query: orange
                Second Query: No such string!
            */

            // </Snippet83>
        }

        static void SingleOrDefaultEx2()
        {
            // <Snippet85>
            string[] fruits = { "apple", "banana", "mango", 
                                  "orange", "passionfruit", "grape" };

            // Get the single string in the array whose length is greater
            // than 10, or else the default value for type string (null).
            string fruit1 =
                fruits.AsQueryable().SingleOrDefault(fruit => fruit.Length > 10);
            Console.WriteLine("First Query: " + fruit1);

            // Get the single string in the array whose length is greater
            // than 15, or else the default value for type string (null).
            string fruit2 =
               fruits.AsQueryable().SingleOrDefault(fruit => fruit.Length > 15);
            Console.WriteLine("Second Query: " +
                (String.IsNullOrEmpty(fruit2) ? "No such string!" : fruit2));

            /*
                This code produces the following output:

                First Query: passionfruit
                Second Query: No such string!
            */

            // </Snippet85>
        }

        static void SingleOrDefaultEx3()
        {
            // <Snippet133>
            int[] pageNumbers = { };

            // Setting the default value to 1 after the query.
            int pageNumber1 = pageNumbers.AsQueryable().SingleOrDefault();
            if (pageNumber1 == 0)
            {
                pageNumber1 = 1;
            }
            Console.WriteLine("The value of the pageNumber1 variable is {0}", pageNumber1);

            // Setting the default value to 1 by using DefaultIfEmpty() in the query.
            int pageNumber2 = pageNumbers.AsQueryable().DefaultIfEmpty(1).Single();
            Console.WriteLine("The value of the pageNumber2 variable is {0}", pageNumber2);

            /*
             This code produces the following output:
            
             The value of the pageNumber1 variable is 1
             The value of the pageNumber2 variable is 1
            */

            // </Snippet133>
        }
        #endregion

        #region Skip
        static void SkipEx1()
        {
            // <Snippet87>
            int[] grades = { 59, 82, 70, 56, 92, 98, 85 };

            // Sort the grades in descending order and
            // get all except the first three.
            IEnumerable<int> lowerGrades =
                grades.AsQueryable().OrderByDescending(g => g).Skip(3);

            Console.WriteLine("All grades except the top three are:");
            foreach (int grade in lowerGrades)
                Console.WriteLine(grade);

            /*
                This code produces the following output:

                All grades except the top three are:
                82
                70
                59
                56
            */

            // </Snippet87>
        }
        #endregion

        #region SkipWhile
        static void SkipWhileEx1()
        {
            // <Snippet88>
            int[] grades = { 59, 82, 70, 56, 92, 98, 85 };

            // Get all grades less than 80 by first
            // sorting the grades in descending order and then
            // taking all the grades after the first grade
            // that is less than 80.
            IEnumerable<int> lowerGrades =
                grades.AsQueryable()
                .OrderByDescending(grade => grade)
                .SkipWhile(grade => grade >= 80);

            Console.WriteLine("All grades below 80:");
            foreach (int grade in lowerGrades)
                Console.WriteLine(grade);

            /*
                This code produces the following output:

                All grades below 80:
                70
                59
                56
            */

            // </Snippet88>
        }

        static void SkipWhileEx2()
        {
            // <Snippet89>
            int[] amounts = { 5000, 2500, 9000, 8000, 
                                6500, 4000, 1500, 5500 };

            // Skip over amounts in the array until the first amount
            // that is less than or equal to the product of its
            // index in the array and 1000. Take the remaining items.
            IEnumerable<int> query =
                amounts.AsQueryable()
                .SkipWhile((amount, index) => amount > index * 1000);

            foreach (int amount in query)
                Console.WriteLine(amount);

            /*
                This code produces the following output:

                4000
                1500
                5500
            */

            // </Snippet89>
        }
        #endregion

        #region Sum
        static void SumEx1()
        {
            // <Snippet120>
            List<float> numbers = new List<float> { 43.68F, 1.25F, 583.7F, 6.5F };

            float sum = numbers.AsQueryable().Sum();

            Console.WriteLine("The sum of the numbers is {0}.", sum);

            /*
                This code produces the following output:

                The sum of the numbers is 635.13.
            */

            // </Snippet120>
        }

        static void SumEx2()
        {
            // <Snippet121>
            float?[] points = { null, 0, 92.83F, null, 100.0F, 37.46F, 81.1F };

            float? sum = points.AsQueryable().Sum();

            Console.WriteLine("Total points earned: {0}", sum);

            /*
                This code produces the following output:

                Total points earned: 311.39
            */

            // </Snippet121>
        }

        static class Sum3
        {
            // <Snippet98>
            class Package
            {
                public string Company { get; set; }
                public double Weight { get; set; }
            }

            public static void SumEx3()
            {
                List<Package> packages =
                    new List<Package> 
                        { new Package { Company = "Coho Vineyard", Weight = 25.2 },
                          new Package { Company = "Lucerne Publishing", Weight = 18.7 },
                          new Package { Company = "Wingtip Toys", Weight = 6.0 },
                          new Package { Company = "Adventure Works", Weight = 33.8 } };

                // Calculate the sum of all package weights.
                double totalWeight = packages.AsQueryable().Sum(pkg => pkg.Weight);

                Console.WriteLine("The total weight of the packages is: {0}", totalWeight);
            }

            /*
                This code produces the following output:

                The total weight of the packages is: 83.7
            */

            // </Snippet98>
        }
        #endregion

        #region Take
        static void TakeEx1()
        {
            // <Snippet99>
            int[] grades = { 59, 82, 70, 56, 92, 98, 85 };

            // Sort the grades in descending order and take the first three.
            IEnumerable<int> topThreeGrades =
                grades.AsQueryable().OrderByDescending(grade => grade).Take(3);

            Console.WriteLine("The top three grades are:");
            foreach (int grade in topThreeGrades)
                Console.WriteLine(grade);

            /*
                This code produces the following output:

                The top three grades are:
                98
                92
                85
            */

            // </Snippet99>
        }
        #endregion

        #region TakeWhile
        static void TakeWhileEx1()
        {
            // <Snippet100>
            string[] fruits = { "apple", "banana", "mango", "orange", 
                                  "passionfruit", "grape" };

            // Take strings from the array until a string
            // that is equal to "orange" is found.
            IEnumerable<string> query =
                fruits.AsQueryable()
                .TakeWhile(fruit => String.Compare("orange", fruit, true) != 0);

            foreach (string fruit in query)
                Console.WriteLine(fruit);

            /*
                This code produces the following output:

                apple
                banana
                mango
            */

            // </Snippet100>
        }

        static void TakeWhileEx2()
        {
            // <Snippet101>
            string[] fruits = { "apple", "passionfruit", "banana", "mango", 
                                  "orange", "blueberry", "grape", "strawberry" };

            // Take strings from the array until a string whose length
            // is less than its index in the array is found.
            IEnumerable<string> query =
                fruits.AsQueryable()
                .TakeWhile((fruit, index) => fruit.Length >= index);

            foreach (string fruit in query)
                Console.WriteLine(fruit);

            /*
                This code produces the following output:

                apple
                passionfruit
                banana
                mango
                orange
                blueberry
            */

            // </Snippet101>
        }
        #endregion

        #region ThenBy
        static void ThenByEx1()
        {
            // <Snippet102>
            string[] fruits = { "grape", "passionfruit", "banana", "apple", 
                                  "orange", "raspberry", "mango", "blueberry" };

            // Sort the strings first by their length and then 
            // alphabetically by passing the identity selector function.
            IEnumerable<string> query =
                fruits.AsQueryable()
                .OrderBy(fruit => fruit.Length).ThenBy(fruit => fruit);

            foreach (string fruit in query)
                Console.WriteLine(fruit);

            /*
                This code produces the following output:

                apple
                grape
                mango
                banana
                orange
                blueberry
                raspberry
                passionfruit
            */

            // </Snippet102>
        }
        #endregion

        #region ThenByDescending
        static class ThenByDescending
        {
            // <Snippet103>
            public class CaseInsensitiveComparer : IComparer<string>
            {
                public int Compare(string x, string y)
                {
                    return string.Compare(x, y, true);
                }
            }

            public static void ThenByDescendingEx1()
            {
                string[] fruits = 
                { "apPLe", "baNanA", "apple", "APple", "orange", "BAnana", "ORANGE", "apPLE" };

                // Sort the strings first ascending by their length and 
                // then descending using a custom case insensitive comparer.
                IEnumerable<string> query =
                    fruits.AsQueryable()
                    .OrderBy(fruit => fruit.Length)
                    .ThenByDescending(fruit => fruit, new CaseInsensitiveComparer());

                foreach (string fruit in query)
                    Console.WriteLine(fruit);
            }

            /*
                This code produces the following output:
            
                apPLe
                apple
                APple
                apPLE
                orange
                ORANGE
                baNanA
                BAnana
            */

            // </Snippet103>
        }
        #endregion

        #region Union
        static void UnionEx1()
        {
            // <Snippet109>
            int[] ints1 = { 5, 3, 9, 7, 5, 9, 3, 7 };
            int[] ints2 = { 8, 3, 6, 4, 4, 9, 1, 0 };

            // Get the set union of the items in the two arrays.
            IEnumerable<int> union = ints1.AsQueryable().Union(ints2);

            foreach (int num in union)
                Console.Write("{0} ", num);

            /*
                This code produces the following output:

                5 3 9 7 8 6 4 1 0
            */

            // </Snippet109>

            Console.WriteLine();
        }
        #endregion

        #region Where
        static void WhereEx1()
        {
            // <Snippet110>
            List<string> fruits =
                new List<string> { "apple", "passionfruit", "banana", "mango", 
                                   "orange", "blueberry", "grape", "strawberry" };

            // Get all strings whose length is less than 6.
            IEnumerable<string> query =
                fruits.AsQueryable().Where(fruit => fruit.Length < 6);

            foreach (string fruit in query)
                Console.WriteLine(fruit);

            /*
                This code produces the following output:

                apple
                mango
                grape
            */

            // </Snippet110>
        }

        static void WhereEx2()
        {
            // <Snippet111>
            int[] numbers = { 0, 30, 20, 15, 90, 85, 40, 75 };

            // Get all the numbers that are less than or equal to
            // the product of their index in the array and 10.
            IEnumerable<int> query =
                numbers.AsQueryable()
                .Where((number, index) => number <= index * 10);

            foreach (int number in query)
                Console.WriteLine(number);

            /*
                This code produces the following output:

                0
                20
                15
                40
            */

            // </Snippet111>
        }
        #endregion

        #region Zip
        static void ZipEx()
        {
            // <Snippet200>
            int[] numbers = { 1, 2, 3, 4 };
            string[] words = { "one", "two", "three" };

            var numbersAndWords = numbers.AsQueryable().Zip(words, (first, second) => first + " " + second);

            foreach (var item in numbersAndWords)
                Console.WriteLine(item);

            // This code produces the following output:

            // 1 one
            // 2 two
            // 3 three

            // </Snippet200>
        }
        #endregion


    }
}
