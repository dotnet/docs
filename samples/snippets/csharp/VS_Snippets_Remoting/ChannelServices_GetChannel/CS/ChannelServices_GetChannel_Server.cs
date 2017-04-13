/*
   This program registers the remote object.
 */ 
using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Collections.Specialized; 
namespace RemotingSamples 
{
   public class MyChannelServices_Server
   {
      public static void Main()
      {
         ListDictionary properties = new ListDictionary();
         properties.Add("port",8086);
         HttpChannel myServerChannel = new HttpChannel(properties,
            new SoapClientFormatterSinkProvider(),
            new SoapServerFormatterSinkProvider());
         ChannelServices.RegisterChannel(myServerChannel);
         RemotingConfiguration.RegisterWellKnownServiceType(Type.GetType(
            "RemotingSamples.HelloServer,ChannelServices_GetChannel_Share"),
            "SayHello", WellKnownObjectMode.Singleton);
         System.Console.WriteLine("Hit <enter> to exit...");
         System.Console.ReadLine();
      }
   }
}

  