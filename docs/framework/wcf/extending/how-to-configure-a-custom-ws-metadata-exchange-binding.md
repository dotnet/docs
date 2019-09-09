---
title: "How to: Configure a Custom WS-Metadata Exchange Binding"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "WS-Metadata Exchange [WCF]"
  - "WS-Metadata Exchange [WCF], configuring a custom binding"
ms.assetid: cdba4d73-da64-4805-bc56-9822becfd1e4
---
# How to: Configure a Custom WS-Metadata Exchange Binding
This topic will explain how to configure a custom WS-Metadata exchange binding. Windows Communication Foundation (WCF) includes four system-defined metadata bindings, but you can publish metadata using any binding you want. This topic will show you how to publish metadata using the `wsHttpBinding`. This binding gives you the option of exposing metadata in a secure way. The code in this article is based on the [Getting Started](../samples/getting-started-sample.md).  
  
### Using a configuration file  
  
1. In the service's configuration file, add a service behavior that contains the `serviceMetadata` tag:  
  
    ```xml  
    <behaviors>  
       <serviceBehaviors>  
         <behavior name="CalculatorServiceBehavior">  
           <serviceMetadata httpGetEnabled="True"/>  
         </behavior>  
       </serviceBehaviors>  
    </behaviors>  
    ```  
  
2. Add a `behaviorConfiguration` attribute to the service tag that references this new behavior:  
  
    ```xml  
    <service        name="Microsoft.ServiceModel.Samples.CalculatorService"  
    behaviorConfiguration="CalculatorServiceBehavior">   
    ```  
  
3. Add a metadata endpoint specifying mex as the address, `wsHttpBinding` as the binding, and <xref:System.ServiceModel.Description.IMetadataExchange> as the contract:  
  
    ```xml  
    <endpoint address="mex"  
              binding="wsHttpBinding"  
              contract="IMetadataExchange" />  
    ```  
  
4. To verify the metadata exchange endpoint is working correctly add an endpoint tag in the client configuration file:  
  
    ```xml  
    <endpoint name="MyMexEndpoint"               address="http://localhost:8000/servicemodelsamples/service/mex"  
              binding="wsHttpBinding"  
              contract="IMetadataExchange"/>  
    ```  
  
5. In the client's Main() method, create a new <xref:System.ServiceModel.Description.MetadataExchangeClient> instance, set its <xref:System.ServiceModel.Description.MetadataExchangeClient.ResolveMetadataReferences%2A> property to `true`, call <xref:System.ServiceModel.Description.MetadataExchangeClient.GetMetadata%2A> and then iterate through the collection of metadata returned:  
  
    ```  
    string mexAddress = "http://localhost:8000/servicemodelsamples/service/mex";  
  
    MetadataExchangeClient mexClient = new MetadataExchangeClient("MyMexEndpoint");  
    mexClient.ResolveMetadataReferences = true;  
    MetadataSet mdSet = mexClient.GetMetadata(new EndpointAddress(mexAddress));  
    foreach (MetadataSection section in mdSet.MetadataSections)  
    Console.WriteLine("Metadata section: " + section.Dialect.ToString());  
    ```  
  
### Configuring by code  
  
1. Create a <xref:System.ServiceModel.WSHttpBinding> binding instance:  
  
    ```  
    WSHttpBinding binding = new WSHttpBinding();  
    ```  
  
2. Create a <xref:System.ServiceModel.ServiceHost> instance:  
  
    ```  
    ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService), baseAddress);  
    ```  
  
3. Add a service endpoint and add a <xref:System.ServiceModel.Description.ServiceMetadataBehavior> instance:  
  
    ```  
    serviceHost.AddServiceEndpoint(typeof(ICalculator), binding, baseAddress);  
    ServiceMetadataBehavior smb = new ServiceMetadataBehavior();  
    smb.HttpGetEnabled = true;  
    serviceHost.Description.Behaviors.Add(smb);  
    ```  
  
4. Add a metadata exchange endpoint, specifying the <xref:System.ServiceModel.WSHttpBinding> created earlier:  
  
    ```  
    serviceHost.AddServiceEndpoint(typeof(IMetadataExchange), binding, mexAddress);  
    ```  
  
5. To verify that the metadata exchange endpoint is working correctly, add an endpoint tag in the client configuration file:  
  
    ```xml  
    <endpoint name="MyMexEndpoint"               address="http://localhost:8000/servicemodelsamples/service/mex"  
              binding="wsHttpBinding"  
              contract="IMetadataExchange"/>  
    ```  
  
6. In the client's Main() method, create a new <xref:System.ServiceModel.Description.MetadataExchangeClient> instance, set the <xref:System.ServiceModel.Description.MetadataExchangeClient.ResolveMetadataReferences%2A> property to `true`, call <xref:System.ServiceModel.Description.MetadataExchangeClient.GetMetadata%2A> and then iterate through the collection of metadata returned:  
  
    ```  
    string mexAddress = "http://localhost:8000/servicemodelsamples/service/mex";  
  
    MetadataExchangeClient mexClient = new MetadataExchangeClient("MyMexEndpoint");  
    mexClient.ResolveMetadataReferences = true;  
    MetadataSet mdSet = mexClient.GetMetadata(new EndpointAddress(mexAddress));  
    foreach (MetadataSection section in mdSet.MetadataSections)  
    Console.WriteLine("Metadata section: " + section.Dialect.ToString());  
    ```  
  
## See also

- [Metadata Publishing Behavior](../samples/metadata-publishing-behavior.md)
- [Retrieve Metadata](../samples/retrieve-metadata.md)
- [Metadata](../feature-details/metadata.md)
- [Publishing Metadata](../feature-details/publishing-metadata.md)
- [Publishing Metadata Endpoints](../publishing-metadata-endpoints.md)
