// <Snippet2>
using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

public class ServerClass {

    public static void Main()  {

        ChannelServices.RegisterChannel(new TcpChannel(8082));

        RemotingConfiguration.RegisterActivatedServiceType(typeof(HelloServiceClass));

        Console.WriteLine("Press enter to stop this process.");
        Console.ReadLine();
    }
}
// </Snippet2>