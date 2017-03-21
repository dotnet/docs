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
   property Object^ ChannelData 
   {
      virtual Object^ get()
      {
         return myChannelData;
      }
   }

   // Create and send the object URL.
   virtual array<String^>^ GetUrlsForUri( String^ objectURI )
   {
      array<String^>^myString = gcnew array<String^>(1);
      myString[ 0 ] = String::Concat( Dns::Resolve( Dns::GetHostName() )->AddressList[ 0 ], "/", objectURI );
      return myString;
   }

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
};