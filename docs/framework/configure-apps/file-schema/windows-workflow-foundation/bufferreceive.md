---
title: "&lt;bufferReceive&gt;"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "reference"
ms.assetid: b23c3a54-10d4-4f13-ab6d-98b26b76f22a
caps.latest.revision: 3
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;bufferReceive&gt;
A service behavior that enables a service to use buffered receive processing, which enables a workflow service to process out-of-order messages.  
  
\<system.ServiceModel>  
\<behaviors>  
\<serviceBehaviors>  
\<behavior>  
\<bufferReceive>  
  
## Syntax  
  
```xml  
<behaviors>
  <serviceBehaviors>
    <behavior name="String">
      <bufferReceive maxPendingMessagesPerChannel="Integer" />
    </behavior>
  </serviceBehaviors>
</behaviors>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|maxPendingMessagesPerChannel|An integer that specifies the maximum number of pending messages allowed for each channel. The default value is 512. This property limits the number of out-of-order messages that can be received by a workflow service.|  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<behavior> of \<serviceBehaviors>](../../../../../docs/framework/configure-apps/file-schema/windows-workflow-foundation/behavior-of-servicebehaviors-of-workflow.md)|Specifies a behavior element.|  
  
## See Also  
<!-- <xref:System.ServiceModel.Activities.Description.BufferReceiveServiceBehavior>  -->
 <xref:System.ServiceModel.Activities.Configuration.BufferedReceiveElement>
