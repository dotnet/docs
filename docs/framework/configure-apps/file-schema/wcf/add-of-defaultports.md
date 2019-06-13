---
title: "<add> of <defaultPorts>"
ms.date: "03/30/2017"
ms.assetid: f162ce42-963b-4779-96a7-d6d8b4ea0d2f
---
# \<add> of \<defaultPorts>
A default communications endpoint that the client application listens to.  
  
 \<system.ServiceModel>  
\<behaviors>  
\<serviceBehaviors>  
\<behavior>  
\<useRequestHeadersForMetadataAddress>  
\<defaultPorts>  
\<add>  
  
## Syntax  
  
```xml  
<useRequestHeadersForMetadataAddress>
  <defaultPorts>
    <add port="Integer"
         scheme="String" />
  </defaultPorts>
</useRequestHeadersForMetadataAddress>
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|port|An integer that specifies the default communications port number|  
|scheme|A string that specifies the group of protocol settings associated with a communications port.|  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<defaultPorts>](../../../../../docs/framework/configure-apps/file-schema/wcf/defaultports.md)|A collection of default ports listing the default communications endpoints that the client application listens to.|  
  
## See also

- <xref:System.ServiceModel.Configuration.DefaultPortElement>
