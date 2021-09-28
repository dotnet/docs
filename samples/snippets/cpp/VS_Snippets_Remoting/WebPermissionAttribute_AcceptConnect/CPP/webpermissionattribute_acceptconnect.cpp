// System::Net::WebPermissionAttribute::Connect;System::Net::WebPermissionAttribute::Accept;

// Demonstrate how to use the WebPermissionAttribute to specify an allowable ConnectPattern.

#using <System.dll>

using namespace System;
using namespace System::Net;
using namespace System::Security;
using namespace System::Security::Permissions;
using namespace System::IO;

public ref class WebPermissionAttribute_AcceptConnect
{
// <Snippet1>
// <Snippet2>
public:
   // Deny access to a specific resource by setting the ConnectPattern property.
   [method:WebPermission(SecurityAction::Deny,ConnectPattern="http://www.contoso.com/")]

   void Connect()
   {
      // Create a Connection.
      HttpWebRequest^ myWebRequest = (HttpWebRequest^)(WebRequest::Create( "http://www.contoso.com" ));
      Console::WriteLine( "This line should never be printed" );
   }
// </Snippet2>
// </Snippet1>
};

int main()
{
   try
   {
      WebPermissionAttribute_AcceptConnect^ myWebAttrib = gcnew WebPermissionAttribute_AcceptConnect;
      myWebAttrib->Connect();
   }
   catch ( SecurityException^ e ) 
   {
      Console::WriteLine( "Security Exception raised: {0}", e->Message );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception raised: {0}", e->Message );
   }
}
