// System.Runtime.Remoting.RemotingServices.GetLifetimeService
// This sample is of a remote client for a group coffee timer.
// Since the client must stay connected to a stateful server object
// for minutes without calling it, it needs to register as a sponsor
// of the lease to prevent the server from being collected.
// Multiple clients can connect to the same timer object, and receive
// notification when the timer expires.
using System;
using System.Net.Sockets;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Lifetime;
using System.Security.Permissions;
using SampleNamespace;

public class SampleClient : MarshalByRefObject {
    [SecurityPermission(SecurityAction.LinkDemand)]
    public static void Main() {
        // System.Runtime.Remoting.RemotingServices.Unmarshal
        // <Snippet2>
        ChannelServices.RegisterChannel(new HttpChannel());

        SampleService objectSample = (SampleService)Activator.GetObject(typeof(SampleService), 
            "http://localhost:9000/MySampleService/SampleService.soap");

        // The GetManuallyMarshaledObject() method uses RemotingServices.Marshal()
        // to create an ObjRef object for a SampleTwo object.
        ObjRef objRefSampleTwo = objectSample.GetManuallyMarshaledObject();

        SampleTwo objectSampleTwo = (SampleTwo)RemotingServices.Unmarshal(objRefSampleTwo);

        objectSampleTwo.PrintMessage("ObjRef successfuly unmarshaled."); 
        // </Snippet2>
    }
}
