---
title: "Publishing Metadata"
description: Learn how WCF services publish metadata by publishing one or more metadata endpoints, making the metadata available using standard protocols.
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "metadata [WCF], publishing"
ms.assetid: 3a56831a-cabc-45c0-bd02-12e2e9bd7313
---
# Publishing Metadata

Windows Communication Foundation (WCF) services publish metadata by publishing one or more metadata endpoints. Publishing service metadata makes the metadata available using standardized protocols, such as WS-MetadataExchange (MEX) and HTTP/GET requests. Metadata endpoints are similar to other service endpoints in that they have an address, a binding, and a contract, and they can be added to a service host through configuration or imperative code.  
  
## Publishing Metadata Endpoints  

 To publish metadata endpoints for a WCF service, you first must add the <xref:System.ServiceModel.Description.ServiceMetadataBehavior> service behavior to the service. Adding a <xref:System.ServiceModel.Description.ServiceMetadataBehavior?displayProperty=nameWithType> instance allows your service to expose metadata endpoints. Once you add the <xref:System.ServiceModel.Description.ServiceMetadataBehavior?displayProperty=nameWithType> service behavior, you can then expose metadata endpoints that support the MEX protocol or that respond to HTTP/GET requests.  
  
 The <xref:System.ServiceModel.Description.ServiceMetadataBehavior?displayProperty=nameWithType> uses a <xref:System.ServiceModel.Description.WsdlExporter> to export metadata for all service endpoints in your service. For more information about exporting metadata from a service, see [Exporting and Importing Metadata](exporting-and-importing-metadata.md).  
  
 The <xref:System.ServiceModel.Description.ServiceMetadataBehavior?displayProperty=nameWithType> adds a <xref:System.ServiceModel.Description.ServiceMetadataExtension> instance as an extension to your service host. The <xref:System.ServiceModel.Description.ServiceMetadataExtension?displayProperty=nameWithType> provides the implementation for the metadata publishing protocols. You can also use the <xref:System.ServiceModel.Description.ServiceMetadataExtension?displayProperty=nameWithType> to get the service's metadata at runtime by accessing the <xref:System.ServiceModel.Description.ServiceMetadataExtension.Metadata%2A?displayProperty=nameWithType> property.  
  
### MEX Metadata Endpoints  

 To add metadata endpoints that use the MEX protocol, add service endpoints to your service host that use the `IMetadataExchange` service contract. WCF includes an <xref:System.ServiceModel.Description.IMetadataExchange> interface with this service contract name that you can use as part of the WCF programming model. WS-MetadataExchange endpoints, or MEX endpoints, can use one of the four default bindings that the static factory methods expose on the <xref:System.ServiceModel.Description.MetadataExchangeBindings> class to match the default bindings used by WCF tools such as Svcutil.exe. You can also configure MEX metadata endpoints using your own custom binding.  
  
### HTTP GET Metadata Endpoints  

 To add a metadata endpoint to your service that responds to HTTP/GET requests, set the <xref:System.ServiceModel.Description.ServiceMetadataBehavior.HttpGetEnabled%2A> property on the <xref:System.ServiceModel.Description.ServiceMetadataBehavior?displayProperty=nameWithType> to `true`. You can also configure a metadata endpoint that uses HTTPS by setting the <xref:System.ServiceModel.Description.ServiceMetadataBehavior.HttpsGetEnabled%2A> property on the <xref:System.ServiceModel.Description.ServiceMetadataBehavior?displayProperty=nameWithType> to `true`.  
  
## In This Section  

 [How to: Publish Metadata for a Service Using a Configuration File](how-to-publish-metadata-for-a-service-using-a-configuration-file.md)  
 Demonstrates how to configure a WCF service to publish metadata so that clients can retrieve the metadata using a WS-MetadataExchange or an HTTP/GET request using the `?wsdl` query string.  
  
 [How to: Publish Metadata for a Service Using Code](how-to-publish-metadata-for-a-service-using-code.md)  
 Demonstrates how to enable metadata publishing for a WCF service in code so that clients can retrieve the metadata using a WS-MetadataExchange or an HTTP/GET request using the `?wsdl` query string.  
  
## Reference  

 <xref:System.ServiceModel.Description.ServiceMetadataBehavior>  
  
 <xref:System.ServiceModel.Description.IMetadataExchange>  
  
 <xref:System.ServiceModel.Description.ServiceMetadataExtension>  
  
 <xref:System.ServiceModel.Description.MetadataExchangeBindings>  
  
## See also

- [Exporting and Importing Metadata](exporting-and-importing-metadata.md)
