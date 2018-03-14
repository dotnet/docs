using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Remoting.Lifetime;

namespace SampleNamespace {
    public class SampleServer {
        public static void Main() {
            HttpChannel channel = new HttpChannel(9000);
            ChannelServices.RegisterChannel(channel);
            RemotingConfiguration.ApplicationName = "MySampleService";
            RemotingConfiguration.RegisterActivatedServiceType(typeof(SampleService));
            
            Console.WriteLine("Press enter to end the server process.");
            Console.ReadLine();
        }
    }
}

