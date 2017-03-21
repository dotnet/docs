         // Tests for the presence of a DesignerVerb in the collection,
         // and retrieves its index if it is found.
         DesignerVerb^ testVerb = gcnew DesignerVerb( "Example designer verb", gcnew EventHandler( this, &Class1::ExampleEvent ) );
         int itemIndex = -1;
         if ( collection->Contains( testVerb ) )
                  itemIndex = collection->IndexOf( testVerb );