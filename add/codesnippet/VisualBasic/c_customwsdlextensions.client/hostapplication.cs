using System;
using System.Configuration;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;

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
      // Create a ServiceHost for the service type and use base address in the configuration file.
      using (ServiceHost serviceHost = new ServiceHost(typeof(Fibonacci)))
      {
        try
        {
          foreach (ServiceEndpoint ep in serviceHost.Description.Endpoints)
          {
            foreach (OperationDescription op in ep.Contract.Operations)
            {
              if (op.Behaviors.Find<DataContractSerializerOperationBehavior>() == null)
              { 
                DataContractSerializerOperationBehavior dcserBehave = new DataContractSerializerOperationBehavior(op);
                dcserBehave.DataContractSurrogate = new DCAnnotationSurrogate();
                op.Behaviors.Add(dcserBehave);
              }
            }
          }

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
}
