// System.Runtime.Remoting.RemotingConfiguration.IsRemotelyActivatedClientType(Type)

/*
The following example demonstrates the 'IsRemotelyActivatedClientType(Type)' method
of 'RemotingConfiguration' class. 
It registers a 'TcpChannel' object with the channel services. Then registers the 'MyServerImpl'
object as activated client type which can be activated at the server. By using the above 
method it gets the activated client type registered at the client side and displays it's 
properties to the console.
*/

using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

   public class ClientClass
   {
      static void Main()
      {
         try
         {
            ChannelServices.RegisterChannel(new TcpChannel());
            RemotingConfiguration.RegisterActivatedClientType(
                           typeof(MyServerImpl),"tcp://localhost:8085");
            MyServerImpl myObject = new MyServerImpl();
            for(int i=0;i<=4;i++)
              Console.WriteLine(myObject.MyMethod("invoke the server method "
                                                    +(i+1)+ " time."));

// <Snippet1>
            // Check whether the 'MyServerImpl' type is registered as
            // a remotely activated client type.
            ActivatedClientTypeEntry myActivatedClientEntry =
            RemotingConfiguration.IsRemotelyActivatedClientType(
                                            typeof(MyServerImpl));
            Console.WriteLine("The Object type is "
                   +myActivatedClientEntry.ObjectType);
            Console.WriteLine("The Application Url is "
                   +myActivatedClientEntry.ApplicationUrl);
// </Snippet1>
         }
         catch(Exception e)
         {
            Console.WriteLine(e.Message);
         }
      }
   }