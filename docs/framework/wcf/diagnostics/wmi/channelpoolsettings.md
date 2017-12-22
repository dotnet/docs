---
title: "ChannelPoolSettings"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: d3f475bd-f780-4bbe-b291-339387322964
caps.latest.revision: 7
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ChannelPoolSettings
ChannelPoolSettings  
  
## Syntax  
  
```  
class ChannelPoolSettings  
{  
  datetime IdleTimeout;  
  datetime LeaseTimeout;  
  sint32 MaxOutboundChannelsPerEndpoint;  
};  
```  
  
## Methods  
 The ChannelPoolSettings class does not define any methods.  
  
## Properties  
 The ChannelPoolSettings class has the following properties:  
  
### IdleTimeout  
 Data type: datetime  
  
 Access type: Read-only  
  
 The maximum time the connection can be idle before being disconnected.  
  
### LeaseTimeout  
 Data type: datetime  
  
 Access type: Read-only  
  
 The maximum time for a lease operation to complete before timing out.  
  
### MaxOutboundChannelsPerEndpoint  
 Data type: sint32  
  
 Access type: Read-only  
  
 The maximum number of outbound channels for each endpoint.  
  
## Requirements  
  
|MOF|Declared in Servicemodel.mof.|  
|---------|-----------------------------------|  
|Namespace|Defined in root\ServiceModel|  
  
## See Also  
 <xref:System.ServiceModel.Channels.ChannelPoolSettings>
