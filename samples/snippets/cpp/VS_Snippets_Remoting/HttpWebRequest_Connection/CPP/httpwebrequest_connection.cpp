

// System::Net::HttpWebRequest::KeepAlive System::Net::HttpWebRequest::Connection
/**
* This program demonstrates Connection and KeepAlive properties of the
* HttpWebRequest Class.
* Two new HttpWebRequest objects are created . The KeepAlive property of one of
* the objects is set to false that in turn sets the value of Connection field of
* the HTTP request Headers to Close.
* The Connection property of the other HttpWebRequest Object* is assigned the
* value Close. This throws an ArgumentException which is caught.The HTTP request
* Headers are displayed to the console.
* The contents of the HTML page of the requested URI are displayed.
**/
#using <System.dll>

using namespace System;
using namespace System::IO;
using namespace System::Net;
using namespace System::Text;

// <Snippet1>
int main()
{
   try
   {
      
      // Create a new HttpWebRequest object.  Make sure that
      // a default proxy is set if you are behind a firewall.
      HttpWebRequest^ myHttpWebRequest1 = dynamic_cast<HttpWebRequest^>(WebRequest::Create( "http://www.contoso.com" ));
      myHttpWebRequest1->KeepAlive = false;
      
      // Assign the response object of HttpWebRequest to a HttpWebResponse variable.
      HttpWebResponse^ myHttpWebResponse1 = dynamic_cast<HttpWebResponse^>(myHttpWebRequest1->GetResponse());
      Console::WriteLine( "\nThe HTTP request Headers for the first request are: \n {0}", myHttpWebRequest1->Headers );
      Console::WriteLine( "Press Enter Key to Continue.........." );
      Console::Read();
      Stream^ streamResponse = myHttpWebResponse1->GetResponseStream();
      StreamReader^ streamRead = gcnew StreamReader( streamResponse );
      array<Char>^readBuff = gcnew array<Char>(256);
      int count = streamRead->Read( readBuff, 0, 256 );
      Console::WriteLine( "The contents of the Html page are.......\n" );
      while ( count > 0 )
      {
         String^ outputData = gcnew String( readBuff,0,count );
         Console::Write( outputData );
         count = streamRead->Read( readBuff, 0, 256 );
      }
      Console::WriteLine();
      
      // Close the Stream object.
      streamResponse->Close();
      streamRead->Close();
      
      // Release the resources held by response object.
      myHttpWebResponse1->Close();
      
      // <Snippet2>
      // Create a new HttpWebRequest object for the specified Uri.
      HttpWebRequest^ myHttpWebRequest2 = dynamic_cast<HttpWebRequest^>(WebRequest::Create( "http://www.contoso.com" ));
      myHttpWebRequest2->Connection = "Close";
      
      // Assign the response object of 'HttpWebRequest' to a 'HttpWebResponse' variable.
      HttpWebResponse^ myHttpWebResponse2 = dynamic_cast<HttpWebResponse^>(myHttpWebRequest2->GetResponse());
      
      // Release the resources held by response object.
      myHttpWebResponse2->Close();
      Console::WriteLine( "\nThe Http RequestHeaders are \n {0}", myHttpWebRequest2->Headers );
      
      // </Snippet2>
      Console::WriteLine( "\nPress 'Enter' Key to Continue........." );
      Console::Read();
   }
   catch ( ArgumentException^ e ) 
   {
      Console::WriteLine( "\nThe second HttpWebRequest Object* has raised an Argument Exception as 'Connection' Property is set to 'Close'" );
      Console::WriteLine( "\n {0}", e->Message );
   }
   catch ( WebException^ e ) 
   {
      Console::WriteLine( "WebException raised!" );
      Console::WriteLine( "\n {0}", e->Message );
      Console::WriteLine( "\n {0}", e->Status );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception raised!" );
      Console::WriteLine( "Source : {0} ", e->Source );
      Console::WriteLine( "Message : {0} ", e->Message );
   }

}

// </Snippet1>
