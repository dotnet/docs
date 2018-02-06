---
title: "Encoding Binary Objects with ByteStream Encoder"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 020ee981-c889-4b12-a3ea-91823ef46444
caps.latest.revision: 8
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Encoding Binary Objects with ByteStream Encoder
Sending and receiving raw binary data with [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] is configured using <xref:System.ServiceModel.Channels.ByteStreamMessageEncodingBindingElement>.  
  
## Byte Stream Message Encoder Architecture  
 The binary message encoder used by [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] has no facility for processing, validating, or identifying the underlying binary data in the message. The data package is encoded into XML, sent, received, and decoded. The encoder processes the data after being passed to the transport and before the message is sent to the message queue. Functionally, the binary encoder wraps the message data in `<binary>` elements for sending and removes the elements after the message is received.  
  
## Using the Byte Stream Message Encoder  
 The following example shows a service contract that implements the byte stream message encoder.  
  
```csharp  
[OperationContract]  
Void Myfunction(Stream stream);  
```  
  
 The following example shows the service being invoked.  
  
```csharp  
proxy.MyFunction(stream);  
```  
  
 In the case of using a service that implements a message infrastructure (such as a router), the message is processed without inspecting, validating, or otherwise interacting with the message, as shown in the following example.  
  
```csharp  
[OperationContract]  
void ProcessMessage(Message message) ;  
```  
  
## Scenarios  
 The Byte Stream Encoder is useful in the following scenarios.  
  
-   Transferring a JPEG image between computers using [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)]. In this scenario, the image will arrive through the transport from an outside source, and the data sent will be the raw bytes that make up the image. A service will receive the binary data and display the image.  
  
-   Reading information out of a message queue and processing it. The message will be read from a message queue manager, and passed up the message queue channel to be handled. The message queue channel will act as a queue manager in the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] channel stack.  
  
 In the case of sending a message over a message queue channel, the sender has no control over the bytes received from the queue manager. If the receiving process has no capability to read raw bytes, the message will be received as badly formatted and will not be processed; it is assumed that the receiving process will have the capability of translating the received bytes back into a usable format.
