// <snippet3>
using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
 
public class Client
{
  public static void Main()
  {
    // Picks up configuration from the config file.
    HelloWorldClient wcfClient = new HelloWorldClient();
    try
    {
      // Making calls.
      Console.WriteLine("Enter the greeting to send: ");
      string greeting = Console.ReadLine();
      Console.WriteLine("The service responded: " + wcfClient.SampleMethod(greeting));

      // Done with service. 
      wcfClient.Close();
      Console.WriteLine("Done!");
    }
    catch (TimeoutException timeProblem)
    {
      Console.WriteLine("The service operation timed out. " + timeProblem.Message);
      wcfClient.Abort();
    }
    catch (CommunicationException commProblem)
    {
      Console.WriteLine("There was a communication problem. " + commProblem.Message);
      wcfClient.Abort();
    }
    finally
    {
      Console.WriteLine("Press ENTER to exit:");
      Console.ReadLine();
    }
  }
}
// </snippet3>
