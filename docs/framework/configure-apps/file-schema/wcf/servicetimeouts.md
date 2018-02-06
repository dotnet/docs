---
title: "&lt;serviceTimeouts&gt;"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: ada536cf-97dc-4cd7-89ec-ed1466c1c557
caps.latest.revision: 11
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
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
  
## See Also  
 <xref:System.ServiceModel.Configuration.ServiceTimeoutsElement>
