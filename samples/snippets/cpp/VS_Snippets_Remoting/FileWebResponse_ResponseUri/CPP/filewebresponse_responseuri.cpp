// System::Net::FileWebResponse::ResponseUri

/* This program demonstrates the 'ResponseUri' property of the 'FileWebResponse' class.
It creates a 'FileWebRequest' Object* and queries for a response.It then displays the Uri of the file
system resource that provided the response.
*/

#using <System.dll>

using namespace System;
using namespace System::Net;

// <Snippet1>
void GetPage( String^ url )
{
   try
   {
      Uri^ fileUrl = gcnew Uri( String::Concat( "file://", url ) );
      
      // Create a 'FileWebrequest' object with the specified Uri .
      FileWebRequest^ myFileWebRequest = (FileWebRequest^)( WebRequest::Create( fileUrl ) );
      
      // Send the 'fileWebRequest' and wait for response.
      FileWebResponse^ myFileWebResponse = (FileWebResponse^)( myFileWebRequest->GetResponse() );
      Console::WriteLine( "\nThe Uri of the file system resource that provided the response is :\n {0}\n\n", myFileWebResponse->ResponseUri );
      
      // Release resources of response object.
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
// </Snippet1>

int main()
{
   array<String^>^ args = Environment::GetCommandLineArgs();
   if ( args->Length < 2 )
   {
      Console::WriteLine( "\nPlease type the file name as command line parameter as:" );
      Console::WriteLine( "Usage:FileWebResponse_ResponseUri <systemname>/<sharedfoldername>/<filename>  \nExample:FileWebResponse_ResponseUri microsoft/shared/hello.txt" );
   }
   else
   {
      GetPage( args[ 1 ] );
   }

   Console::WriteLine( "Press any key to continue..." );
   Console::ReadLine();
}
