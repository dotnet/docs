---
description: "Learn more about: Developing Channels"
title: "Developing Channels"
ms.date: "03/30/2017"
ms.assetid: 0513af9f-a0c2-457b-9a50-5b6bfee48513
---
# Developing Channels

To develop a protocol or transport channel that can be used with the Windows Communication Foundation (WCF) application layer requires several steps. This topic describes those steps and points you to specific topics for more information. To understand the channel model and the various types that are mentioned in this topic, see [Channel Model Overview](channel-model-overview.md). For a complete transport channel sample, see [Transport: UDP](/previous-versions/dotnet/framework/wcf/samples/transport-udp).  
  
## The Channel Development Task List  

 The steps to create a user-defined channel are as follows. All channels must:  
  
1. Decide which of the channel Message Exchange Patterns (<xref:System.ServiceModel.Channels.IOutputChannel>, <xref:System.ServiceModel.Channels.IInputChannel>, <xref:System.ServiceModel.Channels.IDuplexChannel>, <xref:System.ServiceModel.Channels.IRequestChannel>, or <xref:System.ServiceModel.Channels.IReplyChannel>) your <xref:System.ServiceModel.Channels.IChannelFactory> and <xref:System.ServiceModel.Channels.IChannelListener> will support, as well as whether it will support the sessionful variations of these interfaces. For details, see [Choosing a Message Exchange Pattern](choosing-a-message-exchange-pattern.md).  
  
2. Create a channel factory and listener (<xref:System.ServiceModel.Channels.IChannelFactory> and <xref:System.ServiceModel.Channels.IChannelListener>) that support your message exchange pattern. For details about developing factories, see [Client: Channel Factories and Channels](client-channel-factories-and-channels.md). For details about developing listeners, see [Service: Channel Listeners and Channels](service-channel-listeners-and-channels.md).  
  
3. Ensure that any network-specific exceptions are normalized to either <xref:System.TimeoutException?displayProperty=nameWithType> or the appropriate derived class of <xref:System.ServiceModel.CommunicationException>. For details, see [Handling Exceptions and Faults](handling-exceptions-and-faults.md).  
  
4. To enable use from the application layer, add a <xref:System.ServiceModel.Channels.BindingElement> that adds the custom channel to a channel stack. For more information, see [Creating a BindingElement](creating-a-bindingelement.md).  
  
 The following additional steps are required to enable more complete support at the application layer:  
  
1. Add a binding element extension section to expose the new binding element to the configuration system. For more information, see [Configuration and Metadata Support](configuration-and-metadata-support.md).  
  
2. Add metadata extensions to communicate capabilities to other endpoints. For more information, see [Configuration and Metadata Support](configuration-and-metadata-support.md).  
  
3. Add a binding that pre-configures a stack of binding elements according to a well-defined profile. For more information, see [Creating User-Defined Bindings](creating-user-defined-bindings.md).  
  
4. Add a binding section and binding configuration element to expose the binding to the configuration system. For more information, see [Configuration and Metadata Support](configuration-and-metadata-support.md).  
  
## See also

- [Extending Bindings](extending-bindings.md)
