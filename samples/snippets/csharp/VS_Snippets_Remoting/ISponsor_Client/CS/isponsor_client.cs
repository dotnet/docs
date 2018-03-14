// System.Runtime.Remoting.Lifetime.ISponsor
// System.Runtime.Remoting.Lifetime.ISponsor.Renewal
/*
   The following program demonstrates the 'ISponsor' interface and its 'Renewal' method.
   It defines 'MyClientSponsor' which implements 'ISponsor' interface. The server and
   client is created. The client registers a sponsor that(after the initial lease time)
   renews the lease at different time from that specified in the remote type.
*/

// <Snippet3>
using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Lifetime;
using System.Security.Permissions;

public class Client
{
   [SecurityPermission(SecurityAction.LinkDemand)]
   public static void Main()
   {
      // Load the configuration file.
      RemotingConfiguration.Configure("ISponsor_Client.config");
      ClientActivatedType clientActivatedObject = new ClientActivatedType();

      ILease serverLease = (ILease)RemotingServices.GetLifetimeService(clientActivatedObject);
      MyClientSponsor sponsor = new MyClientSponsor();

      // Note: If you don't pass an initial time, the first request will be taken
      // from the LeaseTime settings specified in the ISponsor_Server.config file.
      serverLease.Register(sponsor);

      Console.WriteLine("Client-activated object.\n" + 
         clientActivatedObject.RemoteMethod());

      Console.WriteLine("Press enter to end the client application domain.");
      Console.ReadLine();
   }
}
// <Snippet1>
// <Snippet2>
public class MyClientSponsor : MarshalByRefObject, ISponsor
{
   private DateTime lastRenewal;
   public MyClientSponsor()
   {
      lastRenewal = DateTime.Now;
   }

   [SecurityPermissionAttribute(SecurityAction.LinkDemand, Flags=SecurityPermissionFlag.Infrastructure)]
   public TimeSpan Renewal(ILease lease)
   {
      Console.WriteLine("Request to renew the lease time.");
      Console.WriteLine("Time since last renewal: " + 
         (DateTime.Now - lastRenewal).ToString());

      lastRenewal = DateTime.Now;
      return TimeSpan.FromSeconds(20);
   }
}
// </Snippet2>
// </Snippet1>
// </Snippet3>
