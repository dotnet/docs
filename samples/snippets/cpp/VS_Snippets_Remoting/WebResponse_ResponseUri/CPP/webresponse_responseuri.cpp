// System::Net::WebResponse::ResponseUri

/* This program demonstrates the 'ResponseUri' property of the 'WebResponse' class
It creates a web request and queries for a response.It then compares the ResponseUri value to the actual Url
value to see if the original request was redirected*/

#using <System.dll>

using namespace System;
using namespace System::Net;
using namespace System::IO;
using namespace System::Text;

void GetPage( String^ url )
{
   try
   {
// <Snippet1>
      Uri^ ourUri = gcnew Uri( url );
      
      // Create a 'WebRequest' object with the specified url.
      WebRequest^ myWebRequest = WebRequest::Create( url );
      
      // Send the 'WebRequest' and wait for response.
      WebResponse^ myWebResponse = myWebRequest->GetResponse();
      
      // Use "ResponseUri" property to get the actual Uri from where the response was attained.
      if ( ourUri->Equals( myWebResponse->ResponseUri ) )
      {
         Console::WriteLine( "\nRequest Url : {0} was not redirected", url );
      }
      else
      {
         Console::WriteLine( "\nRequest Url : {0} was redirected to {1}", url, myWebResponse->ResponseUri );
      }
      
      // Release resources of response object.
      myWebResponse->Close();
// </Snippet1>
   }
   catch ( WebException^ e ) 
   {
      Console::WriteLine( "\nWebException is raised->Status is : {0}", e->Status );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "\nThe following Exception was raised->Message is: {0}", e->Message );
   }
}

int main()
{
   array<String^>^ args = Environment::GetCommandLineArgs();
   if ( args->Length < 2 )
   {
      Console::WriteLine( "\nPlease type the Url as command line parameter" );
      Console::WriteLine( "Example:" );
      Console::WriteLine( "WebResponse_ResponseUri http://www.microsoft.com" );
   }
   else
   {
      GetPage( args[ 1 ] );
   }

   Console::WriteLine( "Press any key to continue..." );
   Console::ReadLine();
}
