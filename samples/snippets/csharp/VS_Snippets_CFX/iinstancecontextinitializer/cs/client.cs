using System;
using System.ServiceModel;
using System.ServiceModel.Channels;

using microsoft.wcf.documentation;

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
      wcfClient.Open();
      Console.WriteLine("The service responded: " + wcfClient.SampleMethod(greeting));
      Console.WriteLine("The service responded: " + wcfClient.SampleMethod(greeting));
      Console.WriteLine("The service responded: " + wcfClient.SampleMethod(greeting));
      // Done with service.
      wcfClient.Close();
      Console.WriteLine("Done!");

      SampleServiceClient newclient = new SampleServiceClient();
      newclient.Open();
      Console.WriteLine("The service responded: " + newclient.SampleMethod(greeting));
      Console.WriteLine("The service responded: " + newclient.SampleMethod(greeting));
      Console.WriteLine("Press ENTER to exit:");
      Console.ReadLine();

      // Done with service.
      newclient.Close();

      ChannelFactory<ISampleServiceChannel> chFactory = new ChannelFactory<ISampleServiceChannel>("WSHttpBinding_ISampleService");
      ISampleServiceChannel clientChannel = chFactory.CreateChannel();
      clientChannel.Open();
      Console.Read();
      clientChannel.SampleMethod(greeting);
      clientChannel.SampleMethod(greeting);
      clientChannel.SampleMethod(greeting);
      clientChannel.Close();

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
}
