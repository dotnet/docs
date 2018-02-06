---
title: "System.ServiceModel.Channels.PrematureDatagramEof"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: ec07be8b-b537-4090-be7e-086679dba78d
caps.latest.revision: 4
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# System.ServiceModel.Channels.PrematureDatagramEof
System.ServiceModel.Channels.PrematureDatagramEof  
  
## Description  
 A null Message (signaling end of channel) was received from a datagram channel, but the channel is still in the Opened state. This indicates an error in the datagram channel, and the de-multiplexer receive loop has been prematurely terminated.  
  
## See Also  
 [Tracing](../../../../../docs/framework/wcf/diagnostics/tracing/index.md)  
 [Using Tracing to Troubleshoot Your Application](../../../../../docs/framework/wcf/diagnostics/tracing/using-tracing-to-troubleshoot-your-application.md)  
 [Administration and Diagnostics](../../../../../docs/framework/wcf/diagnostics/index.md)
