---
title: "System.ServiceModel.Channels.PeerFlooderReceiveMessageQuotaExceeded"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: b8371d0a-843e-440b-b86a-6996db131cb0
caps.latest.revision: 7
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# System.ServiceModel.Channels.PeerFlooderReceiveMessageQuotaExceeded
The inbound receive rate of messages is too high.  
  
## Description  
 This trace occurs when attempting to process inbound messages. A message could not be forwarded to a specific neighbor because the quota set for that neighbor has been exceeded. This occurs when an unresponsive neighbor fails to clear a backlog of messages pending for that neighbor.  
  
## Troubleshooting  
 Reduce the rate at which messages are sent within the mesh.  
  
## See Also  
 [Tracing](../../../../../docs/framework/wcf/diagnostics/tracing/index.md)  
 [Using Tracing to Troubleshoot Your Application](../../../../../docs/framework/wcf/diagnostics/tracing/using-tracing-to-troubleshoot-your-application.md)  
 [Administration and Diagnostics](../../../../../docs/framework/wcf/diagnostics/index.md)
