---
description: "Learn more about: <net.pipe>"
title: "<net.pipe>"
ms.date: "03/30/2017"
ms.assetid: 6a0f0318-f8f6-466c-9fae-199d7274a82e
---
# \<net.pipe>

Specifies configuration settings for the Named Pipe Activation Service, which manages the lifetime of the named pipe connection, and handles activation requests that arrive over named pipes.  
  
[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<system.serviceModel.activation>**](system-servicemodel-activation.md)\
&nbsp;&nbsp;&nbsp;&nbsp;**\<net.pipe>**  
  
## Syntax  
  
```xml  
<configuration>
  <system.serviceModel.activation>
    <net.pipe maxPendingAccepts="Integer"
              maxPendingConnections="Integer"
              receiveTimeout="TimeSpan">
      <allowAccounts>
        <!-- LocalSystem account -->
        <add securityIdentifier="S-1-5-18" />
        <!-- LocalService account -->
        <add securityIdentifier="S-1-5-19" />
        <!-- Administrators account -->
        <add securityIdentifier="S-1-5-20" />
        <!-- Network Service account -->
        <add securityIdentifier="S-1-5-32-544" />
        <!-- IIS_IUSRS account (Vista only) -->
        <add securityIdentifier="S-1-5-32-568" />
      </allowAccounts>
    </net.pipe>
  </system.serviceModel.activation>
</configuration>
```  
  
## Type  

 `Type`  
  
## Attributes and Elements  

 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|`maxPendingAccepts`|An integer that specifies the maximum outstanding concurrent accepting threads on the listening endpoint for the sharing service. The default is 2.|  
|`maxPendingConnections`|An integer that specifies the maximum number of connections that can wait for dispatch. The default is 100.|  
|`receiveTimeout`|A <xref:System.TimeSpan> that specifies the timeout for reading the framing data and performing connection dispatching from the underlining connections. The default is "00:00:10"|  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<allowAccounts>](allowaccounts.md)|A collection of configuration elements that contain a `securityIdentifier` attribute to specify user accounts for processes that host WCF services, and are granted connection access to the sharing service.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<system.serviceModel.activation>](system-servicemodel-activation.md)|Contains configuration settings for the listener process SMSvcHost.exe.|  
  
## See also

- <xref:System.ServiceModel.Activation.Configuration.NetPipeSection>
