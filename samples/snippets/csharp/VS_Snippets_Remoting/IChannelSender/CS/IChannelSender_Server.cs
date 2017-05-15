/* This file is a support file for demonstrating the members of
   IChannelSender interface on the client side. */

using System;
using System.Collections;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;

class MyServer
{
   static void Main()
   {
      try
      {
         string myString;
         int myPort = 8085;
         // Create the 'IDictionary' to set the server object properties.
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
         // Indicate whether 'IChannelReceiverHook' wants to be hooked into the outside listener service.
         Console.WriteLine("WantsToListen : " + myHttpServerChannel.WantsToListen);
         // Extract the channel URI and the remote well known object URI from the specified URL.
         Console.WriteLine("Parsed : " + 
                        myHttpServerChannel.Parse(myHttpServerChannel.GetChannelUri()+
                                                               "/SayHello",out myString));
         Console.WriteLine("String : " + myString);
         Console.WriteLine("Hit <enter> to stop listening...");
         Console.ReadLine();
         // Stop listening to channel.
         myHttpServerChannel.StopListening((object)myPort);
         Console.WriteLine("Hit <enter> to exit...");
         Console.ReadLine();
      }
      catch(Exception ex)
      {
         Console.WriteLine("The following exception is raised on server side : " + ex.Message);
      }
   }
}