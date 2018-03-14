---
title: "&lt;synchronousReceive&gt; element"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: cc070387-3d11-4b02-a952-bc08ad2df05a
caps.latest.revision: 6
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;synchronousReceive&gt; element
This configuration element is used to specify run-time behavior for receiving messages in either a service or client application. It does not have any attributes or child elements.  
  
 \<system.ServiceModel>  
\<behaviors>  
\<endpointBehaviors>  
\<behavior>  
\<synchronousReceive>  
  
## Syntax  
  
```xml  
<synchronousReceive />  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
 None.  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<behavior>](../../../../../docs/framework/configure-apps/file-schema/wcf/behavior-of-endpointbehaviors.md)|Specifies an endpoint behavior.|  
  
## Remarks  
 Use this behavior to instruct the channel listener to use a synchronous receive rather than the default, asynchronous. [!INCLUDE[indigo1](../../../../../includes/indigo1-md.md)] issues a new thread to pump for each accepted channel. If there are a lot of channels, there is the possibility of running out of threads.  
  
## See Also  
 <xref:System.ServiceModel.Configuration.SynchronousReceiveElement>  
 <xref:System.ServiceModel.Description.SynchronousReceiveBehavior>
