// System.Runtime.Remoting.Channels.IServerChannelSinkProvider.CreateSink()
// System.Runtime.Remoting.Channels.IServerChannelSinkProvider.GetChannelData()
// System.Runtime.Remoting.Channels.IServerChannelSinkProvider.Next

/* The following program demonstrates 'CreateSink', 'GetChannelData' 
   methods and 'Next' property of 
   'System.Runtime.Remoting.Channels.ServerChannelSinkStack' class.
   It chains together two different sink providers using the 'Next'
   property. The return value of 'GetChannelData()' is displayed on
   the console.   
*/

using System;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;

class MyServerChannelSinkStack
{
   IServerChannelSinkProvider myIServerChannelSinkProvider;
   IServerChannelSinkProvider myIServerChannelSinkProvider1;
   IServerChannelSink myIServerChannelSink;
   IServerChannelSink myIServerChannelSink1;

   static void Main()
   {
      MyServerChannelSinkStack myNewServerChannelSinkStack = 
                              new MyServerChannelSinkStack();
      myNewServerChannelSinkStack.MyCreateSinkMethod();
      myNewServerChannelSinkStack.MyGetChannelDataMethod();
   }

   public void MyCreateSinkMethod()
   {
      Console.Write("Press Enter to set sink providers and create sinks");
      Console.ReadLine();
// <Snippet1>
// <Snippet3>
      // Create the sink providers.
      myIServerChannelSinkProvider  = new SoapServerFormatterSinkProvider();
      myIServerChannelSinkProvider1 = new BinaryServerFormatterSinkProvider();
      // Create the channel sinks.
      myIServerChannelSink  = myIServerChannelSinkProvider.CreateSink(new HttpChannel());
      myIServerChannelSinkProvider.Next = myIServerChannelSinkProvider1;

      myIServerChannelSink1 = myIServerChannelSinkProvider.Next.CreateSink(new HttpChannel());
// </Snippet3>
// </Snippet1>
      Console.WriteLine("Two sink providers have been set");
   }
   
   public void MyGetChannelDataMethod()
   {
// <Snippet2>
      string[] channelUri = new String[5];
      IChannelDataStore myIChannelDataStore  = new ChannelDataStore(channelUri);
      IChannelDataStore myIChannelDataStore1 = new ChannelDataStore(channelUri);
      myIServerChannelSinkProvider.GetChannelData(myIChannelDataStore);
      myIServerChannelSinkProvider1.GetChannelData(myIChannelDataStore1);
// </Snippet2>
      Console.WriteLine("Number of Uris in first IChannelDataStore: " +
                              myIChannelDataStore.ChannelUris.Length);
      Console.WriteLine("Number of Uris in second IChannelDataStore: " + 
                              myIChannelDataStore1.ChannelUris.Length);
   }
}