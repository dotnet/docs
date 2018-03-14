// System::Net::WebPermissionAttribute::Connect;System::Net::WebPermissionAttribute::Accept;

#using <System.dll>

using namespace System;
using namespace System::Net;
using namespace System::Security;
using namespace System::Security::Permissions;
using namespace System::IO;

public ref class WebPermissionAttribute_AcceptConnect
{
// <Snippet1>
public:
   // Set the declarative security for the URI.
   [WebPermission(SecurityAction::Deny,Connect="http://www.contoso.com/")]
   void Connect()
   {
      // Throw an exception.
      try
      {
         HttpWebRequest^ myWebRequest = dynamic_cast<HttpWebRequest^>(WebRequest::Create( "http://www.contoso.com/" ));
      }
      catch ( Exception^ e ) 
      {
         Console::WriteLine( "Exception : {0}", e );
      }
// </Snippet1>
   }
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
