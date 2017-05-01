using System;
using System.Net.Sockets;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Lifetime;
using SampleNamespace;

// The following sample uses an HttpChannel constructor
// to create a new HttpChannel.  
// NOTE: manually instantiating HttpChannel() and registering it does not seem
// necessary. This sample will work if the line of code is commented out.

// System.Runtime.Remoting.Channels.Http.HttpChannel.HttpChannel()
// <Snippet3>
public class SampleClient : MarshalByRefObject {
    public static void Main() {

        ChannelServices.RegisterChannel(new HttpChannel());

        RemotingConfiguration.RegisterWellKnownClientType
            (typeof(SampleService), "http://localhost:9000/MySampleService/SampleService.soap");

        SampleService service = new SampleService();

        service.SampleMethod();
    }
}
// </Snippet3>

