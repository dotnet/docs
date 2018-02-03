---
title: "Creating a BindingElement"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 01a35307-a41f-4ef6-a3db-322af40afc99
caps.latest.revision: 12
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Creating a BindingElement
Bindings and binding elements (objects that extend <xref:System.ServiceModel.Channels.Binding?displayProperty=nameWithType> and <xref:System.ServiceModel.Channels.BindingElement?displayProperty=nameWithType>, respectively) are the place where the [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] application model is associated with channel factories and channel listeners. Without bindings, using custom channels requires programming at the channel level as described in [Service Channel-Level Programming](../../../../docs/framework/wcf/extending/service-channel-level-programming.md) and [Client Channel-Level Programming](../../../../docs/framework/wcf/extending/client-channel-level-programming.md). This topic discusses the minimum requirement to enable using your channel in [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)], the development of a <xref:System.ServiceModel.Channels.BindingElement> for your channel, and enable use from the application as described in step 4 of [Developing Channels](../../../../docs/framework/wcf/extending/developing-channels.md).  
  
## Overview  
 Creating a <xref:System.ServiceModel.Channels.BindingElement> for your channel enables developers to use it in an [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] application. <xref:System.ServiceModel.Channels.BindingElement> objects can be used from the <xref:System.ServiceModel.ServiceHost?displayProperty=nameWithType> class to connect an [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] application to your channel without having to the precise type information of your channel.  
  
 Once a <xref:System.ServiceModel.Channels.BindingElement> has been created, you can enable more functionality depending upon your requirements by following the remaining channel development steps described in [Developing Channels](../../../../docs/framework/wcf/extending/developing-channels.md).  
  
## Adding a Binding Element  
 To implement a custom <xref:System.ServiceModel.Channels.BindingElement>, write a class that inherits from <xref:System.ServiceModel.Channels.BindingElement>. For example, if you have developed a `ChunkingChannel` that can break up large messages into chunks and reassemble them on the other end, you can use this channel in any binding by implementing a <xref:System.ServiceModel.Channels.BindingElement> and configuring the binding to use it. The remainder of this topic uses the `ChunkingChannel` as an example to demonstrate the requirements of implementing a binding element.  
  
 A `ChunkingBindingElement` is responsible for creating the `ChunkingChannelFactory` and `ChunkingChannelListener`. It overrides <xref:System.ServiceModel.Channels.BindingElement.CanBuildChannelFactory%2A> and <xref:System.ServiceModel.Channels.BindingElement.CanBuildChannelListener%2A> implementations, and checks that the type parameter is <xref:System.ServiceModel.Channels.IDuplexSessionChannel> (in our example this is the only channel shape supported by the `ChunkingChannel`) and that the other binding elements in the binding support this channel shape.  
  
 <xref:System.ServiceModel.Channels.BindingElement.BuildChannelFactory%2A> first checks that the requested channel shape can be built and then gets a list of message actions to be chunked. It then creates a new `ChunkingChannelFactory`, passing it the inner channel factory. (If you are creating a transport binding element, that element is the last one in the binding stack and therefore must create a channel listener or channel factory.)  
  
 <xref:System.ServiceModel.Channels.BindingElement.BuildChannelListener%2A> has a similar implementation for creating `ChunkingChannelListener` and passing it the inner channel listener.  
  
 As another example using a transport channel, the [Transport: UDP](../../../../docs/framework/wcf/samples/transport-udp.md) sample provides the following override.  
  
 In the sample, the binding element is `UdpTransportBindingElement`, which derives from <xref:System.ServiceModel.Channels.TransportBindingElement>. It overrides the following methods to build the factories associated with the channel.  
  
```  
public IChannelFactory<TChannel> BuildChannelFactory<TChannel>(BindingContext context)  
{  
            return (IChannelFactory<TChannel>)(object)new UdpChannelFactory(this, context);  
}  
  
public IChannelListener<TChannel> BuildChannelListener<TChannel>(BindingContext context)  
{  
            return (IChannelListener<TChannel>)(object)new UdpChannelListener(this, context);  
}  
```  
  
 It also contains members for cloning the `BindingElement` and returning our scheme (soap.udp).  
  
