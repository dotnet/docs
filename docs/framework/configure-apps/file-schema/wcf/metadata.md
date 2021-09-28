---
description: "Learn more about: <metadata>"
title: "<metadata>"
ms.date: "03/30/2017"
ms.assetid: d09653eb-e355-4c73-b87b-28f93d56480d
---
# \<metadata>

Specifies how service metadata can be processed.  
  
[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<system.serviceModel>**](system-servicemodel.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[**\<client>**](client.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<metadata>**  
  
## Syntax  
  
```xml  
<system.serviceModel>
  <client>
    <metadata>
      <policyImporters>
        <policyImporter type="string" />
      </policyImporters>
      <wsdlImporters>
        <wsdlImporter type="string" />
      </wsdlImporters>
    </metadata>
  </client>
</system.serviceModel>
```  
  
## Attributes and Elements  

 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  

 None.  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<policyImporters>](policyimporters.md)|Specifies all the policy importers that control the import of custom policy assertions about bindings. A policy importer is used to search custom policy assertions about binding features, as well as attach a custom binding element that implements the features the assertion requires.|  
|[\<wsdlImporters>](wsdlimporters.md)|Specifies all the WSDL importers that import Web Services Description Language (WSDL) 1.1 metadata with WS-Policy attachments. A WSDL importer is used to import metadata as well as convert that information into various classes that represent contract and endpoint information. It can selectively import contract and endpoint information and properties that expose any import errors and accept type information relevant to the import and conversion process. It also supports importing binding information and properties that provide access to any policy documents, WSDL documents, WSDL extensions, and XML schema documents.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<client>](client.md)|The client section defines a list of endpoints that a client can connect to.|  
  
## See also

- <xref:System.ServiceModel.Configuration.MetadataElement>
- <xref:System.ServiceModel.Configuration.PolicyImporterElementCollection>
- <xref:System.ServiceModel.Configuration.WsdlImporterElementCollection>
- <xref:System.ServiceModel.Description.MetadataImporter>
- <xref:System.ServiceModel.Description.WsdlImporter>
- [WCF Client Configuration](../../../wcf/feature-details/client-configuration.md)
- [Clients](../../../wcf/feature-details/clients.md)
