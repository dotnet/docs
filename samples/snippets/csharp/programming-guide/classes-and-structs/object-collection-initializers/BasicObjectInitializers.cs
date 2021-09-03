using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace object_collection_initializers
{
    public class BasicObjectInitializers
    {
        // <SnippetCatDeclaration>
        public class Cat
        {
            // Auto-implemented properties.
            public int Age { get; set; }
            public string Name { get; set; }

            public Cat()
            {
            }

            public Cat(string name)
            {
                this.Name = name;
            }
        }
        // </SnippetCatDeclaration>

        // <SnippetCatOwnerDeclaration>
        public class CatOwner
        {
            public IList<Cat> Cats { get; } = new List<Cat>();
        }
        // </SnippetCatOwnerDeclaration>

        // <SnippetMatrixDeclaration>
        public class Matrix
        {
            private double[,] storage = new double[3, 3];

            public double this[int row, int column]
            {
                // The embedded array will throw out of range exceptions as appropriate.
                get { return storage[row, column]; }
                set { storage[row, column] = value; }
            }
        }
        // </SnippetMatrixDeclaration>

        public class Product
        {
            public string ProductName { get; set; }
            public decimal UnitPrice { get; set; }
        }

        public static void ObjectInitializerExamples()
        {
            // <SnippetObjectPropertyInitialization>
            Cat cat = new Cat { Age = 10, Name = "Fluffy" };
            Cat sameCat = new Cat("Fluffy"){ Age = 10 };
            // </SnippetObjectPropertyInitialization>

            // <SnippetMatrixInitialization>
            var identity = new Matrix
            {
                [0, 0] = 1.0,
                [0, 1] = 0.0,
                [0, 2] = 0.0,

                [1, 0] = 0.0,
                [1, 1] = 1.0,
                [1, 2] = 0.0,

                [2, 0] = 0.0,
                [2, 1] = 0.0,
                [2, 2] = 1.0,
            };
            // </SnippetMatrixInitialization>

            var products = new List<Product>();

            // <SnippetAnonymousUse>
            var productInfos =
                from p in products
                select new { p.ProductName, p.UnitPrice };
            // </SnippetAnonymousUse>

            // <SnippetListInitializer>
            List<Cat> cats = new List<Cat>
            {
                new Cat{ Name = "Sylvester", Age=8 },
                new Cat{ Name = "Whiskers", Age=2 },
                new Cat{ Name = "Sasha", Age=14 }
            };
            // </SnippetListInitializer>

            // <SnippetListInitialerWithNull>
            List<Cat> moreCats = new List<Cat>
            {
                new Cat{ Name = "Furrytail", Age=5 },
                new Cat{ Name = "Peaches", Age=4 },
                null
            };
            // </SnippetListInitialerWithNull>

            // <SnippetDictionaryIndexerInitializer>
            var numbers = new Dictionary<int, string>
            {
                [7] = "seven",
                [9] = "nine",
                [13] = "thirteen"
            };
            // </SnippetDictionaryIndexerInitializer>

            // <SnippetDictionaryAddInitializer>
            var moreNumbers = new Dictionary<int, string>
            {
                {19, "nineteen" },
                {23, "twenty-three" },
                {42, "forty-two" }
            };
            // </SnippetDictionaryAddInitializer>

            {
                // <SnippetReadOnlyPropertyCollectionInitializer>
                CatOwner owner = new CatOwner
                {
                    Cats =
                    {
                        new Cat{ Name = "Sylvester", Age=8 },
                        new Cat{ Name = "Whiskers", Age=2 },
                        new Cat{ Name = "Sasha", Age=14 }
                    }
                };
                // </SnippetReadOnlyPropertyCollectionInitializer>
            }

            {
                // <SnippetReadOnlyPropertyCollectionInitializerTranslation>
                CatOwner owner = new CatOwner();
                owner.Cats.Add(new Cat{ Name = "Sylvester", Age=8 });
                owner.Cats.Add(new Cat{ Name = "Whiskers", Age=2 });
                owner.Cats.Add(new Cat{ Name = "Sasha", Age=14 });
                // </SnippetReadOnlyPropertyCollectionInitializerTranslation>
            }

            InitializationSample.Main();
            FullExample.Main();
            DictionaryExample.Main();
        }
    }

    // The following code consolidates examples from the topic.
    // <SnippetFullExample>
    public class InitializationSample
    {
        public class Cat
        {
            // Auto-implemented properties.
            public int Age { get; set; }
            public string Name { get; set; }

            public Cat() { }

            public Cat(string name)
            {
                Name = name;
            }
        }

        public static void Main()
        {
            Cat cat = new Cat { Age = 10, Name = "Fluffy" };
            Cat sameCat = new Cat("Fluffy"){ Age = 10 };

            List<Cat> cats = new List<Cat>
            {
                new Cat { Name = "Sylvester", Age = 8 },
                new Cat { Name = "Whiskers", Age = 2 },
                new Cat { Name = "Sasha", Age = 14 }
            };

            List<Cat> moreCats = new List<Cat>
            {
                new Cat { Name = "Furrytail", Age = 5 },
                new Cat { Name = "Peaches", Age = 4 },
                null
            };

            // Display results.
            System.Console.WriteLine(cat.Name);

            foreach (Cat c in cats)
                System.Console.WriteLine(c.Name);

            foreach (Cat c in moreCats)
                if (c != null)
                    System.Console.WriteLine(c.Name);
                else
                    System.Console.WriteLine("List element has null value.");
        }
        // Output:
        //Fluffy
        //Sylvester
        //Whiskers
        //Sasha
        //Furrytail
        //Peaches
        //List element has null value.
    }
    // </SnippetFullExample>

    // <SnippetFullListExample>
    public class FullExample
    {
        class FormattedAddresses : IEnumerable<string>
        {
            private List<string> internalList = new List<string>();
            public IEnumerator<string> GetEnumerator() => internalList.GetEnumerator();

            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => internalList.GetEnumerator();

            public void Add(string firstname, string lastname,
                string street, string city,
                string state, string zipcode) => internalList.Add(
                $@"{firstname} {lastname}
{street}
{city}, {state} {zipcode}"
                );
        }

        public static void Main()
        {
            FormattedAddresses addresses = new FormattedAddresses()
            {
                {"John", "Doe", "123 Street", "Topeka", "KS", "00000" },
                {"Jane", "Smith", "456 Street", "Topeka", "KS", "00000" }
            };

            Console.WriteLine("Address Entries:");

            foreach (string addressEntry in addresses)
            {
                Console.WriteLine("\r\n" + addressEntry);
            }
        }

        /*
         * Prints:

            Address Entries:

            John Doe
            123 Street
            Topeka, KS 00000

            Jane Smith
            456 Street
            Topeka, KS 00000
         */
    }
    // </SnippetFullListExample>

    // <SnippetFullDictionaryInitializer>
    public class DictionaryExample
    {
        class RudimentaryMultiValuedDictionary<TKey, TValue> : IEnumerable<KeyValuePair<TKey, List<TValue>>>
        {
            private Dictionary<TKey, List<TValue>> internalDictionary = new Dictionary<TKey, List<TValue>>();

            public IEnumerator<KeyValuePair<TKey, List<TValue>>> GetEnumerator() => internalDictionary.GetEnumerator();

            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => internalDictionary.GetEnumerator();

            public List<TValue> this[TKey key]
            {
                get => internalDictionary[key];
                set => Add(key, value);
            }

            public void Add(TKey key, params TValue[] values) => Add(key, (IEnumerable<TValue>)values);

            public void Add(TKey key, IEnumerable<TValue> values)
            {
                if (!internalDictionary.TryGetValue(key, out List<TValue> storedValues))
                    internalDictionary.Add(key, storedValues = new List<TValue>());

                storedValues.AddRange(values);
            }
        }

        public static void Main()
        {
            RudimentaryMultiValuedDictionary<string, string> rudimentaryMultiValuedDictionary1
                = new RudimentaryMultiValuedDictionary<string, string>()
                {
                    {"Group1", "Bob", "John", "Mary" },
                    {"Group2", "Eric", "Emily", "Debbie", "Jesse" }
                };
            RudimentaryMultiValuedDictionary<string, string> rudimentaryMultiValuedDictionary2
                = new RudimentaryMultiValuedDictionary<string, string>()
                {
                    ["Group1"] = new List<string>() { "Bob", "John", "Mary" },
                    ["Group2"] = new List<string>() { "Eric", "Emily", "Debbie", "Jesse" }
                };
            RudimentaryMultiValuedDictionary<string, string> rudimentaryMultiValuedDictionary3
                = new RudimentaryMultiValuedDictionary<string, string>()
                {
                    {"Group1", new string []{ "Bob", "John", "Mary" } },
                    { "Group2", new string[]{ "Eric", "Emily", "Debbie", "Jesse" } }
                };

            Console.WriteLine("Using first multi-valued dictionary created with a collection initializer:");

            foreach (KeyValuePair<string, List<string>> group in rudimentaryMultiValuedDictionary1)
            {
                Console.WriteLine($"\r\nMembers of group {group.Key}: ");

                foreach (string member in group.Value)
                {
                    Console.WriteLine(member);
                }
            }

            Console.WriteLine("\r\nUsing second multi-valued dictionary created with a collection initializer using indexing:");

            foreach (KeyValuePair<string, List<string>> group in rudimentaryMultiValuedDictionary2)
            {
                Console.WriteLine($"\r\nMembers of group {group.Key}: ");

                foreach (string member in group.Value)
                {
                    Console.WriteLine(member);
                }
            }
            Console.WriteLine("\r\nUsing third multi-valued dictionary created with a collection initializer using indexing:");

            foreach (KeyValuePair<string, List<string>> group in rudimentaryMultiValuedDictionary3)
            {
                Console.WriteLine($"\r\nMembers of group {group.Key}: ");

                foreach (string member in group.Value)
                {
                    Console.WriteLine(member);
                }
            }
        }

        /*
         * Prints:

            Using first multi-valued dictionary created with a collection initializer:

            Members of group Group1:
            Bob
            John
            Mary

            Members of group Group2:
            Eric
            Emily
            Debbie
            Jesse

            Using second multi-valued dictionary created with a collection initializer using indexing:

            Members of group Group1:
            Bob
            John
            Mary

            Members of group Group2:
            Eric
            Emily
            Debbie
            Jesse

            Using third multi-valued dictionary created with a collection initializer using indexing:

            Members of group Group1:
            Bob
            John
            Mary

            Members of group Group2:
            Eric
            Emily
            Debbie
            Jesse
         */
    }
    // </SnippetFullDictionaryInitializer>
}
