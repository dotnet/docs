---
title: "&lt;timeOuts&gt;"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 7fccd436-b326-48ec-8de1-c16817a09e0d
caps.latest.revision: 8
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;timeOuts&gt;
Represents a configuration element that specifies the interval of time allowed for the service host to open or close.  
  
 \<system.ServiceModel>  
\<client>  
\<endpoint>  
\<host>  
\<timeOuts>  
  
## Syntax  
  
```xml  
<timeOuts closeTimeout="TimeSpan"  
   openTimeout="TimeSpan" >  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|`closeTimeout`|A <xref:System.TimeSpan> value that specifies the interval of time allowed for the service host to close.|  
|`openTimeout`|A <xref:System.TimeSpan> value that specifies the interval of time allowed for the service host to open.|  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<host>](../../../../../docs/framework/configure-apps/file-schema/wcf/host.md)|A configuration element that specifies settings for a service host.|  
  
## See Also  
 <xref:System.ServiceModel.Configuration.HostElement>  
 <xref:System.ServiceModel.ServiceHost>  
 [Hosting](../../../../../docs/framework/wcf/feature-details/hosting.md)
