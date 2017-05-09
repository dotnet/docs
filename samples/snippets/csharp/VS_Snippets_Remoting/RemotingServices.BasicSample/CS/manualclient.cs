using System;
using System.Net.Sockets;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using SampleNamespace;
// Note: this snippet is based on v-ralphs' Dynamic Remoting sample.

public class ManualClient {
    public static void Main() {
        // System.Runtime.Remoting.RemotingServices.Disconnect() -- ManualServer.cs has a snippet for Disconnect, too.
        // <Snippet3>
        WellKnownClientTypeEntry remoteType = new WellKnownClientTypeEntry(typeof(SampleWellKnown), "tcp://localhost:9000/objectWellKnownUri");
        RemotingConfiguration.RegisterWellKnownClientType(remoteType);

        SampleWellKnown objectWellKnown = new SampleWellKnown();

        try {
            objectWellKnown.Add(2, 3);
            Console.WriteLine("The add method on SampleWellKnown was successfully called.");
        }
        catch(SocketException) {
            Console.WriteLine("The server is not available.  Is it still running?");
        }
        catch(RemotingException) {
            Console.WriteLine("SampleWellKnown is currently not available.  The server probably called Disconnect().");
        }
        // </Snippet3>
    }
}
