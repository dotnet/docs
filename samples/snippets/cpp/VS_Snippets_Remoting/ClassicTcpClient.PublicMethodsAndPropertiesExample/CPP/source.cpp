

#using <System.dll>

using namespace System;
using namespace System::Text;
using namespace System::Net;
using namespace System::Net::Sockets;
public ref class MyTcpClientExample
{
public:

   // <Snippet1>
   //  MyTcpClientConstructor is just used to illustrate the different constructors available in the TcpClient class
   static void MyTcpClientConstructor( String^ myConstructorType )
   {
      if ( myConstructorType == "IPAddressExample" )
      {
         
         // <Snippet2>
         //Creates a TCPClient using a local end point.
         IPAddress^ ipAddress = Dns::Resolve( Dns::GetHostName() )->AddressList[ 0 ];
         IPEndPoint^ ipLocalEndPoint = gcnew IPEndPoint( ipAddress,11000 );
         TcpClient^ tcpClientA = gcnew TcpClient( ipLocalEndPoint );
         
         // </Snippet2> 
      }
      else
      if ( myConstructorType == "HostNameExample" )
      {
         
         // <Snippet3>
         // Creates a TCPClient using hostname and port.
         TcpClient^ tcpClientB = gcnew TcpClient( "www.contoso.com",11000 );
         
         // </Snippet3>
      }
      else
      if ( myConstructorType == "DefaultExample" )
      {
         
         // <Snippet4>
         //Creates a TCPClient using the default constructor.
         TcpClient^ tcpClientC = gcnew TcpClient;
         
         // </Snippet4>  
      }
      else
      {
         
         // <Snippet15>
         TcpClient^ tcpClientD = gcnew TcpClient( AddressFamily::InterNetwork );
         
         // </Snippet15>
      }
   }


   // MyTcpClientConnection class is just used to illustrate the different connection methods of the TcpClient class.
   static void MyTcpClientConnection( String^ myConnectionType )
   {
      if ( myConnectionType == "HostnameExample" )
      {
         
         // <Snippet5>
         //Uses a host name and port number to establish a socket connection.
         TcpClient^ tcpClient = gcnew TcpClient;
         tcpClient->Connect( "www.contoso.com", 11002 );
         
         // </Snippet5>
         tcpClient->Close();
      }
      else
      if ( myConnectionType == "IPAddressExample" )
      {
         
         // <Snippet6>
         //Uses the IP address and port number to establish a socket connection.
         TcpClient^ tcpClient = gcnew TcpClient;
         IPAddress^ ipAddress = Dns::Resolve( "www.contoso.com" )->AddressList[ 0 ];
         tcpClient->Connect( ipAddress, 11003 );
         
         // </Snippet6>
         tcpClient->Close();
      }
      else
      if ( myConnectionType == "RemoteEndPointExample" )
      {
         
         // <Snippet7>
         //Uses a remote end point to establish a socket connection.
         TcpClient^ tcpClient = gcnew TcpClient;
         IPAddress^ ipAddress = Dns::Resolve( "www.contoso.com" )->AddressList[ 0 ];
         IPEndPoint^ ipEndPoint = gcnew IPEndPoint( ipAddress,11004 );
         tcpClient->Connect( ipEndPoint );
         
         // </Snippet7>
         tcpClient->Close();
      }
      else
      {
         
         // Do nothing.
      }
   }


   // MyTcpClientPropertySetter is just used to illustrate setting and getting various properties of the TcpClient class.
   static void MyTcpClientPropertySetter()
   {
      TcpClient^ tcpClient = gcnew TcpClient;
      
      // <Snippet8>
      // sets the receive buffer size using the ReceiveBufferSize public property.
      tcpClient->ReceiveBufferSize = 1024;
      
      // gets the receive buffer size using the ReceiveBufferSize public property.
      if ( tcpClient->ReceiveBufferSize == 1024 )
            Console::WriteLine( "The receive buffer was successfully set to {0}", tcpClient->ReceiveBufferSize );

      
      // </Snippet8>
      // <Snippet9>
      //sets the send buffer size using the SendBufferSize public property.
      tcpClient->SendBufferSize = 1024;
      
      // gets the send buffer size using the SendBufferSize public property.
      if ( tcpClient->SendBufferSize == 1024 )
            Console::WriteLine( "The send buffer was successfully set to {0}", tcpClient->SendBufferSize );

      
      // </Snippet9>
      // <Snippet10>
      // Sets the receive time out using the ReceiveTimeout public property.
      tcpClient->ReceiveTimeout = 5;
      
      // Gets the receive time out using the ReceiveTimeout public property.
      if ( tcpClient->ReceiveTimeout == 5 )
            Console::WriteLine( "The receive time out limit was successfully set {0}", tcpClient->ReceiveTimeout );

      
      // </Snippet10>
      // <Snippet11>
      // sets the send time out using the SendTimeout public property.
      tcpClient->SendTimeout = 5;
      
      // gets the send time out using the SendTimeout public property.
      if ( tcpClient->SendTimeout == 5 )
            Console::WriteLine( "The send time out limit was successfully set {0}", tcpClient->SendTimeout );

      
      // </Snippet11>
      // <Snippet12>
      // sets the amount of time to linger after closing, using the LingerOption public property.
      LingerOption^ lingerOption = gcnew LingerOption( true,10 );
      tcpClient->LingerState = lingerOption;
      
      // gets the amount of linger time set, using the LingerOption public property.
      if ( tcpClient->LingerState->LingerTime == 10 )
            Console::WriteLine( "The linger state setting was successfully set to {0}", tcpClient->LingerState->LingerTime );

      
      // </Snippet12>
      // <Snippet13>
      // Sends data immediately upon calling NetworkStream.Write.
      tcpClient->NoDelay = true;
      
      // Determines if the delay is enabled by using the NoDelay property.
      if ( tcpClient->NoDelay == true )
            Console::WriteLine( "The delay was set successfully to {0}", tcpClient->NoDelay );

      
      // </Snippet13>
      tcpClient->Close();
   }

   static void MyTcpClientCommunicator()
   {
      
      // <Snippet14>
      TcpClient^ tcpClient = gcnew TcpClient;
      
      // Uses the GetStream public method to return the NetworkStream.
      NetworkStream^ netStream = tcpClient->GetStream();
      if ( netStream->CanWrite )
      {
         array<Byte>^sendBytes = Encoding::UTF8->GetBytes( "Is anybody there?" );
         netStream->Write( sendBytes, 0, sendBytes->Length );
      }
      else
      {
         Console::WriteLine( "You cannot write data to this stream." );
         tcpClient->Close();
         
         // Closing the tcpClient instance does not close the network stream.
         netStream->Close();
         return;
      }

      if ( netStream->CanRead )
      {
         
         // Reads NetworkStream into a byte buffer.
         array<Byte>^bytes = gcnew array<Byte>(tcpClient->ReceiveBufferSize);
         
         // Read can return anything from 0 to numBytesToRead. 
         // This method blocks until at least one byte is read.
         netStream->Read( bytes, 0, (int)tcpClient->ReceiveBufferSize );
         
         // Returns the data received from the host to the console.
         String^ returndata = Encoding::UTF8->GetString( bytes );
         Console::WriteLine( "This is what the host returned to you: {0}", returndata );
      }
      else
      {
         Console::WriteLine( "You cannot read data from this stream." );
         tcpClient->Close();
         
         // Closing the tcpClient instance does not close the network stream.
         netStream->Close();
         return;
      }

      
      // </Snippet14>
   }

};


//end class
int main()
{
   
   // Using the default constructor.
   MyTcpClientExample::MyTcpClientConstructor( "DefaultExample" );
   
   // Establish a connection by using the hostname and port number.
   MyTcpClientExample::MyTcpClientConnection( "HostnameExample" );
   
   // Set and verify all communication parameters before attempting communication.
   MyTcpClientExample::MyTcpClientPropertySetter();
   
   // Send and receive data using tcpClient class.
   MyTcpClientExample::MyTcpClientCommunicator();
}

// </Snippet1>
