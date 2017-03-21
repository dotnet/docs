            // Adds an array of CompilerError objects to the collection.
            CompilerError[] errors = { new CompilerError("Testfile.cs", 5, 10, "CS0001", "Example error text"), new CompilerError("Testfile.cs", 5, 10, "CS0001", "Example error text") };
            collection.AddRange( errors );

            // Adds a collection of CompilerError objects to the collection.
            CompilerErrorCollection errorsCollection = new CompilerErrorCollection();
            errorsCollection.Add( new CompilerError("Testfile.cs", 5, 10, "CS0001", "Example error text") );
            errorsCollection.Add( new CompilerError("Testfile.cs", 5, 10, "CS0001", "Example error text") );
            collection.AddRange( errorsCollection );