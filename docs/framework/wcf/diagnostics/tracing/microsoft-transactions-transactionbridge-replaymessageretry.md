---
title: "Microsoft.Transactions.TransactionBridge.ReplayMessageRetry"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: e5b820ae-504d-405a-926a-9effa41d2369
caps.latest.revision: 5
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Microsoft.Transactions.TransactionBridge.ReplayMessageRetry
A replay message retry was sent to an unresponsive coordinator.  
  
## Description  
 Traced if the local Transaction Manager needed to resend a Replay message to a superior coordinator because it did not receive a response in a given amount of time.  
  
## Troubleshooting  
 Investigate potential network or product issues that prevent the response from being delivered on time.  If many of these messages are seen, it can indicate infrastructure problems or abnormally long response times. Both issues will drastically reduce the throughput of transactions within the system.  
  
## See Also  
 [Tracing](../../../../../docs/framework/wcf/diagnostics/tracing/index.md)  
 [Using Tracing to Troubleshoot Your Application](../../../../../docs/framework/wcf/diagnostics/tracing/using-tracing-to-troubleshoot-your-application.md)  
 [Administration and Diagnostics](../../../../../docs/framework/wcf/diagnostics/index.md)
