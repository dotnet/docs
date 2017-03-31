//<snippet10>
using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

public class MyServer
{
    public static void Main()
    {
        ChannelServices.RegisterChannel(new TcpChannel(8082));
        RemotingConfiguration.RegisterActivatedServiceType(typeof(HelloServer));
        Console.WriteLine("Press enter to stop this process");
        Console.ReadLine();
   }
}
//</snippet10>
