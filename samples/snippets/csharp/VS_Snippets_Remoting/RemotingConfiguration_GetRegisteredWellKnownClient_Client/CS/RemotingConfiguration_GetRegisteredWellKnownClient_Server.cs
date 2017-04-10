using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

namespace RemotingSamples 
{
   public class Sample
   {
      public static void Main()
      {
         TcpChannel chan = new TcpChannel(8085);
         ChannelServices.RegisterChannel(chan);
         RemotingConfiguration.RegisterWellKnownServiceType(
           typeof(MyServerImpl),"SayHello", WellKnownObjectMode.Singleton);
         Console.WriteLine("Press <enter> to exit...");
         Console.ReadLine();
      }
   }
}

