// <Snippet5>
using System;
using System.Runtime.Remoting;

public class Server
{
   public static void Main()
   {
      RemotingConfiguration.Configure("ISponsor_Server.config");

      Console.WriteLine("The server is listening. Press Enter to exit....");
      Console.ReadLine();

      Console.WriteLine("Garbage Collecting.");
      GC.Collect();
      GC.WaitForPendingFinalizers();
   }
}
// </Snippet5>
