using System;
using System.Diagnostics;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Contexts;

public class ServerProcess{
	public static void Main(string[] args){
	    TcpChannel channel;
	    bool isReplicationServer = false;
        // Determine if this should be the replication server
        if ((args.Length > 0) && (args[0].ToLower() == "r")) {
            isReplicationServer = true;
            channel = new TcpChannel(9001);
        }
        else {
            channel = new TcpChannel(9000);
        }
        ChannelServices.RegisterChannel(channel);
        WellKnownServiceTypeEntry entry = new WellKnownServiceTypeEntry(typeof(SampleService),
            "SampleServiceUri", WellKnownObjectMode.Singleton);
	    RemotingConfiguration.RegisterWellKnownServiceType(entry);
	    if (!isReplicationServer) {
            ReplicationSinkProp myProp = new ReplicationSinkProp();
            Context.RegisterDynamicProperty(myProp, null, null);
	    }
        Console.WriteLine("**** Press enter to stop this process. ****\n");
		Console.ReadLine();
	}
}



