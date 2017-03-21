         // Removes the specified DesignerVerb from the collection.
         DesignerVerb^ verb = gcnew DesignerVerb( "Example designer verb", gcnew EventHandler( this, &Class1::ExampleEvent ) );
         collection->Remove( verb );