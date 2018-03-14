// snippet code for ServiceMetadataBehavior
// This code does not work, all snippet code is generic
// Most members are obsolete.
// a-arhu 8/15/06
// Fixed for code: rasquill 9/19/2006

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


    private void SnippetEnableHelpPage()
    {
        // see C_HowToSecureEndpoint\cs
        //<snippet1>
        // Create a new metadata behavior object and set its properties to 
        // create a secure endpoint. 
        ServiceMetadataBehavior sb = new ServiceMetadataBehavior();
        //sb.EnableHelpPage= true;
        //sb.HttpsGetUrl = new Uri("https://myMachineName:8036/myEndpoint");
        //myServiceHost.Description.Behaviors.Add(sb);
            

    }

      private void SnippetServiceMetadataBehavior()
      {
          // service for which <<indigo2>> automatically adds a 
          // ServiceMetadataBehavior to publish metadata as well as 
          // an HTML service help page

          // from C_HowToSecureEndpoint\cs
          // Create a new metadata behavior object and set its properties to 
          // create a secure endpoint. 
          ServiceMetadataBehavior sb = new ServiceMetadataBehavior();
/*          sb.EnableHelpPage = true;
          sb.enableMetadataExchange = true;
          sb.HttpsGetUrl = new Uri("https://myMachineName:8036/myEndpoint");
          myServiceHost.Description.Behaviors.Add(sb);
 */


      }

    private void Run()
    {

      // T:System.ServiceModel.ServiceMetadataBehavior
      // <Snippet#0>

      // Create a ServiceHost for the service type and use the base address from configuration.
      ServiceHost host = new ServiceHost(typeof(SampleService));
      try
      {
        // <snippet10>
        ServiceMetadataBehavior metad 
          = host.Description.Behaviors.Find<ServiceMetadataBehavior>();
        if (metad == null)
          metad = new ServiceMetadataBehavior();
        metad.HttpGetEnabled = true;
        host.Description.Behaviors.Add(metad);
        host.AddServiceEndpoint(
          ServiceMetadataBehavior.MexContractName, 
          MetadataExchangeBindings.CreateMexHttpBinding(), 
          "mex"
        );
        // </snippet10>

        // The service can now be accessed.
        Console.WriteLine("The service is ready.");
        Console.WriteLine("Press <ENTER> to terminate service.");
        Console.WriteLine();
        Console.ReadLine();

        // Close the ServiceHostBase to shutdown the service.
        host.Close();

        // </Snippet#0>

//</Snippet1>

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
