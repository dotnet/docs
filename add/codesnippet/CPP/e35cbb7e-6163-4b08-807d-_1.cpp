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