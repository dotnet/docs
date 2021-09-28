// System::Net::FileWebResponse::ContentLength;System::Net::FileWebResponse::ContentType.

/* This program demonstrates the 'ContentLength' and 'ContentType' property of 'FileWebResponse' class.
It creates a web request and queries for a response.It then prints the content length
and content type of the entity body in the response onto the console */

#using <System.dll>

using namespace System;
using namespace System::Net;

// <Snippet1>
// <Snippet2>
void GetPage( String^ url )
{
   try
   {
      Uri^ fileUrl = gcnew Uri( String::Concat( "file://", url ) );
      // Create a 'FileWebrequest' Object* with the specified Uri.
      FileWebRequest^ myFileWebRequest = (FileWebRequest^)( WebRequest::Create( fileUrl ) );
      // Send the 'fileWebRequest' and wait for response.
      FileWebResponse^ myFileWebResponse = (FileWebResponse^)( myFileWebRequest->GetResponse() );
      // Print the ContentLength and ContentType properties received as headers in the response Object*.
      Console::WriteLine( "\nContent length : {0}, Content Type : {1}", myFileWebResponse->ContentLength, myFileWebResponse->ContentType );
      // Release resources of response Object*.
      myFileWebResponse->Close();
   }
   catch ( WebException^ e ) 
   {
      Console::WriteLine( "\r\nWebException thrown.The Reason for failure is : {0}", e->Status );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "\nThe following Exception was raised : {0}", e->Message );
   }
}
// </Snippet2>
// </Snippet1>

int main()
{
   array<String^>^ args = Environment::GetCommandLineArgs();
   if ( args->Length < 2 )
   {
      Console::WriteLine( "\nPlease enter the file name as command line parameter:" );
      Console::WriteLine( "Usage:FileWebResponse_ContentLength_ContentType <systemname>/<sharedfoldername>/<filename>  \nExample:FileWebResponse_ContentLength_ContentType microsoft/shared/hello.txt" );
   }
   else
   {
      GetPage( args[ 1 ] );
   }

   Console::WriteLine( "Press any key to continue..." );
   Console::ReadLine();
   return 0;
}
