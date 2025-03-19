//<Snippet11>
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
//</Snippet11>

//<Snippet12>
public class SynchronizedCache 
{
    private ReaderWriterLockSlim cacheLock = new ReaderWriterLockSlim();
    private Dictionary<int, string> innerCache = new Dictionary<int, string>();

    public int Count
    { get { return innerCache.Count; } }

    public string Read(int key)
    {
        cacheLock.EnterReadLock();
        try
        {
            return innerCache[key];
        }
        finally
        {
            cacheLock.ExitReadLock();
        }
    }

    public void Add(int key, string value)
    {
        cacheLock.EnterWriteLock();
        try
        {
            innerCache.Add(key, value);
        }
        finally
        {
            cacheLock.ExitWriteLock();
        }
    }

    public bool AddWithTimeout(int key, string value, int timeout)
    {
        if (cacheLock.TryEnterWriteLock(timeout))
        {
            try
            {
                innerCache.Add(key, value);
            }
            finally
            {
                cacheLock.ExitWriteLock();
            }
            return true;
        }
        else
        {
            return false;
        }
    }

    public AddOrUpdateStatus AddOrUpdate(int key, string value)
    {
        cacheLock.EnterUpgradeableReadLock();
        try
        {
            string result = null;
            if (innerCache.TryGetValue(key, out result))
            {
                if (result == value)
                {
                    return AddOrUpdateStatus.Unchanged;
                }
                else
                {
                    cacheLock.EnterWriteLock();
                    try
                    {
                        innerCache[key] = value;
                    }
                    finally
                    {
                        cacheLock.ExitWriteLock();
                    }
                    return AddOrUpdateStatus.Updated;
                }
            }
            else
            {
                cacheLock.EnterWriteLock();
                try
                {
                    innerCache.Add(key, value);
                }
                finally
                {
                    cacheLock.ExitWriteLock();
                }
                return AddOrUpdateStatus.Added;
            }
        }
        finally
        {
            cacheLock.ExitUpgradeableReadLock();
        }
    }

    public void Delete(int key)
    {
        cacheLock.EnterWriteLock();
        try
        {
            innerCache.Remove(key);
        }
        finally
        {
            cacheLock.ExitWriteLock();
        }
    }

    public enum AddOrUpdateStatus
    {
        Added,
        Updated,
        Unchanged
    };

    ~SynchronizedCache()
    {
       if (cacheLock != null) cacheLock.Dispose();
    }
}
//</Snippet12>

// <Snippet13>
public class Example
{
   public static void Main()
   {
      var sc = new SynchronizedCache();
      var tasks = new List<Task>();
      int itemsWritten = 0;

      // Execute a writer.
      tasks.Add(Task.Run( () => { String[] vegetables = { "broccoli", "cauliflower",
                                                          "carrot", "sorrel", "baby turnip",
                                                          "beet", "brussel sprout",
                                                          "cabbage", "plantain",
                                                          "spinach", "grape leaves",
                                                          "lime leaves", "corn",
                                                          "radish", "cucumber",
                                                          "raddichio", "lima beans" };
                                  for (int ctr = 1; ctr <= vegetables.Length; ctr++)
                                     sc.Add(ctr, vegetables[ctr - 1]);

                                  itemsWritten = vegetables.Length;
                                  Console.WriteLine($"Task {Task.CurrentId} wrote {itemsWritten} items\n");
                                } ));
      // Execute two readers, one to read from first to last and the second from last to first.
      for (int ctr = 0; ctr <= 1; ctr++) {
         bool desc = ctr == 1;
         tasks.Add(Task.Run( () => { int start, last, step;
                                     int items;
                                     do {
                                        String output = String.Empty;
                                        items = sc.Count;
                                        if (! desc) {
                                           start = 1;
                                           step = 1;
                                           last = items;
                                        }
                                        else {
                                           start = items;
                                           step = -1;
                                           last = 1;
                                        }

                                        for (int index = start; desc ? index >= last : index <= last; index += step)
                                           output += String.Format("[{0}] ", sc.Read(index));

                                        Console.WriteLine($"Task {Task.CurrentId} read {items} items: {output}\n");
                                     } while (items < itemsWritten | itemsWritten == 0);
                             } ));
      }
      // Execute a red/update task.
      tasks.Add(Task.Run( () => { Thread.Sleep(100);
                                  for (int ctr = 1; ctr <= sc.Count; ctr++) {
                                     String value = sc.Read(ctr);
                                     if (value == "cucumber")
                                        if (sc.AddOrUpdate(ctr, "green bean") != SynchronizedCache.AddOrUpdateStatus.Unchanged)
                                           Console.WriteLine("Changed 'cucumber' to 'green bean'");
                                  }
                                } ));

      // Wait for all three tasks to complete.
      Task.WaitAll(tasks.ToArray());

      // Display the final contents of the cache.
      Console.WriteLine();
      Console.WriteLine("Values in synchronized cache: ");
      for (int ctr = 1; ctr <= sc.Count; ctr++)
         Console.WriteLine("   {0}: {1}", ctr, sc.Read(ctr));
   }
}
// The example displays the following output:
//    Task 1 read 0 items:
//
//    Task 3 wrote 17 items
//
//
//    Task 1 read 17 items: [broccoli] [cauliflower] [carrot] [sorrel] [baby turnip] [
//    beet] [brussel sprout] [cabbage] [plantain] [spinach] [grape leaves] [lime leave
//    s] [corn] [radish] [cucumber] [raddichio] [lima beans]
//
//    Task 2 read 0 items:
//
//    Task 2 read 17 items: [lima beans] [raddichio] [cucumber] [radish] [corn] [lime
//    leaves] [grape leaves] [spinach] [plantain] [cabbage] [brussel sprout] [beet] [b
//    aby turnip] [sorrel] [carrot] [cauliflower] [broccoli]
//
//    Changed 'cucumber' to 'green bean'
//
//    Values in synchronized cache:
//       1: broccoli
//       2: cauliflower
//       3: carrot
//       4: sorrel
//       5: baby turnip
//       6: beet
//       7: brussel sprout
//       8: cabbage
//       9: plantain
//       10: spinach
//       11: grape leaves
//       12: lime leaves
//       13: corn
//       14: radish
//       15: green bean
//       16: raddichio
//       17: lima beans
// </Snippet13>
