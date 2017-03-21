public:
   // Set the WebPermissionAttribute ConnectPattern property.
   [WebPermission(SecurityAction::Deny,ConnectPattern="http://www\\.contoso\\.com/Private/.*")]

   static void CheckConnectPermission( String^ uriToCheck )
   {
      WebPermission^ permissionToCheck = gcnew WebPermission;
      permissionToCheck->AddPermission( NetworkAccess::Connect, uriToCheck );
      permissionToCheck->Demand();
   }

   static void demoDenySite()
   {
      //Pass the security check.
      CheckConnectPermission( "http://www.contoso.com/Public/page.htm" );
      Console::WriteLine( "Public page has passed Connect permission check" );

      try
      {
         //Throw a SecurityException.
         CheckConnectPermission( "http://www.contoso.com/Private/page.htm" );
         Console::WriteLine( "This line will not be printed" );
      }
      catch ( SecurityException^ e ) 
      {
         Console::WriteLine( "Expected exception {0}", e->Message );
      }
   }
};