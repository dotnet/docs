using System;
using System.IO;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using Share;

public class MyServiceClass
{
   public static void Main()
   {
      HttpChannel myHttpChannel = new HttpChannel(8082);
      ChannelServices.RegisterChannel(myHttpChannel);
      RemotingConfiguration.RegisterActivatedServiceType(typeof(MyHelloService));
      Console.WriteLine("Press Enter to Exit the Server");
      Console.ReadLine();
   }
}