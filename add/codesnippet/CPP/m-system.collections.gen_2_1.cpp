        // Use the Remove method to remove a key/value pair.
        Console::WriteLine("\nRemove(\"doc\")");
        openWith->Remove("doc");

        if (!openWith->ContainsKey("doc"))
        {
            Console::WriteLine("Key \"doc\" is not found.");
        }