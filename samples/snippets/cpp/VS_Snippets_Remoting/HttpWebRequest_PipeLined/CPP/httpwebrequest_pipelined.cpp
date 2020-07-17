/*Sytem::Net.HttpWebRequest::PipeLined
This program demonstrates  'Pipelined' property of the 'HttpWebRequest' class.
A new 'HttpWebRequest' Object* is created.The 'Pipelined' property is displayed to the console.
HTTP Request  and  Response Headers are displayed to the console.The contents of the page of the
requested URI are displayed to the console.

Note:The 'Pipelined' property is supported only by servers that allow Pipelining of requests.
*/

#using <System.dll>

using namespace System;
using namespace System::IO;
using namespace System::Net;
using namespace System::Text;

void GetPage( String^ myUri )
{
   try
   {
// <Snippet1>
      // Create a 'HttpWebRequest' object.
      HttpWebRequest^ myHttpWebRequest = (HttpWebRequest^)( WebRequest::Create( myUri ) );
      // Assign the response object of 'HttpWebRequest' to a 'HttpWebResponse' variable.
      HttpWebResponse^ myHttpWebResponse = (HttpWebResponse^)( myHttpWebRequest->GetResponse() );
      // Display the contents of the page to the console.
      Stream^ streamResponse = myHttpWebResponse->GetResponseStream();
      StreamReader^ streamRead = gcnew StreamReader( streamResponse );
      array<Char>^ readBuffer = gcnew array<Char>(256);
      int count = streamRead->Read( readBuffer, 0, 256 );
      Console::WriteLine( "\nThe contents of HTML page are......." );
      while ( count > 0 )
      {
         String^ outputData = gcnew String( readBuffer,0,count );
         Console::Write( outputData );
         count = streamRead->Read( readBuffer, 0, 256 );
      }
      Console::WriteLine( "\nHTTP Request  Headers :\n\n {0}", myHttpWebRequest->Headers );
      Console::WriteLine( "\nHTTP Response Headers :\n\n {0}", myHttpWebResponse->Headers );
      streamRead->Close();
      streamResponse->Close();
      // Release the response object resources.
      myHttpWebResponse->Close();
      Console::WriteLine( "\n'Pipelined' property is: {0}", myHttpWebRequest->Pipelined );
      Console::WriteLine( "\nPress 'Enter' Key to Continue......" );
      Console::Read();
// </Snippet1>
   }
   catch ( WebException^ e ) 
   {
      Console::WriteLine( "\nWebException Caught!" );
      Console::WriteLine( "Message : {0}", e->Message );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "\nException Caught!" );
      Console::WriteLine( "Message : {0} ", e->Message );
   }
}

int main()
{
   array<String^>^ args = Environment::GetCommandLineArgs();
   try
   {
      if ( args->Length < 2 )
      {
         Console::WriteLine( "\nPlease enter the Uri address as a command line parameter:" );
         Console::WriteLine( "->Item[ Usage:HttpWebRequest_Pipelined http://www.microsoft.com ]" );
      }
      else
      {
         GetPage( args[ 1 ] );
      }
   }
   catch ( WebException^ e ) 
   {
      Console::WriteLine( "\nWebException Caught!" );
      Console::WriteLine( "Message : {0}", e->Message );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "\nException Caught!" );
      Console::WriteLine( "Message : {0}", e->Message );
   }
}
