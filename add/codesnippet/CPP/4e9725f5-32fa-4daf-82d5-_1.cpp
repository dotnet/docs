      // Check for 'myFormatExtension' object in collection.
      if ( myCollection->Contains( myFormatExtensionObject ) )
      {
         // Get index of a 'myFormatExtension' object in collection.
         Console::WriteLine( "Index of 'myFormatExtensionObject' is {0} in collection.", myCollection->IndexOf( myFormatExtensionObject ) );

         // Remove 'myFormatExtensionObject' element from collection.
         myCollection->Remove( myFormatExtensionObject );
         Console::WriteLine( "'myFormatExtensionObject' is removed  from collection." );
      }