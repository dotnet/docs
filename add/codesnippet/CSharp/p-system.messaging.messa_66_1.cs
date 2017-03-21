        // Set the queue's MaximumJournalSize property value.
        queue.MaximumJournalSize = 10;

        // Display the new value of the queue's MaximumJournalSize property.
        Console.WriteLine("MessageQueue.MaximumJournalSize: {0}",
            queue.MaximumJournalSize);