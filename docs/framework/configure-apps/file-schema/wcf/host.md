---
title: "<host>"
ms.date: "03/30/2017"
ms.assetid: be566d55-9d50-4b2e-985d-52a5cc26cbbb
---
# \<host>
Specifies settings for a service host.  
  
[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<system.serviceModel>**](system-servicemodel.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[**\<services>**](services.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<service>**](service.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<host>**  
  
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
|[\<baseAddresses>](baseaddresses.md)|A collection of `baseAddress` elements that specifies the base addresses used by the service host.|  
|[\<timeOuts>](timeouts.md)|A configuration element that specifies the interval of time allowed for the service host to open or close.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<service>](service.md)|Specifies the settings for a Windows Communication Foundation (WCF) service.|  
  
## See also

- <xref:System.ServiceModel.Configuration.HostElement>
- <xref:System.ServiceModel.ServiceHost>
- [Hosting](../../../wcf/feature-details/hosting.md)
