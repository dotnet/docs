---
title: "Creating User-Defined Bindings"
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
  - "user-defined bindings [WCF]"
ms.assetid: c4960675-d701-4bc9-b400-36a752fdd08b
caps.latest.revision: 19
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Creating User-Defined Bindings
There are several ways to create bindings not provided by the system:  
  
-   Create a custom binding, based on the <xref:System.ServiceModel.Channels.CustomBinding> class, which is a container that you fill with binding elements. The custom binding is then added to a service endpoint. You can create the custom binding either programmatically or in an application configuration file. To use a binding element from an application configuration file, the binding element must extend <xref:System.ServiceModel.Configuration.BindingElementExtensionElement>. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] custom bindings, see [Custom Bindings](../../../../docs/framework/wcf/extending/custom-bindings.md) and <xref:System.ServiceModel.Channels.CustomBinding>.  
  
-   You can create a class that derives from a standard binding. For example, you can derive a class from <xref:System.ServiceModel.WSHttpBinding> and override <xref:System.ServiceModel.Channels.CustomBinding.CreateBindingElements%2A> method to obtain the binding elements and insert a custom binding element or establish a particular value for security.  
  
-   You can create a new <xref:System.ServiceModel.Channels.Binding> type to completely control the entire binding implementation.  
  
## The Order of Binding Elements  
 Each binding element represents a processing step when sending or receiving messages. At runtime, binding elements create the channels and listeners necessary to build outgoing and incoming channel stacks.  
  
 There are three main types of binding elements: Protocol Binding Elements, Encoding Binding Elements and Transport Binding Elements.  
  
 Protocol Binding Elements – These elements represent higher-level processing steps that act on messages. Channels and listeners created by these binding elements can add, remove, or modify the message content. A given binding may have an arbitrary number of protocol binding elements, each inheriting from <xref:System.ServiceModel.Channels.BindingElement>. [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] includes several protocol binding elements, including the <xref:System.ServiceModel.Channels.ReliableSessionBindingElement> and the <xref:System.ServiceModel.Channels.SymmetricSecurityBindingElement>.  
  
 Encoding Binding Element – These elements represent transformations between a message and an encoding ready for transmission on the wire. Typical [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] bindings include exactly one encoding binding element. Examples of encoding binding elements include the <xref:System.ServiceModel.Channels.MtomMessageEncodingBindingElement>, the <xref:System.ServiceModel.Channels.BinaryMessageEncodingBindingElement>, and the <xref:System.ServiceModel.Channels.TextMessageEncodingBindingElement>. If an encoding binding element is not specified for a binding, a default encoding is used. The default is text when the transport is HTTP and binary otherwise.  
  
 Transport Binding Element – These elements represent the transmission of an encoding message on a transport protocol. Typical [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] bindings include exactly one transport binding element, which inherits from <xref:System.ServiceModel.Channels.TransportBindingElement>. Examples of transport binding elements include the <xref:System.ServiceModel.Channels.TcpTransportBindingElement>, the <xref:System.ServiceModel.Channels.HttpTransportBindingElement>, and the <xref:System.ServiceModel.Channels.NamedPipeTransportBindingElement>.  
  
 When creating new bindings, the order of the added binding elements is important. Always add binding elements in the following order:  
  
|Layer|Options|Required|  
|-----------|-------------|--------------|  
|Transaction Flow|<xref:System.ServiceModel.Channels.TransactionFlowBindingElement?displayProperty=nameWithType>|No|  
|Reliability|<xref:System.ServiceModel.Channels.ReliableSessionBindingElement?displayProperty=nameWithType>|No|  
|Security|<xref:System.ServiceModel.Channels.SecurityBindingElement?displayProperty=nameWithType>|No|  
|Composite Duplex|<xref:System.ServiceModel.Channels.CompositeDuplexBindingElement?displayProperty=nameWithType>|No|  
|Encoding|Text, Binary, MTOM, Custom|Yes*|  
|Transport|TCP, Named Pipes, HTTP, HTTPS, MSMQ, Custom|Yes|  
  
 *Because an encoding is required for each binding, if an encoding is not specified, [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] adds a default encoding for you. The default is Text/XML for the HTTP and HTTPS transports, and Binary otherwise.  
  
## Creating a new Binding Element  
 In addition to the types derived from <xref:System.ServiceModel.Channels.BindingElement> that are provided by [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)], you can create your own binding elements. This lets you customize the way the stack of bindings is created and the components that go in it by creating your own <xref:System.ServiceModel.Channels.BindingElement> that can be composed with the other system-provided types in the stack.  
  
 For example, if you implement a `LoggingBindingElement` that provides the ability to log the message to a database, you must place it above a transport channel in the channel stack. In this case, the application creates a custom binding that composed the `LoggingBindingElement` with `TcpTransportBindingElement`, as in the following example.  
  
```csharp  
Binding customBinding = new CustomBinding(  
  new LoggingBindingElement(),   
  new TcpTransportBindingElement()  
);  
```  
  
 How you write your new binding element depends on its exact functionality. One of the samples, [Transport: UDP](../../../../docs/framework/wcf/samples/transport-udp.md), provides a detailed description of how to implement one kind of binding element.  
  
