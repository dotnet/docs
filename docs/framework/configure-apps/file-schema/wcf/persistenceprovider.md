---
description: "Learn more about: <persistenceProvider>"
title: "<persistenceProvider>"
ms.date: "03/30/2017"
ms.assetid: a37049c5-a7ea-4519-94f2-912eeb010380
---
# \<persistenceProvider>

Specifies the type of the persistence provider implementation to use, as well as the time-out to use for persistence operations.  
  
[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<system.serviceModel>**](system-servicemodel.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[**\<behaviors>**](behaviors.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<serviceBehaviors>**](servicebehaviors.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<behavior>**](behavior-of-servicebehaviors.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<persistenceProvider>**  
  
## Syntax  
  
```xml  
<persistenceProvider persistenceOperationTimeout="TimeSpan"
                     type="String" />
```  
  
## Attributes and Elements  

 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|persistenceOperationTimeout|A <xref:System.TimeSpan> value that specifies the time-out used for persistence operations. The default is "00:00:30".|  
|type|A string that specifies the type of the persistence provider factory to use.|  
  
### Child Elements  

 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<behavior>](behavior-of-endpointbehaviors.md)|Specifies a behavior element.|  
  
## Remarks  

 This element specifies the persistence provider to be used to serialize the state of a WCF service. It should be used together with the `wsHttpContextBinding` which passes state information in HTTP headers.  
  
## See also

- <xref:System.ServiceModel.Configuration.PersistenceProviderElement>
- <xref:System.ServiceModel.Persistence.PersistenceProvider>
