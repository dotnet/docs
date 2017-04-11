// System.Runtime.Remoting.RemotingConfiguration.GetRegisteredWellKnownClientTypes

/*
The following example demonstrates the 'GetRegisteredWellKnownClientTypes' method
of 'RemotingConfiguration' class. 
It registers a 'TcpChannel' object with the channel services. Then registers the 
'MyServerImpl' object as well-known type at the client end. By using the 
'GetRegisteredWellKnownClientTypes' method it gets well-known types registered
at the client side and displays it's properties to the console.
*/
using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

   public class Client
   {
      public static void Main()
      {
         ChannelServices.RegisterChannel(new TcpChannel());
         // Register the specified object as well-known type at client end.
         RemotingConfiguration.RegisterWellKnownClientType(
              typeof(MyServerImpl),"tcp://localhost:8085/SayHello");
         MyServerImpl myObject = new MyServerImpl();
         Console.WriteLine(myObject.MyMethod("ClientString"));

// <Snippet1>
         // Get the well-known types registered at the client.
         WellKnownClientTypeEntry[] myEntries =
                RemotingConfiguration.GetRegisteredWellKnownClientTypes();
         Console.WriteLine("The number of WellKnownClientTypeEntries are:"
                                    +myEntries.Length);
         Console.WriteLine("The Object type is:"+myEntries[0].ObjectType);
         Console.WriteLine("The Object Url is:"+myEntries[0].ObjectUrl);
// </Snippet1>

      } 
   }


