// System.Runtime.Remoting.Channels.Http.HttpServerChannel
// System.Runtime.Remoting.Channels.Http.HttpServerChannel.StartListening(); System.Runtime.Remoting.Channels.Http.HttpServerChannel.ChannelName; System.Runtime.Remoting.Channels.Http.HttpServerChannel.ChannelPriority; System.Runtime.Remoting.Channels.Http.HttpServerChannel.ChannelScheme; System.Runtime.Remoting.Channels.Http.HttpServerChannel.GetChannelUri(); System.Runtime.Remoting.Channels.Http.HttpServerChannel.WantsToListen
// System.Runtime.Remoting.Channels.Http.HttpServerChannel.Parse(); System.Runtime.Remoting.Channels.Http.HttpServerChannel.StopListening()

/* The following program demonstrates the 'HttpServerChannel' class, 'ChannelName',
   'ChannelPriority', 'ChannelScheme', 'WantsToListen' properties, 'GetChannelUri',
   'StartListening', 'StopListening' and 'Parse' methods of 'HttpServerChannel' class. 
   This program creates and registers 'HttpServerChannel'. This will change the priority 
   of the 'HttpServerChannel' channel and displays the property values of this class.
*/

// <Snippet1>
using System;
using System.Collections;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;

class MyHttpServerChannel
{
   static void Main( )
   {
      try
      {
         string myString;
// <Snippet2>
         int myPort = 8085;
         // Creating the 'IDictionary' to set the server object properties.
         IDictionary myDictionary = new Hashtable();
         myDictionary["name"] = "MyServerChannel1";
         myDictionary["priority"] = 2;
         myDictionary["port"] = 8085;
         // Set the properties along with the constructor.
         HttpServerChannel myHttpServerChannel = new HttpServerChannel(myDictionary,
                                             new BinaryServerFormatterSinkProvider());
         // Register the server channel.
         ChannelServices.RegisterChannel(myHttpServerChannel);
         RemotingConfiguration.RegisterWellKnownServiceType(typeof(MyHelloServer), 
                                       "SayHello", WellKnownObjectMode.SingleCall);  
         myHttpServerChannel.WantsToListen = true;
         // Start listening on a specific port.
         myHttpServerChannel.StartListening((object)myPort);
         // Get the name of the channel.
         Console.WriteLine("ChannelName : " + myHttpServerChannel.ChannelName);
         // Get the channel priority.
         Console.WriteLine("ChannelPriority : " + myHttpServerChannel.ChannelPriority);
         // Get the schema of the channel.
         Console.WriteLine("ChannelScheme : " + myHttpServerChannel.ChannelScheme);
         // Get the channel URI.
         Console.WriteLine("GetChannelUri : " + myHttpServerChannel.GetChannelUri());
         // Indicates whether 'IChannelReceiverHook' wants to be hooked into the outside listener service.
         Console.WriteLine("WantsToListen : " + myHttpServerChannel.WantsToListen);
// </Snippet2>
// <Snippet3>
         // Extract the channel URI and the remote well known object URI from the specified URL.
         Console.WriteLine("Parsed : " + 
                        myHttpServerChannel.Parse(myHttpServerChannel.GetChannelUri()+
                                                               "/SayHello",out myString));
         Console.WriteLine("Remote WellKnownObject : " + myString);
         Console.WriteLine("Hit <enter> to stop listening...");
         Console.ReadLine();
         // Stop listening to channel.
         myHttpServerChannel.StopListening((object)myPort);
// </Snippet3>
         Console.WriteLine("Hit <enter> to exit...");
         Console.ReadLine();
      }
      catch(Exception ex)
      {
         Console.WriteLine("The following exception is raised on server side : " + ex.Message);
      }
   }
}
// </Snippet1>