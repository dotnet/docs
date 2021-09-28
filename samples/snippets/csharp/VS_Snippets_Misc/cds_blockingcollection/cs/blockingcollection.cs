using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace OverviewSnippets
{
    using System;
    using System.Collections.Concurrent;

    class Program
    {
        class Data
        { }

        static void Main()
        {
            bool moreItemsToAdd = false;

            //<snippet04>
            // A bounded collection. It can hold no more
            // than 100 items at once.
            BlockingCollection<Data> dataItems = new BlockingCollection<Data>(100);

            // A simple blocking consumer with no cancellation.
            Task.Run(() =>
            {
                while (!dataItems.IsCompleted)
                {

                    Data data = null;
                    // Blocks if dataItems.Count == 0.
                    // IOE means that Take() was called on a completed collection.
                    // Some other thread can call CompleteAdding after we pass the
                    // IsCompleted check but before we call Take.
                    // In this example, we can simply catch the exception since the
                    // loop will break on the next iteration.
                    try
                    {
                        data = dataItems.Take();
                    }
                    catch (InvalidOperationException) { }

                    if (data != null)
                    {
                        Process(data);
                    }
                }
                Console.WriteLine("\r\nNo more items to take.");
            });

            // A simple blocking producer with no cancellation.
            Task.Run(() =>
            {
                while (moreItemsToAdd)
                {
                    Data data = GetData();
                    // Blocks if numbers.Count == dataItems.BoundedCapacity
                    dataItems.Add(data);
                }
                // Let consumer know we are done.
                dataItems.CompleteAdding();
            });

            //</snippet04>
        }

        static void NonBlockingProducer(BlockingCollection<int> bc, CancellationToken ct)
        {
            int itemToAdd = 0;
            bool moreItems = true;
            bool success = false;

            //<snippet05>
            do
            {
                // Cancellation causes OCE. We know how to handle it.
                try
                {
                    success = bc.TryAdd(itemToAdd, 2, ct);
                }
                catch (OperationCanceledException)
                {
                    bc.CompleteAdding();
                    break;
                }
                //...
            } while (moreItems == true);
            //</snippet05>
        }
        static void Process(Data n) { }
        static Data GetData() { return new Data(); }
    }
}
