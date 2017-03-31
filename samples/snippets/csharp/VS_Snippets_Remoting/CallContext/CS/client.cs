// <Snippet1>
using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Messaging;
using System.Security.Principal;
using System.Security.Permissions;

public class ClientClass {
   [PermissionSet(SecurityAction.LinkDemand)]
   public static void Main() {
      
      GenericIdentity ident = new GenericIdentity("Bob");
      GenericPrincipal prpal = new GenericPrincipal(ident, 
                                                    new string[] {"Level1"});
      LogicalCallContextData data = new LogicalCallContextData(prpal);      
      
      //Enter data into the CallContext
      CallContext.SetData("test data", data);

      
      Console.WriteLine(data.numOfAccesses);

      ChannelServices.RegisterChannel(new TcpChannel());

      RemotingConfiguration.RegisterActivatedClientType(typeof(HelloServiceClass),
                                                        "tcp://localhost:8082");

      HelloServiceClass service = new HelloServiceClass();

      if(service == null) {
          Console.WriteLine("Could not locate server.");
          return;
      }


      // call remote method
      Console.WriteLine();
      Console.WriteLine("Calling remote object");
      Console.WriteLine(service.HelloMethod("Caveman"));
      Console.WriteLine(service.HelloMethod("Spaceman"));
      Console.WriteLine(service.HelloMethod("Bob"));
      Console.WriteLine("Finished remote object call");
      Console.WriteLine();

      //Extract the returned data from the call context
      LogicalCallContextData returnedData = 
         (LogicalCallContextData)CallContext.GetData("test data");

      Console.WriteLine(data.numOfAccesses);
      Console.WriteLine(returnedData.numOfAccesses);
   }
}
// </Snippet1>
