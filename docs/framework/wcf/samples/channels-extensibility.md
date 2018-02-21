---
title: "Channels Extensibility"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 4cc3b20b-778a-4ae8-b58c-a3822fb13065
caps.latest.revision: 3
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Channels Extensibility
This section contains samples that demonstrate custom channels.  
  
## In This Section  
 [Local Channel](../../../../docs/framework/wcf/samples/local-channel.md)  
 Demonstrates the local channel, a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] transport channel that is used for communication within the same application domain.  
  
 [Reliable Secure Profile](../../../../docs/framework/wcf/samples/reliable-secure-profile.md)  
 Demonstrates how to compose [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] and Reliable Secure Profile (RSP).  
  
 [Custom Channel Dispatcher](../../../../docs/framework/wcf/samples/custom-channel-dispatcher.md)  
 Demonstrates how to build the channel stack in a custom way by implementing <xref:System.ServiceModel.ServiceHostBase> directly and how to create a custom channel dispatcher in Web host environment.  
  
 [Chunking Channel](../../../../docs/framework/wcf/samples/chunking-channel.md)  
 Demonstrates how to limit the amount of memory used to buffer large messages sent using [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)].  
  
 [HTTP Acknowledgement Channel](../../../../docs/framework/wcf/samples/http-acknowledgement-channel.md)  
 Demonstrates a layered channel which changes the one-way messaging pattern.  
  
 [HttpCookieSession](../../../../docs/framework/wcf/samples/httpcookiesession.md)  
 Demonstrates how to build a custom protocol channel to use HTTP cookies for session management.  
  
 [Custom Message Interceptor](../../../../docs/framework/wcf/samples/custom-message-interceptor.md)  
 Demonstrates how to implement a custom binding element that creates channel factories and channel listeners to intercept all incoming and outgoing messages at a particular point in the run-time stack.
