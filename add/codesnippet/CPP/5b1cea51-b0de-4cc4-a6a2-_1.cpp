         // Inserts a DesignerVerb at index 0 of the collection.
         collection->Insert( 0, gcnew DesignerVerb( "Example designer verb", gcnew EventHandler( this, &Class1::ExampleEvent ) ) );