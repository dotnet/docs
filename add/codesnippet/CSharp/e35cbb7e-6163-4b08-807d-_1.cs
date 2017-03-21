            // Adds an array of DesignerVerb objects to the collection.
            DesignerVerb[] verbs = { new DesignerVerb("Example designer verb", new EventHandler(this.ExampleEvent)), new DesignerVerb("Example designer verb", new EventHandler(this.ExampleEvent)) };
            collection.AddRange( verbs );

            // Adds a collection of DesignerVerb objects to the collection.
            DesignerVerbCollection verbsCollection = new DesignerVerbCollection();
            verbsCollection.Add( new DesignerVerb("Example designer verb", new EventHandler(this.ExampleEvent)) );
            verbsCollection.Add( new DesignerVerb("Example designer verb", new EventHandler(this.ExampleEvent)) );
            collection.AddRange( verbsCollection );