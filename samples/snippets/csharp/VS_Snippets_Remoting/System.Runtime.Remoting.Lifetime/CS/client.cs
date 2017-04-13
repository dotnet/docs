// <Snippet1>
using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Lifetime;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Security.Permissions;

public class Client {
[SecurityPermission(SecurityAction.Demand)]
   public static void Main() {
   
      ChannelServices.RegisterChannel(new HttpChannel(0));
      RemotingConfiguration.RegisterActivatedClientType(typeof(ClientActivatedType), "http://localhost:8080");
       
      ClientActivatedType CAObject = new ClientActivatedType();

      ILease serverLease = (ILease)RemotingServices.GetLifetimeService(CAObject);
      MyClientSponsor sponsor = new MyClientSponsor();

      serverLease.Register(sponsor);
    
      // Call same method on the object
      Console.WriteLine("Client-activated object: " + CAObject.RemoteMethod("Bob"));

      Console.WriteLine("Press Enter to end the client application domain.");
      Console.ReadLine();
   }
}


public class MyClientSponsor : MarshalByRefObject, ISponsor {

   private DateTime lastRenewal;

   public MyClientSponsor() {
       Console.WriteLine("Activateing client...");
       lastRenewal = DateTime.Now;
   }

[SecurityPermission(SecurityAction.Demand, Flags=SecurityPermissionFlag.Infrastructure)]
   public TimeSpan Renewal(ILease lease) {
      Console.WriteLine("Renewing a lease for 4 seconds.");
      Console.WriteLine("Time since last renewal:" + (DateTime.Now - lastRenewal).ToString());
      lastRenewal = DateTime.Now;
      
      return TimeSpan.FromSeconds(4);
   }
}
// </Snippet1>
