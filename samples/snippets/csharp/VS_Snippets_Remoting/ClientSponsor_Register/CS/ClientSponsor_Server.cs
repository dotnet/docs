using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Lifetime;


namespace RemotingSamples
{
   class HelloServer
   {
      static void Main()
      {
        
         RemotingConfiguration.Configure("Server.config");
         Console.WriteLine("Server started.");
         Console.WriteLine("Hit enter to terminate...");
         Console.Read();
      }
   }
}
