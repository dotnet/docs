         // Adds an array of CodeTypeMember objects to the collection.
         array<CodeTypeMember^>^members = {gcnew CodeMemberField( "System.String","TestStringField1" ),gcnew CodeMemberField( "System.String","TestStringField2" )};
         collection->AddRange( members );
         
         // Adds a collection of CodeTypeMember objects to the collection.
         CodeTypeMemberCollection^ membersCollection = gcnew CodeTypeMemberCollection;
         membersCollection->Add( gcnew CodeMemberField( "System.String","TestStringField1" ) );
         membersCollection->Add( gcnew CodeMemberField( "System.String","TestStringField2" ) );
         collection->AddRange( membersCollection );