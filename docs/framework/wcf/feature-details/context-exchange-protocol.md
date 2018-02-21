---
title: "Context Exchange Protocol"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 3dfd38e0-ae52-491c-94f4-7a862b9843d4
caps.latest.revision: 6
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Context Exchange Protocol
This section describes the context exchange protocol introduced in [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)][!INCLUDE[netfx35_long](../../../../includes/netfx35-long-md.md)] release. This protocol allows the client channel to accept a context supplied by a service and apply it to all subsequent requests to that service sent over the same client channel instance. The implementation of the context exchange protocol can use one of the following two mechanisms to propagate the context between the server and the client: HTTP cookies or a SOAP header.  
  
 The context exchange protocol is implemented in a custom channel layer. The channel communicates the context to and from the application layer using a <xref:System.ServiceModel.Channels.ContextMessageProperty> property. For transmission between endpoints, the value of the context is either serialized as a SOAP header at the channel layer, or converted to or from the message properties that represent a HTTP request and response. In the latter case, it is expected that one of the underlying channel layers converts the HTTP request and response message properties to and from HTTP cookies, respectively. The choice of the mechanism used to exchange the context is done using the <xref:System.ServiceModel.Channels.ContextExchangeMechanism> property on the <xref:System.ServiceModel.Channels.ContextBindingElement>. Valid values are `HttpCookie` or `SoapHeader`.  
  
 On the client, an instance of a channel can operate in two modes based on the settings on the channel property, <xref:System.ServiceModel.Channels.IContextManager.Enabled%2A>.  
  
## Mode 1: Channel Context Management  
 This is the default mode where <xref:System.ServiceModel.Channels.IContextManager.Enabled%2A> is set to `true`. In this mode the context channel manages the context and caches the context during its lifetime. Context can be retrieved from the channel through channel property `IContextManager` by calling the `GetContext` method. The channel can also be pre-initialized with specific context before being opened by calling the `SetContext` method on the channel property. Once the channel is initialized with context it cannot be reset.  
  
 The following is a list of invariants in this mode:  
  
-   Any attempt to reset the context using `SetContext` after the channel has been opened throws an <xref:System.InvalidOperationException>.  
  
-   Any attempt to send context by using the <xref:System.ServiceModel.Channels.ContextMessageProperty> in an outgoing message throws an <xref:System.InvalidOperationException>.  
  
-   If a message is received from server with a specific context, when the channel has already been initialized with a specific context, this results in a <xref:System.ServiceModel.ProtocolException>.  
  
    > [!NOTE]
    >  It is appropriate to receive an initial context from the server only if the channel is opened without any context set explicitly.  
  
-   The <xref:System.ServiceModel.Channels.ContextMessageProperty> on incoming message is always null.  
  
## Mode 2: Application Context Management  
 This is the mode when <xref:System.ServiceModel.Channels.IContextManager.Enabled%2A> is set to `false`. In this mode the context channel does not manage context. It is the application's responsibility to retrieve, manage and apply context by using the <xref:System.ServiceModel.Channels.ContextMessageProperty>. Any attempt to call `GetContext` or `SetContext` results in an <xref:System.InvalidOperationException>.  
  
 No matter which mode is chosen the client channel factory supports <xref:System.ServiceModel.Channels.IRequestChannel>, <xref:System.ServiceModel.Channels.IRequestSessionChannel>, and <xref:System.ServiceModel.Channels.IDuplexSessionChannel> message exchange patterns.  
  
 On the service, an instance of the channel is responsible for converting the context supplied by the client on incoming messages to the <xref:System.ServiceModel.Channels.ContextMessageProperty>. The message property can then be accessed by the application layer or other channels further up in the call stack. The service channels also allow the application layer to specify a new context value to be propagated back to the client by attaching a <xref:System.ServiceModel.Channels.ContextMessageProperty> to the response message. This property is converted to the SOAP header or HTTP cookie that contains the context, which depends on the configuration of the binding. The service channel listener supports <xref:System.ServiceModel.Channels.IReplyChannel>, <xref:System.ServiceModel.Channels.IReplySessionChannel>, and <xref:System.ServiceModel.Channels.IReplySessionChannel> message exchange patterns.  
  
 The context exchange protocol introduces a new `wsc:Context` SOAP header to represent the context information when HTTP cookies are not used to propagate the context. The context header schema allows for any number of child elements, each with a string key and string content. The following is an example of a context header.  
  
 `<Context xmlns="http://schemas.microsoft.com/ws/2006/05/context">`  
  
 `<property name="myContext">context-2</property>`  
  
 `</Context>`  
  
 When in `HttpCookie` mode, cookies are set using the `SetCookie` header. The cookie name is `WscContext`. The value of the cookie is the Base64 encoding of the `wsc:Context` header. This value is enclosed in quotes.  
  
 The value of the context must be protected from modification while in transit for the same reason WS-Addressing headers are protected – the header is used to determine where to dispatch the request to on the service. The `wsc:Context` header is therefore required to be digitally signed or signed and encrypted at either the SOAP or transport level when the binding offers message protection capability. When HTTP cookies are used to propagate context, they should be protected using transport security.  
  
 Service endpoints that require support for the context exchange protocol can make it explicit in the published policy. Two new policy assertions have been introduced to represent the requirement for the client to support the context exchange protocol at the SOAP level or to enable HTTP cookie support. Generation of these assertions into the policy on the service is controlled by the value of the <xref:System.ServiceModel.Channels.ContextBindingElement.ContextExchangeMechanism%2A> property as follows:  
  
-   For <xref:System.ServiceModel.Channels.ContextExchangeMechanism.ContextSoapHeader>, the following assertion is generated:  
  
    ```xml  
    <IncludeContext   
    xmlns="http://schemas.microsoft.com/ws/2006/05/context"  
    protectionLevel="Sign" />  
    ```  
  
-   For <xref:System.ServiceModel.Channels.ContextExchangeMechanism.HttpCookie>, the following assertion is generated:  
  
    ```xml  
    <HttpUseCookie xmlns="http://schemas.xmlsoap.org/soap/http"/>  
    ```  
  
## See Also  
 [Web Services Protocols Interoperability Guide](../../../../docs/framework/wcf/feature-details/web-services-protocols-interoperability-guide.md)
