---
title: "Significant Traces"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 40a1770e-3b09-4142-b0dd-f9ef73642074
caps.latest.revision: 4
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Significant Traces
This topic lists some of the major traces emitted by [!INCLUDE[indigo1](../../../../../includes/indigo1-md.md)].  
  
## Significant Traces  
  
|Trace|Description|  
|-----------|-----------------|  
|Message log trace|The trace is emitted when a [!INCLUDE[indigo2](../../../../../includes/indigo2-md.md)] message is logged by the message logging feature when the `System.ServiceModel.MessageLogging` trace source is enabled. Clicking this trace displays the message. There are four configurable logging points for a message: `ServiceLevelSendRequest`, `TransportSend`, `TransportReceive`, `ServiceLevelReceiveRequest`, also indicated by the Message Source attribute in the message log trace.|  
|Message received trace|This trace is emitted when a [!INCLUDE[indigo2](../../../../../includes/indigo2-md.md)] message is received if the `System.ServiceModel` trace source is enabled at information or verbose level. This trace is necessary to see the message correlation arrow in the activity graph view.|  
|Message sent trace|This trace is emitted when a [!INCLUDE[indigo2](../../../../../includes/indigo2-md.md)] message is sent if the `System.ServiceModel` trace source is enabled at information or verbose level. This trace is necessary to see the message correlation arrow in the activity graph view.|  
|Get ChannelEndpointElement|This trace is emitted in Construct channel factory, at information level. It provides a description of the endpoint the client is talking to (remote address, binding, contract name).|  
|Get ServiceElement|This trace is emitted in Construct service host, at Information level. It provides a description of the service contract and binding.|  
|SocketConnection create|This trace is emitted in the first Process action performed by the client and in the Receive bytes activity on the service. It provides the local and remote IP addresses. It is emitted at Information level.|
