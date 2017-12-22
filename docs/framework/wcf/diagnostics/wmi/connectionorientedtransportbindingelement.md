---
title: "ConnectionOrientedTransportBindingElement"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: c1308313-f0e2-49e6-977d-6b4ce9ad35d1
caps.latest.revision: 8
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ConnectionOrientedTransportBindingElement
ConnectionOrientedTransportBindingElement  
  
## Syntax  
  
```  
class ConnectionOrientedTransportBindingElement : TransportBindingElement  
{  
  datetime ChannelInitializationTimeout;  
  sint32 ConnectionBufferSize;  
  string HostNameComparisonMode;  
  sint32 MaxBufferSize;  
  datetime MaxOutputDelay;  
  sint32 MaxPendingAccepts;  
  sint32 MaxPendingConnections;  
  string TransferMode;  
};  
```  
  
## Methods  
 The ConnectionOrientedTransportBindingElement class does not define any methods.  
  
## Properties  
 The ConnectionOrientedTransportBindingElement class has the following properties:  
  
### ChannelInitializationTimeout  
 Data type: datetime  
  
 Access type: Read-only  
  
 The timespan that specifies how long the channel initialization has to complete before timing out.  
  
### ConnectionBufferSize  
 Data type: sint32  
  
 Access type: Read-only  
  
 The size of the buffer used to transmit a chunk of the serialized message on the wire from the client or service.  
  
### HostNameComparisonMode  
 Data type: string  
  
 Access type: Read-only  
  
 A value that indicates whether the hostname is used to reach the service when matching on the URI.  
  
### MaxBufferSize  
 Data type: sint32  
  
 Access type: Read-only  
  
 The maximum size of the buffer to use.  
  
### MaxOutputDelay  
 Data type: datetime  
  
 Access type: Read-only  
  
 The maximum interval of time that a chunk of a message or a full message can remain buffered in memory before being sent out.  
  
### MaxPendingAccepts  
 Data type: sint32  
  
 Access type: Read-only  
  
 The maximum number of pending asynchronous accept threads that are available for processing incoming connections on the service.  
  
### MaxPendingConnections  
 Data type: sint32  
  
 Access type: Read-only  
  
 The maximum number of pending connections.  
  
### TransferMode  
 Data type: string  
  
 Access type: Read-only  
  
 A value that specifies whether the messages are buffered or streamed with the connection-oriented transport.  
  
## Requirements  
  
|MOF|Declared in Servicemodel.mof.|  
|---------|-----------------------------------|  
|Namespace|Defined in root\ServiceModel|  
  
## See Also  
 <xref:System.ServiceModel.Channels.ConnectionOrientedTransportBindingElement>
