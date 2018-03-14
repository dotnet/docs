// System.Runtime.Remoting.Lifetime.ClientSponsor.Register(MarshalByRefObject)
// System.Runtime.Remoting.Lifetime.ClientSponsor.Unregister(MarshalByRefObject)
// System.Runtime.Remoting.Lifetime.ClientSponsor.RenewalTime
// System.Runtime.Remoting.Lifetime.ClientSponsor.InitializeLifetimeService()
// System.Runtime.Remoting.Lifetime.ClientSponsor.Renewal(ILease)
// System.Runtime.Remoting.Lifetime.ClientSponsor.Close()
// System.Runtime.Remoting.Lifetime.ClientSponsor

/* The following example demonstrates 'RenewalTime', 'Register', 'UnRegister' and
   'Close' methods of 'ClientSponsor' class.
   A remote object is created and registered with 'ClientSponsor' class. The renewal
   time is set. Then the leased time is renewed and the method of remote object is invoked.
   Finally the remote object is unregistered.
*/

// <Snippet1>
using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Lifetime;
namespace RemotingSamples
{

// <Snippet2>
   class HelloClient
   {
       static void Main()
      {
         // Register a channel.
         TcpChannel myChannel = new TcpChannel ();
         ChannelServices.RegisterChannel(myChannel);
         RemotingConfiguration.RegisterActivatedClientType(
                                typeof(HelloService),"tcp://localhost:8085/");

         // Get the remote object.
         HelloService myService = new HelloService();

         // Get a sponsor for renewal of time.
         ClientSponsor mySponsor = new ClientSponsor();

         // Register the service with sponsor.
         mySponsor.Register(myService);

         // Set renewaltime.
         mySponsor.RenewalTime = TimeSpan.FromMinutes(2);

         // Renew the lease.
         ILease myLease = (ILease)mySponsor.InitializeLifetimeService();
         TimeSpan myTime = mySponsor.Renewal(myLease);
         Console.WriteLine("Renewed time in minutes is " + myTime.Minutes.ToString());

         // Call the remote method.
         Console.WriteLine(myService.HelloMethod("World"));

         // Unregister the channel.
         mySponsor.Unregister(myService);
         mySponsor.Close();
      }
   }
// </Snippet2>

}
// </Snippet1>
