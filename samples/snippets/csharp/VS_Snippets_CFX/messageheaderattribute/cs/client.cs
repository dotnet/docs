// <snippet6>
using System;
using System.ServiceModel;
using System.ServiceModel.Channels;

public class Client
{
  public static void Main()
  {
    // Picks up configuration from the config file.
    MessagingHelloClient wcfClient = new MessagingHelloClient();
    try
    {
      // Making calls.
      Console.WriteLine("Enter the greeting to send: ");
      string greeting = Console.ReadLine();
      HelloResponseMessage response = wcfClient.Hello(new HelloGreetingMessage(greeting));
      Console.WriteLine("The service responded: " + response.ResponseToGreeting);
      Console.WriteLine("and " + response.OutOfBandData);

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
// </snippet6>