#### Protocol Binding Elements  
 New binding elements can replace or augment any of the included binding elements, adding new transports, encodings, or higher-level protocols. To create a new Protocol Binding Element, start by extending the <xref:System.ServiceModel.Channels.BindingElement> class. At a minimum, you must then implement the <xref:System.ServiceModel.Channels.BindingElement.Clone%2A?displayProperty=nameWithType> and implement the `ChannelProtectionRequirements` using <xref:System.ServiceModel.Channels.IChannel.GetProperty%2A?displayProperty=nameWithType>. This returns the <xref:System.ServiceModel.Security.ChannelProtectionRequirements> for this binding element.  For more information, see <xref:System.ServiceModel.Security.ChannelProtectionRequirements>.  
  
 <xref:System.ServiceModel.Channels.BindingElement.Clone%2A> should return a fresh copy of this binding element. As a best practice, we recommend that binding element authors implement <xref:System.ServiceModel.Channels.BindingElement.Clone%2A> by using a copy constructor that calls the base copy constructor, then clones any additional fields in this class.  
  
#### Transport Binding Elements  
 To create a new Transport Binding Element, extend the <xref:System.ServiceModel.Channels.TransportBindingElement> interface. At a minimum, you must then implement the <xref:System.ServiceModel.Channels.BindingElement.Clone%2A> method and the <xref:System.ServiceModel.Channels.TransportBindingElement.Scheme%2A?displayProperty=nameWithType> property.  
  
 <xref:System.ServiceModel.Channels.BindingElement.Clone%2A> – Should return a fresh copy of this Binding Element.  As a best practice, we recommend that Binding Element authors implement Clone by way of a copy constructor that calls the base copy constructor, then clones any additional fields in this class.  
  
 <xref:System.ServiceModel.Channels.TransportBindingElement.Scheme%2A> – The <xref:System.ServiceModel.Channels.TransportBindingElement.Scheme%2A> get property returns the URI scheme for the transport protocol represented by the binding element. For example, the <xref:System.ServiceModel.Channels.HttpTransportBindingElement?displayProperty=nameWithType> and the <xref:System.ServiceModel.Channels.TcpTransportBindingElement?displayProperty=nameWithType> return "http" and "net.tcp" from their respective <xref:System.ServiceModel.Channels.TransportBindingElement.Scheme%2A> properties.  
  
#### Encoding Binding Elements  
 To create new Encoding Binding Elements, start by extending the <xref:System.ServiceModel.Channels.BindingElement> class and implementing the <xref:System.ServiceModel.Channels.MessageEncodingBindingElement?displayProperty=nameWithType> class. At a minimum, you must then implement the <xref:System.ServiceModel.Channels.BindingElement.Clone%2A>, <xref:System.ServiceModel.Channels.MessageEncodingBindingElement.CreateMessageEncoderFactory%2A?displayProperty=nameWithType> methods and the <xref:System.ServiceModel.Channels.MessageEncodingBindingElement.MessageVersion%2A?displayProperty=nameWithType> property.  
  
-   <xref:System.ServiceModel.Channels.BindingElement.Clone%2A>. Returns a fresh copy of this binding element. As a best practice, we recommend that binding element authors implement <xref:System.ServiceModel.Channels.BindingElement.Clone%2A> by using a copy constructor that calls the base copy constructor, then clones any additional fields in this class.  
  
-   <xref:System.ServiceModel.Channels.MessageEncodingBindingElement.CreateMessageEncoderFactory%2A>. Returns a <xref:System.ServiceModel.Channels.MessageEncoderFactory>, which provides a handle to the actual class that implements your new encoder and which should extend <xref:System.ServiceModel.Channels.MessageEncoder>. For more information, see <xref:System.ServiceModel.Channels.MessageEncoderFactory> and <xref:System.ServiceModel.Channels.MessageEncoder>.  
  
-   <xref:System.ServiceModel.Channels.MessageEncodingBindingElement.MessageVersion%2A>. Returns the <xref:System.ServiceModel.Channels.MessageVersion> used in this encoding, which represents the versions of SOAP and WS-Addressing in use.  
  
 For a complete listing of optional methods and properties for user-defined encoding binding elements, see <xref:System.ServiceModel.Channels.MessageEncodingBindingElement>.  
  
 For more information on creating a new binding element, see [Creating User-Defined Bindings](../../../../docs/framework/wcf/extending/creating-user-defined-bindings.md).  
  
 Once you have created a binding element for your channel, return to the [Developing Channels](../../../../docs/framework/wcf/extending/developing-channels.md) topic to see whether you want to add configuration file support to your binding element, if and how to add metadata publication support, and whether and how to construct a user-defined binding that uses your binding element.  
  
## See Also  
 <xref:System.ServiceModel.Channels.BindingElement>  
 [Developing Channels](../../../../docs/framework/wcf/extending/developing-channels.md)  
 [Transport: UDP](../../../../docs/framework/wcf/samples/transport-udp.md)
