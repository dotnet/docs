using System;
using System.Collections.Generic;
using System.Linq;

namespace SequenceExamples
{
    class Program
    {
        // This part is just for testing the examples
        static void Main(string[] args)
        {
            CountEx1();
            Count.CountEx2();
        }

        #region Aggregate
        static void AggregateEx1()
        {
            // <Snippet1>
            string sentence = "the quick brown fox jumps over the lazy dog";

            // Split the string into individual words.
            string[] words = sentence.Split(' ');

            // Prepend each word to the beginning of the 
            // new sentence to reverse the word order.
            string reversed = words.Aggregate((workingSentence, next) =>
                                                  next + " " + workingSentence);

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
            int numEven = ints.Aggregate(0, (total, next) =>
                                                next % 2 == 0 ? total + 1 : total);

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
                fruits.Aggregate("banana",
                                (longest, next) =>
                                    next.Length > longest.Length ? next : longest,
                // Return the final result as an upper case string.
                                fruit => fruit.ToUpper());

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
        static class All
        {
            // <Snippet4>
            class Pet
            {
                public string Name { get; set; }
                public int Age { get; set; }
            }

            public static void AllEx()
            {
                // Create an array of Pets.
                Pet[] pets = { new Pet { Name="Barley", Age=10 },
                               new Pet { Name="Boots", Age=4 },
                               new Pet { Name="Whiskers", Age=6 } };

                // Determine whether all pet names 
                // in the array start with 'B'.
                bool allStartWithB = pets.All(pet =>
                                                  pet.Name.StartsWith("B"));

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
            // <Snippet129>
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
                                            where person.Pets.All(pet => pet.Age > 5)
                                            select person.LastName;

                foreach (string name in names)
                {
                    Console.WriteLine(name);
                }

                /* This code produces the following output:
                 * 
                 * Haas
                 * Antebi
                 */
            }
            // </Snippet129>
        }
        #endregion

        #region Any

        static class Any1
        {
            public static void AnyEx1()
            {
                // <Snippet5>
                List<int> numbers = new List<int> { 1, 2 };
                bool hasElements = numbers.Any();

                Console.WriteLine("The list {0} empty.",
                    hasElements ? "is not" : "is");

                // This code produces the following output:
                //
                // The list is not empty. 

                // </Snippet5>
            }

            // <Snippet130>
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
                                            where person.Pets.Any()
                                            select person.LastName;

                foreach (string name in names)
                {
                    Console.WriteLine(name);
                }

                /* This code produces the following output:
                  
                   Haas
                   Fakhouri
                   Philips
                */
            }
            // </Snippet130>
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
                // Create an array of Pets.
                Pet[] pets =
                    { new Pet { Name="Barley", Age=8, Vaccinated=true },
                      new Pet { Name="Boots", Age=4, Vaccinated=false },
                      new Pet { Name="Whiskers", Age=1, Vaccinated=false } };

                // Determine whether any pets over age 1 are also unvaccinated.
                bool unvaccinated =
                    pets.Any(p => p.Age > 1 && p.Vaccinated == false);

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

        #region AsEnumerable

        // <Snippet108>
        // Custom class.
        class Clump<T> : List<T>
        {
            // Custom implementation of Where().
            public IEnumerable<T> Where(Func<T, bool> predicate)
            {
                Console.WriteLine("In Clump's implementation of Where().");
                return Enumerable.Where(this, predicate);
            }
        }

        static void AsEnumerableEx1()
        {
            // Create a new Clump<T> object.
            Clump<string> fruitClump =
                new Clump<string> { "apple", "passionfruit", "banana", 
                    "mango", "orange", "blueberry", "grape", "strawberry" };

            // First call to Where():
            // Call Clump's Where() method with a predicate.
            IEnumerable<string> query1 =
                fruitClump.Where(fruit => fruit.Contains("o"));

            Console.WriteLine("query1 has been created.\n");

            // Second call to Where():
            // First call AsEnumerable() to hide Clump's Where() method and thereby
            // force System.Linq.Enumerable's Where() method to be called.
            IEnumerable<string> query2 =
                fruitClump.AsEnumerable().Where(fruit => fruit.Contains("o"));

            // Display the output.
            Console.WriteLine("query2 has been created.");
        }

        // This code produces the following output:
        //
        // In Clump's implementation of Where().
        // query1 has been created.
        //
        // query2 has been created.

        // </Snippet108> 
        #endregion

        #region Average
        static void AverageEx1()
        {
            // <Snippet8>
            List<int> grades = new List<int> { 78, 92, 100, 37, 81 };

            double average = grades.Average();

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

            double? average = longs.Average();

            Console.WriteLine("The average is {0}.", average);

            // This code produces the following output:
            //
            // The average is 133282081426.333. 

            // </Snippet12>
        }

        static void AverageEx3()
        {
            // <Snippet16>
            string[] numbers = { "10007", "37", "299846234235" };

            double average = numbers.Average(num => Convert.ToInt64(num));

            Console.WriteLine("The average is {0}.", average);

            // This code produces the following output:
            //
            // The average is 99948748093. 

            // </Snippet16>
        }

        static void AverageEx4()
        {
            // <Snippet18>
            string[] fruits = { "apple", "banana", "mango", "orange", "passionfruit", "grape" };

            double average = fruits.Average(s => s.Length);

            Console.WriteLine("The average string length is {0}.", average);

            // This code produces the following output:
            //
            // The average string length is 6.5. 

            // </Snippet18>
        }
        #endregion

        #region Cast
        static void CastEx1()
        {
            // <Snippet19>
            System.Collections.ArrayList fruits = new System.Collections.ArrayList();
            fruits.Add("mango");
            fruits.Add("apple");
            fruits.Add("lemon");
            
            IEnumerable<string> query =
                fruits.Cast<string>().OrderBy(fruit => fruit).Select(fruit => fruit);
            
            // The following code, without the cast, doesn't compile.
            //IEnumerable<string> query1 =
            //    fruits.OrderBy(fruit => fruit).Select(fruit => fruit);
            
            foreach (string fruit in query)
            {
                Console.WriteLine(fruit);
            }

            // This code produces the following output: 
            //
            // apple 
            // lemon
            // mango
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

            static Pet[] GetCats()
            {
                Pet[] cats = { new Pet { Name="Barley", Age=8 },
                               new Pet { Name="Boots", Age=4 },
                               new Pet { Name="Whiskers", Age=1 } };
                return cats;
            }

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

                IEnumerable<string> query =
                    cats.Select(cat => cat.Name).Concat(dogs.Select(dog => dog.Name));

                foreach (string name in query)
                {
                    Console.WriteLine(name);
                }
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

                IEnumerable<string> query =
                    new[] { cats.Select(cat => cat.Name), dogs.Select(dog => dog.Name) }
                    .SelectMany(name => name);

                foreach (string name in query)
                {
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

                // </Snippet112>
            }
        }
        #endregion

        #region Contains
        static void ContainsEx1()
        {
            // <Snippet21>
            string[] fruits = { "apple", "banana", "mango", "orange", "passionfruit", "grape" };

            string fruit = "mango";

            bool hasMango = fruits.Contains(fruit);

            Console.WriteLine(
                "The array {0} contain '{1}'.",
                hasMango ? "does" : "does not",
                fruit);

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
            string[] fruits = { "apple", "banana", "mango", "orange", "passionfruit", "grape" };

            try
            {
                int numberOfFruits = fruits.Count();
                Console.WriteLine(
                    "There are {0} fruits in the collection.",
                    numberOfFruits);

            }
            catch (OverflowException)
            {
                Console.WriteLine("The count is too large to store as an Int32.");
                Console.WriteLine("Try using the LongCount() method instead.");
            }

            // This code produces the following output:
            //
            // There are 6 fruits in the collection. 

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
                Pet[] pets = { new Pet { Name="Barley", Vaccinated=true },
                               new Pet { Name="Boots", Vaccinated=false },
                               new Pet { Name="Whiskers", Vaccinated=false } };

                try
                {
                    int numberUnvaccinated = pets.Count(p => p.Vaccinated == false);
                    Console.WriteLine("There are {0} unvaccinated animals.", numberUnvaccinated);
                }
                catch (OverflowException)
                {
                    Console.WriteLine("The count is too large to store as an Int32.");
                    Console.WriteLine("Try using the LongCount() method instead.");
                }
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
                List<Pet> pets =
                    new List<Pet>{ new Pet { Name="Barley", Age=8 },
                                   new Pet { Name="Boots", Age=4 },
                                   new Pet { Name="Whiskers", Age=1 } };

                foreach (Pet pet in pets.DefaultIfEmpty())
                {
                    Console.WriteLine(pet.Name);
                }
            }

            /*
             This code produces the following output:
            
             Barley
             Boots
             Whiskers
            */

            // </Snippet24>
        }

