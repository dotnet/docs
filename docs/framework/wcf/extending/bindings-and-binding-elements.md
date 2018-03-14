---
title: "Bindings and Binding Elements"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "binding elements [WCF]"
ms.assetid: 765ff77b-7682-4ea3-90eb-e4d751e37379
caps.latest.revision: 12
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Bindings and Binding Elements
Bindings are collections of special configuration elements, called *binding elements*, which are evaluated by the service runtime whenever a client or service endpoint is being constructed. The type and order of the binding elements within a binding determines the selection and stacking order of the protocol and transport channels in an endpoint's channel stack.  
  
 Bindings, especially the system-provided bindings, usually also have a number of configuration properties that reflect the most commonly modified properties of the encapsulated binding elements.  
  
 A binding must contain exactly one transport binding element. Each transport binding element implies a default message encoding binding element, which can be overridden by adding at most one message encoding binding element to the binding. In addition to the transport and encoder binding elements, the binding may contain any number of protocol binding elements that together implement the functionality needed to service and send a SOAP message from one endpoint to another. For details, see [Using Bindings to Configure Services and Clients](../../../../docs/framework/wcf/using-bindings-to-configure-services-and-clients.md).  
  
## Extending Bindings and Binding Elements  
 [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] includes system-provided bindings that cover a wide range of scenarios. (For more, see [System-Provided Bindings](../../../../docs/framework/wcf/system-provided-bindings.md).) There may be times, however, when you need to create and use a binding that is not included in [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)]. The following scenarios require the creation of a new binding.  
  
-   To use a new binding element (such as a new transport, encoding, or protocol binding element), you must create a new binding that includes that binding element. For example, if you added a custom `UdpTransportBindingElement` for UDP transport, you would need to create a new binding to make use of it. For information about performing this behavior using the <xref:System.ServiceModel.Channels.CustomBinding?displayProperty=nameWithType> type, see [Custom Bindings](../../../../docs/framework/wcf/extending/custom-bindings.md).  
  
-   To configure existing binding elements in a way that the system-provided bindings to not expose on public properties. For example, you must create a new binding to change the order in which signing and encryption operations are performed. For information about performing this behavior, see [How to: Customize a System-Provided Binding](../../../../docs/framework/wcf/extending/how-to-customize-a-system-provided-binding.md).  
  
-   To establish corporate standard bindings that expose only specific configuration options. For example, to create for your company a variant of the <xref:System.ServiceModel.WSHttpBinding> for your company in which security cannot be disabled, create a new binding that behaves like the <xref:System.ServiceModel.WSHttpBinding>, but with security always on. For details, see [Creating User-Defined Bindings](../../../../docs/framework/wcf/extending/creating-user-defined-bindings.md).  
  
-   To perform some customization of metadata, typically but not necessarily to configure or use some custom binding element. For more information about providing metadata support to bindings and binding elements, see [Configuration and Metadata Support](../../../../docs/framework/wcf/extending/configuration-and-metadata-support.md).  
  
-  
  
## Channels, Bindings, and Binding Elements  
 Bindings and binding elements are the connection between the application programming model, which includes the attributes and behaviors, and the channel model, which includes the factories and listeners, message encoders, and transport and protocol implementations. Typically, binding elements and bindings are implemented to enable channels to be used by the application layer.  
  
 The channel layer hands off or receives messages to and from the service layer and transports those messages between endpoints. On a client, the channel layer is a stack of channel factories that create channels to a network endpoint. On a service, the channel layer is a stack of channel listeners that accept channels received at a network endpoint.  
  
 There are two general types of channels: protocol channels and transport channels. Transport channels are responsible for the actual transmission of a message from one network endpoint to another. Transport channels must have a default message encoder and should be able to use an alternate message encoder supplied through a message encoder binding element. A message encoder is responsible for turning a <xref:System.ServiceModel.Channels.Message?displayProperty=nameWithType> into a wire representation and vice-versa. Protocol channels are responsible for implementing SOAP-level protocols (for example, WS-Security or WS-ReliableMessaging).  
  
 The primary requirement for transport and protocol channels is that they implement the required channel interfaces. To create a working channel layer they must have associated factories and listeners, and so on. To use the channel implementations from [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] there needs to be an associated binding elements derived from <xref:System.ServiceModel.Channels.BindingElement> for each channel and there should be a related binding extension element for inclusion into configuration files that derives from <xref:System.ServiceModel.Configuration.BindingElementExtensionElement>.  
  
 As mentioned earlier, binding elements for message encoders, protocol, and transport channel implementations can be stacked to form a channel stack and the mechanism to line them up into an ordered set is the binding. Bindings and binding elements connect the application programming model to the channel model. You can use your channel implementations from code directly, but unless encoders, transports, and protocols are implemented as binding elements they cannot be used from the service layer programming model.  
  
 For details about developing channels and their binding elements, see [Extending the Channel Layer](../../../../docs/framework/wcf/extending/extending-the-channel-layer.md).
