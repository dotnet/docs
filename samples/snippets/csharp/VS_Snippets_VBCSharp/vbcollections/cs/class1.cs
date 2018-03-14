using System;
using System.Collections.Generic;

public class Class1
{
    // Collections (C# and Visual Basic)
    // e76533a9-5033-4a0b-b003-9c2be60d185b

    public void Process()
    {
        CreateList();
        Console.WriteLine();
        UseCollectionInitializer();
        Console.WriteLine();
        IterateUsingForNext();
        Console.WriteLine();
        RemoveBySpecifyingObject();
        Console.WriteLine();
        RemoveUsingForNext();
        Console.WriteLine();
        IterateThroughList();
        Console.WriteLine();
    }

    private void CreateList()
    {
        //<Snippet11>
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
        //</Snippet11>
    }

    private void UseCollectionInitializer()
    {
        //<Snippet12>
        // Create a list of strings by using a
        // collection initializer.
        var salmons = new List<string> { "chinook", "coho", "pink", "sockeye" };

        // Iterate through the list.
        foreach (var salmon in salmons)
        {
            Console.Write(salmon + " ");
        }
        // Output: chinook coho pink sockeye
        //</Snippet12>
    }

    private void IterateUsingForNext()
    {
        //<Snippet13>
        // Create a list of strings by using a
        // collection initializer.
        var salmons = new List<string> { "chinook", "coho", "pink", "sockeye" };

        for (var index = 0; index < salmons.Count; index++)
        {
            Console.Write(salmons[index] + " ");
        }
        // Output: chinook coho pink sockeye
        //</Snippet13>
    }

    private void RemoveBySpecifyingObject()
    {
        //<Snippet14>
        // Create a list of strings by using a
        // collection initializer.
        var salmons = new List<string> { "chinook", "coho", "pink", "sockeye" };

        // Remove an element from the list by specifying
        // the object.
        salmons.Remove("coho");

        // Iterate through the list.
        foreach (var salmon in salmons)
        {
            Console.Write(salmon + " ");
        }
        // Output: chinook pink sockeye
        //</Snippet14>
    }

    private void RemoveUsingForNext()
    {
        //<Snippet15>
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
        //</Snippet15>
    }


    //<Snippet16>
    private static void IterateThroughList()
    {
        var theGalaxies = new List<Galaxy>
            {
                new Galaxy() { Name="Tadpole", MegaLightYears=400},
                new Galaxy() { Name="Pinwheel", MegaLightYears=25},
                new Galaxy() { Name="Milky Way", MegaLightYears=0},
                new Galaxy() { Name="Andromeda", MegaLightYears=3}
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
    //</Snippet16>
}
