

#using <System.dll>

using namespace System;
using namespace System::Net;
using namespace System::Net::Sockets;
using namespace System::Text;
using namespace System::Threading;

/*****************************
commented out contents of snippets 1,2,8 becuase this is not legal cpp.
the use of jagged arrays is not supprted and these throw a compiler error. 

*******************************/
// State object for reading client data asynchronously
private ref class StateObject
{
public private:

   // Client  socket.
   Socket^ workSocket;

   // Size of receive buffer.
   literal int BufferSize = 1024;

   // Receive buffer.
   array<Byte>^buffer;

   // Received data string.
   StringBuilder^ sb;

public:
   StateObject()
   {
      workSocket = nullptr;
      buffer = gcnew array<Byte>(BufferSize);
      sb = gcnew StringBuilder;
   }

};

public ref class Test
{
public:

   // Incoming data from client.
   static String^ data = nullptr;

private:

   // ManualResetEvent instances signal completion.
   static ManualResetEvent^ connectDone = gcnew ManualResetEvent( false );
   static ManualResetEvent^ sendDone = gcnew ManualResetEvent( false );
   static ManualResetEvent^ receiveDone = gcnew ManualResetEvent( false );
   static ManualResetEvent^ disconnectDone = gcnew ManualResetEvent( false );

   // The response from the remote device.
   static String^ response = String::Empty;

public:

   // Thread signal.
   static ManualResetEvent^ allDone = gcnew ManualResetEvent( false );
   static void Main()
   {
      array<String^>^args = Environment::GetCommandLineArgs();
      Console::WriteLine( "{0}", args );
      if ( args[ 1 ]->Equals( "as" ) )
      {
         
         // Start the asynchronous server.
         Console::WriteLine( "the asychronous server" );
         AsynchronousServer();
      }
      else
      if ( args[ 1 ]->Equals( "ac" ) )
      {
         
         // Start the asynchronous client.
         Console::WriteLine( "the asynchronous client" );
         AsynchronousClient();
      }
      else
      if ( args[ 1 ]->Equals( "ss" ) )
      {
         
         // Start the synchronous server. 
         Console::WriteLine( "the sychronous server" );
         SynchronousServer();
      }
      else
      if ( args[ 1 ]->Equals( "sc" ) )
      {
         
         // Start the synchronous client.
         Console::WriteLine( "the synchronous client" );
         SynchronousClient();
      }
      else
      {
         Console::WriteLine( "default" );
      }
   }

   static void AsynchronousServer()
   {
      
      // This server waits for a connection and then uses  asychronous operations to
      // accept the connection, get data from the connected client, 
      // echo that data back to the connected client.
      // It then disconnects from the client and waits for another client. 
      Listen();
      
      // ListenWithSocket();
   }

   static void Listen()
   {
      
      // <snippet6>
      // This server waits for a connection and then uses asynchronous operations to
      // accept the connection with initial data sent from the client.
      // Establish the local endpoint for the socket.
      IPHostEntry^ ipHostInfo = Dns::GetHostEntry( Dns::GetHostName() );
      IPAddress^ ipAddress = ipHostInfo->AddressList[ 0 ];
      IPEndPoint^ localEndPoint = gcnew IPEndPoint( ipAddress,11000 );
      
      // Create a TCP/IP socket.
      Socket^ listener = gcnew Socket( AddressFamily::InterNetwork,SocketType::Stream,ProtocolType::Tcp );
      
      // Bind the socket to the local endpoint, and listen for incoming connections.
      listener->Bind( localEndPoint );
      listener->Listen( 100 );
      for ( ; ;  )
      {
         
         // Set the event to nonsignaled state.
         allDone->Reset();
         
         // Start an asynchronous socket to listen for connections and receive data from the client.
         Console::WriteLine( "Waiting for a connection..." );
         
         // Accept the connection and receive the first 10 bytes of data.
         int receivedDataSize = 10;
         listener->BeginAccept( receivedDataSize, gcnew AsyncCallback( AcceptReceiveCallback ), listener );
         
         // Wait until a connection is made and processed before continuing.
         allDone->WaitOne();

      }
   }

   static void AcceptReceiveCallback( IAsyncResult^ ar )
   {
      // Get the socket that handles the client request.
      Socket^ listener = dynamic_cast<Socket^>(ar->AsyncState);

      // End the operation and display the received data on the console.
      array<Byte>^Buffer;
      int bytesTransferred;
      Socket^ handler = listener->EndAccept( Buffer, bytesTransferred, ar );
      String^ stringTransferred = Encoding::ASCII->GetString( Buffer, 0, bytesTransferred );
      Console::WriteLine( stringTransferred );
      Console::WriteLine( "Size of data transferred is {0}", bytesTransferred );

      // Create the state object for the asynchronous receive.
      StateObject^ state = gcnew StateObject;
      state->workSocket = handler;
      handler->BeginReceive( state->buffer, 0, StateObject::BufferSize, static_cast<SocketFlags>(0), gcnew AsyncCallback( ReadCallback ), state );
   }


   // </snippet6>
   static void ListenWithSocket()
   {
      // <snippet7>
      // This server waits for a connection and then uses asynchronous operations to
      // accept the connection with initial data sent from the client.
      // Establish the local endpoint for the socket.
      IPHostEntry^ ipHostInfo = Dns::GetHostEntry( Dns::GetHostName() );
      IPAddress^ ipAddress = ipHostInfo->AddressList[ 0 ];
      IPEndPoint^ localEndPoint = gcnew IPEndPoint( ipAddress,11000 );

      // Create a TCP/IP socket.
      Socket^ listener = gcnew Socket( AddressFamily::InterNetwork,SocketType::Stream,ProtocolType::Tcp );

      // Bind the socket to the local endpoint, and listen for incoming connections.
      listener->Bind( localEndPoint );
      listener->Listen( 100 );
      for ( ; ;  )
      {
         // Set the event to nonsignaled state.
         allDone->Reset();

         // Start an asynchronous socket to listen for connections and receive data from the client.
         Console::WriteLine( "Waiting for a connection..." );

         // Accept the connection and receive the first 10 bytes of data. 
         // BeginAccept() creates the accepted socket.
         int receivedDataSize = 10;
         listener->BeginAccept( nullptr, receivedDataSize, gcnew AsyncCallback( AcceptReceiveDataCallback ), listener );

         // Wait until a connection is made and processed before continuing.
         allDone->WaitOne();
      }
   }

   static void AcceptReceiveDataCallback( IAsyncResult^ ar )
   {
      // Get the socket that handles the client request.
      Socket^ listener = dynamic_cast<Socket^>(ar->AsyncState);
      
      // End the operation and display the received data on the console.
      array<Byte>^Buffer;
      int bytesTransferred;
      Socket^ handler = listener->EndAccept( Buffer, bytesTransferred, ar );
      String^ stringTransferred = Encoding::ASCII->GetString( Buffer, 0, bytesTransferred );
      Console::WriteLine( stringTransferred );
      Console::WriteLine( "Size of data transferred is {0}", bytesTransferred );
      
      // Create the state object for the asynchronous receive.
      StateObject^ state = gcnew StateObject;
      state->workSocket = handler;
      handler->BeginReceive( state->buffer, 0, StateObject::BufferSize, static_cast<SocketFlags>(0), gcnew AsyncCallback( ReadCallback ), state );
   }

   // </snippet7>
   static void ReadCallback( IAsyncResult^ ar )
   {
      String^ content = String::Empty;

      // Retrieve the state object and the handler socket
      // from the asynchronous state object.
      StateObject^ state = dynamic_cast<StateObject^>(ar->AsyncState);
      Socket^ handler = state->workSocket;

      // Read data from the client socket. 
      int bytesRead = handler->EndReceive( ar );
      if ( bytesRead > 0 )
      {
         // There  might be more data, so store the data received so far.
         state->sb->Append( Encoding::ASCII->GetString( state->buffer, 0, bytesRead ) );

         // Check for end-of-file tag. If it is not there, read 
         // more data.
         content = state->sb->ToString();
         if ( content->IndexOf( "<EOF>" ) > -1 )
         {
            // All the data has been read from the 
            // client. Display it on the console.
            Console::WriteLine( "Read {0} bytes from socket. Data : {1}", content->Length, content );

            // Echo the data back to the client.
            Send( handler, content );
         }
         else
         {
            // Not all data received. Get more.
            handler->BeginReceive( state->buffer, 0, StateObject::BufferSize, static_cast<SocketFlags>(0), gcnew AsyncCallback( ReadCallback ), state );
         }
      }
   }


private:
   static void Send( Socket^ handler, String^ data )
   {
      // Convert the string data to byte data using ASCII encoding.
      array<Byte>^byteData = Encoding::ASCII->GetBytes( data );

      // Begin sending the data to the remote device.
      handler->BeginSend( byteData, 0, byteData->Length, static_cast<SocketFlags>(0), gcnew AsyncCallback( SendCallback ), handler );
   }

   static void SendCallback( IAsyncResult^ ar )
   {
      // Retrieve the socket from the state object.
      Socket^ handler = dynamic_cast<Socket^>(ar->AsyncState);

      // Complete sending the data to the remote device.
      int bytesSent = handler->EndSend( ar );
      Console::WriteLine( "Sent {0} bytes to client.", bytesSent );
      handler->Shutdown( SocketShutdown::Both );
      handler->Close();

      // Signal the main thread to continue.
      allDone->Set();
   }

public:
   static void AsynchronousClient()
   {
      // The following methods set up a socket and demonstrate the use of a new Sockets method.
      // Send multiple buffers to remote device.
      //   AsynchronousSendBuffers();
      // Send a file to the remote host.
      //     AsynchronousFileSend();
      // Send a file with pre and post buffers.
      //        AsynchronousFileSendWithBuffers();
      // Show use of Begin/EndDisconnect
      ClientDisconnect();
   }


private:
   static void ClientSendCallback( IAsyncResult^ ar )
   {
      // Retrieve the socket from the state object.
      Socket^ client = dynamic_cast<Socket^>(ar->AsyncState);

      // Complete sending the data to the remote device.
      int bytesSent = client->EndSend( ar );

      // Write to the console the number of bytes sent.
      Console::WriteLine( "Sent {0} bytes to server.", bytesSent );

      // Signal that all bytes have been sent.
      sendDone->Set();
   }


public:

   // <snippet9>
   static void AsynchronousFileSend()
   {
      // Send a file to a remote device.
      // Establish the remote endpoint for the socket.
      IPHostEntry^ ipHostInfo = Dns::GetHostEntry( Dns::GetHostName() );
      IPAddress^ ipAddress = ipHostInfo->AddressList[ 0 ];
      IPEndPoint^ remoteEP = gcnew IPEndPoint( ipAddress,11000 );

      // Create a TCP/IP socket.
      Socket^ client = gcnew Socket( AddressFamily::InterNetwork,SocketType::Stream,ProtocolType::Tcp );

      // Connect to the remote endpoint.
      client->BeginConnect( remoteEP, gcnew AsyncCallback( ConnectCallback ), client );

      // Wait for connect.
      connectDone->WaitOne();

      // There is a text file test.txt in the root directory.
      String^ fileName = "C:\\test.txt";

      // Send file fileName to the remote device.
      Console::WriteLine( fileName );
      client->BeginSendFile( fileName, gcnew AsyncCallback( FileSendCallback ), client );

      // Release the socket.
      client->Shutdown( SocketShutdown::Both );
      client->Close();
   }

private:
   static void FileSendCallback( IAsyncResult^ ar )
   {
      // Retrieve the socket from the state object.
      Socket^ client = dynamic_cast<Socket^>(ar->AsyncState);

      // Complete sending the data to the remote device.
      client->EndSendFile( ar );
      sendDone->Set();
   }

   // </snippet9>


   // <snippet10>
public:
   static void AsynchronousFileSendWithBuffers()
   {
      // Send a file asynchronously to the remote device. Send a buffer before the file and a buffer afterwards.
      // Establish the remote endpoint for the socket.
      IPHostEntry^ ipHostInfo = Dns::GetHostEntry( Dns::GetHostName() );
      IPAddress^ ipAddress = ipHostInfo->AddressList[ 0 ];
      IPEndPoint^ remoteEP = gcnew IPEndPoint( ipAddress,11000 );

      // Create a TCP/IP socket.
      Socket^ client = gcnew Socket( AddressFamily::InterNetwork,SocketType::Stream,ProtocolType::Tcp );

      // Connect to the remote endpoint.
      client->BeginConnect( remoteEP, gcnew AsyncCallback( ConnectCallback ), client );

      // Wait for connect.
      connectDone->WaitOne();

      // Send a file fileName to the remote device with preBuffer and postBuffer data.
      // Create the preBuffer data.
      String^ string1 = String::Format( "This is text data that precedes the file.{0}", Environment::NewLine );
      array<Byte>^preBuf = Encoding::ASCII->GetBytes( string1 );

      // Create the postBuffer data.
      String^ string2 = String::Format( "This is text data that will follow the file.{0}", Environment::NewLine );
      array<Byte>^postBuf = Encoding::ASCII->GetBytes( string2 );

      // There is a file test.txt in the root directory.
      String^ fileName = "C:\\test.txt";

      //Send file fileName with buffers and default flags to the remote device.
      Console::WriteLine( fileName );
      client->BeginSendFile( fileName, preBuf, postBuf, static_cast<TransmitFileOptions>(0), gcnew AsyncCallback( AsynchronousFileSendCallback ), client );

      // Release the socket.
      client->Shutdown( SocketShutdown::Both );
      client->Close();
   }


private:
   static void AsynchronousFileSendCallback( IAsyncResult^ ar )
   {
      // Retrieve the socket from the state object.
      Socket^ client = dynamic_cast<Socket^>(ar->AsyncState);

      // Complete sending the data to the remote device.
      client->EndSendFile( ar );
      sendDone->Set();
   }
   // </snippet10>

   static void ConnectCallback( IAsyncResult^ ar )
   {
      // Retrieve the socket from the state object.
      Socket^ client = dynamic_cast<Socket^>(ar->AsyncState);

      // Complete the connection.
      client->EndConnect( ar );
      Console::WriteLine( "Socket connected to {0}", client->RemoteEndPoint );

      // Signal that the connection has been made.
      connectDone->Set();
   }

   static void Receive( Socket^ client )
   {
      // Create the state object.
      StateObject^ state = gcnew StateObject;
      state->workSocket = client;

      // Begin receiving the data from the remote device.
      client->BeginReceive( state->buffer, 0, StateObject::BufferSize, static_cast<SocketFlags>(0), gcnew AsyncCallback( ReceiveCallback ), state );
   }

   static void ReceiveCallback( IAsyncResult^ ar )
   {
      // Retrieve the state object and the client socket 
      // from the asynchronous state object.
      StateObject^ state = dynamic_cast<StateObject^>(ar->AsyncState);
      Socket^ client = state->workSocket;

      // Read data from the remote device.
      int bytesRead = client->EndReceive( ar );
      if ( bytesRead > 0 )
      {
         // There might be more data, so store the data received so far.
         state->sb->Append( Encoding::ASCII->GetString( state->buffer, 0, bytesRead ) );

         // Get the rest of the data.
         client->BeginReceive( state->buffer, 0, StateObject::BufferSize, static_cast<SocketFlags>(0), gcnew AsyncCallback( ReceiveCallback ), state );
      }
      else
      {
         // All the data has arrived; put it in response.
         if ( state->sb->Length > 1 )
         {
            response = state->sb->ToString();
         }

         // Signal that all bytes have been received.
         receiveDone->Set();
      }
   }


public:
   static void ClientDisconnect()
   {
      //<snippet11>
      // Establish the remote endpoint for the socket.
      // For this example use local computer.
      IPHostEntry^ ipHostInfo = Dns::GetHostEntry( Dns::GetHostName() );
      IPAddress^ ipAddress = ipHostInfo->AddressList[ 0 ];
      IPEndPoint^ remoteEP = gcnew IPEndPoint( ipAddress,11000 );

      // Create a TCP/IP socket.
      Socket^ client = gcnew Socket( AddressFamily::InterNetwork,SocketType::Stream,ProtocolType::Tcp );

      // Connect to the remote endpoint.
      client->BeginConnect( remoteEP, gcnew AsyncCallback( ConnectCallback ), client );

      // Wait for connect.
      connectDone->WaitOne();

      // Send some data to the remote device.
      String^ data = "This is a string of data <EOF>";
      array<Byte>^buffer = Encoding::ASCII->GetBytes( data );
      client->BeginSend( buffer, 0, buffer->Length, static_cast<SocketFlags>(0), gcnew AsyncCallback( ClientSendCallback ), client );

      // Wait for send done.
      sendDone->WaitOne();

      // Release the socket.
      client->Shutdown( SocketShutdown::Both );
      client->BeginDisconnect( true, gcnew AsyncCallback( DisconnectCallback ), client );

      // Wait for the disconnect to complete.
      disconnectDone->WaitOne();
      if ( client->Connected )
            Console::WriteLine( "We're still connected" );
      else
            Console::WriteLine( "We're disconnected" );
   }

private:
   static void DisconnectCallback( IAsyncResult^ ar )
   {
      // Complete the disconnect request.
      Socket^ client = dynamic_cast<Socket^>(ar->AsyncState);
      client->EndDisconnect( ar );

      // Signal that the disconnect is complete.
      disconnectDone->Set();
   }

public:

   //</snippet11>
   static void SynchronousServer()
   {
      // Establish the local endpoint for the socket.
      IPHostEntry^ ipHost = Dns::GetHostEntry( Dns::GetHostName() );
      IPAddress^ ipAddr = ipHost->AddressList[ 0 ];
      IPEndPoint^ ipEndPoint = gcnew IPEndPoint( ipAddr,11000 );

      // For the purposes of this example, we will send and 
      // receive on the same machine. 
      // 
      Socket^ listener = gcnew Socket( AddressFamily::InterNetwork,SocketType::Stream,ProtocolType::Tcp );

      // Bind to the local endpoint and listen to the incoming sockets. 
      listener->Bind( ipEndPoint );
      listener->Listen( 10 );
      for ( ; ;  )
      {
         Console::WriteLine( "Waiting for a connection..." );
         Socket^ handler = listener->Accept();
         String^ data = nullptr;

         // A client is connecting.
         for ( ; ;  )
         {
            array<Byte>^bytes = gcnew array<Byte>(1024);
            int bytesReceived = handler->Receive( bytes );
            data = String::Concat( data, Encoding::ASCII->GetString( bytes, 0, bytesReceived ) );
            if ( data->IndexOf( "<EOF>" ) > -1 )
            {
               break;
            }
         }

         // All the data has been read from the client.
         // Display it on the console.
         Console::WriteLine( "Read {0} bytes from socket. Data : {1}", data->Length, data );

         // Echo the data back to the client.
         //Send(handler, content);
         handler->Send( Encoding::ASCII->GetBytes( data ) );
         handler->Shutdown( SocketShutdown::Both );
         handler->Close();
      }
   }

   static void SynchronousClient()
   {
      // The following methods set up a socket and demonstrate the use of a new Sockets method.
      // Set the socket options
      //     SetSocketOptions();
      // Send multiple buffers to remote device.
      //  SendMultiBuffers();
      // Send multiple buffers with socket flags
      //  SendMultiBuffersWithFlags();
      // Send a file to the remote host.
      //  FileSend();
      // Send a file with pre and post buffers 
      //  FileSendWithBuffers();
      // Show synchronous disconnect
      SynchronousDisconnect();
   }

private:
   static void SetSocketOptions()
   {
      // <snippet5>
      // Establish the local endpoint for the socket.
      IPHostEntry^ ipHost = Dns::GetHostEntry( Dns::GetHostName() );
      IPAddress^ ipAddr = ipHost->AddressList[ 0 ];
      IPEndPoint^ ipEndPoint = gcnew IPEndPoint( ipAddr,11000 );

      // Create a TCP socket.
      Socket^ client = gcnew Socket( AddressFamily::InterNetwork,SocketType::Stream,ProtocolType::Tcp );

      // Connect the socket to the remote endpoint.
      client->Connect( ipEndPoint );

      // Set option that allows socket to close gracefully without lingering.
      client->SetSocketOption( SocketOptionLevel::Socket, SocketOptionName::DontLinger, true );

      // Set option that allows socket to receive out-of-band information in the data stream.
      client->SetSocketOption( SocketOptionLevel::Socket, SocketOptionName::OutOfBandInline, true );

      // </snippet5>
      // Release the socket.
      client->Shutdown( SocketShutdown::Both );
      client->Close();
   }

   static void FileSend()
   {
      // <snippet3>
      // Establish the local endpoint for the socket.
      IPHostEntry^ ipHost = Dns::GetHostEntry( Dns::GetHostName() );
      IPAddress^ ipAddr = ipHost->AddressList[ 0 ];
      IPEndPoint^ ipEndPoint = gcnew IPEndPoint( ipAddr,11000 );

      // Create a TCP socket.
      Socket^ client = gcnew Socket( AddressFamily::InterNetwork,SocketType::Stream,ProtocolType::Tcp );

      // Connect the socket to the remote endpoint.
      client->Connect( ipEndPoint );

      // There is a text file test.txt located in the root directory.
      String^ fileName = "C:\\test.txt";

      // Send file fileName to remote device
      Console::WriteLine( "Sending {0} to the host.", fileName );
      client->SendFile( fileName );

      // Release the socket.
      client->Shutdown( SocketShutdown::Both );
      client->Close();
      // </snippet3>
   }

   static void FileSendWithBuffers()
   {
      // <snippet4>
      // Establish the local endpoint for the socket.
      IPHostEntry^ ipHost = Dns::GetHostEntry( Dns::GetHostName() );
      IPAddress^ ipAddr = ipHost->AddressList[ 0 ];
      IPEndPoint^ ipEndPoint = gcnew IPEndPoint( ipAddr,11000 );

      // Create a TCP socket.
      Socket^ client = gcnew Socket( AddressFamily::InterNetwork,SocketType::Stream,ProtocolType::Tcp );

      // Connect the socket to the remote endpoint.
      client->Connect( ipEndPoint );

      // Send file fileName to the remote host with preBuffer and postBuffer data.
      // There is a text file test.txt located in the root directory.
      String^ fileName = "C:\\test.txt";

      // Create the preBuffer data.
      String^ string1 = String::Format( "This is text data that precedes the file.{0}", Environment::NewLine );
      array<Byte>^preBuf = Encoding::ASCII->GetBytes( string1 );

      // Create the postBuffer data.
      String^ string2 = String::Format( "This is text data that will follow the file.{0}", Environment::NewLine );
      array<Byte>^postBuf = Encoding::ASCII->GetBytes( string2 );

      //Send file fileName with buffers and default flags to the remote device.
      Console::WriteLine( "Sending {0} with buffers to the host.{1}", fileName, Environment::NewLine );
      client->SendFile( fileName, preBuf, postBuf, TransmitFileOptions::UseDefaultWorkerThread );

      // Release the socket.
      client->Shutdown( SocketShutdown::Both );
      client->Close();
      // </snippet4>
   }

public:
   static void SynchronousDisconnect()
   {
      //<snippet12>
      IPHostEntry^ ipHost = Dns::GetHostEntry( Dns::GetHostName() );
      IPAddress^ ipAddr = ipHost->AddressList[ 0 ];
      IPEndPoint^ ipEndPoint = gcnew IPEndPoint( ipAddr,11000 );
      Socket^ client = gcnew Socket( AddressFamily::InterNetwork,SocketType::Stream,ProtocolType::Tcp );

      // Connect the socket to the remote end point.
      client->Connect( ipEndPoint );

      // Send some data to the remote device.
      String^ data = "This is a string of data <EOF>";
      array<Byte>^buffer = Encoding::ASCII->GetBytes( data );
      int bytesTransferred = client->Send( buffer );

      // Write to the console the number of bytes transferred.
      Console::WriteLine( "{0} bytes were sent.\n", bytesTransferred );

      // Release the socket.
      client->Shutdown( SocketShutdown::Both );
      client->Disconnect( true );
      if ( client->Connected )
            Console::WriteLine( "We're still connnected" );
      else
            Console::WriteLine( "We're disconnected" );
      //</snippet12>
   }
};

int main()
{
   Test::Main();
}

/*
The output from this example will vary depending on the value passed into Main 
but will be similar to the following:

Content length is 1542
Content type is text/html; charset=utf-8
Response stream received.
<html>
...
</html>

*/
