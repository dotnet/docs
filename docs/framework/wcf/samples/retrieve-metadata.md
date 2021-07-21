---
description: "Learn more about: Retrieve Metadata"
title: "Retrieve Metadata"
ms.date: "03/30/2017"
ms.assetid: e8a6ef8c-a195-495a-a15e-7d92bdf0b28c
---
# Retrieve Metadata

The [RetrieveMetadata sample](https://github.com/dotnet/samples/tree/main/framework/wcf/Basic/Client/RetrieveMetadata/CS) demonstrates how to implement a client that dynamically retrieves metadata from a service to choose an endpoint with which to communicate. This sample is based on the [Getting Started](getting-started-sample.md). The service has been modified to expose two endpoints—an endpoint at the base address using the `basicHttpBinding` binding, and a secure endpoint at {*baseaddress*}/secure using the `wsHttpBinding` binding. Instead of configuring the client with the endpoint addresses and bindings, the client dynamically retrieves the metadata for the service using the <xref:System.ServiceModel.Description.MetadataExchangeClient> class and then imports the metadata as a <xref:System.ServiceModel.Description.ServiceEndpointCollection> using the <xref:System.ServiceModel.Description.WsdlImporter> class.

> [!NOTE]
> The setup procedure and build instructions for this sample are located at the end of this topic.

The client application uses the imported <xref:System.ServiceModel.Description.ServiceEndpointCollection> to create clients to communicate with the service. The client application iterates through each retrieved endpoint and communicates with each endpoint that implements the `ICalculator` contract. The appropriate address and binding are provided with the retrieved endpoint, so that the client is configured to communicate with each endpoint, as shown in the following sample code.

```csharp
// Create a MetadataExchangeClient for retrieving metadata.
EndpointAddress mexAddress = new EndpointAddress(ConfigurationManager.AppSettings["mexAddress"]);
MetadataExchangeClient mexClient = new MetadataExchangeClient(mexAddress);

// Retrieve the metadata for all endpoints using metadata exchange protocol (mex).
MetadataSet metadataSet = mexClient.GetMetadata();

//Convert the metadata into endpoints.
WsdlImporter importer = new WsdlImporter(metadataSet);
ServiceEndpointCollection endpoints = importer.ImportAllEndpoints();

CalculatorClient client = null;
ContractDescription contract = ContractDescription.GetContract(typeof(ICalculator));
// Communicate with each endpoint that supports the ICalculator contract.
foreach (ServiceEndpoint ep in endpoints)
{
    if (ep.Contract.Namespace.Equals(contract.Namespace) && ep.Contract.Name.Equals(contract.Name))
    {
        // Create a client using the endpoint address and binding.
        client = new CalculatorClient(ep.Binding, new EndpointAddress(ep.Address.Uri));
        Console.WriteLine("Communicate with endpoint: ");
        Console.WriteLine("   AddressPath={0}", ep.Address.Uri.PathAndQuery);
        Console.WriteLine("   Binding={0}", ep.Binding.Name);
        // Call operations.
        DoCalculations(client);

        //Closing the client gracefully closes the connection and cleans up resources.
        client.Close();
    }
}
```

The client console window displays the operations sent to each of the endpoints, displaying the address path and binding name.

### To set up, build, and run the sample

1. Ensure that you have performed the [One-Time Setup Procedure for the Windows Communication Foundation Samples](one-time-setup-procedure-for-the-wcf-samples.md).

2. To build the C#, C++, or Visual Basic .NET edition of the solution, follow the instructions in [Building the Windows Communication Foundation Samples](building-the-samples.md).

3. To run the sample in a single- or cross-machine configuration, follow the instructions in [Running the Windows Communication Foundation Samples](running-the-samples.md).
