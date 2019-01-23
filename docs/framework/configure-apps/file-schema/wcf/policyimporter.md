---
title: "&lt;policyImporter&gt;"
ms.date: "03/30/2017"
ms.assetid: b0d03456-546f-44bb-ab12-1b2ce7f98fca
---
# &lt;policyImporter&gt;
Specifies a policy importer that controls the import of custom policy assertions about bindings.  
  
 \<system.ServiceModel>  
\<client>  
\<metadata>  
\<policyImporters>  
\<policyImporter>  
  
## Syntax  
  
```xml  
<metadata>
  <policyImporters>
    <policyImporter type="String" />
  </policyImporters>
</metadata>
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|`type`|The type of this element.|  
  
### Child Elements  
 None  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<policyImporters>](../../../../../docs/framework/configure-apps/file-schema/wcf/policyimporters.md)|Specifies all the policy importers that control the import of custom policy assertions about bindings.|  
  
## Remarks  
 A policy importer is used to search custom policy assertions about binding features, as well as attach a custom binding element that implements the features the assertion requires.  
  
## See also
- <xref:System.ServiceModel.Configuration.PolicyImporterElementCollection>
- <xref:System.ServiceModel.Configuration.PolicyImporterElement>
- <xref:System.ServiceModel.Configuration.MetadataElement>
- <xref:System.ServiceModel.Description.MetadataImporter>
- [WCF Client Configuration](../../../../../docs/framework/wcf/feature-details/client-configuration.md)
- [Clients](../../../../../docs/framework/wcf/feature-details/clients.md)
