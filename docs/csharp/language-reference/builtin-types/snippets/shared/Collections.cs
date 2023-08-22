namespace CollectionExamples;

public class Collections
{
    public static void CreateList()
    {
        // <SnippetCreateList>
        // Create a list of strings.
        var salmons = new List<string>();
        salmons.Add("chinook");
        salmons.Add("coho");
        salmons.Add("pink");
        salmons.Add("sockeye");

        // Iterate through the list.
        foreach (var salmon in salmons)
        {
            Console.Write(salmon + " ");
        }
        // Output: chinook coho pink sockeye
        // </SnippetCreateList>
    }

    public static void CreateListInitializer()
    {
        // <SnippetCreateListInitializer>
        // Create a list of strings by using a
        // collection initializer.
        var salmons = new List<string> { "chinook", "coho", "pink", "sockeye" };

        // Iterate through the list.
        foreach (var salmon in salmons)
        {
            Console.Write(salmon + " ");
        }
        // Output: chinook coho pink sockeye
        // </SnippetCreateListInitializer>

        // <SnippetForLoop>
        for (var index = 0; index < salmons.Count; index++)
        {
            Console.Write(salmons[index] + " ");
        }
        // Output: chinook coho pink sockeye
        // </SnippetForLoop>

        // <SnippetRemoveItemByContent>
        // Remove an element from the list by specifying
        // the object.
        salmons.Remove("coho");

        // Iterate through the list.
        foreach (var salmon in salmons)
        {
            Console.Write(salmon + " ");
        }
        // Output: chinook pink sockeye
        // </SnippetRemoveItemByContent>
    }

    public static void RemoveByIndex()
    {

        // <SnippetRemoveItemByIndex>
        var numbers = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        // Remove odd numbers.
        for (var index = numbers.Count - 1; index >= 0; index--)
        {
            if (numbers[index] % 2 == 1)
            {
                // Remove the element by specifying
                // the zero-based index in the list.
                numbers.RemoveAt(index);
            }
        }

        // Iterate through the list.
        // A lambda expression is placed in the ForEach method
        // of the List(T) object.
        numbers.ForEach(
            number => Console.Write(number + " "));
        // Output: 0 2 4 6 8
        // </SnippetRemoveItemByIndex>
    }

    // <SnippetCustomList>
    private static void IterateThroughList()
    {
        var theGalaxies = new List<Galaxy>
        {
            new (){ Name="Tadpole", MegaLightYears=400},
            new (){ Name="Pinwheel", MegaLightYears=25},
            new (){ Name="Milky Way", MegaLightYears=0},
            new (){ Name="Andromeda", MegaLightYears=3}
        };

        foreach (Galaxy theGalaxy in theGalaxies)
        {
            Console.WriteLine(theGalaxy.Name + "  " + theGalaxy.MegaLightYears);
        }

        // Output:
        //  Tadpole  400
        //  Pinwheel  25
        //  Milky Way  0
        //  Andromeda  3
    }

    public class Galaxy
    {
        public string Name { get; set; }
        public int MegaLightYears { get; set; }
    }
    // </SnippetCustomList>

    // <SnippetDictionaryOldStyle>
    private static void IterateThruDictionary()
    {
        Dictionary<string, Element> elements = BuildDictionary();

        foreach (KeyValuePair<string, Element> kvp in elements)
        {
            Element theElement = kvp.Value;

            Console.WriteLine("key: " + kvp.Key);
            Console.WriteLine("values: " + theElement.Symbol + " " +
                theElement.Name + " " + theElement.AtomicNumber);
        }
    }

    private static Dictionary<string, Element> BuildDictionary()
    {
        var elements = new Dictionary<string, Element>();

        AddToDictionary(elements, "K", "Potassium", 19);
        AddToDictionary(elements, "Ca", "Calcium", 20);
        AddToDictionary(elements, "Sc", "Scandium", 21);
        AddToDictionary(elements, "Ti", "Titanium", 22);

        return elements;
    }

    private static void AddToDictionary(Dictionary<string, Element> elements,
        string symbol, string name, int atomicNumber)
    {
        Element theElement = new Element();

        theElement.Symbol = symbol;
        theElement.Name = name;
        theElement.AtomicNumber = atomicNumber;

        elements.Add(key: theElement.Symbol, value: theElement);
    }

    public class Element
    {
        public string Symbol { get; set; }
        public string Name { get; set; }
        public int AtomicNumber { get; set; }
    }
    // </SnippetDictionaryOldStyle>

    // <SnippetDictionaryBetter>
    private static Dictionary<string, Element> BuildDictionary2() =>
        new ()
        {
            {"K",
                new (){ Symbol="K", Name="Potassium", AtomicNumber=19}},
            {"Ca",
                new (){ Symbol="Ca", Name="Calcium", AtomicNumber=20}},
            {"Sc",
                new (){ Symbol="Sc", Name="Scandium", AtomicNumber=21}},
            {"Ti",
                new (){ Symbol="Ti", Name="Titanium", AtomicNumber=22}}
        };
    // </SnippetDictionaryBetter>

    // <SnippetFindInDictionary>
    private static void FindInDictionary(string symbol)
    {
        Dictionary<string, Element> elements = BuildDictionary();

        if (elements.ContainsKey(symbol) == false)
        {
            Console.WriteLine(symbol + " not found");
        }
        else
        {
            Element theElement = elements[symbol];
            Console.WriteLine("found: " + theElement.Name);
        }
    }
    // </SnippetFindInDictionary>

