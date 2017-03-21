         // Adds an array of CodeCatchClause objects to the collection.
         array<CodeCatchClause^>^clauses = {gcnew CodeCatchClause,gcnew CodeCatchClause};
         collection->AddRange( clauses );

         // Adds a collection of CodeCatchClause objects to the collection.
         CodeCatchClauseCollection^ clausesCollection = gcnew CodeCatchClauseCollection;
         clausesCollection->Add( gcnew CodeCatchClause( "e",gcnew CodeTypeReference( System::ArgumentOutOfRangeException::typeid ) ) );
         clausesCollection->Add( gcnew CodeCatchClause( "e" ) );
         collection->AddRange( clausesCollection );