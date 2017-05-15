using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

  public class Sample {

    public static void Main()
    {
      ChannelServices.RegisterChannel( new TcpChannel(8085));
      RemotingConfiguration.RegisterWellKnownServiceType(typeof(MyServerImpl),
                     "SayHello", WellKnownObjectMode.Singleton);
      Console.WriteLine("Press <enter> to exit...");
      Console.ReadLine();
    }
  }

