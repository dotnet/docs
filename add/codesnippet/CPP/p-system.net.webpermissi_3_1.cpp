public:
   // Deny access to a specific resource by setting the Accept property.
   [method:WebPermission(SecurityAction::Deny,Accept="http://www.contoso.com/Private.htm")]

   static void CheckAcceptPermission( String^ uriToCheck )
   {
      WebPermission^ permissionToCheck = gcnew WebPermission;
      permissionToCheck->AddPermission( NetworkAccess::Accept, uriToCheck );
      permissionToCheck->Demand();
   }

   static void demoDenySite()
   {
      // Pass the security check when accessing allowed resources.
      CheckAcceptPermission( "http://www.contoso.com/" );
      Console::WriteLine( "Public page has passed Accept permission check" );

      try
      {
         // Throw a SecurityException when trying to access not allowed resources.
         CheckAcceptPermission( "http://www.contoso.com/Private.htm" );
         Console::WriteLine( "This line will not be printed" );
      }
      catch ( SecurityException^ e ) 
      {
         Console::WriteLine( "Exception trying to access private resource: {0}", e->Message );
      }
   }