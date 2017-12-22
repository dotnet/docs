---
title: "Custom Channel Dispatcher"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 813acf03-9661-4d57-a3c7-eeab497321c6
caps.latest.revision: 7
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Custom Channel Dispatcher
This sample demonstrates how to build the channel stack in a custom way by implementing <xref:System.ServiceModel.ServiceHostBase> directly and how to create a custom channel dispatcher in Web host environment. The channel dispatcher interacts with <xref:System.ServiceModel.Channels.IChannelListener> to accept channels and retrieves messages from the channel stack. This sample also provides a basic sample to show how to build a channel stack in a Web host environment by using <xref:System.ServiceModel.Activation.VirtualPathExtension>.  
  
## Custom ServiceHostBase  
 This sample implements the base type <xref:System.ServiceModel.ServiceHostBase> instead of <xref:System.ServiceModel.ServiceHost> to demonstrate how to replace the [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] stack implementation with a custom message handling layer on top of the channel stack. You override the virtual method <xref:System.ServiceModel.ServiceHostBase.InitializeRuntime%2A> to build channel listeners and the channel dispatcher.  
  
 To implement a Web-hosted service, get the service extension <xref:System.ServiceModel.Activation.VirtualPathExtension> from the <xref:System.ServiceModel.ServiceHostBase.Extensions%2A> collection and add it to the <xref:System.ServiceModel.Channels.BindingParameterCollection> so that the transport layer knows how to configure the channel listener based on the hosting environment settings, that is, the Internet Information Services (IIS)/Windows Process Activation Service (WAS) settings.  
  
## Custom Channel Dispatcher  
 The custom channel dispatcher extends the type <xref:System.ServiceModel.Dispatcher.ChannelDispatcherBase>. This type implements the channel-layer programming logic. In this sample, only <xref:System.ServiceModel.Channels.IReplyChannel> is supported for request-reply message exchange pattern, but the custom channel dispatcher can be easily extended to other channel types.  
  
 The dispatcher first opens the channel listener and then accepts the singleton reply channel. With the channel, it starts to send messages (requests) in an infinite loop. For each request, it creates a reply message and sends it back to the client.  
  
## Creating a Response Message  
 The message processing is implemented in the type `MyServiceManager`. In the `HandleRequest` method, the `Action` header of the message is first checked to see whether the request is supported. A predefined SOAP action "http://tempuri.org/HelloWorld/Hello" is defined to provide message filtering. This is similar to the service contract concept in the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] implementation of <xref:System.ServiceModel.ServiceHost>.  
  
 For the correct SOAP action case, the sample retrieves the requested message data and generates a corresponding response to the request similar to what is seen in the <xref:System.ServiceModel.ServiceHost> case.  
  
 You specially handled the HTTP-GET verb by returning a custom HTML message, in this, case so that you can browse the service from a browser to see that it is compiled correctly. If the SOAP action does not match, send a fault message back to indicate that the request is not supported.  
  
 The client of this sample is a normal [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] client that does not assume anything from the service. So, the service is specially designed to match what you get from a normal [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)]<xref:System.ServiceModel.ServiceHost> implementation. As a result, only a service contract is required on the client.  
  
## Using the sample  
 Running the client application directly produces the following output.  
  
```Output  
Client is talking to a request/reply WCF service.   
Type what you want to say to the server: Howdy  
Server replied: You said: Howdy. Message id: 1  
Server replied: You said: Howdy. Message id: 2  
Server replied: You said: Howdy. Message id: 3  
Server replied: You said: Howdy. Message id: 4  
Server replied: You said: Howdy. Message id: 5  
```  
  
 You can also browse the service from a browser so that an HTTP-GET message gets processed on the server. This gets you well-formatted HTML text back.  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WCF\Extensibility\Channels\CustomChannelDispatcher`
