// System.Runtime.Remoting.RemotingConfiguration.IsWellKnownClientType(String,String)
/*
The following example demonstrates the 'IsWellKnownClientType(String,String)' method
of 'RemotingConfiguration' class. It registers a 'TcpChannel' object with the channel
services. Then registers the 'MyServerImpl' object as well-known type at the client end.
and displays it's properties to the console.
*/
using System;
using System.Reflection;
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
         RemotingConfiguration.RegisterWellKnownClientType(
                    typeof(MyServerImpl),"tcp://localhost:8085/SayHello");
// <Snippet1>
         MyServerImpl myObject = new MyServerImpl();
         // Get the assembly for the 'MyServerImpl' object.
         Assembly myAssembly = Assembly.GetAssembly(typeof(MyServerImpl));
         AssemblyName myName = myAssembly.GetName();
        // Check whether the specified object type is registered as
        // well-known client type.
        WellKnownClientTypeEntry myWellKnownClientType =
           RemotingConfiguration.IsWellKnownClientType(
                             (typeof(MyServerImpl)).FullName,myName.Name);
        Console.WriteLine("The Object type :"
                        +myWellKnownClientType.ObjectType);
        Console.WriteLine("The Object Uri :"
                        +myWellKnownClientType.ObjectUrl);
// </Snippet1>
        Console.WriteLine(myObject.MyMethod("Remote method is called."));
      }
   }


