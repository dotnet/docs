//<snippet23>
using System;
using System.Collections.Generic;

class AdvantageGenerics
{
    public static void Main()
    {
        string[] myArray =
            {"First String", "test string",  "Last String"};

        //<snippet24>
        LinkedList<string> llist = new LinkedList<string>();
        //</snippet24>

        foreach (string item in myArray)
        {
            llist.AddLast(item);
        }
        LinkedListNode<string> found = llist.Find("test string");
        if (found != null)
        {
            Console.WriteLine($"Item found: {found.Value}");
        }
        //<snippet25>
        int index0 = Array.BinarySearch(myArray, "test string");
        int index1 = Array.BinarySearch<string>(myArray, "test string");
        //</snippet25>

        Console.WriteLine("Indexes for binary searches: {0}, {1}", index0, index1);
    }
}
//</snippet23>
