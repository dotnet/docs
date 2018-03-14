//<Snippet1>
using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels.Tcp;

class SampleClass {
   public static void Main() {

      // Create a remotable object.
      TcpChannel tcpChannel = new TcpChannel(8085);

      WellKnownServiceTypeEntry WKSTE = 
         new WellKnownServiceTypeEntry(typeof(HelloService),
                                       "Service", 
                                       WellKnownObjectMode.Singleton);
      RemotingConfiguration.RegisterWellKnownServiceType(WKSTE);

      RemotingConfiguration.ApplicationName = "HelloServer";

      // Print out the urls for the HelloServer.
      string[] urls = tcpChannel.GetUrlsForUri("HelloServer");
      
      foreach (string url in urls)
         System.Console.WriteLine("{0}", url);
      
   }
}
//</Snippet1>
