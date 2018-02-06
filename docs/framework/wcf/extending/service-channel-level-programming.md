---
title: "Service Channel-Level Programming"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
ms.assetid: 8d8dcd85-0a05-4c44-8861-4a0b3b90cca9
caps.latest.revision: 9
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Service Channel-Level Programming
This topic describes how to write a [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] service application without using the <xref:System.ServiceModel.ServiceHost?displayProperty=nameWithType> and its associated object model.  
  
## Receiving Messages  
 To be ready to receive and process messages, the following steps are required:  
  
1.  Create a binding.  
  
2.  Build a channel listener.  
  
3.  Open the channel listener.  
  
4.  Read the request and send a reply.  
  
5.  Close all channel objects.  
  
#### Creating a Binding  
 The first step in listening for and receiving messages is creating a binding. [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] ships with several built-in or system-provided bindings that can be used directly by instantiating one of them. In addition, you can also create your own custom binding by instantiating a CustomBinding class which is what the code in listing 1 does.  
  
 The code example below creates an instance of <xref:System.ServiceModel.Channels.CustomBinding?displayProperty=nameWithType> and adds an <xref:System.ServiceModel.Channels.HttpTransportBindingElement?displayProperty=nameWithType> to its Elements collection which is a collection of binding elements that are used to build the channel stack. In this example, because the elements collection has only the <xref:System.ServiceModel.Channels.HttpTransportBindingElement>, the resulting channel stack has only the HTTP transport channel.  
  
#### Building a ChannelListener  
 After creating a binding, we call <!--zz<xref:System.ServiceModel.Channels.Binding.BuildChannelListener%601%2A?displayProperty=nameWithType>--> `System.ServiceModel.Channels.Binding.BuildChannelListener` to build the channel listener where the type parameter is the channel shape to create. In this example we are using <xref:System.ServiceModel.Channels.IReplyChannel?displayProperty=nameWithType> because we want to listen for incoming messages in a request/reply message exchange pattern.  
  
 <xref:System.ServiceModel.Channels.IReplyChannel> is used for receiving request messages and sending back reply messages. Calling <xref:System.ServiceModel.Channels.IReplyChannel.ReceiveRequest%2A?displayProperty=nameWithType> returns an <xref:System.ServiceModel.Channels.IRequestChannel?displayProperty=nameWithType>, which can be used to receive the request message and to send back a reply message.  
  
 When creating the listener, we pass the network address on which it listens, in this case `http://localhost:8080/channelapp`. In general, each transport channel supports one or possibly several address schemes, for example, the HTTP transport supports both http and https schemes.  
  
 We also pass an empty <xref:System.ServiceModel.Channels.BindingParameterCollection?displayProperty=nameWithType> when creating the listener. A binding parameter is a mechanism to pass parameters that control how the listener should be built. In our example, we are not using any such parameters so we pass an empty collection.  
  
#### Listening for Incoming Messages  
 We then call <xref:System.ServiceModel.ICommunicationObject.Open%2A?displayProperty=nameWithType> on the listener and start accepting channels. The behavior of <xref:System.ServiceModel.Channels.IChannelListener%601.AcceptChannel%2A?displayProperty=nameWithType> depends on whether the transport is connection-oriented or connection-less. For connection-oriented transports, <xref:System.ServiceModel.Channels.IChannelListener%601.AcceptChannel%2A> blocks until a new connection request comes in at which point it returns a new channel that represents that new connection. For connection-less transports, such as HTTP, <xref:System.ServiceModel.Channels.IChannelListener%601.AcceptChannel%2A> returns immediately with the one and only channel that the transport listener creates.  
  
 In this example, the listener returns a channel that implements <xref:System.ServiceModel.Channels.IReplyChannel>. To receive messages on this channel we first call <xref:System.ServiceModel.ICommunicationObject.Open%2A?displayProperty=nameWithType> on it to place it in a state ready for communication. We then call <xref:System.ServiceModel.Channels.IReplyChannel.ReceiveRequest%2A> which blocks until a message arrives.  
  
#### Reading the Request and Sending a Reply  
 When <xref:System.ServiceModel.Channels.IReplyChannel.ReceiveRequest%2A> returns a <xref:System.ServiceModel.Channels.RequestContext>, we get the received message using its <xref:System.ServiceModel.Channels.RequestContext.RequestMessage%2A> property. We write out the message’s action and body content, (which we assume is a string).  
  
 To send a reply, we create a new reply message in this case passing back the string data we received in the request. We then call <xref:System.ServiceModel.Channels.RequestContext.Reply%2A> to send the reply message.  
  
#### Closing Objects  
 To avoid leaking resources, it is very important to close objects used in communications when they are no longer required. In this example we close the request message, the request context, the channel and the listener.  
  
 The following code example shows a basic service in which a channel listener receives only one message. A real service keeps accepting channels and receiving messages until the service exits.  
  
 [!code-csharp[ChannelProgrammingBasic#1](../../../../samples/snippets/csharp/VS_Snippets_CFX/channelprogrammingbasic/cs/serviceprogram.cs#1)]
 [!code-vb[ChannelProgrammingBasic#1](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/channelprogrammingbasic/vb/serviceprogram.vb#1)]
