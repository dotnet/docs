/* The following program is the supporting program for demonstration of
   'System.Runtime.Remoting.Channels.SinkProviderData' class and its
   properties 'Children', 'Name', 'Properties'.
*/

using System;
using System.Runtime.Remoting;

public class SinkProviderData_Client
{
   public static void Main()
   {
      RemotingConfiguration.Configure("channels.config");
      RemotingConfiguration.Configure("client.exe.config");
      mySharedStringClass server = new mySharedStringClass();
      Console.WriteLine(server.PrintString("Welcome to .NET!."));
   }
}