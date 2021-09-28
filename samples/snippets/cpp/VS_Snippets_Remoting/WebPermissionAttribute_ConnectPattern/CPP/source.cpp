// System::Net::WebPermissionAttribute::Connect;System::Net::WebPermissionAttribute::Connect;

// Demonstrate how to use the WebPermissionAttribute  ConnectPattern property.

#using <System.dll>

using namespace System;
using namespace System::Net;
using namespace System::Security;
using namespace System::Security::Permissions;
using namespace System::IO;
using namespace System::Text::RegularExpressions;

public ref class WebPermissionAttribute_Connect
{
//<Snippet1>
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
//</Snippet1>

int main()
{
   WebPermissionAttribute_Connect::demoDenySite();
}
