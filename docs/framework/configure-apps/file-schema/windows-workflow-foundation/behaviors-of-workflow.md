---
title: "&lt;behaviors&gt; of workflow"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "reference"
ms.assetid: 3c6017b6-0c4f-4192-bd67-9515f5d1ec82
caps.latest.revision: 2
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;behaviors&gt; of workflow
This element contains the **serviceBehaviors** collection.  Each element in the collection defines behavior elements consumed by workflow services. Each behavior element is identified by its unique **name** attribute.  
  
 \<system.ServiceModel>  
  
## Syntax  
  
```xml  
<behaviors>  
  <serviceBehaviors>  
  </serviceBehaviors>  
</behaviors>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
 None  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<serviceBehaviors>](../../../../../docs/framework/configure-apps/file-schema/windows-workflow-foundation/servicebehaviors-of-workflow.md)|This configuration section represents all the behaviors defined for a specific workflow service.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<system.serviceModel>](../../../../../docs/framework/configure-apps/file-schema/wcf/system-servicemodel.md)|The root element of all workflow configuration elements.|  
  
## See Also  
 <xref:System.ServiceModel.Configuration.BehaviorsSection>  
 <xref:System.ServiceModel.Configuration.ServiceBehaviorElementCollection>  
 <xref:System.ServiceModel.Configuration.ServiceBehaviorElement>  
 [Configuring and Extending the Runtime with Behaviors](../../../../../docs/framework/wcf/extending/configuring-and-extending-the-runtime-with-behaviors.md)
