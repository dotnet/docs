            // Tests for the presence of a DesignerVerb in the collection, 
            // and retrieves its index if it is found.
            DesignerVerb testVerb = new DesignerVerb("Example designer verb", new EventHandler(this.ExampleEvent));
            int itemIndex = -1;
            if( collection.Contains( testVerb ) )
                itemIndex = collection.IndexOf( testVerb );