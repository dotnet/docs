using System;
using System.ServiceModel;

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
}
