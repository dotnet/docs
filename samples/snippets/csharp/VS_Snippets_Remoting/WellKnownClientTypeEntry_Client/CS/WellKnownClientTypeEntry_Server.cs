// This is the server program for the 'WellKnownClientTypeEntry_Client.cs' program.

using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;

public class MyServer 
{
   public static void Main() 
   {
      ChannelServices.RegisterChannel(new HttpChannel(8086));
      // Record the 'HelloServer' type as 'Singleton' well-known type.
      WellKnownServiceTypeEntry myWellKnownServiceTypeEntry= 
          new WellKnownServiceTypeEntry(typeof(HelloServer),
                                        "SayHello",
                                        WellKnownObjectMode.Singleton);
      RemotingConfiguration.RegisterWellKnownServiceType(
                                          myWellKnownServiceTypeEntry);
      Console.WriteLine("Started the Server, Hit <enter> to exit...");
      Console.ReadLine();
   }
}

