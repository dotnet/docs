// System.Runtime.Remoting.Channels.IChannelSender
// System.Runtime.Remoting.Channels.IChannelSender.CreateMessageSink()

/* The following program demonstrates the usage of IChannelSender 
   interface and its 'CreateMessageSink' method in the namespace
   'System.Runtime.Remoting.Channels'. This program creates and
   registers an IChannelSender of type 'HttpClientChannel'.
   It sets the priority of the channel and it displays the
   property values of 'HttpClientChannel'. */

// <Snippet1>
using System;
using System.Collections;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Channels.Http;
using System.Security.Permissions;

public class MyClient
{
   [PermissionSet(SecurityAction.LinkDemand)]
   public static void Main()
   {
      try
      {
         // Create the 'IDictionary' to set the server object properties.
         IDictionary myDictionary = new Hashtable();
         myDictionary["name"] = "HttpClientChannel";
         myDictionary["priority"] = 2;
         // Set the properties along with the constructor.
         IChannelSender myIChannelSender = new HttpClientChannel(myDictionary,
                                    new BinaryClientFormatterSinkProvider());
         // Register the server channel.
         ChannelServices.RegisterChannel(myIChannelSender);
         MyHelloServer myHelloServer1 = (MyHelloServer)Activator.GetObject(
                  typeof(MyHelloServer), "http://localhost:8085/SayHello");
         if (myHelloServer1 == null)
         {
            Console.WriteLine("Could not locate server");
         }
         else
         {
            Console.WriteLine(myHelloServer1.myHelloMethod("Client"));
            // Get the name of the channel.
            Console.WriteLine("Channel Name :" + myIChannelSender.ChannelName);
            // Get the channel priority.
            Console.WriteLine("ChannelPriority :" + 
                        myIChannelSender.ChannelPriority.ToString());
            string myString,myObjectURI1;
            Console.WriteLine("Parse :" + 
                myIChannelSender.Parse("http://localhost:8085/SayHello",out myString)
                + myString);
// <Snippet2>
            // Get the channel message sink that delivers message to specified url.
            IMessageSink myIMessageSink = 
                  myIChannelSender.CreateMessageSink(
                  "http://localhost:8085/NewEndPoint", null,out myObjectURI1);
            Console.WriteLine("Channel message sink used :" + myIMessageSink.ToString());
// </Snippet2>
            Console.WriteLine("URI of new channel message sink :" + myObjectURI1);
         }
      }
      catch(Exception ex)
      {
         Console.WriteLine("Following exception is raised on client side : " + ex.Message);
      }
   }
}
// </Snippet1>