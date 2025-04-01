// <snippet1>
using System;
using System.ServiceModel;
using System.ServiceModel.Channels;

// Define class that implements the callback interface of duplex
// contract.
public class CallbackHandler : ICalculatorDuplexCallback
{
  public void Result(double result)
  {
    Console.WriteLine($"Result({result})");
  }
  public void Equation(string equation)
  {
    Console.WriteLine($"Equation({equation})");
  }
}

public class Client
{
  public static void Main()
  {
    // Picks up configuration from the config file.

    CalculatorDuplexClient wcfClient
      = new CalculatorDuplexClient(new InstanceContext(new CallbackHandler()));
    try
    {
      // Call the AddTo service operation.
      double value = 100.00D;
      wcfClient.AddTo(value);

      // Call the SubtractFrom service operation.
      value = 50.00D;
      wcfClient.SubtractFrom(value);

      // Call the MultiplyBy service operation.
      value = 17.65D;
      wcfClient.MultiplyBy(value);

      // Call the DivideBy service operation.
      value = 2.00D;
      wcfClient.DivideBy(value);

      // Complete equation.
      wcfClient.Clear();

      // Wait for callback messages to complete before
      // closing.
      System.Threading.Thread.Sleep(5000);

      // Close the WCF client.
      wcfClient.Close();
      Console.WriteLine("Done!");
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
}
// </snippet1>
