---
title: "ReliableSessionBindingElement"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: effda125-b8d3-4de6-8c0e-f59f5ea8f6eb
caps.latest.revision: 11
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ReliableSessionBindingElement
ReliableSessionBindingElement  
  
## Syntax  
  
```  
class ReliableSessionBindingElement : BindingElement  
{  
  datetime AcknowledgementInterval;  
  boolean FlowControlEnabled;  
  datetime InactivityTimeout;  
  sint32 MaxPendingChannels;  
  sint32 MaxRetryCount;  
  sint32 MaxTransferWindowSize;  
  boolean Ordered;  
  integer ReliableMessagingVersion;  
};  
```  
  
## Methods  
 The ReliableSessionBindingElement class does not define any methods.  
  
## Properties  
 The ReliableSessionBindingElement class has the following properties:  
  
### AcknowledgementInterval  
 Data type: datetime  
  
 Access type: Read-only  
  
 The interval of time that a destination waits before sending an acknowledgement to the message source on reliable channels that are created by the factory.  
  
### FlowControlEnabled  
 Data type: boolean  
  
 Access type: Read-only  
  
 A Boolean value that specifies whether flow control is enabled.  
  
### InactivityTimeout  
 Data type: datetime  
  
 Access type: Read-only  
  
 Specifies the maximum duration the channel is going to allow the other communicating party not to send any messages before faulting the channel.  
  
### MaxPendingChannels  
 Data type: sint32  
  
 Access type: Read-only  
  
 The maximum number of channels that can wait to be accepted on the listener.  
  
### MaxRetryCount  
 Data type: sint32  
  
 Access type: Read-only  
  
 The maximum number of times a reliable channel attempts to retransmit a message it has not received an acknowledgement for, by calling `Send` on its underlying channel.  
  
### MaxTransferWindowSize  
 Data type: sint32  
  
 Access type: Read-only  
  
 The maximum transfer window size for the reliable session.  
  
### Ordered  
 Data type: boolean  
  
 Access type: Read-only  
  
 A Boolean value that specifies whether messages are guaranteed to arrive in the order they were sent.  
  
### ReliableMessagingVersion  
 Data type: integer  
  
 Access type: Read-only  
  
 An integer that specifies the WS-ReliableMessaging protocol version used in the reliable session.  
  
## Requirements  
  
|MOF|Declared in Servicemodel.mof.|  
|---------|-----------------------------------|  
|Namespace|Defined in root\ServiceModel|  
  
## See Also  
 <xref:System.ServiceModel.Channels.ReliableSessionBindingElement>
