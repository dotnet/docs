// <snippet4>
using System;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Channels;

public class Client
{
    public static void Main()
    {
        try
        {
            SampleServiceClient wcfClient;
            // Client has an endpoint for metadata
            EndpointAddress metaAddress
              = new EndpointAddress(new Uri("http://localhost:8080/SampleService/mex"));
            EndpointAddress httpGetMetaAddress
              = new EndpointAddress(new Uri("http://localhost:8080/SampleService?wsdl"));

            // <snippet1>
            // Get the endpoints for such a service
            ServiceEndpointCollection endpoints = MetadataResolver.Resolve(typeof(SampleServiceClient), metaAddress);
            Console.WriteLine("Trying all available WS-Transfer metadata endpoints...");

            foreach (ServiceEndpoint point in endpoints)
            {
                if (point != null)
                {
                    // Create a new wcfClient using retrieved endpoints.
                    wcfClient = new SampleServiceClient(point.Binding, point.Address);
                    Console.WriteLine(
                      wcfClient.SampleMethod("Client used the "
                      + point.Address.ToString()
                      + " address.")
                    );
                    wcfClient.Close();
                }
            }
            // </snippet1>
            // <snippet2>
            // Get the endpoints for such a service using Http/Get request
            endpoints = MetadataResolver.Resolve(typeof(SampleServiceClient), httpGetMetaAddress.Uri, MetadataExchangeClientMode.HttpGet);
            Client.WriteParameters(endpoints);
            ISampleService serviceChannel;
            Console.WriteLine(
              "\r\nTrying all endpoints from HTTP/Get and with direct service channels...");

            foreach (ServiceEndpoint point in endpoints)
            {
                if (point != null)
                {
                    ChannelFactory<ISampleService> factory = new ChannelFactory<ISampleService>(point.Binding);
                    factory.Endpoint.Address = point.Address;
                    serviceChannel = factory.CreateChannel();
                    Console.WriteLine("Client used the " + point.Address.ToString() + " address.");
                    Console.WriteLine(
                      serviceChannel.SampleMethod(
                        "Client used the " + point.Address.ToString() + " address."
                      )
                    );
                    factory.Close();
                }
            }
            // </snippet2>

            // <snippet3>
            // Get metadata documents.
            Console.WriteLine("URI of the metadata documents retrieved:");
            MetadataExchangeClient metaTransfer
              = new MetadataExchangeClient(httpGetMetaAddress.Uri, MetadataExchangeClientMode.HttpGet);
            metaTransfer.ResolveMetadataReferences = true;
            MetadataSet otherDocs = metaTransfer.GetMetadata();
            foreach (MetadataSection doc in otherDocs.MetadataSections)
                Console.WriteLine(doc.Dialect + " : " + doc.Identifier);
            // </snippet3>

            Console.WriteLine("Press ENTER to exit...");
            Console.ReadLine();
        }
        catch (TimeoutException timeProblem)
        {
            Console.WriteLine("The service operation timed out. " + timeProblem.Message);
        }
        catch (FaultException unkException)
        {
            Console.WriteLine(unkException.Message);
            Console.ReadLine();
        }
        catch (CommunicationException commProblem)
        {
            Console.WriteLine("There was a communication problem. " + commProblem.Message);
        }
    }

    private static void WriteParameters(ServiceEndpointCollection endpoints)
    {
        foreach (ServiceEndpoint ep in endpoints)
        {
            foreach (OperationDescription od in ep.Contract.Operations)
            {
                Console.WriteLine($"OPERATION {od.Name}");
                Console.WriteLine("in params");
                foreach (MessagePartDescription part in od.Messages[0].Body.Parts)
                {
                    Console.WriteLine($"{part.Index}:{part.Name}:{part.Type}");
                }
                // assume two-way op below
                Console.WriteLine("out params");
                foreach (MessagePartDescription part in od.Messages[1].Body.Parts)
                {
                    Console.WriteLine($"{part.Index}:{part.Name}:{part.Type}");
                }
                Console.WriteLine("return value");
                MessagePartDescription rv = od.Messages[1].Body.ReturnValue;
                Console.WriteLine($"{rv.Index}:{rv.Name}:{rv.Type}");
                Console.WriteLine();
            }
        }
    }
}
// </snippet4>

/*
<snippet5>
The output of the program is:

Trying all available WS-Transfer metadata endpoints...
The service greets you: Client used the http://localhost:9090/SampleService address.
The service greets you: Client used the net.tcp://localhost:30000/SampleService address.
The service greets you: Client used the net.tcp://localhost:15342/SampleService address.
The service greets you: Client used the http://localhost:8989/SampleService address.

Trying all endpoints from HTTP/Get and with direct service channels...
SampleMethodResponse
SampleMethodResponse
SampleMethodResponse
SampleMethodResponse

URI of the metadata documents retrieved:
http://schemas.xmlsoap.org/wsdl/ : http://tempuri.org/
http://schemas.xmlsoap.org/wsdl/ : http://Microsoft.WCF.Documentation
http://www.w3.org/2001/XMLSchema : http://schemas.microsoft.com/2003/10/Serialization/
http://www.w3.org/2001/XMLSchema : http://Microsoft.WCF.Documentation
Press ENTER to exit...
</snippet5>
*/
