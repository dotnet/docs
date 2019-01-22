---
title: "&lt;net.tcp&gt;"
ms.date: "03/30/2017"
ms.assetid: 8bc2f2be-11c1-4bab-9018-1d21ae568d94
---
# &lt;net.tcp&gt;
Specifies configuration settings for the NET.TCP Port Sharing Service, which allows multiple processes to share the same TCP port.  
  
 \<system.serviceModel.activation>  
\<net.tcp>  
  
## Syntax  
  
```xml  
<configuration>
  <system.serviceModel.activation>
    <net.tcp listenBacklog="Integer"
             maxPendingAccepts="Integer"
             maxPendingConnections="Integer"
             receiveTimeout="TimeSpan"
             teredoEnabled="Boolean">
      <allowAccounts>
        <!-- LocalSystem account -->
        <add securityIdentifier="S-1-5-18"/>
        <!-- LocalService account -->
        <add securityIdentifier="S-1-5-19"/>
        <!-- Administrators account -->
        <add securityIdentifier="S-1-5-20"/>
        <!-- Network Service account -->
        <add securityIdentifier="S-1-5-32-544" />
        <!-- IIS_IUSRS account (Vista only)-->
        <add securityIdentifier="S-1-5-32-568"/>
      </allowAccounts>
    </net.tcp>
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
|`listenBacklog`|An integer that specifies the maximum outstanding connections that are accepted from the shared connection, but are not yet dispatched to Windows Communication Foundation (WCF) services. The default is 10.|  
|`maxPendingAccepts`|An integer that specifies the maximum outstanding concurrent accepting threads on the listening endpoint for the sharing service. The default is 2.|  
|`MaxPendingConnections`|The maximum number of connections that the listener can have waiting to be accepted by the application. When this quota value is exceeded, new incoming connections are dropped rather than waiting to be accepted. Connection features such as message security can cause a client to open more than one connection. Service administrators should account for these additional connections when setting this quota value. The default is 10.|  
|`receiveTimeout`|A `TimeSpan` that specifies the timeout for reading the framing data and performing connection dispatching from the underlining connections. The default is "00:00:10".|  
|`teredoEnabled`|A Boolean value that indicates whether the port sharing service uses Microsoft Teredo service to listen on TCP ports on behalf of WCF services. The default is `false`.|  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<allowAccounts>](../../../../../docs/framework/configure-apps/file-schema/wcf/allowaccounts.md)|A collection of configuration elements that contain a `securityIdentifier` attribute to specify user accounts for processes that host WCF services, and are granted connection access to the sharing service.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<system.serviceModel.activation>](../../../../../docs/framework/configure-apps/file-schema/wcf/system-servicemodel-activation.md)|Contains configuration settings for the listener process SMSvcHost.exe.|  
  
## Remarks  
 For more information on port sharing, see [Net.TCP Port Sharing](../../../../../docs/framework/wcf/feature-details/net-tcp-port-sharing.md). To understand how to configure the port sharing service, see [Configuring the Net.TCP Port Sharing Service](../../../../../docs/framework/wcf/feature-details/configuring-the-net-tcp-port-sharing-service.md).  
  
## See also
 <xref:System.ServiceModel.Activation.Configuration.NetTcpSection>  
 [Net.TCP Port Sharing](../../../../../docs/framework/wcf/feature-details/net-tcp-port-sharing.md)  
 [Configuring the Net.TCP Port Sharing Service](../../../../../docs/framework/wcf/feature-details/configuring-the-net-tcp-port-sharing-service.md)
