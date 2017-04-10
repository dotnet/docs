

//  System.Runtime.Remoting.Channels.IChannelReceiver
//  System.Runtime.Remoting.Channels.IChannelReceiver.ChannelData
//  System.Runtime.Remoting.Channels.IChannelReceiver.GetUrlsForUri
//  System.Runtime.Remoting.Channels.IChannelReceiver.StartListening
//  System.Runtime.Remoting.Channels.IChannelReceiver.StopListening
/*
This example implements the 'ChannelData' property and 'GetUrlsForUri',
'StartListening' and 'StopListening' method of 'IChannelReceiver' interface.
It creates a server by implementing 'IChannelReceiver' interface to receive 
request send by the client.
*/
#using <System.dll>
#using <IChannelReceiver_ChannelData_Share.dll>

using namespace System::Runtime::InteropServices;
using namespace System;
using namespace System::IO;
using namespace System::Net;
using namespace System::Threading;
using namespace System::Net::Sockets;
using namespace System::Runtime::Remoting::Channels;
using namespace System::Text::RegularExpressions;

// <Snippet1>
ref class MyCustomChannel: public IChannelReceiver
{
private:
   ChannelDataStore^ myChannelData;
   int myChannelPriority;

   // Set the 'ChannelName' to 'MyCustomChannel'.
   String^ myChannelName;

   // Implement 'ChannelName' property.
   TcpListener^ myTcpListener;
   int myPortNo;
   bool myListening;
   Thread^ myThread;

public:
   MyCustomChannel()
      : myChannelPriority( 25 ), myChannelName( "tcp" ), myListening( false )
   {}

   MyCustomChannel( int portNo )
   {
      myPortNo = portNo;
      array<String^>^myURI = gcnew array<String^>(1);
      myURI[ 0 ] = String::Concat( Dns::Resolve( Dns::GetHostName() )->AddressList[ 0 ], ":", portNo );

      // Store the 'URI' in 'myChannelDataStore'.
      myChannelData = gcnew ChannelDataStore( myURI );

      // Create 'myTcpListener' to listen at the 'myPortNo' port.
      myTcpListener = gcnew TcpListener( myPortNo );

      // Create the thread 'myThread'.
      myThread = gcnew Thread( gcnew ThreadStart( myTcpListener, &TcpListener::Start ) );
      this->StartListening( nullptr );
   }

   property String^ ChannelName 
   {
      virtual String^ get()
      {
         return myChannelName;
      }
   }

   property int ChannelPriority 
   {
      virtual int get()
      {
         return myChannelPriority;
      }
   }
   virtual String^ Parse( String^ myUrl, [Out]String^% objectURI )
   {
      Regex^ myRegex = gcnew Regex( "/",RegexOptions::RightToLeft );
      
      // Check for '/' in 'myUrl' from Right to left.
      Match^ myMatch = myRegex->Match(myUrl);
      
      // Get the object URI.
      objectURI = myUrl->Substring( myMatch->Index );
      
      // Return the channel url.
      return myUrl->Substring( 0, myMatch->Index );
   }

   // Implementation of 'IChannelReceiver' interface.
   // <Snippet2>
   property Object^ ChannelData 
   {
      virtual Object^ get()
      {
         return myChannelData;
      }
   }
   // </Snippet2>

   // <Snippet3>
   // Create and send the object URL.
   virtual array<String^>^ GetUrlsForUri( String^ objectURI )
   {
      array<String^>^myString = gcnew array<String^>(1);
      myString[ 0 ] = String::Concat( Dns::Resolve( Dns::GetHostName() )->AddressList[ 0 ], "/", objectURI );
      return myString;
   }
   // </Snippet3>

   // <Snippet4>
   // Start listening to the port.
   virtual void StartListening( Object^ data )
   {
      if ( myListening == false )
      {
         myTcpListener->Start();
         myListening = true;
         Console::WriteLine( "Server Started Listening !!!" );
      }
   }
   // </Snippet4>

   // <Snippet5>
   // Stop listening to the port.
   virtual void StopListening( Object^ data )
   {
      if ( myListening == true )
      {
         myTcpListener->Stop();
         myListening = false;
         Console::WriteLine( "Server Stopped Listening !!!" );
      }
   }
   // </Snippet5>
};
// </Snippet1>

int main()
{
   MyCustomChannel^ myChannel = gcnew MyCustomChannel( 8085 );
   ChannelDataStore^ myChannelDataStore = (ChannelDataStore^)myChannel->ChannelData;
   Console::WriteLine( "The channel URI is {0}", myChannelDataStore->ChannelUris[ 0 ] );
   array<String^>^myUrlArray = myChannel->GetUrlsForUri( "SayHello" );
   Console::WriteLine( "The URL for the objectURI is {0}", myUrlArray[ 0 ] );
   bool continueOption = true;
   while ( continueOption )
   {
      Console::WriteLine( "" );
      Console::WriteLine( "Select a option .." );
      Console::WriteLine( " 1 - StartListening" );
      Console::WriteLine( " 2 - StopListening" );
      Console::WriteLine( " 3 - Exit" );
      Console::Write( "Option : " );
      int myOption = Int32::Parse( Console::ReadLine() );
      switch ( myOption )
      {
         case 1:
            myChannel->StartListening( nullptr );
            break;

         case 2:
            myChannel->StopListening( nullptr );
            break;

         case 3:
            continueOption = false;
            break;
      }
   }
}
