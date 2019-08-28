---
title: "<backupLists>"
ms.date: "03/30/2017"
ms.assetid: 593b3390-f65b-4684-ad40-0596b62f0954
---
# \<backupLists>
Represents a configuration section for defining a set of backup services used in error handling. Each child element is a backup list that enumerates a set of endpoints that you would like the Routing Service to use in case the primary endpoint can't be reached. If the first endpoint in the list is down, the Routing Service will automatically fail-over to the next one in the list.  This gives you a quick way to add reliability to your application without having to teach your client application how to handle complex patterns or where all of your services are deployed.  
  
 \<system.serviceModel>  
\<routing>  
\<backupLists>  
  
## Syntax  
  
```xml  
<routing>
  <backupLists>
    <backupList name="String">
      <add endpointName="String" />
    </backupList>
  </backupLists>
</routing>
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
 None.  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<filter>](filter.md)|Contains a list of endpoints that you would like the Routing Service to use in case the primary endpoint can't be reached. .|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<routing>](routing.md)|Represents a configuration section for defining a set of routing filters, which determine the type of Windows Communication Foundation (WCF)<xref:System.ServiceModel.Dispatcher.MessageFilter> to be used when evaluating incoming messages, as well as routing tables that define the target endpoints to send messages to when a filter matches.|  
  
## See also

- <xref:System.ServiceModel.Routing.Configuration.BackupEndpointCollection?displayProperty=nameWithType>
