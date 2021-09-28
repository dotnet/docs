

// System.Runtime.Remoting.Channels.ITransportHeaders
// System.Runtime.Remoting.Channels.ITransportHeaders.Item
// System.Runtime.Remoting.Channels.ITransportHeaders.GetEnumerator()
/* The following program demonstrates the 'ITransportHeaders' interface,
its 'Item' property and 'GetEnumerator' method. It implements the 'Item'
property and 'GetEnumerator' method in a class derived from 'ITransportHeaders'
interface. It then adds a few headers to the header list and displays them.
*/
// <Snippet1>
#using <System.Runtime.Remoting.dll>
#using <System.dll>
#using <ITransportHeaders_3_Share.dll>

using namespace System;
using namespace System::Collections;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Channels;
using namespace System::Runtime::Remoting::Channels::Tcp;
ref class MyITransportHeadersClass: public ITransportHeaders
{
private:

   // <Snippet2>
   // <Snippet3>
   int myInt;
   array<DictionaryEntry>^myDictionaryEntry;

public:
   MyITransportHeadersClass()
   {
      myInt = 0;
      myDictionaryEntry = gcnew array<DictionaryEntry>(10);
   }


   property Object^ Item [Object^]
   {

      // Implement the 'Item' property.
     virtual Object^ get( Object^ myKey )
      {
         if ( myKey != nullptr )
         {
            for ( int i = 0; i <= myInt; i++ )
               if ( myDictionaryEntry[ i ].Key == myKey )
                              return myDictionaryEntry[ i ].Value;
         }

         return nullptr;
      }

      virtual void set( Object^ myKey, Object^ value )
      {
         myDictionaryEntry[ myInt ] = DictionaryEntry(myKey,value);
         myInt++;
      }

   }

   // Implement the 'GetEnumerator' method.
   virtual IEnumerator^ GetEnumerator()
   {
      Hashtable^ myHashtable = gcnew Hashtable;
      for ( int j = 0; j < myInt; j++ )
         myHashtable->Add( myDictionaryEntry[ j ].Key, myDictionaryEntry[ j ].Value );
      return myHashtable->GetEnumerator();
   }

   // </Snippet3>
   // </Snippet2>
};

int main()
{
   try
   {
      
      // Create and register a 'TcpChannel' object.
      TcpChannel^ myTcpChannel = gcnew TcpChannel( 8085 );
      ChannelServices::RegisterChannel( myTcpChannel, false );
	  RemotingConfiguration::RegisterWellKnownServiceType( MyHelloServer::typeid, "SayHello", WellKnownObjectMode::SingleCall );
      
      // Create an instance of 'myITransportHeadersObj'.
      MyITransportHeadersClass^ myITransportHeadersObj = gcnew MyITransportHeadersClass;
      ITransportHeaders^ myITransportHeaders = dynamic_cast<ITransportHeaders^>(myITransportHeadersObj);
      
      // Add items to the header list.
      myITransportHeaders->default[ "Header1" ] = "TransportHeader1";
      myITransportHeaders->default[ "Header2" ] = "TransportHeader2";
      
      // Get the 'ITranportHeader' item value with key 'Header2'.
      Console::WriteLine( "ITransport Header item value with key 'Header2' is :{0}", myITransportHeaders->default[ "Header2" ] );
      IEnumerator^ myEnumerator = myITransportHeaders->GetEnumerator();
      Console::WriteLine( "     -KEY-      -VALUE-" );
      while ( myEnumerator->MoveNext() )
      {
         
         // Display the 'Key' and 'Value' of the current element.
         Object^ myEntry = myEnumerator->Current;
         DictionaryEntry myDictionaryEntry =  *dynamic_cast<DictionaryEntry^>(myEntry);
         Console::WriteLine( "   {0}:   {1}", myDictionaryEntry.Key, myDictionaryEntry.Value );
      }
      Console::WriteLine( "Hit <enter> to exit..." );
      Console::ReadLine();
   }
   catch ( Exception^ ex ) 
   {
      Console::WriteLine( "The following exception is raised on the server side: {0}", ex->Message );
   }

}

// </Snippet1>
