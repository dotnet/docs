/* The following program is the supporting program for demonstration of
   'System.Runtime.Remoting.Channels.SinkProviderData' class and its 
   properties 'Children', 'Name', 'Properties'.
*/
using System;
using System.Collections;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Security.Permissions;
using System.Threading;
using IPFilter;

public class Server
{
   [SecurityPermission(SecurityAction.Demand)]
   public static void Main()
   {
      RemotingConfiguration.Configure("channels.config");
      RemotingConfiguration.Configure("server.exe.config");        
      Console.WriteLine("Server Listening...");
      // Obtain filter interface.
      IDictionary myIDictionary = 
         ((HttpServerChannel)ChannelServices.GetChannel("MyHttpChannel")).Properties;       
      String keyState = "";
      while (String.Compare(keyState,"0", true) != 0)
      {
         Console.WriteLine("***** Press 0 to exit this service *****");
         keyState = Console.ReadLine();
      }
   }
}