## Creating a New Binding  
 A user-created binding element can be used in two ways. The previous section illustrates the first way: through a custom binding. A custom binding allows the user to create their own binding based on an arbitrary set of binding elements, including user-created ones.  
  
 If you use the binding in more than one application, create your own binding and extend the <xref:System.ServiceModel.Channels.Binding>. This avoids manually creating a custom binding every time you want to use it. A user-defined binding allows you to define the binding’s behavior and include user-defined binding elements. And it is *pre-packaged*: you do not have to rebuild the binding every time you use it.  
  
 At a minimum, a user-defined binding must implement the <xref:System.ServiceModel.Channels.Binding.CreateBindingElements%2A> method and the <xref:System.ServiceModel.Channels.Binding.Scheme%2A> property.  
  
 The <xref:System.ServiceModel.Channels.Binding.CreateBindingElements%2A> method returns a new <xref:System.ServiceModel.Channels.BindingElementCollection> that contains the binding elements for the binding. The collection is ordered, and should contain the protocol binding elements first, followed by the encoding binding element, followed by the transport binding element. When using the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] system-provided binding elements, you must follow the binding element ordering rules specified in [Custom Bindings](../../../../docs/framework/wcf/extending/custom-bindings.md). This collection should never reference objects referenced within the user-defined binding class; consequently, binding authors must return a `Clone()` of the <xref:System.ServiceModel.Channels.BindingElementCollection> on each call to <xref:System.ServiceModel.Channels.Binding.CreateBindingElements%2A>.  
  
 The <xref:System.ServiceModel.Channels.Binding.Scheme%2A> property represents the URI scheme for the transport protocol in use on the binding. For example, the *WSHttpBinding* and the *NetTcpBinding* return "http" and "net.tcp" from their respective <xref:System.ServiceModel.Channels.Binding.Scheme%2A> properties.  
  
 For a complete list of optional methods and properties for user-defined bindings, see <xref:System.ServiceModel.Channels.Binding>.  
  
### Example  
 This example implements profile binding in `SampleProfileUdpBinding`, which derives from <xref:System.ServiceModel.Channels.Binding>. The `SampleProfileUdpBinding` contains up to four binding elements within it: one user-created `UdpTransportBindingElement`; and three system-provided: `TextMessageEncodingBindingElement`, `CompositeDuplexBindingElement`, and `ReliableSessionBindingElement`.  
  
```  
public override BindingElementCollection CreateBindingElements()  
{     
    BindingElementCollection bindingElements = new BindingElementCollection();  
    if (ReliableSessionEnabled)  
    {  
        bindingElements.Add(session);  
        bindingElements.Add(compositeDuplex);  
    }  
    bindingElements.Add(encoding);  
    bindingElements.Add(transport);  
    return bindingElements.Clone();  
}  
```  
  
## Security Restrictions with Duplex Contracts  
 Not all binding elements are compatible with each other. In particular, there are some restrictions on security binding elements when used with duplex contracts.  
  
### One-Shot Security  
 You can implement "one-shot" security, where all the necessary security credentials are sent in a single message, by setting the `negotiateServiceCredential` attribute of the \<message> configuration element to `false`.  
  
 One-shot authentication does not work with duplex contracts.  
  
 For Request-Reply contracts, one-shot authentication works only if the binding stack below the security binding element supports creating <xref:System.ServiceModel.Channels.IRequestChannel> or <xref:System.ServiceModel.Channels.IRequestSessionChannel> instances.  
  
 For one-way contracts, one-shot authentication works if the binding stack below the security binding element supports creating <xref:System.ServiceModel.Channels.IRequestChannel>, <xref:System.ServiceModel.Channels.IRequestSessionChannel>, <xref:System.ServiceModel.Channels.IOutputChannel> or <xref:System.ServiceModel.Channels.IOutputSessionChannel> instances.  
  
### Cookie-mode Security Context Tokens  
 Cookie mode security context tokens cannot be used with duplex contracts.  
  
 For Request-Reply contracts, cookie-mode security context tokens work only if the binding stack below the security binding element supports creating <xref:System.ServiceModel.Channels.IRequestChannel> or <xref:System.ServiceModel.Channels.IRequestSessionChannel> instances.  
  
 For one-way contracts, cookie-mode security context tokens works if the binding stack below the security binding element supports creating <xref:System.ServiceModel.Channels.IRequestChannel> or <xref:System.ServiceModel.Channels.IRequestSessionChannel> instances.  
  
### Session-mode Security Context Tokens  
 Session mode SCT works for duplex contracts if the binding stack below the security binding element supports creating <xref:System.ServiceModel.Channels.IDuplexChannel> or <xref:System.ServiceModel.Channels.IDuplexSessionChannel> instances.  
  
 Session mode SCT works for Request-Reply contracts if the binding stack below the security binding element supports creating <xref:System.ServiceModel.Channels.IDuplexChannel>, <xref:System.ServiceModel.Channels.IDuplexSessionChannel>, <xref:System.ServiceModel.Channels.IRequestChannel> or <xref:System.ServiceModel.Channels.IRequestSessionChannel>, instances.  
  
 Session mode SCT works for 1-way contracts if the binding stack below the security binding element supports creating <xref:System.ServiceModel.Channels.IDuplexChannel>, <xref:System.ServiceModel.Channels.IDuplexSessionChannel>, <xref:System.ServiceModel.Channels.IRequestChannel> or <xref:System.ServiceModel.Channels.IRequestSessionChannel> instances.  
  
## Deriving from a Standard Binding  
 Instead of creating an entirely new binding class, it may be possible for you to extend one of the existing system-provided bindings. Much like the preceding case, you must override the <xref:System.ServiceModel.Channels.Binding.CreateBindingElements%2A> method and the <xref:System.ServiceModel.Channels.Binding.Scheme%2A> property.  
  
## See Also  
 <xref:System.ServiceModel.Channels.Binding>  
 [Custom Bindings](../../../../docs/framework/wcf/extending/custom-bindings.md)