    // <SnippetFindInDictionary2>
    private static void FindInDictionary2(string symbol)
    {
        Dictionary<string, Element> elements = BuildDictionary();

        if (elements.TryGetValue(symbol, out Element? theElement) == false)
            Console.WriteLine(symbol + " not found");
        else
            Console.WriteLine("found: " + theElement.Name);
    }
    // </SnippetFindInDictionary2>

    // <ShowLINQ>
    private static void ShowLINQ()
    {
        List<Element> elements = BuildList();

        // LINQ Query.
        var subset = from theElement in elements
                     where theElement.AtomicNumber < 22
                     orderby theElement.Name
                     select theElement;

        foreach (Element theElement in subset)
        {
            Console.WriteLine(theElement.Name + " " + theElement.AtomicNumber);
        }

        // Output:
        //  Calcium 20
        //  Potassium 19
        //  Scandium 21
    }

    private static List<Element> BuildList() => new()
        {
            { new(){ Symbol="K", Name="Potassium", AtomicNumber=19}},
            { new(){ Symbol="Ca", Name="Calcium", AtomicNumber=20}},
            { new(){ Symbol="Sc", Name="Scandium", AtomicNumber=21}},
            { new(){ Symbol="Ti", Name="Titanium", AtomicNumber=22}}
        };
    // </ShowLINQ>

    // <SnippetSortList>
    private static void ListCars()
    {
        var cars = new List<Car>
        {
            { new (){ Name = "car1", Color = "blue", Speed = 20}},
            { new (){ Name = "car2", Color = "red", Speed = 50}},
            { new (){ Name = "car3", Color = "green", Speed = 10}},
            { new (){ Name = "car4", Color = "blue", Speed = 50}},
            { new (){ Name = "car5", Color = "blue", Speed = 30}},
            { new (){ Name = "car6", Color = "red", Speed = 60}},
            { new (){ Name = "car7", Color = "green", Speed = 50}}
        };

        // Sort the cars by color alphabetically, and then by speed
        // in descending order.
        cars.Sort();

        // View all of the cars.
        foreach (Car thisCar in cars)
        {
            Console.WriteLine($"{thisCar.Color.PadRight(5)} {thisCar.Speed} {thisCar.Name}");
        }

        // Output:
        //  blue  50 car4
        //  blue  30 car5
        //  blue  20 car1
        //  green 50 car7
        //  green 10 car3
        //  red   60 car6
        //  red   50 car2
    }

    public class Car : IComparable<Car>
    {
        public string Name { get; init; }
        public int Speed { get; init; }
        public string Color { get; init; }

        public int CompareTo(Car other)
        {
            // A call to this method makes a single comparison that is
            // used for sorting.

            // Determine the relative order of the objects being compared.
            // Sort by color alphabetically, and then by speed in
            // descending order.

            // Compare the colors.
            int compare;
            compare = String.Compare(this.Color, other.Color, true);

            // If the colors are the same, compare the speeds.
            if (compare == 0)
            {
                compare = this.Speed.CompareTo(other.Speed);

                // Use descending order for speed.
                compare = -compare;
            }

            return compare;
        }
    }
    // </SnippetSortList>

    // <SnippetEnumeration>
    private static void ListColors()
    {
        var colors = new AllColors();

        foreach (Color theColor in colors)
        {
            Console.Write(theColor.Name + " ");
        }
        Console.WriteLine();
        // Output: red blue green
    }

    // Collection class.
    public class AllColors : System.Collections.IEnumerable
    {
        Color[] _colors =
        {
            new (){ Name = "red" },
            new (){ Name = "blue" },
            new (){ Name = "green" }
        };

        public System.Collections.IEnumerator GetEnumerator()
        {
            return new ColorEnumerator(_colors);

            // Instead of creating a custom enumerator, you could
            // use the GetEnumerator of the array.
            //return _colors.GetEnumerator();
        }

        // Custom enumerator.
        private class ColorEnumerator : System.Collections.IEnumerator
        {
            private Color[] _colors;
            private int _position = -1;

            public ColorEnumerator(Color[] colors)
            {
                _colors = colors;
            }

            object System.Collections.IEnumerator.Current
            {
                get
                {
                    return _colors[_position];
                }
            }

            bool System.Collections.IEnumerator.MoveNext()
            {
                _position++;
                return (_position < _colors.Length);
            }

            void System.Collections.IEnumerator.Reset()
            {
                _position = -1;
            }
        }
    }

    // Element class.
    public class Color
    {
        public required string Name { get; init; }
    }
    // </SnippetEnumeration>

    // <SnippetIteratorMethod>
    private static void ListEvenNumbers()
    {
        foreach (int number in EvenSequence(5, 18))
        {
            Console.Write(number.ToString() + " ");
        }
        Console.WriteLine();
        // Output: 6 8 10 12 14 16 18
    }

    private static IEnumerable<int> EvenSequence(
        int firstNumber, int lastNumber)
    {
        // Yield even numbers in the range.
        for (var number = firstNumber; number <= lastNumber; number++)
        {
            if (number % 2 == 0)
            {
                yield return number;
            }
        }
    }
    // </SnippetIteratorMethod>
}
