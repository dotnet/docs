// This is the client program for the 'WellKnownServiceTypeEntry_Server.cs' program.

using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;

public class MyClient 
{
   public static void Main()
   {
      ChannelServices.RegisterChannel(new HttpChannel());
      Console.WriteLine(" Start calling from Client One.......");
      WellKnownClientTypeEntry myWellKnownClientTypeEntry = 
                     new WellKnownClientTypeEntry(typeof(HelloServer),
                                     "http://localhost:8086/SayHello");
      myWellKnownClientTypeEntry.ApplicationUrl="http://localhost:8086/SayHello";
      RemotingConfiguration.RegisterWellKnownClientType(myWellKnownClientTypeEntry);
      HelloServer myHelloServerObject = new HelloServer();
      for (int i = 0; i < 5; i++) 
         Console.WriteLine(myHelloServerObject.HelloMethod(" Client One"));
   }
}
