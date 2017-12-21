---
title: "&lt;bindings&gt;"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: b62cd369-5409-4030-8490-9759a462dd3a
caps.latest.revision: 10
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;bindings&gt;
This section holds a collection of standard and custom bindings. Each entry is a `binding` element that can be identified by its unique `name`. Services use bindings by linking them using the `name`. Starting with [!INCLUDE[netfx40_short](../../../../../includes/netfx40-short-md.md)], bindings and behaviors are not required to have a name. For more information about default configuration and nameless bindings and behaviors, see [Simplified Configuration](../../../../../docs/framework/wcf/simplified-configuration.md) and [Simplified Configuration for WCF Services](../../../../../docs/framework/wcf/samples/simplified-configuration-for-wcf-services.md).  
  
## System-Provided Binding  
 System-provided bindings hide the complexity of the WCF messaging stack. Applications using system-provided bindings do not require full control over the stack. The attributes exposed on each system-provided binding are the ones most appropriate for the usage scenario the binding addresses.  
  
 The configuration section for each system-provided binding can define several configurations used to configure the binding. Each configuration is identified by a unique name.  
  
 It is not possible to add elements or attributes to a system-provided binding. To do so, you should implement a custom binding as described in the "Custom Binding" section of this topic. It is possible to define a custom binding that mimics a system-provided binding perfectly and adds a few settings the user application wants to have control over.  
  
 For a list of system-provided bindings, see [System-Provided Bindings](../../../../../docs/framework/wcf/system-provided-bindings.md).  
  
## Custom Binding  
 Custom bindings provide full control over the WCF messaging stack. An individual binding defines the message stack by specifying the configuration elements for the stack elements in the order they appear on the stack. Each element defines and configures the one element of the stack. There must be one and only one `transport` element in each custom binding. Without this element, the messaging stack is incomplete.  
  
 The order in which elements appear in the stack matters, because it is the order in which operations are applied to the message. The required order of stack elements is the following:  
  
1.  Transactions (optional)  
  
2.  Reliable Messaging (optional)  
  
3.  Security (optional)  
  
4.  Encoder  
  
5.  Transport  
  
 Custom bindings are identified by their `name` attribute. For more information on custom bindings, see [Custom Bindings](../../../../../docs/framework/wcf/extending/custom-bindings.md).  
  
## See Also  
 <xref:System.ServiceModel.Configuration.BindingsSection>  
 <xref:System.ServiceModel.Channels.Binding>  
 <xref:System.ServiceModel.Channels.BindingElement>  
 [Bindings](../../../../../docs/framework/wcf/bindings.md)  
 [Custom Bindings](../../../../../docs/framework/wcf/extending/custom-bindings.md)  
 [\<customBinding>](../../../../../docs/framework/configure-apps/file-schema/wcf/custombinding.md)  
 [\<binding>](../../../../../docs/framework/misc/binding.md)
