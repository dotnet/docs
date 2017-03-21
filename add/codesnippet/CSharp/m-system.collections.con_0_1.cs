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