        static void DefaultIfEmptyEx1a()
        {
            // <Snippet25>
            List<int> numbers = new List<int>();

            foreach (int number in numbers.DefaultIfEmpty())
            {
                Console.WriteLine(number);
            }

            /*
             This code produces the following output:
            
             0
            */

            // </Snippet25>
        }

        static class DefaultIfEmtpy2
        {
            // <Snippet26>
            class Pet
            {
                public string Name { get; set; }
                public int Age { get; set; }
            }

            public static void DefaultIfEmptyEx2()
            {
                Pet defaultPet = new Pet { Name = "Default Pet", Age = 0 };

                List<Pet> pets1 =
                    new List<Pet>{ new Pet { Name="Barley", Age=8 },
                                   new Pet { Name="Boots", Age=4 },
                                   new Pet { Name="Whiskers", Age=1 } };

                foreach (Pet pet in pets1.DefaultIfEmpty(defaultPet))
                {
                    Console.WriteLine("Name: {0}", pet.Name);
                }

                List<Pet> pets2 = new List<Pet>();

                foreach (Pet pet in pets2.DefaultIfEmpty(defaultPet))
                {
                    Console.WriteLine("\nName: {0}", pet.Name);
                }
            }

            /*
             This code produces the following output:
            
             Name: Barley
             Name: Boots
             Name: Whiskers

             Name: Default Pet
            */

            // </Snippet26>
        }
        #endregion

        #region Distinct
        static void DistinctEx1()
        {
            // <Snippet27>
            List<int> ages = new List<int> { 21, 46, 46, 55, 17, 21, 55, 55 };

            IEnumerable<int> distinctAges = ages.Distinct();

            Console.WriteLine("Distinct ages:");

            foreach (int age in distinctAges)
            {
                Console.WriteLine(age);
            }

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
            string[] names =
                { "Hartono, Tommy", "Adams, Terry", "Andersen, Henriette Thaulow", 
                    
                    "Hedlund, Magnus", "Ito, Shu" };
            Random random = new Random(DateTime.Now.Millisecond);

            string name = names.ElementAt(random.Next(0, names.Length));

            Console.WriteLine("The name chosen at random is '{0}'.", name);

            /*
             This code produces the following sample output:
            
             The name chosen at random is 'Ito, Shu'.
            */

            // </Snippet28>
        }
        #endregion

        #region ElementAtOrDefault
        static void ElementAtOrDefaultEx1()
        {
            // <Snippet29>
            string[] names =
                { "Hartono, Tommy", "Adams, Terry", "Andersen, Henriette Thaulow",
                    "Hedlund, Magnus", "Ito, Shu" };

            int index = 20;

            string name = names.ElementAtOrDefault(index);

            Console.WriteLine(
                "The name chosen at index {0} is '{1}'.",
                index,
                String.IsNullOrEmpty(name) ? "<no name at this index>" : name);

            /*
             This code produces the following output:
            
             The name chosen at index 20 is '<no name at this index>'.
            */

            // </Snippet29>
        }
        #endregion

        #region Empty
        static void EmptyEx1()
        {
            // <Snippet30>
            IEnumerable<decimal> empty = Enumerable.Empty<decimal>();
            // </Snippet30>
        }

