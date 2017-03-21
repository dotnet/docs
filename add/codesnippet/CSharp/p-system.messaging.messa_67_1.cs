        // Set the queue's EncryptionRequired property value.
        queue.EncryptionRequired = System.Messaging.EncryptionRequired.Optional;

        // Display the new value of the queue's EncryptionRequired property.
        Console.WriteLine("MessageQueue.EncryptionRequired: {0}",
            queue.EncryptionRequired);