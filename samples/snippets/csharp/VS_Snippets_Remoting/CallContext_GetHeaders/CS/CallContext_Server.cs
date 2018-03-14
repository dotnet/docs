using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

namespace RemotingSamples
{
   class HelloServer
   {
      static void Main()
      {
         TcpChannel myChannel = new TcpChannel (8082);
         ChannelServices.RegisterChannel(myChannel);
         RemotingConfiguration.RegisterActivatedServiceType(typeof(HelloService));
         Console.WriteLine("Server started.");
         Console.WriteLine("Hit enter to terminate...");
         Console.Read();
      }
   }
}
