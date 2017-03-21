         // Creates an empty DesignerVerbCollection.
         DesignerVerbCollection^ collection = gcnew DesignerVerbCollection;

         // Adds a DesignerVerb to the collection.
         collection->Add( gcnew DesignerVerb( "Example designer verb",gcnew EventHandler( this, &Class1::ExampleEvent ) ) );

         // Adds an array of DesignerVerb objects to the collection.
         array<DesignerVerb^>^ verbs = {
            gcnew DesignerVerb( "Example designer verb", gcnew EventHandler( this, &Class1::ExampleEvent ) ),
            gcnew DesignerVerb( "Example designer verb", gcnew EventHandler( this, &Class1::ExampleEvent ) )};
         collection->AddRange( verbs );
         
         // Adds a collection of DesignerVerb objects to the collection.
         DesignerVerbCollection^ verbsCollection = gcnew DesignerVerbCollection;
         verbsCollection->Add( gcnew DesignerVerb( "Example designer verb", gcnew EventHandler( this, &Class1::ExampleEvent ) ) );
         verbsCollection->Add( gcnew DesignerVerb( "Example designer verb", gcnew EventHandler( this, &Class1::ExampleEvent ) ) );
         collection->AddRange( verbsCollection );

         // Tests for the presence of a DesignerVerb in the collection,
         // and retrieves its index if it is found.
         DesignerVerb^ testVerb = gcnew DesignerVerb( "Example designer verb", gcnew EventHandler( this, &Class1::ExampleEvent ) );
         int itemIndex = -1;
         if ( collection->Contains( testVerb ) )
                  itemIndex = collection->IndexOf( testVerb );

         // Copies the contents of the collection, beginning at index 0,
         // to the specified DesignerVerb array.
         // 'verbs' is a DesignerVerb array.
         collection->CopyTo( verbs, 0 );

         // Retrieves the count of the items in the collection.
         int collectionCount = collection->Count;

         // Inserts a DesignerVerb at index 0 of the collection.
         collection->Insert( 0, gcnew DesignerVerb( "Example designer verb", gcnew EventHandler( this, &Class1::ExampleEvent ) ) );

         // Removes the specified DesignerVerb from the collection.
         DesignerVerb^ verb = gcnew DesignerVerb( "Example designer verb", gcnew EventHandler( this, &Class1::ExampleEvent ) );
         collection->Remove( verb );

         // Removes the DesignerVerb at index 0.
         collection->RemoveAt( 0 );