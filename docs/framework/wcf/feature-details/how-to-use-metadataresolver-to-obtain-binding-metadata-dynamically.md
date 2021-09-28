---
description: "Learn more about: How to: Use MetadataResolver to Obtain Binding Metadata Dynamically"
title: "How to: Use MetadataResolver to Obtain Binding Metadata Dynamically"
ms.date: "03/30/2017"
ms.assetid: 56ffcb99-fff0-4479-aca0-e3909009f605
---
# How to: Use MetadataResolver to Obtain Binding Metadata Dynamically

This topic shows you how to use the <xref:System.ServiceModel.Description.MetadataResolver> class to dynamically obtain binding metadata.  
  
### To dynamically obtain binding metadata  
  
1. Create an <xref:System.ServiceModel.EndpointAddress> object with the address of the metadata endpoint.  
  
    ```csharp
    EndpointAddress metaAddress  
      = new EndpointAddress(new Uri("http://localhost:8080/SampleService/mex"));  
    ```  
  
2. Call <xref:System.ServiceModel.Description.MetadataResolver.Resolve%28System.Type%2CSystem.ServiceModel.EndpointAddress%29>, which passes in the service type and the metadata endpoint address. This returns a collection of endpoints that implement the specified contract. Only binding information is imported from the metadata; contract information is not imported. The supplied contract is used instead.  
  
    ```csharp  
    ServiceEndpointCollection endpoints = MetadataResolver.Resolve(typeof(SampleServiceClient),metaAddress);  
    ```  
  
3. You can then iterate through the collection of service endpoints to extract the binding information you need. The following code iterates through the endpoints, creates a service client object that passes in the binding and address associated with the current endpoint, and then calls a method on the service.  
  
    ```csharp  
    foreach (ServiceEndpoint point in endpoints)  
    {  
       if (point != null)  
       {  
          // Create a new wcfClient using retrieved endpoints.  
          using (wcfClient = new SampleServiceClient(point.Binding, point.Address))  
          {  
             Console.WriteLine(  
               wcfClient.SampleMethod("Client used the "  
               + point.Address.ToString() + " address."));  
          }  
      }  
    }  
    ```  
  
## See also

- [Metadata](metadata.md)