        static void EmptyEx2()
        {
            // <Snippet31>
            string[] names1 = { "Hartono, Tommy" };
            string[] names2 = { "Adams, Terry", "Andersen, Henriette Thaulow",
                                  "Hedlund, Magnus", "Ito, Shu" };
            string[] names3 = { "Solanki, Ajay", "Hoeing, Helge",
                                  "Andersen, Henriette Thaulow",
                                  "Potra, Cristina", "Iallo, Lucio" };

            List<string[]> namesList =
                new List<string[]> { names1, names2, names3 };

            // Only include arrays that have four or more elements
            IEnumerable<string> allNames =
                namesList.Aggregate(Enumerable.Empty<string>(),
                (current, next) => next.Length > 3 ? current.Union(next) : current);

            foreach (string name in allNames)
            {
                Console.WriteLine(name);
            }

            /*
             This code produces the following output:
            
             Adams, Terry
             Andersen, Henriette Thaulow
             Hedlund, Magnus
             Ito, Shu
             Solanki, Ajay
             Hoeing, Helge
             Potra, Cristina
             Iallo, Lucio
            */

            // </Snippet31>
        }
        #endregion

        #region Except
        static void ExceptEx1()
        {
            // <Snippet34>
            double[] numbers1 = { 2.0, 2.0, 2.1, 2.2, 2.3, 2.3, 2.4, 2.5 };
            double[] numbers2 = { 2.2 };

            IEnumerable<double> onlyInFirstSet = numbers1.Except(numbers2);

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

            int first = numbers.First();

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

            int first = numbers.First(number => number > 80);

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
            int[] numbers = { };
            int first = numbers.FirstOrDefault();
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

            string firstLongName = names.FirstOrDefault(name => name.Length > 20);

            Console.WriteLine("The first long name is '{0}'.", firstLongName);

            string firstVeryLongName = names.FirstOrDefault(name => name.Length > 30);

            Console.WriteLine(
                "There is {0} name longer than 30 characters.",
                string.IsNullOrEmpty(firstVeryLongName) ? "not a" : "a");

            /*
             This code produces the following output:
            
             The first long name is 'Andersen, Henriette Thaulow'.
             There is not a name longer than 30 characters.
            */

            // </Snippet38>
        }

        static void FirstOrDefaultEx3()
        {
            // <Snippet126>
            List<int> months = new List<int> { };

            // Setting the default value to 1 after the query.
            int firstMonth1 = months.FirstOrDefault();
            if (firstMonth1 == 0)
            {
                firstMonth1 = 1;
            }
            Console.WriteLine("The value of the firstMonth1 variable is {0}", firstMonth1);

            // Setting the default value to 1 by using DefaultIfEmpty() in the query.
            int firstMonth2 = months.DefaultIfEmpty(1).First();
            Console.WriteLine("The value of the firstMonth2 variable is {0}", firstMonth2);

            /*
             This code produces the following output:
            
             The value of the firstMonth1 variable is 1
             The value of the firstMonth2 variable is 1
            */

            // </Snippet126>
        }
        #endregion

        #region GroupBy
        static class GroupBy
        {
            // <Snippet39>
            class Pet
            {
                public string Name { get; set; }
                public int Age { get; set; }
            }

