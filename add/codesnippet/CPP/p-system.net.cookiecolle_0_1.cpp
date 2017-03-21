   // Get the cookies in the 'CookieCollection' object using the 'Item' property.
   // The 'Item' property in C++ is implemented through Indexers. 
   // The class that implements indexers is usually a collection of other objects. 
   // This class provides access to those objects with the '<class-instance>[i]' syntax. 
   try
   {
      if ( cookies->Count == 0 )
      {
         Console::WriteLine( "No cookies to display" );
         return;
      }

      Console::WriteLine( "{0}", cookies[ "UserName" ] );
      Console::WriteLine( "{0}", cookies[ "DateOfBirth" ] );
      Console::WriteLine( "{0}", cookies[ "PlaceOfBirth" ] );
      Console::WriteLine( "" );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception raised.\nError : {0}", e->Message );
   }