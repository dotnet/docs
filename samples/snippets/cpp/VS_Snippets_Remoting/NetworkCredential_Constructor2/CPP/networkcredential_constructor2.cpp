// System::Net::NetworkCredential::NetworkCredential(String*, String*)

/*This program demontrates the 'NetworkCredential(String*, String*)' constructor of 'NetworkCredential' class.
It takes an URL, username, password and domainname from console and forms a 'NetworkCredential' Object* with
these arguments.Then a 'WebRequest' Object* is created and the 'NetworkCredential' Object* is associated with
it.A message is displayed onto the console on successful reception of response otherwise an exception is thrown.
*/

#using <System.dll>

using namespace System;
using namespace System::Net;

void GetPage( String^ url, String^ username, String^ passwd, String^ domain )
{
   try
   {
// <Snippet1>
      // Call the onstructor  to create an instance of NetworkCredential with the
      // specified user name and password.
      NetworkCredential^ myCredentials = gcnew NetworkCredential( username,passwd );
      
      // Create a WebRequest with the specified URL.
      WebRequest^ myWebRequest = WebRequest::Create( url );
      myCredentials->Domain = domain;
      myWebRequest->Credentials = myCredentials;
      Console::WriteLine( "\n\nCredentials Domain : {0} , UserName : {1} , Password : {2}",
         myCredentials->Domain, myCredentials->UserName, myCredentials->Password );
      Console::WriteLine( "\n\nRequest to Url is sent.Waiting for response..." );
      
      // Send the request and wait for a response.
      WebResponse^ myWebResponse = myWebRequest->GetResponse();
      
      // Process the response.
      Console::WriteLine( "\nResponse received successfully." );
      
      // Release the resources of the response object.
      myWebResponse->Close();
// </Snippet1>
   }
   catch ( WebException^ e ) 
   {
      Console::WriteLine( "\r\nWebException is raised.The Reason for failure is : {0}", e->Status );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "\nThe following exception was raised : {0}", e->Message );
   }
}

int main()
{
   array<String^>^args = Environment::GetCommandLineArgs();
   if ( args->Length < 5 )
   {
      Console::WriteLine( "\nPlease enter a protected resource Url and other details as command line parameter as below:" );
      Console::WriteLine( "\nUsage: NetworkCredential_Constructor2 URLname username password domainname" );
      Console::WriteLine( "\nExample: NetworkCredential_Constructor2 http://dotnet.microsoft.com/ george george123 microsoft" );
   }
   else
   {
      GetPage( args[ 1 ], args[ 2 ], args[ 3 ], args[ 4 ] );
   }

   Console::WriteLine( "\n\nPress 'Enter key' to continue..." );
   Console::ReadLine();
}
