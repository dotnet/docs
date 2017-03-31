//<Snippet2>
using System;
using System.Collections;

public class ScrambleList : ArrayList
{
    public static void Main()
    {
        // Create an empty ArrayList, and add some elements.
        ScrambleList integerList = new ScrambleList();

        for (int i = 0; i < 10; i++)
        {
            integerList.Add(i);
        }

        Console.WriteLine("Ordered:\n");
        foreach (int value in integerList)
        {
            Console.Write("{0}, ", value);
        }
        Console.WriteLine("<end>\n\nScrambled:\n");
        
        // Scramble the order of the items in the list.
        integerList.Scramble();
        
        foreach (int value in integerList)
        {
            Console.Write("{0}, ", value);
        }
        Console.WriteLine("<end>\n");
    }

    public void Scramble()
    {
        int limit = this.Count;
        int temp;
        int swapindex;
        Random rnd = new Random();
        for (int i = 0; i < limit; i++)
        {
            // The Item property of ArrayList is the default indexer. Thus,
            // this[i] is used instead of Item[i].
            temp = (int)this[i];
            swapindex = rnd.Next(0, limit - 1);
            this[i] = this[swapindex];
            this[swapindex] = temp;
        }
    }
}

// The program produces output similar to the following:
//
// Ordered:
//
// 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, <end>
//
// Scrambled:
//
// 5, 2, 8, 9, 6, 1, 7, 0, 4, 3, <end>
//</Snippet2>



