         // Removes the specified CodeTypeMember from the collection.
         CodeTypeMember^ member = gcnew CodeMemberField( "System.String","TestStringField" );
         collection->Remove( member );