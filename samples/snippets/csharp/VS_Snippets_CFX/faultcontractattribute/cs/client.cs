// <snippet3>
using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using Microsoft.WCF.Documentation;

public class Client
{
  public static void Main()
  {
    // Picks up configuration from the config file.
    SampleServiceClient wcfClient = new SampleServiceClient();
    try
    {
      // Making calls.
      Console.WriteLine("Enter the greeting to send: ");
      string greeting = Console.ReadLine();
      Console.WriteLine("The service responded: " + wcfClient.SampleMethod(greeting));

      Console.WriteLine("Press ENTER to exit:");
      Console.ReadLine();

      // Done with service. 
      wcfClient.Close();
      Console.WriteLine("Done!");
    }
    catch (TimeoutException timeProblem)
    {
      Console.WriteLine("The service operation timed out. " + timeProblem.Message);
      Console.ReadLine();
      wcfClient.Abort();
    }
    catch (FaultException<GreetingFault> greetingFault)
    {
      Console.WriteLine(greetingFault.Detail.Message);
      Console.ReadLine();
      wcfClient.Abort();
    }
    catch (FaultException unknownFault)
    {
      Console.WriteLine("An unknown exception was received. " + unknownFault.Message);
      Console.ReadLine();
      wcfClient.Abort();
    }
    catch (CommunicationException commProblem)
    {
      Console.WriteLine("There was a communication problem. " + commProblem.Message + commProblem.StackTrace);
      Console.ReadLine();
      wcfClient.Abort();
    }
  }
}
// </snippet3>
