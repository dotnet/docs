// <Snippet2>
using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Remoting.Lifetime;
using System.Security.Permissions;

public class Server {

   public static void Main() {

      Server myServer = new Server();
      myServer.Run();
   }
 
[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.Infrastructure)]
   public void Run()
   {
      LifetimeServices.LeaseTime = TimeSpan.FromSeconds(5);
      LifetimeServices.LeaseManagerPollTime = TimeSpan.FromSeconds(3);
      LifetimeServices.RenewOnCallTime = TimeSpan.FromSeconds(2);
      LifetimeServices.SponsorshipTimeout = TimeSpan.FromSeconds(1);
   
      ChannelServices.RegisterChannel(new HttpChannel(8080), true);
      RemotingConfiguration.RegisterActivatedServiceType(typeof(ClientActivatedType));
      
      Console.WriteLine("The server is listening. Press Enter to exit....");
      Console.ReadLine();  

      Console.WriteLine("GC'ing.");
      GC.Collect();
      GC.WaitForPendingFinalizers();
   }
}
// </Snippet2>
