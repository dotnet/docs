         // Creates an empty CodeTypeMemberCollection.
         CodeTypeMemberCollection^ collection = gcnew CodeTypeMemberCollection;

         // Adds a CodeTypeMember to the collection.
         collection->Add( gcnew CodeMemberField( "System.String","TestStringField" ) );

         // Adds an array of CodeTypeMember objects to the collection.
         array<CodeTypeMember^>^members = {gcnew CodeMemberField( "System.String","TestStringField1" ),gcnew CodeMemberField( "System.String","TestStringField2" )};
         collection->AddRange( members );
         
         // Adds a collection of CodeTypeMember objects to the collection.
         CodeTypeMemberCollection^ membersCollection = gcnew CodeTypeMemberCollection;
         membersCollection->Add( gcnew CodeMemberField( "System.String","TestStringField1" ) );
         membersCollection->Add( gcnew CodeMemberField( "System.String","TestStringField2" ) );
         collection->AddRange( membersCollection );

         // Tests for the presence of a CodeTypeMember in the collection, 
         // and retrieves its index if it is found.
         CodeTypeMember^ testMember = gcnew CodeMemberField( "System.String","TestStringField" );
         int itemIndex = -1;
         if ( collection->Contains( testMember ) )
            itemIndex = collection->IndexOf( testMember );

         // Copies the contents of the collection, beginning at index 0,
         // to the specified CodeTypeMember array.
         // 'members' is a CodeTypeMember array.
         collection->CopyTo( members, 0 );

         // Retrieves the count of the items in the collection.
         int collectionCount = collection->Count;

         // Inserts a CodeTypeMember at index 0 of the collection.
         collection->Insert( 0, gcnew CodeMemberField( "System.String","TestStringField" ) );

         // Removes the specified CodeTypeMember from the collection.
         CodeTypeMember^ member = gcnew CodeMemberField( "System.String","TestStringField" );
         collection->Remove( member );

         // Removes the CodeTypeMember at index 0.
         collection->RemoveAt( 0 );