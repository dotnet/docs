---
title: "&lt;allowAccounts&gt;"
ms.date: "03/30/2017"
ms.assetid: 166923a9-a8ac-478f-92f9-529d9667f3a6
---
# &lt;allowAccounts&gt;
Contains a collection of configuration elements that specify user accounts for processes that host Windows Communication Foundation (WCF) services, and are granted connection access to the sharing service.  
  
 \<system.serviceModel.activation>  
  
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
|[\<add>](../../../../../docs/framework/configure-apps/file-schema/wcf/add-of-allowaccounts.md)|Adds a user account for processes that host WCF services, and are granted connection access to the sharing service|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<net.pipe>](../../../../../docs/framework/configure-apps/file-schema/wcf/net-pipe.md) or [\<net.tcp>](../../../../../docs/framework/configure-apps/file-schema/wcf/net-tcp.md)|Specifies configuration settings for the Net Pipe or TCP sharing services.|  
  
## See also
 <xref:System.ServiceModel.Activation.Configuration.NetTcpSection.AllowAccounts%2A>  
 <xref:System.ServiceModel.Activation.Configuration.NetPipeSection.AllowAccounts%2A>  
 <xref:System.ServiceModel.Activation.Configuration.SecurityIdentifierElementCollection>  
 <xref:System.ServiceModel.Activation.Configuration.SecurityIdentifierElement>
