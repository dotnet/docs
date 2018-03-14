using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Web.Services.Description;
using System.Xml;

namespace Microsoft.WCF.Documentation
{
  class Client
  {
    StatefulServiceClient wcfClient = null;

    void Run()
    {
      // Picks up configuration from the config file.
      this.wcfClient = new StatefulServiceClient();
      try
      {
        //<snippet10>
        // Download all metadata. 
        ServiceEndpointCollection endpoints
          = MetadataResolver.Resolve(
            typeof(IStatefulService),
            new EndpointAddress("http://localhost:8080/StatefulService/mex")
          );
        //</snippet10>

        Console.WriteLine("Calling 5 times: ");

        for (int i = 0; i < 5; i++)
        {
          string response = this.wcfClient.GetSessionID();
          Console.WriteLine(response);
        }
        Console.WriteLine("Press ENTER to exit...");
        Console.ReadLine();
      }
      catch (TimeoutException timeProblem)
      {
        Console.WriteLine("The service operation timed out. " + timeProblem.Message);
      }
      catch (CommunicationException commProblem)
      {
        Console.WriteLine("There was a communication problem. " + commProblem.Message);
      }
      finally
      {
        if (wcfClient.State != CommunicationState.Closed)
          wcfClient.Close();
      }
    }

    static void Main(string[] args)
    {
      Client client = new Client();
      client.Run();
    }
  }
}
