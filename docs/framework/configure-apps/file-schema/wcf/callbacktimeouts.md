---
title: "<callbackTimeouts>"
ms.date: "03/30/2017"
ms.assetid: d7fcfc5f-6d35-491e-8fa6-2f964c1e792f
---
# \<callbackTimeouts>
Specifies the timeout value when flowing transactions from server to client.in a duplex callback contract scenario.  
  
 \<system.ServiceModel>  
\<behaviors>  
\<endpointBehaviors>  
\<behavior>  
\<callbackTimeOuts>  
  
## Syntax  
  
```xml  
<callbackTimeOuts transactionTimeout="TimeSpan" />
```  
  
## Type  
 `Type`  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|`transactionTimeout`|A <xref:System.TimeSpan> value that specifies the interval of time within which transactions must complete or be automatically terminated. The default is "00:00:00".|  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<behavior>](behavior-of-endpointbehaviors.md)|Specifies an endpoint behavior.|  
  
## See also

- <xref:System.ServiceModel.Configuration.CallbackTimeoutsElement>
