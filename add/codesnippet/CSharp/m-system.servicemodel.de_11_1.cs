using System;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace WsdlExporterSample
{
    class Program
    {
        static void Main(string[] args)
        {
            WsdlExporter exporter = new WsdlExporter();
            exporter.PolicyVersion = PolicyVersion.Policy15;
          
            ServiceEndpoint [] myServiceEndpoints = new ServiceEndpoint[2];
            ContractDescription myDescription = new ContractDescription ("myContract");
            myServiceEndpoints[0] = new ServiceEndpoint(myDescription,new BasicHttpBinding(),new EndpointAddress("http://localhost/myservice"));
            myServiceEndpoints[1] = new ServiceEndpoint(myDescription,new BasicHttpBinding(),new EndpointAddress("http://localhost/myservice"));
            
            // Export all endpoints for each endpoint in collection.
            foreach (ServiceEndpoint endpoint in myServiceEndpoints)
            {
                exporter.ExportEndpoint(endpoint);
            }
            // If there are no errors, get the documents.
            MetadataSet metadataDocs = null;
            if (exporter.Errors.Count != 0)
            {
                metadataDocs = exporter.GetGeneratedMetadata();
            }
        }
    }
}