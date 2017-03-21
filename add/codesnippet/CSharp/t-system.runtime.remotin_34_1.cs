using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Lifetime;
namespace RemotingSamples
{

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

}