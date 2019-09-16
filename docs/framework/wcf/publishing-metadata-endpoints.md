---
title: "Publishing Metadata Endpoints"
ms.date: "03/30/2017"
ms.assetid: 29cd8a60-dfb7-460c-bf5a-c2b31b782671
---
# Publishing Metadata Endpoints
Windows Communication Foundation (WCF) services publish metadata by publishing one or more metadata endpoints. Publishing service metadata makes the metadata available using standardized protocols, such as WS-MetadataExchange (MEX) and HTTP/GET requests. Metadata endpoints are similar to other service endpoints in that they have an address, a binding, and a contract, and they can be added to a service host through configuration or in code. To enable publishing metadata endpoints, you must add the <xref:System.ServiceModel.Description.ServiceMetadataBehavior> service behavior to the service.  
  
## In This Section  
 [How to: Publish Metadata for a Service Using a Configuration File](../../../docs/framework/wcf/feature-details/how-to-publish-metadata-for-a-service-using-a-configuration-file.md)  
 Demonstrates how to configure a WCF service to publish metadata so that clients can retrieve the metadata using a WS-MetadataExchange or an HTTP/GET request using the `?wsdl` query string.  
  
 [How to: Publish Metadata for a Service Using Code](../../../docs/framework/wcf/feature-details/how-to-publish-metadata-for-a-service-using-code.md)  
 Demonstrates how to enable metadata publishing for a WCF service in code so that clients can retrieve the metadata using a WS-MetadataExchange or an HTTP/GET request using the `?wsdl` query string.  
  
## See also

- [Publishing Metadata](../../../docs/framework/wcf/feature-details/publishing-metadata.md)
