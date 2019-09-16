---
title: "<baseAddresses>"
ms.date: "03/30/2017"
ms.assetid: 78918102-2898-46e0-9ea8-6b8afe65603e
---
# \<baseAddresses>
Represents a collection of `baseAddress` elements, which are base addresses for a service host in a self-hosted environment. If a base address is present, endpoints can be configured with addresses relative to the base address.  
  
[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<system.serviceModel>**](system-servicemodel.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[**\<services>**](services.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<service>**](service.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<host>**](host.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<baseAddresses>**  
  
## Syntax  
  
```xml  
<baseAddresses>
  <add baseAddress="string" />
</baseAddresses>
```  
  
## Type  
 `Type`  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
 None.  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<add>](add-of-baseaddresses.md)|A configuration element that specifies the base addresses used by the service host.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<host>](host.md)|A configuration element that specifies settings for a service host.|  
  
## See also

- <xref:System.ServiceModel.Configuration.HostElement>
- <xref:System.ServiceModel.ServiceHost>
- <xref:System.ServiceModel.ServiceHostBase.BaseAddresses%2A>
- [Hosting](../../../wcf/feature-details/hosting.md)
