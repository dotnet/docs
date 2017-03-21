        // ContainsKey can be used to test keys before inserting
        // them.
        if (!openWith->ContainsKey("ht"))
        {
            openWith->Add("ht", "hypertrm.exe");
            Console::WriteLine("Value added for key = \"ht\": {0}",
                openWith["ht"]);
        }