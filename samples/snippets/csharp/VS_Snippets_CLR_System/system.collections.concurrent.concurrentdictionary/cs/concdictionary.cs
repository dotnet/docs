using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
//<snippet1> 

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
            int NUMITEMS = 64;
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
            for (int i = 0; i < NUMITEMS; i++) cd[i] = i * i;

            Console.WriteLine("The square of 23 is {0} (should be {1})", cd[23], 23 * 23);
        }
}
//</snippet1>

//<snippet2>
class CD_TryXYZ
{
        // Demonstrates:
        //      ConcurrentDictionary<TKey, TValue>.TryAdd()
        //      ConcurrentDictionary<TKey, TValue>.TryUpdate()
        //      ConcurrentDictionary<TKey, TValue>.TryRemove()
        static void Main()
        {
            int numFailures = 0; // for bookkeeping

            // Construct an empty dictionary
            ConcurrentDictionary<int, String> cd = new ConcurrentDictionary<int, string>();

            // This should work
            if (!cd.TryAdd(1, "one"))
            {
                Console.WriteLine("CD.TryAdd() failed when it should have succeeded");
                numFailures++;
            }

            // This shouldn't work -- key 1 is already in use
            if (cd.TryAdd(1, "uno"))
            {
                Console.WriteLine("CD.TryAdd() succeeded when it should have failed");
                numFailures++;
            }

            // Now change the value for key 1 from "one" to "uno" -- should work
            if (!cd.TryUpdate(1, "uno", "one"))
            {
                Console.WriteLine("CD.TryUpdate() failed when it should have succeeded");
                numFailures++;
            }

            // Try to change the value for key 1 from "eine" to "one" 
            //    -- this shouldn't work, because the current value isn't "eine"
            if (cd.TryUpdate(1, "one", "eine"))
            {
                Console.WriteLine("CD.TryUpdate() succeeded when it should have failed");
                numFailures++;
            }

            // Remove key/value for key 1.  Should work.
            string value1;
            if (!cd.TryRemove(1, out value1))
            {
                Console.WriteLine("CD.TryRemove() failed when it should have succeeded");
                numFailures++;
            }

            // Remove key/value for key 1.  Shouldn't work, because I already removed it
            string value2;
            if (cd.TryRemove(1, out value2))
            {
                Console.WriteLine("CD.TryRemove() succeeded when it should have failed");
                numFailures++;
            }

            // If nothing went wrong, say so
            if (numFailures == 0) Console.WriteLine("  OK!");
        }
}
//</snippet2>

//<snippet3>
class CD_GetOrAddOrUpdate
{
    // Demonstrates:
    //      ConcurrentDictionary<TKey, TValue>.AddOrUpdate()
    //      ConcurrentDictionary<TKey, TValue>.GetOrAdd()
    //      ConcurrentDictionary<TKey, TValue>[]
    static void Main()
    {
        // Construct a ConcurrentDictionary
        ConcurrentDictionary<int, int> cd = new ConcurrentDictionary<int, int>();

        // Bombard the ConcurrentDictionary with 10000 competing AddOrUpdates
        Parallel.For(0, 10000, i =>
        {
            // Initial call will set cd[1] = 1.  
            // Ensuing calls will set cd[1] = cd[1] + 1
            cd.AddOrUpdate(1, 1, (key, oldValue) => oldValue + 1);
        });

        Console.WriteLine("After 10000 AddOrUpdates, cd[1] = {0}, should be 10000", cd[1]);

        // Should return 100, as key 2 is not yet in the dictionary
        int value = cd.GetOrAdd(2, (key) => 100);
        Console.WriteLine("After initial GetOrAdd, cd[2] = {0} (should be 100)", value);

        // Should return 100, as key 2 is already set to that value
        value = cd.GetOrAdd(2, 10000);
        Console.WriteLine("After second GetOrAdd, cd[2] = {0} (should be 100)", value);
    }
}
//</snippet3>
