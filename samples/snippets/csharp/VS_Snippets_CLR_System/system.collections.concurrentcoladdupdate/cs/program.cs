//<snippet1>
using System;
using System.Collections.Concurrent;

class CD_Ctor
{
    // Demonstrates: 
    //      ConcurrentDictionary<TKey, TValue> ctor(concurrencyLevel, initialCapacity) 
    //      ConcurrentDictionary<TKey, TValue>[TKey] 
    static void Main()
    {
        // We know how many items we want to insert into the ConcurrentDictionary. 
        // So set the initial capacity to some prime number above that, to ensure that 
        // the ConcurrentDictionary does not need to be resized while initializing it. 
        int HIGHNUMBER = 64;
        int initialCapacity = 101;

        // The higher the concurrencyLevel, the higher the theoretical number of operations 
        // that could be performed concurrently on the ConcurrentDictionary.  However, global 
        // operations like resizing the dictionary take longer as the concurrencyLevel rises.  
        // For the purposes of this example, we'll compromise at numCores * 2. 
        int numProcs = Environment.ProcessorCount;
        int concurrencyLevel = numProcs * 2;

        // Construct the dictionary with the desired concurrencyLevel and initialCapacity
        ConcurrentDictionary<int, int> cd = new ConcurrentDictionary<int, int>(concurrencyLevel, initialCapacity);

        // Initialize the dictionary 
        for (int i = 1; i <= HIGHNUMBER; i++) cd[i] = i * i;

        Console.WriteLine("The square of 23 is {0} (should be {1})", cd[23], 23 * 23);

        // Now iterate through, adding one to the end of the list. Existing items should be updated to be divided by their 
        // key  and a new item will be added that is the square of its key.
        for (int i = 1; i <= HIGHNUMBER + 1; i++)
          cd.AddOrUpdate(i, i * i, (k,v) => v / i);

        Console.WriteLine("The square root of 529 is {0} (should be {1})", cd[23], 529 / 23);
        Console.WriteLine("The square of 65 is {0} (should be {1})", cd[HIGHNUMBER + 1], ((HIGHNUMBER + 1) * (HIGHNUMBER + 1)));
       
    }
}
//</snippet1>