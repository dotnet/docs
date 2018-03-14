using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Remoting.Lifetime;
using SampleNamespace;

// This assembly contains a remote service and its server host wrapped together.
public class SampleServer {
    public static void Main() {

        // The following sample uses an HttpChannel constructor
        // to create a new HttpChannel that will listen on port 9000.
        // System.Runtime.Remoting.Channels.Http.HttpChannel.HttpChannel(int)
        // System.Runtime.Remoting.Channels.Http.HttpChannel
        // <Snippet1>
        HttpChannel channel = new HttpChannel(9000);
        ChannelServices.RegisterChannel(channel);

        RemotingConfiguration.RegisterWellKnownServiceType( typeof(SampleService), 
		"MySampleService/SampleService.soap", WellKnownObjectMode.Singleton);
        
        Console.WriteLine("** Press enter to end the server process. **");
        Console.ReadLine();
        // </Snippet1>
    }
}
