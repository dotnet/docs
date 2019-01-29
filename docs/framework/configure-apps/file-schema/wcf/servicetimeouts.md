---
title: "&lt;serviceTimeouts&gt;"
ms.date: "03/30/2017"
ms.assetid: ada536cf-97dc-4cd7-89ec-ed1466c1c557
---
# &lt;serviceTimeouts&gt;
Specifies the timeout for a service.  
  
 \<system.ServiceModel>  
\<behaviors>  
\<serviceBehaviors>  
\<behavior>  
\<serviceTimeouts>  
  
## Syntax  
  
```xml  
<serviceTimeouts transactionTimeout="TimeSpan" />
```  
  
## Type  
 `Type`  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|`transactionTimeout`|A <xref:System.TimeSpan> value that specifies the interval of time a transaction must flow from client to server. The default is "00:00:00".|  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<behavior>](../../../../../docs/framework/configure-apps/file-schema/wcf/behavior-of-endpointbehaviors.md)|Specifies a behavior element.|  
  
## See also
- <xref:System.ServiceModel.Configuration.ServiceTimeoutsElement>
