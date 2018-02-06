---
title: "&lt;add&gt; of &lt;backupList&gt;"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: bc5939fc-314a-4ea4-a533-c96958da7173
caps.latest.revision: 2
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;add&gt; of &lt;backupList&gt;
Represents a configuration element that defines a backup endpoint element.  
  
 \<system.serviceModel>  
\<routing>  
\<backupLists>  
\<backupList>  
\<add>  
  
## Syntax  
  
```xml  
   <routing>  <backupLists>    <backupList name="String">      <add endpointName="String" />    </backupList>    </backupLists></routing>  
```  
  
```csharp  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|name|A string that specifies the name of the backup endpoint.|  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<routing>](../../../../../docs/framework/configure-apps/file-schema/wcf/routing.md)|Contains a list of endpoints that you would like the Routing Service to use in case the primary endpoint can't be reached.|  
  
## See Also  
 <xref:System.ServiceModel.Routing.Configuration.BackupEndpointElement?displayProperty=nameWithType> 
