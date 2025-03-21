using System;
using System.Configuration;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;

using microsoft.wcf.documentation;

namespace Microsoft.WCF.Documentation
{
  class HostApplication
  {

    static void Main()
    {
      HostApplication app = new HostApplication();
      app.Run();
    }

    private void Run()
    {
      // Create a ServiceHost for the service type and use the base address from configuration.
      using (ServiceHost serviceHost = new ServiceHost(typeof(SampleService)))
      {
        try
        {
          // Open the ServiceHostBase to create listeners and start listening for messages.
          serviceHost.Open();

          // The service can now be accessed.
          Console.WriteLine("The service is ready.");
          Console.WriteLine("Press <ENTER> to terminate service.");
          Console.WriteLine();
          Console.ReadLine();

          // Close the ServiceHostBase to shutdown the service.
          serviceHost.Close();
        }
        catch (TimeoutException timeProblem)
        {
          Console.WriteLine("The service operation timed out. " + timeProblem.Message);
          Console.Read();
        }
        catch (CommunicationException commProblem)
        {
          Console.WriteLine("There was a communication problem. " + commProblem.Message);
          Console.Read();
        }
      }
    }
  }
  // <snippet5>
  // Implement the service. This is a very simple service.
  class SampleService : ISampleService
  {
    public string SampleMethod(string msg)
    {
      Console.WriteLine($"The caller said: \"{msg}\"");
      return "The service greets you: " + msg;
    }
  }
  // </snippet5>
}
