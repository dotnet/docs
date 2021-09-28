---
description: "Learn more about: <allowAccounts>"
title: "<allowAccounts>"
ms.date: "03/30/2017"
ms.assetid: 166923a9-a8ac-478f-92f9-529d9667f3a6
---
# \<allowAccounts>

Contains a collection of configuration elements that specify user accounts for processes that host Windows Communication Foundation (WCF) services, and are granted connection access to the sharing service.  
  
[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<system.serviceModel.activation>**](system-servicemodel-activation.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[**\<net.pipe>**](net-pipe.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<allowAccounts>**  
  
## Syntax  
  
```xml  
<allowAccounts>
  <add securityIdentifier="String" />
</allowAccounts>
```  
  
## Attributes and Elements  

 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  

 None.  
  
### Child Elements  
  
|Attribute|Description|  
|---------------|-----------------|  
|[\<add>](add-of-allowaccounts.md)|Adds a user account for processes that host WCF services, and are granted connection access to the sharing service|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<net.pipe>](net-pipe.md) or [\<net.tcp>](net-tcp.md)|Specifies configuration settings for the Net Pipe or TCP sharing services.|  
  
## See also

- <xref:System.ServiceModel.Activation.Configuration.NetTcpSection.AllowAccounts%2A>
- <xref:System.ServiceModel.Activation.Configuration.NetPipeSection.AllowAccounts%2A>
- <xref:System.ServiceModel.Activation.Configuration.SecurityIdentifierElementCollection>
- <xref:System.ServiceModel.Activation.Configuration.SecurityIdentifierElement>
