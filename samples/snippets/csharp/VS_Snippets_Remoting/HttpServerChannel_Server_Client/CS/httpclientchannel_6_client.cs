// System.Runtime.Remoting.Channels.Http.HttpClientChannel
// System.Runtime.Remoting.Channels.Http.HttpClientChannel.ChannelName; System.Runtime.Remoting.Channels.Http.HttpClientChannel.ChannelPriority; System.Runtime.Remoting.Channels.Http.HttpClientChannel.Parse(); System.Runtime.Remoting.Channels.Http.HttpClientChannel.Keys; System.Runtime.Remoting.Channels.Http.HttpClientChannel.CreateMessageSink()

/*
The following program demonstrates the 'HttpClientChannel' class and
'ChannelName','ChannelPriority' , 'Keys', properties, and 'Parse',
CreateMessageSink methods of 'HttpClientChannel' class. This program 
create and registers 'HttpClientChannel'. This will change the priority
of the 'HttpClientChannel' channel and it displays the property values 
of 'HttpClientChannel'.
*/
// <Snippet4>
using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Collections;
using  System.Runtime.Remoting.Messaging;
using System.Security.Permissions;

public class MyHttpClientChannel 
{
   [PermissionSet(SecurityAction.LinkDemand)]
   public static void Main() 
   {
      try
      {
// <Snippet5>
         // Creating the 'IDictionary' to set the server object properties.
         IDictionary myDictionary = new Hashtable();
         myDictionary["name"]="HttpClientChannel";
         myDictionary["priority"]=2;
         // Set the properties along with the constructor.
         HttpClientChannel myHttpClientChannel = 
               new HttpClientChannel(myDictionary,new BinaryClientFormatterSinkProvider());
         // Register the server channel.
         ChannelServices.RegisterChannel(myHttpClientChannel);
         MyHelloServer myHelloServer1 = (MyHelloServer)Activator.GetObject(
         typeof(MyHelloServer), "http://localhost:8085/SayHello");
         if (myHelloServer1 == null)
            System.Console.WriteLine("Could not locate server");
         else
         {
            Console.WriteLine(myHelloServer1.myHelloMethod("Client"));
            // Get the name of the channel.
            Console.WriteLine("Channel Name :"+myHttpClientChannel.ChannelName);
            // Get the channel priority.
            Console.WriteLine("ChannelPriority :"+myHttpClientChannel.ChannelPriority.ToString());
            string myString,myObjectURI1;
            Console.WriteLine("Parse :" + 
                myHttpClientChannel.Parse("http://localhost:8085/SayHello",out myString)+myString);
            // Get the key count.
            System.Console.WriteLine("Keys.Count : " + myHttpClientChannel.Keys.Count);
            // Get the channel message sink that delivers message to the specified url.
            IMessageSink myIMessageSink = 
            myHttpClientChannel.CreateMessageSink("http://localhost:8085/NewEndPoint", 
                                                                            null,out myObjectURI1);
            Console.WriteLine("The channel message sink that delivers the messages to the URL is : "
                                    +myIMessageSink.ToString());
            Console.WriteLine("URI of the new channel message sink is: " +myObjectURI1);
         }
// </Snippet5>
      }
      catch(Exception ex)
      {
         Console.WriteLine("The following exception is raised on client side :"+ex.Message);
      }     
   }
}
// </Snippet4>
