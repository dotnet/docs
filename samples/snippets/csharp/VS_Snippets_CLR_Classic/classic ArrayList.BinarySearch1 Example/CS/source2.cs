//<Snippet2>
using System;
using System.Collections;

public class SimpleStringComparer : IComparer
{
    int IComparer.Compare(object x, object y)
    {
        string cmpstr = (string)x;
        return cmpstr.CompareTo((string)y);
    }
}

public class MyArrayList : ArrayList
{
    public static void Main()
    {
        // Creates and initializes a new ArrayList.
        MyArrayList coloredAnimals = new MyArrayList();

        coloredAnimals.Add("White Tiger");
        coloredAnimals.Add("Pink Bunny");
        coloredAnimals.Add("Red Dragon");
        coloredAnimals.Add("Green Frog");
        coloredAnimals.Add("Blue Whale");
        coloredAnimals.Add("Black Cat");
        coloredAnimals.Add("Yellow Lion");

        // BinarySearch requires a sorted ArrayList.
        coloredAnimals.Sort();

        // Compare results of an iterative search with a binary search
        int index = coloredAnimals.IterativeSearch("White Tiger");
        Console.WriteLine("Iterative search, item found at index: {0}", index);

        index = coloredAnimals.BinarySearch("White Tiger", new SimpleStringComparer());
        Console.WriteLine("Binary search, item found at index:    {0}", index);
    }

    public int IterativeSearch(object finditem)
    {
        int index = -1;

        for (int i = 0; i < this.Count; i++)
        {
            if (finditem.Equals(this[i]))
            {
                index = i;
                break;
            }
        }
        return index;
    }
}
//
// This code produces the following output.
//
// Iterative search, item found at index: 5
// Binary search, item found at index:    5
//
//</Snippet2>

