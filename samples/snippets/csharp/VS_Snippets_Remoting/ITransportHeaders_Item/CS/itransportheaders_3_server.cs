// System.Runtime.Remoting.Channels.ITransportHeaders
// System.Runtime.Remoting.Channels.ITransportHeaders.Item
// System.Runtime.Remoting.Channels.ITransportHeaders.GetEnumerator()

/* The following program demonstrates the 'ITransportHeaders' interface,
   its 'Item' property and 'GetEnumerator' method. It implements the 'Item'
   property and 'GetEnumerator' method in a class derived from 'ITransportHeaders'
   interface. It then adds a few headers to the header list and displays them.
*/

// <Snippet1>

using System;
using System.Collections;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

class MyITransportHeadersClass : ITransportHeaders
{
// <Snippet2>
// <Snippet3>
   int myInt = 0;
   DictionaryEntry[] myDictionaryEntry = new DictionaryEntry[10];
   // Implement the 'Item' property.
   object ITransportHeaders.this[object myKey]
   {
      get
      {
         if(myKey != null)
         {
            for(int i = 0; i <= myInt; i++)
               if(myDictionaryEntry[i].Key == myKey)
                  return myDictionaryEntry[i].Value;
         }
         return 0;
      }
      set
      {
         myDictionaryEntry[myInt] = new DictionaryEntry(myKey, value);
         myInt++;
      }
   }
   // Implement the 'GetEnumerator' method.
   IEnumerator ITransportHeaders.GetEnumerator()
   {
      Hashtable myHashtable = new Hashtable();
      for(int j = 0; j < myInt; j++)
         myHashtable.Add(myDictionaryEntry[j].Key, myDictionaryEntry[j].Value);
      return myHashtable.GetEnumerator();
   }

   public static void Main()
   {
      try
      {
         // Create and register a 'TcpChannel' object.
         TcpChannel myTcpChannel = new TcpChannel(8085);
         ChannelServices.RegisterChannel(myTcpChannel);
         RemotingConfiguration.RegisterWellKnownServiceType(typeof(MyHelloServer), "SayHello",
            WellKnownObjectMode.SingleCall);
         // Create an instance of 'myITransportHeadersObj'.
         MyITransportHeadersClass myITransportHeadersObj = new MyITransportHeadersClass();
         ITransportHeaders myITransportHeaders = (ITransportHeaders)myITransportHeadersObj;
         // Add items to the header list.
         myITransportHeaders["Header1"] = "TransportHeader1";
         myITransportHeaders["Header2"] = "TransportHeader2";
         // Get the 'ITranportHeader' item value with key 'Header2'.
         Console.WriteLine("ITransport Header item value with key 'Header2' is :"
            +myITransportHeaders["Header2"]);
         IEnumerator myEnumerator = myITransportHeaders.GetEnumerator();
         Console.WriteLine( "     -KEY-      -VALUE-" );
         while ( myEnumerator.MoveNext() )
         {
            // Display the 'Key' and 'Value' of the current element.
            object myEntry = myEnumerator.Current;
            DictionaryEntry myDictionaryEntry = (DictionaryEntry)myEntry;
            Console.WriteLine("   {0}:   {1}", myDictionaryEntry.Key, myDictionaryEntry.Value);
         }
         Console.WriteLine("Hit <enter> to exit...");
         Console.ReadLine();
      }
      catch(Exception ex)
      {
         Console.WriteLine("The following exception is raised on the server side: " +ex.Message);
      }
   }
// </Snippet3>
// </Snippet2>
}

// </Snippet1>