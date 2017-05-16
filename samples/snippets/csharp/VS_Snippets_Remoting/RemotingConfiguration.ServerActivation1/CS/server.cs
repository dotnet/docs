// <Snippet1>
using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

public class ServerClass {

    public static void Main()  {

// </Snippet1>
// <Snippet2>
        ChannelServices.RegisterChannel(new TcpChannel(8082));

        RemotingConfiguration.ApplicationName = "HelloServiceApplication";

        RemotingConfiguration.RegisterWellKnownServiceType( typeof(HelloService),
                                                            "MyUri",
                                                            WellKnownObjectMode.SingleCall 
                                                          );
// </Snippet2>
// <Snippet3>

        Console.WriteLine("Press enter to stop this process.");
        Console.ReadLine();
    }
}
// </Snippet3>