            // Uses method-based query syntax.
            public static void GroupByEx1()
            {
                // Create a list of pets.
                List<Pet> pets =
                    new List<Pet>{ new Pet { Name="Barley", Age=8 },
                                   new Pet { Name="Boots", Age=4 },
                                   new Pet { Name="Whiskers", Age=1 },
                                   new Pet { Name="Daisy", Age=4 } };

                // Group the pets using Age as the key value 
                // and selecting only the pet's Name for each value.
                IEnumerable<IGrouping<int, string>> query =
                    pets.GroupBy(pet => pet.Age, pet => pet.Name);

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

            // Uses query expression syntax.
            public static void GroupByEx2()
            {
                // Create a list of pets.
                List<Pet> pets =
                    new List<Pet>{ new Pet { Name="Barley", Age=8 },
                                   new Pet { Name="Boots", Age=4 },
                                   new Pet { Name="Whiskers", Age=1 },
                                   new Pet { Name="Daisy", Age=4 } };

                // Group the pets using Age as the key value 
                // and selecting only the pet's Name for each value.
                // <Snippet122>
                IEnumerable<IGrouping<int, string>> query =
                    from pet in pets
                    group pet.Name by pet.Age;
                // </Snippet122>

                // Iterate over each IGrouping in the collection.
                foreach (IGrouping<int, string> petGroup in query)
                {
                    // Print the key value of the IGrouping.
                    Console.WriteLine(petGroup.Key);
                    // Iterate over each value in the IGrouping 
                    // and print the value.
                    foreach (string name in petGroup)
                        Console.WriteLine("  {0}", name);
                }
            }

        }

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
                var query = petsList.GroupBy(
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
            // <Snippet125>
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
                var query = petsList.GroupBy(
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

            // </Snippet125>
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
                // type that contains a person's name and 
                // a collection of names of the pets they own.
                var query =
                    people.GroupJoin(pets,
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
                    {
                        Console.WriteLine("  {0}", pet);
                    }
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

            // Uses query syntax.
            public static void GroupJoinEx2()
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

                // <Snippet123>
                var query = from person in people
                            join pet in pets
                            on person equals pet.Owner into petCollection
                            select new
                            {
                                OwnerName = person.Name,
                                Pets = petCollection.Select(p => p.Name)
                            };
                // </Snippet123>

                foreach (var obj in query)
                {
                    // Output the owner's name.
                    Console.WriteLine("{0}:", obj.OwnerName);
                    // Output each of the owner's pet's names.
                    foreach (string pet in obj.Pets)
                    {
                        Console.WriteLine("  {0}", pet);
                    }
                }
            }
        }
        #endregion

        #region Intersect
        static void IntersectEx1()
        {
            // <Snippet41>
            int[] id1 = { 44, 26, 92, 30, 71, 38 };
            int[] id2 = { 39, 59, 83, 47, 26, 4, 30 };

            IEnumerable<int> both = id1.Intersect(id2);

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

                // Create a list of Person-Pet pairs where 
                // each element is an anonymous type that contains a
                // Pet's name and the name of the Person that owns the Pet.
                var query =
                    people.Join(pets,
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

            int last = numbers.Last();

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

            int last = numbers.Last(num => num > 80);

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
            string[] fruits = { };
            string last = fruits.LastOrDefault();
            Console.WriteLine(
                String.IsNullOrEmpty(last) ? "<string is null or empty>" : last);

            /*
             This code produces the following output:
            
             <string is null or empty>
            */

            // </Snippet45>
        }

        static void LastOrDefaultEx2()
        {
            // <Snippet46>
            double[] numbers = { 49.6, 52.3, 51.0, 49.4, 50.2, 48.3 };

            double last50 = numbers.LastOrDefault(n => Math.Round(n) == 50.0);

            Console.WriteLine("The last number that rounds to 50 is {0}.", last50);

            double last40 = numbers.LastOrDefault(n => Math.Round(n) == 40.0);

            Console.WriteLine(
                "The last number that rounds to 40 is {0}.",
                last40 == 0.0 ? "<DOES NOT EXIST>" : last40.ToString());

            /*
             This code produces the following output:
            
             The last number that rounds to 50 is 50.2.
             The last number that rounds to 40 is <DOES NOT EXIST>.
            */

            // </Snippet46>
        }

        static void LastOrDefaultEx3()
        {
            // <Snippet127>
            List<int> daysOfMonth = new List<int> { };

            // Setting the default value to 1 after the query.
            int lastDay1 = daysOfMonth.LastOrDefault();
            if (lastDay1 == 0)
            {
                lastDay1 = 1;
            }
            Console.WriteLine("The value of the lastDay1 variable is {0}", lastDay1);

            // Setting the default value to 1 by using DefaultIfEmpty() in the query.
            int lastDay2 = daysOfMonth.DefaultIfEmpty(1).Last();
            Console.WriteLine("The value of the lastDay2 variable is {0}", lastDay2);

            /*
             This code produces the following output:
             
             The value of the lastDay1 variable is 1
             The value of the lastDay2 variable is 1
            */
            // </Snippet127>
        }
        #endregion

        #region LongCount
        public static void LongCountEx1()
        {
            // <Snippet47>
            string[] fruits = { "apple", "banana", "mango", 
                                  "orange", "passionfruit", "grape" };

            long count = fruits.LongCount();

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

                long count = pets.LongCount(pet => pet.Age > Age);

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

            long max = longs.Max();

            Console.WriteLine("The largest number is {0}.", max);

            /*
             This code produces the following output:
            
             The largest number is 4294967296.
            */

            // </Snippet52>
        }

        static void MaxEx2()
        {
            // <Snippet54>
            double?[] doubles = { null, 1.5E+104, 9E+103, -2E+103 };

            double? max = doubles.Max();

            Console.WriteLine("The largest number is {0}.", max);

            /*
             This code produces the following output:
            
             The largest number is 1.5E+104.
            */

            // </Snippet54>
        }

        static class Max2 // IEnumerable<T>
        {
            // <Snippet57>
            /// <summary>
            /// This class implements IComparable to be able to 
            /// compare one Pet to another Pet.
            /// </summary>
            class Pet : IComparable<Pet>
            {
                public string Name { get; set; }
                public int Age { get; set; }

                /// <summary>
                /// Compares this Pet to another Pet by 
                /// summing each Pet's age and name length.
                /// </summary>
                /// <param name="other">The Pet to compare this Pet to.</param>
                /// <returns>-1 if this Pet is 'less' than the other Pet, 
                /// 0 if they are equal,
                /// or 1 if this Pet is 'greater' than the other Pet.</returns>
                int IComparable<Pet>.CompareTo(Pet other)
                {
                    int sumOther = other.Age + other.Name.Length;
                    int sumThis = this.Age + this.Name.Length;

                    if (sumOther > sumThis)
                        return -1;
                    else if (sumOther == sumThis)
                        return 0;
                    else
                        return 1;
                }
            }

            public static void MaxEx3()
            {
                Pet[] pets = { new Pet { Name="Barley", Age=8 },
                               new Pet { Name="Boots", Age=4 },
                               new Pet { Name="Whiskers", Age=1 } };

                Pet max = pets.Max();

                Console.WriteLine(
                    "The 'maximum' animal is {0}.",
                    max.Name);
            }

            /*
             This code produces the following output:
            
             The 'maximum' animal is Barley.
            */

            // </Snippet57>
        }

        static class Max10 // with a selector
        {
            // <Snippet58>
            class Pet
            {
                public string Name { get; set; }
                public int Age { get; set; }
            }

            public static void MaxEx4()
            {
                Pet[] pets = { new Pet { Name="Barley", Age=8 },
                               new Pet { Name="Boots", Age=4 },
                               new Pet { Name="Whiskers", Age=1 } };

                int max = pets.Max(pet => pet.Age + pet.Name.Length);

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

            double min = doubles.Min();

            Console.WriteLine("The smallest number is {0}.", min);

            /*
             This code produces the following output:
            
             The smallest number is -2E+103.
            */

            // </Snippet60>
        }

        static void MinEx2()
        {
            // <Snippet63>
            int?[] grades = { 78, 92, null, 99, 37, 81 };

            int? min = grades.Min();

            Console.WriteLine("The lowest grade is {0}.", min);

            /*
             This code produces the following output:
            
             The lowest grade is 37.
            */

            // </Snippet63>
        }

        static class Min9 // IEnumerable<T>
        {
            // <Snippet67>
            /// <summary>
            /// This class implements IComparable in order to 
            /// be able to compare different Pet objects.
            /// </summary>
            class Pet : IComparable<Pet>
            {
                public string Name { get; set; }
                public int Age { get; set; }

                /// <summary>
                /// Compares this Pet's age to another Pet's age.
                /// </summary>
                /// <param name="other">The Pet to compare this Pet to.</param>
                /// <returns>-1 if this Pet's age is smaller, 
                /// 0 if the Pets' ages are equal, or 
                /// 1 if this Pet's age is greater.</returns>
                int IComparable<Pet>.CompareTo(Pet other)
                {
                    if (other.Age > this.Age)
                        return -1;
                    else if (other.Age == this.Age)
                        return 0;
                    else
                        return 1;
                }
            }

            public static void MinEx3()
            {
                Pet[] pets = { new Pet { Name="Barley", Age=8 },
                               new Pet { Name="Boots", Age=4 },
                               new Pet { Name="Whiskers", Age=1 } };

                Pet min = pets.Min();

                Console.WriteLine(
                    "The 'minimum' animal is {0}.",
                    min.Name);
            }

            /*
             This code produces the following output:
            
             The 'minimum' animal is Whiskers.
            */

            // </Snippet67>
        }

        static class Min10 // with a selector
        {
            // <Snippet68>
            class Pet
            {
                public string Name { get; set; }
                public int Age { get; set; }
            }

            public static void MinEx4()
            {
                Pet[] pets = { new Pet { Name="Barley", Age=8 },
                               new Pet { Name="Boots", Age=4 },
                               new Pet { Name="Whiskers", Age=1 } };

                int min = pets.Min(pet => pet.Age);

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
            System.Collections.ArrayList fruits = new System.Collections.ArrayList(4);
            fruits.Add("Mango");
            fruits.Add("Orange");
            fruits.Add("Apple");
            fruits.Add(3.0);
            fruits.Add("Banana");

            // Apply OfType() to the ArrayList.
            IEnumerable<string> query1 = fruits.OfType<string>();

            Console.WriteLine("Elements of type 'string' are:");
            foreach (string fruit in query1)
            {
                Console.WriteLine(fruit);
            }

            // The following query shows that the standard query operators such as 
            // Where() can be applied to the ArrayList type after calling OfType().
            IEnumerable<string> query2 =
                fruits.OfType<string>().Where(fruit => fruit.ToLower().Contains("n"));

            Console.WriteLine("\nThe following strings contain 'n':");
            foreach (string fruit in query2)
            {
                Console.WriteLine(fruit);
            }

            // This code produces the following output:
            //
            // Elements of type 'string' are:
            // Mango
            // Orange
            // Apple
            // Banana
            //
            // The following strings contain 'n':
            // Mango
            // Orange
            // Banana

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

                IEnumerable<Pet> query = pets.OrderBy(pet => pet.Age);

                foreach (Pet pet in query)
                {
                    Console.WriteLine("{0} - {1}", pet.Name, pet.Age);
                }
            }

            /*
             This code produces the following output:
            
             Whiskers - 1
             Boots - 4
             Barley - 8
            */

            // </Snippet70>
        }

        // <Snippet140>
        public class CaseInsensitiveCompare : IComparer<string>
        {
            // Define a compare method that ignores case.
            public int Compare(string s1, string s2)
            {
                return string.Compare(s1, s2, true);
            }
        }

        public class CaseSensitiveCompare : IComparer<string>
        {
            // Define a compare method that does not ignore case.
            public int Compare(string s1, string s2)
            {
                return string.Compare(s1, s2, false);
            }
        }


        public static void OrderByIComparer()
        {

            string[] unsortedArray = { "one", "Four", "One", "First", "four", "first" };

            // Sort the array, ignoring case, and display the results.
            var sortedArray = unsortedArray.OrderBy(a => a, new CaseInsensitiveCompare());
            Console.WriteLine("Case-insensitive sort of the strings " +
                "in the array:");
            foreach (var element in sortedArray)
            {
                Console.WriteLine(element);
            }

            // Sort the array, not ignoring case, and display the results.
            sortedArray = unsortedArray.OrderBy(a => a, new CaseSensitiveCompare());
            Console.WriteLine("\nCase-sensitive sort of the strings in " +
                "the array:");
            foreach (var element in sortedArray)
            {
                Console.WriteLine(element);
            }

            // Change the lambda expression to sort by the length of each string.
            sortedArray = unsortedArray.OrderBy(a => (a.Length).ToString(), new CaseInsensitiveCompare());
            Console.WriteLine("\nSort based on the lengths of the strings in " +
                    "the array:");
            foreach (var element in sortedArray)
            {
                Console.WriteLine(element);
            }
        }
        // Output:
        // Case-insensitive sort of the strings in the array:
        // First
        // first
        // Four
        // four
        // one
        // One

        // Case-sensitive sort of the strings in the array:
        // first
        // First
        // four
        // Four
        // one
        // One

        // Sort based on the lengths of the strings in the array:
        // one
        // One
        // Four
        // four
        // First
        // first  
        // </Snippet140>
        #endregion

        #region OrderByDescending
        // overload calls the other
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

                IEnumerable<decimal> query =
                    decimals.OrderByDescending(num =>
                                                   num, new SpecialComparer());

                foreach (decimal num in query)
                {
                    Console.WriteLine(num);
                }
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

        #region Range
        static void RangeEx1()
        {
            // <Snippet72>
            // Generate a sequence of integers from 1 to 10 
            // and then select their squares.
            IEnumerable<int> squares = Enumerable.Range(1, 10).Select(x => x * x);

            foreach (int num in squares)
            {
                Console.WriteLine(num);
            }

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

            // </Snippet72>
        }
        #endregion

        #region Repeat
        static void RepeatEx1()
        {
            // <Snippet73>
            IEnumerable<string> strings =
                Enumerable.Repeat("I like programming.", 15);

            foreach (String str in strings)
            {
                Console.WriteLine(str);
            }

            /*
             This code produces the following output:
            
             I like programming.
             I like programming.
             I like programming.
             I like programming.
             I like programming.
             I like programming.
             I like programming.
             I like programming.
             I like programming.
             I like programming.
             I like programming.
             I like programming.
             I like programming.
             I like programming.
             I like programming.
            */

            // </Snippet73>
        }
        #endregion

        #region Reverse
        static void ReverseEx1()
        {
            // <Snippet74>
            char[] apple = { 'a', 'p', 'p', 'l', 'e' };

            char[] reversed = apple.Reverse().ToArray();

            foreach (char chr in reversed)
            {
                Console.Write(chr + " ");
            }
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
            IEnumerable<int> squares =
                Enumerable.Range(1, 10).Select(x => x * x);

            foreach (int num in squares)
            {
                Console.WriteLine(num);
            }
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

            var query =
                fruits.Select((fruit, index) =>
                                  new { index, str = fruit.Substring(0, index) });

            foreach (var obj in query)
            {
                Console.WriteLine("{0}", obj);
            }

            /*
             This code produces the following output:
            
             {index=0, str=}
             {index=1, str=b}
             {index=2, str=ma}
             {index=3, str=ora}
             {index=4, str=pass}
             {index=5, str=grape}
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
                IEnumerable<string> query1 = petOwners.SelectMany(petOwner => petOwner.Pets);

                Console.WriteLine("Using SelectMany():");

                // Only one foreach loop is required to iterate 
                // through the results since it is a
                // one-dimensional collection.
                foreach (string pet in query1)
                {
                    Console.WriteLine(pet);
                }

                // This code shows how to use Select() 
                // instead of SelectMany().
                IEnumerable<List<String>> query2 =
                    petOwners.Select(petOwner => petOwner.Pets);

                Console.WriteLine("\nUsing Select():");

                // Notice that two foreach loops are required to 
                // iterate through the results
                // because the query returns a collection of arrays.
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

                // Project the items in the array by appending the index 
                // of each PetOwner to each pet's name in that petOwner's 
                // array of pets.
                IEnumerable<string> query =
                    petOwners.SelectMany((petOwner, index) =>
                                             petOwner.Pets.Select(pet => index + pet));

                foreach (string pet in query)
                {
                    Console.WriteLine(pet);
                }
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
                public List<string> Pets { get; set; }
            }

            public static void SelectManyEx3()
            {
                PetOwner[] petOwners =
                    { new PetOwner { Name="Higa", 
                          Pets = new List<string>{ "Scruffy", "Sam" } },
                      new PetOwner { Name="Ashkenazi", 
                          Pets = new List<string>{ "Walker", "Sugar" } },
                      new PetOwner { Name="Price", 
                          Pets = new List<string>{ "Scratches", "Diesel" } },
                      new PetOwner { Name="Hines", 
                          Pets = new List<string>{ "Dusty" } } };

                // Project the pet owner's name and the pet's name.
                var query =
                    petOwners
                    .SelectMany(petOwner => petOwner.Pets, (petOwner, petName) => new { petOwner, petName })
                    .Where(ownerAndPet => ownerAndPet.petName.StartsWith("S"))
                    .Select(ownerAndPet =>
                            new
                            {
                                Owner = ownerAndPet.petOwner.Name,
                                Pet = ownerAndPet.petName
                            }
                    );

                // Print the results.
                foreach (var obj in query)
                {
                    Console.WriteLine(obj);
                }
            }

            // This code produces the following output:
            //
            // {Owner=Higa, Pet=Scruffy}
            // {Owner=Higa, Pet=Sam}
            // {Owner=Ashkenazi, Pet=Sugar}
            // {Owner=Price, Pet=Scratches}

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

                bool equal = pets1.SequenceEqual(pets2);

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
                List<Pet> pets2 =
                    new List<Pet> { new Pet { Name = "Turbo", Age = 2 }, 
                                    new Pet { Name = "Peanut", Age = 8 } };

                bool equal = pets1.SequenceEqual(pets2);

                Console.WriteLine("The lists {0} equal.", equal ? "are" : "are not");
            }

            /*
             This code produces the following output:
            
             The lists are not equal.
            */

            // </Snippet33>
        }
        #endregion

        #region Single
        static void SingleEx1()
        {
            // <Snippet79>
            string[] fruits1 = { "orange" };

            string fruit1 = fruits1.Single();

            Console.WriteLine(fruit1);

            /*
             This code produces the following output:
            
             orange
            */

            // </Snippet79>

            // <Snippet80>
            string[] fruits2 = { "orange", "apple" };
            string fruit2 = null;

            try
            {
                fruit2 = fruits2.Single();
            }
            catch (System.InvalidOperationException)
            {
                Console.WriteLine("The collection does not contain exactly one element.");
            }

            Console.WriteLine(fruit2);

            /*
             This code produces the following output:
            
             The collection does not contain exactly one element.
            */

            // </Snippet80>
        }

        // TODO - Should I add exception handling to 
        // all the snippets whose operators are 
        // documented to throw those exceptions??
        static void SingleEx2()
        {
            // <Snippet81>
            string[] fruits = { "apple", "banana", "mango", 
                                  "orange", "passionfruit", "grape" };

            string fruit1 = fruits.Single(fruit => fruit.Length > 10);

            Console.WriteLine(fruit1);

            /*
             This code produces the following output:
            
             passionfruit
            */

            // </Snippet81>

            // <Snippet82>
            string fruit2 = null;

            try
            {
                fruit2 = fruits.Single(fruit => fruit.Length > 15);
            }
            catch (System.InvalidOperationException)
            {
                Console.WriteLine(@"The collection does not contain exactly 
                                one element whose length is greater than 15.");
            }

            Console.WriteLine(fruit2);

            // This code produces the following output:
            //
            // The collection does not contain exactly  
            // one element whose length is greater than 15.

            // </Snippet82>
        }
        #endregion

        #region SingleOrDefault
        static void SingleOrDefaultEx1()
        {
            // <Snippet83>
            string[] fruits1 = { "orange" };

            string fruit1 = fruits1.SingleOrDefault();

            Console.WriteLine(fruit1);

            /*
             This code produces the following output:
            
             orange
            */

            // </Snippet83>

            // <Snippet84>
            string[] fruits2 = { };

            string fruit2 = fruits2.SingleOrDefault();

            Console.WriteLine(
                String.IsNullOrEmpty(fruit2) ? "No such string!" : fruit2);

            /*
             This code produces the following output:
            
             No such string!
            */

            // </Snippet84>
        }

        static void SingleOrDefaultEx2()
        {
            // <Snippet85>
            string[] fruits = { "apple", "banana", "mango", 
                                  "orange", "passionfruit", "grape" };

            string fruit1 = fruits.SingleOrDefault(fruit => fruit.Length > 10);

            Console.WriteLine(fruit1);

            /*
             This code produces the following output:
            
             passionfruit
            */

            // </Snippet85>

            // <Snippet86>
            string fruit2 =
                fruits.SingleOrDefault(fruit => fruit.Length > 15);

            Console.WriteLine(
                String.IsNullOrEmpty(fruit2) ? "No such string!" : fruit2);

            /*
             This code produces the following output:
            
             No such string!
            */

            // </Snippet86>
        }

        static void SingleOrDefaultEx3()
        {
            // <Snippet128>
            int[] pageNumbers = { };

            // Setting the default value to 1 after the query.
            int pageNumber1 = pageNumbers.SingleOrDefault();
            if (pageNumber1 == 0)
            {
                pageNumber1 = 1;
            }
            Console.WriteLine("The value of the pageNumber1 variable is {0}", pageNumber1);

            // Setting the default value to 1 by using DefaultIfEmpty() in the query.
            int pageNumber2 = pageNumbers.DefaultIfEmpty(1).Single();
            Console.WriteLine("The value of the pageNumber2 variable is {0}", pageNumber2);

            /*
             This code produces the following output:
            
             The value of the pageNumber1 variable is 1
             The value of the pageNumber2 variable is 1
            */

            // </Snippet128>
        }
        #endregion

        #region Skip
        static void SkipEx1()
        {
            // <Snippet87>
            int[] grades = { 59, 82, 70, 56, 92, 98, 85 };

            IEnumerable<int> lowerGrades =
                grades.OrderByDescending(g => g).Skip(3);

            Console.WriteLine("All grades except the top three are:");
            foreach (int grade in lowerGrades)
            {
                Console.WriteLine(grade);
            }

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

            IEnumerable<int> lowerGrades =
                grades
                .OrderByDescending(grade => grade)
                .SkipWhile(grade => grade >= 80);

            Console.WriteLine("All grades below 80:");
            foreach (int grade in lowerGrades)
            {
                Console.WriteLine(grade);
            }

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

            IEnumerable<int> query =
                amounts.SkipWhile((amount, index) => amount > index * 1000);

            foreach (int amount in query)
            {
                Console.WriteLine(amount);
            }

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
        static class Sum9
        {
            // <Snippet98>
            class Package
            {
                public string Company { get; set; }
                public double Weight { get; set; }
            }

            public static void SumEx1()
            {
                List<Package> packages =
                    new List<Package> 
                        { new Package { Company = "Coho Vineyard", Weight = 25.2 },
                          new Package { Company = "Lucerne Publishing", Weight = 18.7 },
                          new Package { Company = "Wingtip Toys", Weight = 6.0 },
                          new Package { Company = "Adventure Works", Weight = 33.8 } };

                double totalWeight = packages.Sum(pkg => pkg.Weight);

                Console.WriteLine("The total weight of the packages is: {0}", totalWeight);
            }

            /*
             This code produces the following output:
            
             The total weight of the packages is: 83.7
            */

            // </Snippet98>
        }

        static void SumEx2()
        {
            // <Snippet120>
            List<float> numbers = new List<float> { 43.68F, 1.25F, 583.7F, 6.5F };

            float sum = numbers.Sum();

            Console.WriteLine("The sum of the numbers is {0}.", sum);

            /*
             This code produces the following output:
            
             The sum of the numbers is 635.13.
            */

            // </Snippet120>
        }

        static void SumEx3()
        {
            // <Snippet121>
            float?[] points = { null, 0, 92.83F, null, 100.0F, 37.46F, 81.1F };

            float? sum = points.Sum();

            Console.WriteLine("Total points earned: {0}", sum);

            /*
             This code produces the following output:
            
             Total points earned: 311.39
            */

            // </Snippet121>
        }

        #endregion

        #region Take
        static void TakeEx1()
        {
            // <Snippet99>
            int[] grades = { 59, 82, 70, 56, 92, 98, 85 };

            IEnumerable<int> topThreeGrades =
                grades.OrderByDescending(grade => grade).Take(3);

            Console.WriteLine("The top three grades are:");
            foreach (int grade in topThreeGrades)
            {
                Console.WriteLine(grade);
            }
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

            IEnumerable<string> query =
                fruits.TakeWhile(fruit => String.Compare("orange", fruit, true) != 0);

            foreach (string fruit in query)
            {
                Console.WriteLine(fruit);
            }

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

            IEnumerable<string> query =
                fruits.TakeWhile((fruit, index) => fruit.Length >= index);

            foreach (string fruit in query)
            {
                Console.WriteLine(fruit);
            }

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
        // overload calls the other
        static void ThenByEx1()
        {
            // <Snippet102>
            string[] fruits = { "grape", "passionfruit", "banana", "mango", 
                                  "orange", "raspberry", "apple", "blueberry" };

            // Sort the strings first by their length and then 
            //alphabetically by passing the identity selector function.
            IEnumerable<string> query =
                fruits.OrderBy(fruit => fruit.Length).ThenBy(fruit => fruit);

            foreach (string fruit in query)
            {
                Console.WriteLine(fruit);
            }

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
        // overload calls the other
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
                string[] fruits = { "apPLe", "baNanA", "apple", "APple", "orange", "BAnana", "ORANGE", "apPLE" };

                // Sort the strings first ascending by their length and 
                // then descending using a custom case insensitive comparer.
                IEnumerable<string> query =
                    fruits
                    .OrderBy(fruit => fruit.Length)
                    .ThenByDescending(fruit => fruit, new CaseInsensitiveComparer());

                foreach (string fruit in query)
                {
                    Console.WriteLine(fruit);
                }
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

        #region ToArray
        static class ToArray
        {
            // <Snippet104>
            class Package
            {
                public string Company { get; set; }
                public double Weight { get; set; }
            }

            public static void ToArrayEx1()
            {
                List<Package> packages =
                    new List<Package> 
                        { new Package { Company = "Coho Vineyard", Weight = 25.2 },
                          new Package { Company = "Lucerne Publishing", Weight = 18.7 },
                          new Package { Company = "Wingtip Toys", Weight = 6.0 },
                          new Package { Company = "Adventure Works", Weight = 33.8 } };

                string[] companies = packages.Select(pkg => pkg.Company).ToArray();

                foreach (string company in companies)
                {
                    Console.WriteLine(company);
                }
            }

            /*
             This code produces the following output:
            
             Coho Vineyard
             Lucerne Publishing
             Wingtip Toys
             Adventure Works
            */

            // </Snippet104>
        }
        #endregion

        #region ToDictionary
        // overloads call each other
        static class ToDictionary
        {
            // <Snippet105>
            class Package
            {
                public string Company { get; set; }
                public double Weight { get; set; }
                public long TrackingNumber { get; set; }
            }

            public static void ToDictionaryEx1()
            {
                List<Package> packages =
                    new List<Package>
                        { new Package { Company = "Coho Vineyard", Weight = 25.2, TrackingNumber = 89453312L },
                          new Package { Company = "Lucerne Publishing", Weight = 18.7, TrackingNumber = 89112755L },
                          new Package { Company = "Wingtip Toys", Weight = 6.0, TrackingNumber = 299456122L },
                          new Package { Company = "Adventure Works", Weight = 33.8, TrackingNumber = 4665518773L } };

                // Create a Dictionary of Package objects, 
                // using TrackingNumber as the key.
                Dictionary<long, Package> dictionary =
                    packages.ToDictionary(p => p.TrackingNumber);

                foreach (KeyValuePair<long, Package> kvp in dictionary)
                {
                    Console.WriteLine(
                        "Key {0}: {1}, {2} pounds",
                        kvp.Key,
                        kvp.Value.Company,
                        kvp.Value.Weight);
                }
            }

            /*
             This code produces the following output:
            
             Key 89453312: Coho Vineyard, 25.2 pounds
             Key 89112755: Lucerne Publishing, 18.7 pounds
             Key 299456122: Wingtip Toys, 6 pounds
             Key 4665518773: Adventure Works, 33.8 pounds
            */

            // </Snippet105>
        }
        #endregion

        #region ToList
        static void ToListEx1()
        {
            // <Snippet106>
            string[] fruits = { "apple", "passionfruit", "banana", "mango", 
                                  "orange", "blueberry", "grape", "strawberry" };

            List<int> lengths = fruits.Select(fruit => fruit.Length).ToList();

            foreach (int length in lengths)
            {
                Console.WriteLine(length);
            }

            /*
             This code produces the following output:
            
             5
             12
             6
             5
             6
             9
             5
             10
            */

            // </Snippet106>
        }
        #endregion

        #region ToLookup
        // overloads call the same method
        static class ToLookup
        {
            // <Snippet107>
            class Package
            {
                public string Company { get; set; }
                public double Weight { get; set; }
                public long TrackingNumber { get; set; }
            }

            public static void ToLookupEx1()
            {
                // Create a list of Packages.
                List<Package> packages =
                    new List<Package>
                        { new Package { Company = "Coho Vineyard", 
                              Weight = 25.2, TrackingNumber = 89453312L },
                          new Package { Company = "Lucerne Publishing", 
                              Weight = 18.7, TrackingNumber = 89112755L },
                          new Package { Company = "Wingtip Toys", 
                              Weight = 6.0, TrackingNumber = 299456122L },
                          new Package { Company = "Contoso Pharmaceuticals", 
                              Weight = 9.3, TrackingNumber = 670053128L },
                          new Package { Company = "Wide World Importers", 
                              Weight = 33.8, TrackingNumber = 4665518773L } };

                // Create a Lookup to organize the packages. 
                // Use the first character of Company as the key value.
                // Select Company appended to TrackingNumber 
                // as the element values of the Lookup.
                ILookup<char, string> lookup =
                    packages
                    .ToLookup(p => Convert.ToChar(p.Company.Substring(0, 1)),
                              p => p.Company + " " + p.TrackingNumber);

                // Iterate through each IGrouping in the Lookup.
                foreach (IGrouping<char, string> packageGroup in lookup)
                {
                    // Print the key value of the IGrouping.
                    Console.WriteLine(packageGroup.Key);
                    // Iterate through each value in the 
                    // IGrouping and print its value.
                    foreach (string str in packageGroup)
                        Console.WriteLine("    {0}", str);
                }
            }

            /*
             This code produces the following output:
            
             C
                 Coho Vineyard 89453312
                 Contoso Pharmaceuticals 670053128
             L
                 Lucerne Publishing 89112755
             W
                 Wingtip Toys 299456122
                 Wide World Importers 4665518773
            */

            // </Snippet107>
        }
        #endregion

        #region Union
        static void UnionEx1()
        {
            // <Snippet109>
            int[] ints1 = { 5, 3, 9, 7, 5, 9, 3, 7 };
            int[] ints2 = { 8, 3, 6, 4, 4, 9, 1, 0 };

            IEnumerable<int> union = ints1.Union(ints2);

            foreach (int num in union)
            {
                Console.Write("{0} ", num);
            }

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

            IEnumerable<string> query = fruits.Where(fruit => fruit.Length < 6);

            foreach (string fruit in query)
            {
                Console.WriteLine(fruit);
            }
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

            IEnumerable<int> query =
                numbers.Where((number, index) => number <= index * 10);

            foreach (int number in query)
            {
                Console.WriteLine(number);
            }
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

            var numbersAndWords = numbers.Zip(words, (first, second) => first + " " + second);

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
