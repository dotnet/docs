// System.Runtime.Remoting.RemotingConfiguration.IsWellKnownClientType(Type)
/*
The following example demonstrates the 'IsWellKnownClientType(Type)' method
of 'RemotingConfiguration' class. It registers a 'TcpChannel' object with the channel
services. Then registers the 'MyServerImpl' object as well-known type. By using the above 
method it gets the well-known type registered at the client side and displays it's 
properties to the console.
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
         // Register the 'MyServerImpl' object as well known type 
         // at client end.
         RemotingConfiguration.RegisterWellKnownClientType(typeof(MyServerImpl),
                              "tcp://localhost:8085/SayHello");
         MyServerImpl myObject = new MyServerImpl();

         Console.WriteLine(myObject.MyMethod("ClientString"));
// <Snippet1>
         // Check whether the specified object type is registered as 
         // well known client type or not.
         WellKnownClientTypeEntry myWellKnownClientType =
             RemotingConfiguration.IsWellKnownClientType(typeof(MyServerImpl));
         Console.WriteLine("The Object type is "
                           +myWellKnownClientType.ObjectType);
         Console.WriteLine("The Object Url is "
                           +myWellKnownClientType.ObjectUrl);
// </Snippet1>
      }
   }


