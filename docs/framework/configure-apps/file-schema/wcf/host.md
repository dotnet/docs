---
title: "&lt;host&gt;"
ms.date: "03/30/2017"
ms.assetid: be566d55-9d50-4b2e-985d-52a5cc26cbbb
---
# &lt;host&gt;
Specifies settings for a service host.  
  
 \<system.ServiceModel>  
\<services>  
\<service>  
\<host>  
  
## Syntax  
  
```xml  
<host>
  <baseAddresses>
    <add baseAddress="string" />
  </baseAddresses>
  <timeOuts closeTimeout="TimeSpan"
            openTimeout="TimeSpan" />
</host>
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
|[\<baseAddresses>](../../../../../docs/framework/configure-apps/file-schema/wcf/baseaddresses.md)|A collection of `baseAddress` elements that specifies the base addresses used by the service host.|  
|[\<timeOuts>](../../../../../docs/framework/configure-apps/file-schema/wcf/timeouts.md)|A configuration element that specifies the interval of time allowed for the service host to open or close.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<service>](../../../../../docs/framework/configure-apps/file-schema/wcf/service.md)|Specifies the settings for a Windows Communication Foundation (WCF) service.|  
  
## See also
- <xref:System.ServiceModel.Configuration.HostElement>
- <xref:System.ServiceModel.ServiceHost>
- [Hosting](../../../../../docs/framework/wcf/feature-details/hosting.md)
