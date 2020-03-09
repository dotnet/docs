// System::Net::WebPermissionAttribute::Connect;System::Net::WebPermissionAttribute::Accept;

/*
This program demonstrates the 'Connect' and 'Accept' properties of the class 'WebPermissionAttribute'.
The program uses declarative security for calling the code in 'Connect' method.
By using the 'Accept' and 'Connect' properties of 'WebPermissionAttribute' accept and connect access
has been given to the uri www.contoso.com.
*/

#using <System.dll>

using namespace System;
using namespace System::Net;
using namespace System::Security;
using namespace System::Security::Permissions;
using namespace System::IO;
using namespace System::Text::RegularExpressions;

public ref class WebPermissionAttribute_AcceptConnect
{
//<Snippet1>
public:
   [method:WebPermission(SecurityAction::Deny,AcceptPattern="http://www\\.contoso\\.com/Private/.*")]
   static void CheckAcceptPermission( String^ uriToCheck )
   {
      WebPermission^ permissionToCheck = gcnew WebPermission;
      permissionToCheck->AddPermission( NetworkAccess::Accept, uriToCheck );
      permissionToCheck->Demand();
   }

   static void demoDenySite()
   {
      // Passes a security check.
      CheckAcceptPermission( "http://www.contoso.com/Public/page.htm" );
      Console::WriteLine( "Public page has passed Accept permission check" );

      try
      {
         // Throws a SecurityException.
         CheckAcceptPermission( "http://www.contoso.com/Private/page.htm" );
         Console::WriteLine( "This line will not be printed" );
      }
      catch ( SecurityException^ e ) 
      {
         Console::WriteLine( "Expected exception: {0}", e->Message );
      }
   }
//</Snippet1>
};

int main()
{
   WebPermissionAttribute_AcceptConnect::demoDenySite();
}
