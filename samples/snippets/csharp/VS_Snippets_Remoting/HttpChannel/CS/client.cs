using System;
using System.Net.Sockets;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Lifetime;
using System.Security.Permissions;
using SampleNamespace;

// The following sample uses an HttpChannel constructor
// to create a new HttpChannel, allowing this client to
// hook up to an event on a server object.
// System.Runtime.Remoting.Channels.Http.HttpChannel.HttpChannel(int)
// <Snippet2>
public class SampleClient : MarshalByRefObject {

    public static void Main() {
        SampleClient client = new SampleClient();
    }

    [PermissionSet(SecurityAction.LinkDemand)]
    public SampleClient() {

        ChannelServices.RegisterChannel(new HttpChannel(0));

        SampleService service = (SampleService)Activator.GetObject(typeof(SampleService), 
            "http://localhost:9000/MySampleService/SampleService.soap");

        // Subscribe to event so that the client can receive notification from ther server.
        SomethingHappenedEventHandler eventHandler = new SomethingHappenedEventHandler(OnSomethingHappened);

        service.SomethingHappened += eventHandler;

        // The server will fire the SomethingHappened event in SampleMethod()
        service.SampleMethod();
        service.SomethingHappened -= eventHandler;
    }

    private void OnSomethingHappened (object source, SampleServiceEventArgs e) {
        Console.WriteLine("SomethingHappened event fired: {0}", e.Message);
    }
    
}
// </Snippet2>

