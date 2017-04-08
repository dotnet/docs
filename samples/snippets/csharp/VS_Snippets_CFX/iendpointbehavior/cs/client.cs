using System;
using System.ServiceModel;
using System.ServiceModel.Channels;

using microsoft.wcf.documentation;
// for the client behavior
using Microsoft.WCF.Documentation;
 
// <snippet10>
public class Client
{
  public static void Main()
  {
    // Picks up configuration from the config file.
    SampleServiceClient wcfClient = new SampleServiceClient();
    try
    {
      // Add the client side behavior programmatically.
      wcfClient.Endpoint.Behaviors.Add(new EndpointBehaviorMessageInspector());

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
      Console.Read();
    }
    catch (FaultException<SampleFault> fault)
    {
      Console.WriteLine("SampleFault fault occurred: {0}", fault.Detail.FaultMessage);
      Console.Read();
    }
    catch (CommunicationException commProblem)
    {
      Console.WriteLine("There was a communication problem. " + commProblem.Message);
      Console.Read();
    }
  }
  // </snippet10>
}
