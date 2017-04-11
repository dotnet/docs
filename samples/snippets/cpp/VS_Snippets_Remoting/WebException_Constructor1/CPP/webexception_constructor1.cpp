// System::Net::WebException::WebException();

/*
This program demonstrates the 'WebException()' constructor of 'WebException' class.
It creates a 'HttpConnect' Object* and calls the 'ConnectHttpServer' method with an invalid 'URL'.
When the method tries to establish a socket connection to that address an exception is thrown.In
the 'catch' block  a new 'WebException' Object* is created  and  thrown to the caller.That exception
is caught in the calling method and the error message is dispalyed to the console.
*/

#using <System.dll>

using namespace System;
using namespace System::Net;
using namespace System::Net::Sockets;
using namespace System::Text;

public ref class HttpConnect
{
public:
   void ConnectHttpServer( String^ connectUri )
   {
// <Snippet1>
      try
      {
         // A 'Socket' object has been created.
         Socket^ httpSocket = gcnew Socket( AddressFamily::InterNetwork,SocketType::Stream,ProtocolType::Tcp );
         

         // The IPaddress of the unknown uri is resolved using the 'Dns::Resolve' method.

         IPHostEntry^ hostEntry = Dns::Resolve( "http://www.contoso.com" );

         IPAddress^ serverAddress = hostEntry->AddressList[ 0 ];
         IPEndPoint^ endPoint = gcnew IPEndPoint( serverAddress, 80 );
         httpSocket->Connect( endPoint );
         Console::WriteLine( "Connection created successfully" );
         httpSocket->Close();
      }
      catch ( SocketException^ e ) 
      {
         String^ exp = e->Message;
         // Throw the WebException with no parameters.
         throw gcnew WebException;
      }
// </Snippet1>
   }
};

int main()
{
   try
   {
      HttpConnect^ myHttpConnect = gcnew HttpConnect;
      // If the Uri is valid  then 'ConnectHttpServer' method will connect to the server.
      myHttpConnect->ConnectHttpServer( "www.contoso.com" );
   }
   catch ( WebException^ e ) 
   {
      Console::WriteLine( "The Exception is: {0}", e->Message );
      Console::WriteLine( "The Exception is: Unable to Contact the server" );
   }
}
