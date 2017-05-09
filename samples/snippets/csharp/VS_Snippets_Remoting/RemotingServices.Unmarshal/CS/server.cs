using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Remoting.Lifetime;

namespace SampleNamespace {
    public class SampleServer {
        public static void Main() {
            // System.Runtime.Remoting.RemotingServices.SetObjectUriForMarshal
            // <Snippet1>
            RemotingConfiguration.ApplicationName = "MySampleService";
            HttpChannel channel = new HttpChannel(9000);
            ChannelServices.RegisterChannel(channel);
            SampleService objectService = new SampleService();
            RemotingServices.SetObjectUriForMarshal(objectService, "SampleService.soap");
            ObjRef objRefService = RemotingServices.Marshal(objectService);
            
            Console.WriteLine("Press enter to end the server process.");
            Console.ReadLine();
            // </Snippet1>
        }
    }
}

