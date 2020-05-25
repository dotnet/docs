

//<Snippet1>
#using <System.dll>

using namespace System;
using namespace System::Text;
using namespace System::IO;
using namespace System::Net;
using namespace System::Net::Sockets;
String^ DoSocketGet( String^ server )
{
   
   //Set up variables and String to write to the server.
   Encoding^ ASCII = Encoding::ASCII;
   String^ Get =  "GET / HTTP/1.1\r\nHost: ";
   Get->Concat( server,  "\r\nConnection: Close\r\n\r\n" );
   array<Byte>^ByteGet = ASCII->GetBytes( Get );
   array<Byte>^RecvBytes = gcnew array<Byte>(256);
   String^ strRetPage = nullptr;
   
   // IPAddress and IPEndPoint represent the endpoint that will
   //   receive the request.
   // Get first IPAddress in list return by DNS.
   try
   {
      
      // Define those variables to be evaluated in the next for loop and 
      // then used to connect to the server. These variables are defined
      // outside the for loop to make them accessible there after.
      Socket^ s = nullptr;
      IPEndPoint^ hostEndPoint;
      IPAddress^ hostAddress = nullptr;
      int conPort = 80;
      
      // Get DNS host information.
      IPHostEntry^ hostInfo = Dns::Resolve( server );
      
      // Get the DNS IP addresses associated with the host.
      array<IPAddress^>^IPaddresses = hostInfo->AddressList;
      
      // Evaluate the socket and receiving host IPAddress and IPEndPoint. 
      for ( int index = 0; index < IPaddresses->Length; index++ )
      {
         hostAddress = IPaddresses[ index ];
         hostEndPoint = gcnew IPEndPoint( hostAddress,conPort );
         
         //<Snippet3>
         // Creates the Socket to send data over a TCP connection.
         s = gcnew Socket( AddressFamily::InterNetwork,SocketType::Stream,ProtocolType::Tcp );
         
         //<Snippet2>
         // Connect to the host using its IPEndPoint.
         s->Connect( hostEndPoint );
         if (  !s->Connected )
         {
            
            // Connection failed, try next IPaddress.
            strRetPage =  "Unable to connect to host";
            s = nullptr;
            continue;
         }

         
         //</Snippet2>
         // Sent the GET request to the host.
         s->Send( ByteGet, ByteGet->Length, SocketFlags::None );
         
         //</Snippet3>

      }
      
      //<Snippet4>
      // Receive the host home page content and loop until all the data is received.
      Int32 bytes = s->Receive( RecvBytes, RecvBytes->Length, SocketFlags::None );
      strRetPage =  "Default HTML page on ";
      strRetPage->Concat( server,  ":\r\n", ASCII->GetString( RecvBytes, 0, bytes ) );
      while ( bytes > 0 )
      {
         bytes = s->Receive( RecvBytes, RecvBytes->Length, SocketFlags::None );
         strRetPage->Concat( ASCII->GetString( RecvBytes, 0, bytes ) );
      }

      
      //</Snippet4>
   }
   catch ( SocketException^ e ) 
   {
      Console::WriteLine(  "SocketException caught!!!" );
      Console::Write(  "Source : " );
      Console::WriteLine( e->Source );
      Console::Write(  "Message : " );
      Console::WriteLine( e->Message );
   }
   catch ( ArgumentNullException^ e ) 
   {
      Console::WriteLine(  "ArgumentNULLException caught!!!" );
      Console::Write(  "Source : " );
      Console::WriteLine( e->Source );
      Console::Write(  "Message : " );
      Console::WriteLine( e->Message );
   }
   catch ( NullReferenceException^ e ) 
   {
      Console::WriteLine(  "NULLReferenceException caught!!!" );
      Console::Write(  "Source : " );
      Console::WriteLine( e->Source );
      Console::Write(  "Message : " );
      Console::WriteLine( e->Message );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine(  "Exception caught!!!" );
      Console::Write(  "Source : " );
      Console::WriteLine( e->Source );
      Console::Write(  "Message : " );
      Console::WriteLine( e->Message );
   }

   return strRetPage;
}

int main()
{
   Console::WriteLine( DoSocketGet(  "localhost" ) );
}

//</Snippet1>
