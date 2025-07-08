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
    try
    {
      // Picks up configuration from the config file.
      ChannelFactory<ISampleServiceChannel> factory
        = new ChannelFactory<ISampleServiceChannel>("WSHttpBinding_ISampleService");

      // Add the client side behavior programmatically to all created channels.
      factory.Endpoint.Behaviors.Add(new EndpointBehaviorMessageInspector());

      ISampleServiceChannel wcfClientChannel = factory.CreateChannel();

      // Making calls.
      Console.WriteLine("Enter the greeting to send: ");
      string greeting = Console.ReadLine();
      Console.WriteLine("The service responded: " + wcfClientChannel.SampleMethod(greeting));

      Console.WriteLine("Press ENTER to exit:");
      Console.ReadLine();

      // Done with service.
      wcfClientChannel.Close();
      Console.WriteLine("Done!");
    }
    catch (TimeoutException timeProblem)
    {
      Console.WriteLine("The service operation timed out. " + timeProblem.Message);
      Console.Read();
    }
    catch (FaultException<SampleFault> fault)
    {
      Console.WriteLine($"SampleFault fault occurred: {fault.Detail.FaultMessage}");
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
