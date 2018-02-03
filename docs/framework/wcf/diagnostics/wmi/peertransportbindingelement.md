---
title: "PeerTransportBindingElement"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 40bf6be2-8087-4cb3-a66c-408d53eb9269
caps.latest.revision: 8
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# PeerTransportBindingElement
PeerTransportBindingElement  
  
## Syntax  
  
```  
class PeerTransportBindingElement : TransportBindingElement  
{  
  string ListenIPAddress;  
  sint32 Port;  
  PeerSecuritySettings Security;  
};  
```  
  
## Methods  
 The PeerTransportBindingElement class does not define any methods.  
  
## Properties  
 The PeerTransportBindingElement class has the following properties:  
  
### ListenIPAddress  
 Data type: string  
  
 Access type: Read-only  
  
 The IP address on which the peer node listens for messages.  
  
### Port  
 Data type: sint32  
  
 Access type: Read-only  
  
 The network interface port on which this binding processes peer channel messages.  
  
### Security  
 Data type: PeerSecuritySettings  
  
 Access type: Read-only  
  
 Peer transport security settings.  
  
## Requirements  
  
|MOF|Declared in Servicemodel.mof.|  
|---------|-----------------------------------|  
|Namespace|Defined in root\ServiceModel|  
  
## See Also  
 <xref:System.ServiceModel.Channels.PeerTransportBindingElement>
