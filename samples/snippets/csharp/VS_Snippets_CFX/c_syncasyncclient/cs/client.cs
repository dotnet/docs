// <snippet5>
using System;
using System.ServiceModel;

public class Client
{

  void Run()
  {
    // Picks up configuration from the config file.
    using (SampleServiceClient wcfClient = new SampleServiceClient())
    {
      try
      {
        // Make asynchronous call.
        Console.WriteLine("Enter the greeting to send asynchronously: ");
        string greeting = Console.ReadLine();
        IAsyncResult waitResult = wcfClient.BeginSampleMethod(greeting, new AsyncCallback(ProcessResponse), wcfClient);
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Sent asynchronous method. Waiting on the response.");
        waitResult.AsyncWaitHandle.WaitOne();
        Console.ResetColor();

        // Make synchronous call.
        Console.WriteLine("Enter the greeting to send synchronously: ");
        greeting = Console.ReadLine();
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write("Response: ");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(wcfClient.SampleMethod(greeting));
        Console.ResetColor();

        // Make synchronous call on asynchronous method.
        Console.WriteLine("Enter the greeting to send synchronously to async service operation: ");
        greeting = Console.ReadLine();
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write("Response: ");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(wcfClient.ServiceAsyncMethod(greeting));
        Console.ResetColor();

        Console.WriteLine("Press ENTER to exit:");
        Console.ReadLine();

        // Done with service.
        wcfClient.Close();
        Console.WriteLine("Done!");
      }
      catch (TimeoutException timeProblem)
      {
        Console.WriteLine("The service operation timed out. " + timeProblem.Message);
        Console.Read();
        wcfClient.Abort();
      }
      catch (CommunicationException commProblem)
      {
        Console.WriteLine("There was a communication problem. " + commProblem.Message);
        Console.Read();
        wcfClient.Abort();
      }
    }
  }

  private void ProcessResponse(IAsyncResult result)
  {
    try
    {
      Console.ForegroundColor = ConsoleColor.Blue;
      Console.WriteLine("In the async response handler.");
      SampleServiceClient responseClient = (SampleServiceClient)(result.AsyncState);
      string response = responseClient.EndSampleMethod(result);
      Console.Write("ProcessResponse: ");
      Console.ForegroundColor = ConsoleColor.Red;
      Console.WriteLine(response);
      Console.ResetColor();
    }
    catch (TimeoutException timeProblem)
    {
      Console.WriteLine("The service operation timed out. " + timeProblem.Message);
    }
    catch (CommunicationException commProblem)
    {
      Console.WriteLine("There was a communication problem. " + commProblem.Message);
    }
    catch (Exception e)
    {
      Console.WriteLine("There was an exception: " + e.Message);
    }
  }

  public static void Main()
  {
    Client thisClient = new Client();
    thisClient.Run();
  }
}
// </snippet5>
