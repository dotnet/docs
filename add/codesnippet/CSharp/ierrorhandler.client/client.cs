// <snippet3>
using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using Microsoft.WCF.Documentation;

public class Client
{
  public static void Main()
  {
    // Picks up configuration from the configuration file.
    SampleServiceClient wcfClient = new SampleServiceClient();
    try
    {
      // Making calls.
      Console.WriteLine("Enter the greeting to send: ");
      string greeting = Console.ReadLine();
      Console.WriteLine("The service responded: " + wcfClient.SampleMethod(greeting));
      Console.WriteLine("Press ENTER to exit:");
      Console.ReadLine();
    }
    catch (TimeoutException timeProblem)
    {
      Console.WriteLine("The service operation timed out. " + timeProblem.Message);
      wcfClient.Abort();
      Console.ReadLine();
    }
    // Catch the contractually specified SOAP fault raised here as an exception.
    catch (FaultException<GreetingFault> greetingFault)
    {
      Console.WriteLine(greetingFault.Detail.Message);
      Console.Read();
      wcfClient.Abort();
    }
    // Catch unrecognized faults. This handler receives exceptions thrown by WCF
    // services when ServiceDebugBehavior.IncludeExceptionDetailInFaults 
    // is set to true.
    catch (FaultException faultEx)
    {
      Console.WriteLine("An unknown exception was received. " 
        + faultEx.Message
        + faultEx.StackTrace
      );
      Console.Read();
      wcfClient.Abort();
    }
    // Standard communication fault handler.
    catch (CommunicationException commProblem)
    {
      Console.WriteLine("There was a communication problem. " + commProblem.Message + commProblem.StackTrace);
      Console.Read();
      wcfClient.Abort();
    }
  }
}
// </snippet3>
