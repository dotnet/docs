

#using <System.dll>
#using <System.Web.dll>

using namespace System;
using namespace System::Net;
using namespace System::Web;
using namespace System::Web::UI;
using namespace System::Security::Cryptography;
using namespace System::Text;
int main()
{
   // <Snippet1>  
   // Create a secure group name.
   SHA1Managed^ Sha1 = gcnew SHA1Managed;
   array<Byte>^updHash = Sha1->ComputeHash( Encoding::UTF8->GetBytes( "usernamepassworddomain" ) );
   String^ secureGroupName = Encoding::Default->GetString( updHash );

   // Create a request for a specific URL.
   WebRequest^ myWebRequest = WebRequest::Create( "http://www.contoso.com" );

   // Set the authentication credentials for the request.      
   myWebRequest->Credentials = gcnew NetworkCredential( "username","password","domain" );
   myWebRequest->ConnectionGroupName = secureGroupName;

   // Get the response.
   WebResponse^ myWebResponse = myWebRequest->GetResponse();

   // Insert the code that uses myWebResponse here.
   // Close the response.
   myWebResponse->Close();
   // </Snippet1>
}
