using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

public class ClientProcess{
	public static void Main(){
        ChannelServices.RegisterChannel(new TcpChannel());
        WellKnownClientTypeEntry remoteType = new WellKnownClientTypeEntry(typeof(SampleService),"tcp://localhost:9000/SampleServiceUri");
	    RemotingConfiguration.RegisterWellKnownClientType(remoteType);

        SampleService service = new SampleService();
        Console.WriteLine("Connected to SampleService");
        bool returnValue = service.UpdateServer(3, 3.14, "Pi");
	}
}



