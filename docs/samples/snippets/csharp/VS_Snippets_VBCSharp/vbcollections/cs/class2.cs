using System;
using System.Collections.Generic;

public class Class2
{
    // Collections (C# and Visual Basic)
    // e76533a9-5033-4a0b-b003-9c2be60d185b


    public void Process()
    {
        IterateThruDictionary();
        Console.WriteLine();
        FindInDictionary("Ca");
        FindInDictionary("ca");
        Console.WriteLine();
        FindInDictionary2("Ca");
        FindInDictionary2("ca");
        Console.WriteLine();
    }

    //<Snippet21>
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
    //</Snippet21>


    //<Snippet22>
    private static Dictionary<string, Element> BuildDictionary2()
    {
        return new Dictionary<string, Element>
        {
            {"K",
                new Element() { Symbol="K", Name="Potassium", AtomicNumber=19}},
            {"Ca",
                new Element() { Symbol="Ca", Name="Calcium", AtomicNumber=20}},
            {"Sc",
                new Element() { Symbol="Sc", Name="Scandium", AtomicNumber=21}},
            {"Ti",
                new Element() { Symbol="Ti", Name="Titanium", AtomicNumber=22}}
        };
    }
    //</Snippet22>


    //<Snippet23>
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
    //</Snippet23>


    //<Snippet24>
    private static void FindInDictionary2(string symbol)
    {
        Dictionary<string, Element> elements = BuildDictionary();

        Element theElement = null;
        if (elements.TryGetValue(symbol, out theElement) == false)
            Console.WriteLine(symbol + " not found");
        else
            Console.WriteLine("found: " + theElement.Name);
    }
    //</Snippet24>

}

