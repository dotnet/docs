// <snippet3>
using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Security.Principal;
using System.Threading;

namespace Microsoft.WCF.Documentation
{
  public class Client
  {
    public void Run()
    {
      // Picks up configuration from the config file.
      SampleHelloClient wcfClient = new SampleHelloClient();
      try
      {
        // Set the client credentials to permit impersonation. You can do this programmatically or in the configuration file.
        wcfClient.ClientCredentials.Windows.AllowedImpersonationLevel = TokenImpersonationLevel.Impersonation;

        // Make calls using the proxy.
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Enter a greeting to send and press ENTER: ");
        Console.Write(">>> ");
        Console.ForegroundColor = ConsoleColor.Green;
        string greeting = Console.ReadLine();
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Called service with: \r\n\t" + greeting);
        Console.WriteLine("Service returned: " + wcfClient.Hello(greeting));
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write("Press ");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("ENTER");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write(" to exit...");
        Console.ReadLine();
        wcfClient.Close();
      }
      catch (TimeoutException timeProblem)
      {
        Console.WriteLine("The service operation timed out. " + timeProblem.Message);
        wcfClient.Abort();
        Console.Read();
      }
      catch (CommunicationException commProblem)
      {
        Console.WriteLine("There was a communication problem. " + commProblem.Message);
        wcfClient.Abort();
        Console.Read();
      }
    }
    public static void Main()
    {
      Client client = new Client();
      client.Run();
    }
  }
}
// </snippet3>
