---
title: "&lt;persistenceProvider&gt;"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: a37049c5-a7ea-4519-94f2-912eeb010380
caps.latest.revision: 5
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;persistenceProvider&gt;
Specifies the type of the persistence provider implementation to use, as well as the time-out to use for persistence operations.  
  
 \<system.ServiceModel>  
\<behaviors>  
\<serviceBehaviors>  
\<behavior>  
\<persistenceProvider>  
  
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
|[\<behavior>](../../../../../docs/framework/configure-apps/file-schema/wcf/behavior-of-endpointbehaviors.md)|Specifies a behavior element.|  
  
## Remarks  
 This element specifies the persistence provider to be used to serialize the state of a WCF service. It should be used together with the `wsHttpContextBinding` which passes state information in HTTP headers.  
  
## See Also  
 <xref:System.ServiceModel.Configuration.PersistenceProviderElement>  
 <xref:System.ServiceModel.Persistence.PersistenceProvider>
