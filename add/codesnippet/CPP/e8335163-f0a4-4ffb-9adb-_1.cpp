         // Tests for the presence of a CodeTypeMember in the collection, 
         // and retrieves its index if it is found.
         CodeTypeMember^ testMember = gcnew CodeMemberField( "System.String","TestStringField" );
         int itemIndex = -1;
         if ( collection->Contains( testMember ) )
            itemIndex = collection->IndexOf( testMember );