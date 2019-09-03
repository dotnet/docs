---
title: "<behaviors> of workflow"
ms.date: "03/30/2017"
ms.topic: "reference"
ms.assetid: 3c6017b6-0c4f-4192-bd67-9515f5d1ec82
---
# \<behaviors> of workflow
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
|[\<serviceBehaviors>](servicebehaviors-of-workflow.md)|This configuration section represents all the behaviors defined for a specific workflow service.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<system.serviceModel>](../wcf/system-servicemodel.md)|The root element of all workflow configuration elements.|  
  
## See also

- <xref:System.ServiceModel.Configuration.BehaviorsSection>
- <xref:System.ServiceModel.Configuration.ServiceBehaviorElementCollection>
- <xref:System.ServiceModel.Configuration.ServiceBehaviorElement>
- [Configuring and Extending the Runtime with Behaviors](../../../wcf/extending/configuring-and-extending-the-runtime-with-behaviors.md)
