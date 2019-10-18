---
title: "<wsdlImporters>"
ms.date: "03/30/2017"
ms.assetid: 270c7f93-eab7-47b6-8b94-ac3f5b7f17e4
---
# \<wsdlImporters>
This configuration element specifies all the WSDL importers that imports Web Services Description Language (WSDL) 1.1 metadata with WS-Policy attachments. Each child element is a <`wsdlImporter`> that specifies the way to import metadata as well as convert that information into various classes that represent contract and endpoint information. It can selectively import contract and endpoint information and properties that expose any import errors and accept type information relevant to the import and conversion process. It also supports importing binding information and properties that provide access to any policy documents, WSDL documents, WSDL extensions, and XML schema documents.  
  
## See also

- <xref:System.ServiceModel.Configuration.MetadataElement>
- <xref:System.ServiceModel.Configuration.WsdlImporterElementCollection>
- <xref:System.ServiceModel.Description.MetadataImporter>
- <xref:System.ServiceModel.Description.WsdlImporter>
- [WCF Client Configuration](../../../wcf/feature-details/client-configuration.md)
- [Clients](../../../wcf/feature-details/clients.md)
