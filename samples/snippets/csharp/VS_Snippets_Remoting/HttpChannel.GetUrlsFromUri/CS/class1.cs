//<Snippet1>
using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels.Http;

class Class1 {
   public static void Main() {

      // Create a remotable object.
      HttpChannel httpChannel = new HttpChannel(8085);

      WellKnownServiceTypeEntry WKSTE = 
         new WellKnownServiceTypeEntry(typeof(HelloService),
                                       "Service", 
                                       WellKnownObjectMode.Singleton);
      RemotingConfiguration.RegisterWellKnownServiceType(WKSTE);

      RemotingConfiguration.ApplicationName = "HelloServer";

      // Print out the urls for HelloServer.
      string[] urls = httpChannel.GetUrlsForUri("HelloServer");
      
      foreach (string url in urls)
         System.Console.WriteLine("{0}", url);
      
   }
}

public class HelloService : MarshalByRefObject{

}
//</Snippet1>
