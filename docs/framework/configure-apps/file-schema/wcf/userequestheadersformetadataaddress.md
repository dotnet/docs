---
title: "<useRequestHeadersForMetadataAddress>"
ms.date: "03/30/2017"
ms.assetid: 679f0eae-f353-44d1-b42d-a9e247509774
---
# \<useRequestHeadersForMetadataAddress>
Enables the retrieval of metadata address information from the request message headers.  
  
\<system.ServiceModel>  
\<behaviors>  
\<serviceBehaviors>  
\<behavior>  
\<useRequestHeadersForMetadataAddress>  
  
## Syntax  
  
```xml  
<useRequestHeadersForMetadataAddress>
  <defaultPorts>
    <add scheme="http"
         port="integer" />
  </defaultPorts>
</useRequestHeadersForMetadataAddress>
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
 None.  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<defaultPorts>](../../../../../docs/framework/configure-apps/file-schema/wcf/defaultports.md)|A collection of default ports listing the default communications endpoints that the client application listens to.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<behavior>](../../../../../docs/framework/configure-apps/file-schema/wcf/behavior-of-endpointbehaviors.md)|Specifies a behavior element.|  
  
## See also

- <xref:System.ServiceModel.Configuration.UseRequestHeadersForMetadataAddressElement>
