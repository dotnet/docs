class ConsumingEnumerableDemo
{
    // Demonstrates:
    //      BlockingCollection<T>.Add()
    //      BlockingCollection<T>.CompleteAdding()
    //      BlockingCollection<T>.GetConsumingEnumerable()
    public static void BC_GetConsumingEnumerable()
    {
        using (BlockingCollection<int> bc = new BlockingCollection<int>())
        {

            // Kick off a producer task
            Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    bc.Add(i);
                    Thread.Sleep(100); // sleep 100 ms between adds
                }

                // Need to do this to keep foreach below from hanging
                bc.CompleteAdding();
            });

            // Now consume the blocking collection with foreach.
            // Use bc.GetConsumingEnumerable() instead of just bc because the
            // former will block waiting for completion and the latter will
            // simply take a snapshot of the current state of the underlying collection.
            foreach (var item in bc.GetConsumingEnumerable())
            {
                Console.WriteLine(item);
            }
        }
    }
}