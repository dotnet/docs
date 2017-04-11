// System.Runtime.Remoting.RemotingConfiguration.IsRemotelyActivatedClientType(String,String)

/*
The following example demonstrates the 'IsRemotelyActivatedClientType(String,String)' method
of 'RemotingConfiguration' class. 
It registers a 'TcpChannel' object with the channel services. Then registers the 'MyServerImpl'
object as activated client type which can be activated at the server and displays it's 
properties to the console.
*/

using System;
using System.Reflection;
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
              Console.WriteLine(myObject.MyMethod("invoke the server method "));
            // Get the assembly for the 'MyServerImpl' object.
// <Snippet1>
            Assembly myAssembly = Assembly.GetAssembly(typeof(MyServerImpl));
            AssemblyName myName = myAssembly.GetName();
            // Check whether the 'MyServerImpl' type is registered as
            // a remotely activated client type.
            ActivatedClientTypeEntry myActivatedClientEntry =
            RemotingConfiguration.IsRemotelyActivatedClientType(
                                 (typeof(MyServerImpl)).FullName,myName.Name);
            Console.WriteLine("The Object type : "
                   +myActivatedClientEntry.ObjectType);
            Console.WriteLine("The Application Url : "
                   +myActivatedClientEntry.ApplicationUrl);
	    if (myActivatedClientEntry != null)
		Console.WriteLine("Object is client activated");
	    else 
		Console.WriteLine("Object is not client activated");
// </Snippet1>
         }
         catch(Exception e)
         {
            Console.WriteLine(e.Message);
         }
      }
   }