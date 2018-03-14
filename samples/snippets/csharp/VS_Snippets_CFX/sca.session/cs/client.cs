// <snippet3>
using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading;

namespace Microsoft.WCF.Documentation
{
  public class Client : SampleDuplexHelloCallback
  {
    AutoResetEvent waitHandle;

    public Client()
    {
      waitHandle = new AutoResetEvent(false);
    }

    public void Run()
    {
      // Picks up configuration from the config file.
      SampleDuplexHelloClient wcfClient
        = new SampleDuplexHelloClient(new InstanceContext(this));
      try
      {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Enter a greeting to send and press ENTER: ");
        Console.Write(">>> ");
        Console.ForegroundColor = ConsoleColor.Green;
        string greeting = Console.ReadLine();
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Called service with: \r\n\t" + greeting);
        wcfClient.Hello(greeting);
        wcfClient.Hello("Second greeting.");
        Console.WriteLine("Execution passes service call and moves to the WaitHandle.");
        this.waitHandle.WaitOne();
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Set was called.");
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
        Console.ReadLine();
        wcfClient.Abort();
      }
      catch (CommunicationException commProblem)
      {
        Console.WriteLine("There was a communication problem. " + commProblem.Message);
        Console.ReadLine();
        wcfClient.Abort();
      }
    }
    public static void Main()
    {
      Client client = new Client();
      client.Run();
    }

    public void Reply(string response)
    {
      Console.WriteLine("Received output.");
      Console.WriteLine("\r\n\t" + response);
      if (response.Contains("Second greeting."))
        this.waitHandle.Set();
    }
  }
}
// </snippet3>
