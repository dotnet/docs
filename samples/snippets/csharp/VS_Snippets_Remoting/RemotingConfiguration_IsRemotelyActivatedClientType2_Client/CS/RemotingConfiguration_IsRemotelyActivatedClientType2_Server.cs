using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

public class ServerClass
{
   static void Main()
   {
      ChannelServices.RegisterChannel(new TcpChannel(8085), false);
      RemotingConfiguration.RegisterActivatedServiceType(typeof(MyServerImpl));
      Console.WriteLine("Press enter to stop this process.");
      Console.ReadLine();
   }
}
