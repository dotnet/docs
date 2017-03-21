            // Creates an empty DesignerVerbCollection.
            DesignerVerbCollection collection = new DesignerVerbCollection();

            // Adds a DesignerVerb to the collection.
            collection.Add( new DesignerVerb("Example designer verb", new EventHandler(this.ExampleEvent)) );

            // Adds an array of DesignerVerb objects to the collection.
            DesignerVerb[] verbs = { new DesignerVerb("Example designer verb", new EventHandler(this.ExampleEvent)), new DesignerVerb("Example designer verb", new EventHandler(this.ExampleEvent)) };
            collection.AddRange( verbs );

            // Adds a collection of DesignerVerb objects to the collection.
            DesignerVerbCollection verbsCollection = new DesignerVerbCollection();
            verbsCollection.Add( new DesignerVerb("Example designer verb", new EventHandler(this.ExampleEvent)) );
            verbsCollection.Add( new DesignerVerb("Example designer verb", new EventHandler(this.ExampleEvent)) );
            collection.AddRange( verbsCollection );

            // Tests for the presence of a DesignerVerb in the collection, 
            // and retrieves its index if it is found.
            DesignerVerb testVerb = new DesignerVerb("Example designer verb", new EventHandler(this.ExampleEvent));
            int itemIndex = -1;
            if( collection.Contains( testVerb ) )
                itemIndex = collection.IndexOf( testVerb );

            // Copies the contents of the collection, beginning at index 0, 
            // to the specified DesignerVerb array.
            // 'verbs' is a DesignerVerb array.
            collection.CopyTo( verbs, 0 );

            // Retrieves the count of the items in the collection.
            int collectionCount = collection.Count;

            // Inserts a DesignerVerb at index 0 of the collection.
            collection.Insert( 0, new DesignerVerb("Example designer verb", new EventHandler(this.ExampleEvent)) );

            // Removes the specified DesignerVerb from the collection.
            DesignerVerb verb = new DesignerVerb("Example designer verb", new EventHandler(this.ExampleEvent));
            collection.Remove( verb );

            // Removes the DesignerVerb at index 0.
            collection.RemoveAt(0);