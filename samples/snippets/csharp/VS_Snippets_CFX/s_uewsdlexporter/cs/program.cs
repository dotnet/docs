// <Snippet0>
using System;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace WsdlExporterSample
{
    class Program
    {
        static void Main(string[] args)
        {
	        // <Snippet1>
            WsdlExporter exporter = new WsdlExporter();
            // </Snippet1>   
            // <Snippet2>
            exporter.PolicyVersion = PolicyVersion.Policy15;
            // </Snippet2>
          
            // <Snippet3>
            ServiceEndpoint [] myServiceEndpoints = new ServiceEndpoint[2];
            ContractDescription myDescription = new ContractDescription ("myContract");
            myServiceEndpoints[0] = new ServiceEndpoint(myDescription,new BasicHttpBinding(),new EndpointAddress("http://localhost/myservice"));
            myServiceEndpoints[1] = new ServiceEndpoint(myDescription,new BasicHttpBinding(),new EndpointAddress("http://localhost/myservice"));
            // </Snippet3>
            
            // <Snippet4>
            // Export all endpoints for each endpoint in collection.
            foreach (ServiceEndpoint endpoint in myServiceEndpoints)
            {
                exporter.ExportEndpoint(endpoint);
            }
            // </Snippet4>
            // <Snippet5>
            // If there are no errors, get the documents.
            MetadataSet metadataDocs = null;
            if (exporter.Errors.Count != 0)
            {
                metadataDocs = exporter.GetGeneratedMetadata();
            }
            // </Snippet5>
        }
    }
}
// </Snippet0>