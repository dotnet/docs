---
title: "System.ServiceModel.Channels.PeerMaintainerActivity"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: ef28d086-d7fb-4e81-82e9-45a54647783b
caps.latest.revision: 10
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# System.ServiceModel.Channels.PeerMaintainerActivity
The PeerMaintainer module is performing a specific operation (details contained within the trace message body).  
  
## Description  
 This trace occurs during various PeerMaintainer operations.  
  
 PeerMaintainer is an internal component of PeerNode. Every minute, or every 32 messages received, it sends a LinkUtility message to its neighbors with statistics about how many messages are exchanged and how many are useful (non-duplicates, untampered). This helps determine a particular neighbor's Link Utility. Approximately every five minutes, the maintainer checks the health of neighbor connections. If the number of neighbor connections exceeds the ideal amount, the maintainer prunes off the least useful connections. If there are not enough connections, the maintainer acquires new connections.  
  
## See Also  
 [Tracing](../../../../../docs/framework/wcf/diagnostics/tracing/index.md)  
 [Using Tracing to Troubleshoot Your Application](../../../../../docs/framework/wcf/diagnostics/tracing/using-tracing-to-troubleshoot-your-application.md)  
 [Administration and Diagnostics](../../../../../docs/framework/wcf/diagnostics/index.md)
