// System.Runtime.Remoting.RemotingServices.GetLifetimeService
// This sample is of a remote client for a group coffee timer.
// Since the client must stay connected to a stateful server object
// for minutes without calling it, it needs to register as a sponsor
// of the lease to prevent the server from being collected.
// Multiple clients can connect to the same timer object, and receive
// notification when the timer expires.
// System.Runtime.Remoting.RemotingServices.GetLifetimeService
// <Snippet1>
using System;
using System.Collections;
using System.Net.Sockets;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Lifetime;
using System.Security.Permissions;
using TimerSample;

namespace GroupCoffeeTimer {
    public class TimerClient : MarshalByRefObject, ISponsor {
        public static void Main() {
            TimerClient myClient = new TimerClient();
        }

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.Infrastructure)]
        public TimerClient() {
            // Registers the HTTP Channel so that this client can receive
            // events from the remote service.

            BinaryServerFormatterSinkProvider serverProv = new BinaryServerFormatterSinkProvider();
            serverProv.TypeFilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Full;
            BinaryClientFormatterSinkProvider clientProv = new BinaryClientFormatterSinkProvider();

            IDictionary props = new Hashtable();
            props["port"] = 0;
            HttpChannel channel = new HttpChannel(props, clientProv, serverProv);
            ChannelServices.RegisterChannel(channel);

            WellKnownClientTypeEntry remoteType = new WellKnownClientTypeEntry(typeof(TimerService), "http://localhost:9000/MyService/TimerService.soap");
            RemotingConfiguration.RegisterWellKnownClientType(remoteType);
            
            TimerService groupTimer = new TimerService();
            groupTimer.MinutesToTime = 4.0; 

            // Registers this client as a lease sponsor so that it can
            // prevent the expiration of the TimerService.
            ILease leaseObject = (ILease)RemotingServices.GetLifetimeService(groupTimer);
            leaseObject.Register(this);
            
            // Subscribes to the event so that the client can receive notifications from the server.
            groupTimer.TimerExpired += new TimerExpiredEventHandler(OnTimerExpired);
            Console.WriteLine("Connected to TimerExpired event");
            
            groupTimer.Start();
            Console.WriteLine("Timer started for {0} minutes.", groupTimer.MinutesToTime);
            Console.WriteLine("Press enter to end the client process.");
            Console.ReadLine();
        }
        
        private void OnTimerExpired (object source, TimerServiceEventArgs e) {
            Console.WriteLine("TimerHelper.OnTimerExpired: {0}", e.Message);
        }

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.Infrastructure)]
        public TimeSpan Renewal(ILease lease) {
            Console.WriteLine("TimerClient: Renewal called.");
            return TimeSpan.FromMinutes(0.5);
        }
    }
}
// </Snippet1>
