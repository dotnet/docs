---
title: "<add> of <baseAddresses>"
ms.date: "03/30/2017"
ms.assetid: 1bd7426f-5f4f-43fc-b8e9-de842219aa32
---
# \<add> of \<baseAddresses>
Represents a configuration element that specifies the base addresses used by the service host.  
  
 \<system.ServiceModel>  
\<client>  
\<endpoint>  
\<host>  
\<baseAddresses>  
\<baseAddress>  
  
## Syntax  
  
```xml  
<add baseAddress="string" />
```  
  
## Type  
 `Type`  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|`baseAddress`|A string that specifies a base address used by the service host.|  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<baseAddresses>](baseaddresses.md)|A collection of `baseAddress` elements.|  
  
## See also

- <xref:System.ServiceModel.Configuration.HostElement>
- <xref:System.ServiceModel.ServiceHost>
- <xref:System.ServiceModel.ServiceHostBase.BaseAddresses%2A>
- [Hosting](../../feature-details/hosting.md)
