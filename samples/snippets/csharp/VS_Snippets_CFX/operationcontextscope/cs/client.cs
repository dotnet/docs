// <snippet3>
using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading;

public class Client : ISampleServiceCallback
{
  ManualResetEvent wait = null;

  Client()
  {
    this.wait = new ManualResetEvent(false);
  }

  public static void Main()
  {
    Client client = new Client();
    client.Run();
  }

  void Run()
  {
    // Picks up configuration from the config file.
    // <snippet4>
    SampleServiceClient wcfClient = new SampleServiceClient(new InstanceContext(this));
    try
    {
      using (OperationContextScope scope = new OperationContextScope(wcfClient.InnerChannel))
      {
        MessageHeader header
          = MessageHeader.CreateHeader(
          "Service-Bound-CustomHeader",
          "http://Microsoft.WCF.Documentation",
          "Custom Happy Value."
          );
        OperationContext.Current.OutgoingMessageHeaders.Add(header);

        // Making calls.
        Console.WriteLine("Enter the greeting to send: ");
        string greeting = Console.ReadLine();

        //Console.ReadLine();
        header = MessageHeader.CreateHeader(
            "Service-Bound-OneWayHeader",
            "http://Microsoft.WCF.Documentation",
            "Different Happy Value."
          );
        OperationContext.Current.OutgoingMessageHeaders.Add(header);

        // One-way
        wcfClient.Push(greeting);
        this.wait.WaitOne();

        // Done with service.
        wcfClient.Close();
        Console.WriteLine("Done!");
        Console.ReadLine();
      }
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
    // </snippet4>
  }

  // <snippet5>

  #region ISampleServiceCallback Members

  public void PushBack(string msg)
  {
    Console.WriteLine("Service said: " + msg);
    this.WriteHeaders(OperationContext.Current.IncomingMessageHeaders);
    this.wait.Set();
  }

  void WriteHeaders(MessageHeaders headers)
  {
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("IncomingHeader:");
    Console.ForegroundColor = ConsoleColor.Blue;
    foreach (MessageHeaderInfo h in headers)
    {
      if (!h.Actor.Equals(String.Empty))
        Console.WriteLine("\t" + h.Actor);
      Console.ForegroundColor = ConsoleColor.White;
      Console.WriteLine("\t" + h.Name);
      Console.ForegroundColor = ConsoleColor.Blue;
      Console.WriteLine("\t" + h.Namespace);
      Console.WriteLine("\t" + h.Relay);
      if (h.IsReferenceParameter == true)
      {
        Console.WriteLine("IsReferenceParameter header detected: " + h.ToString());
      }
    }
    Console.ResetColor();
  }
  #endregion
  // </snippet5>
}
// </snippet3>
