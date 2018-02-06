---
title: "System.ServiceModel.TxCompletionStatusCompletedForAsyncAbort"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 155c3203-2e17-4709-b896-2254e22da45e
caps.latest.revision: 7
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# System.ServiceModel.TxCompletionStatusCompletedForAsyncAbort
The specified transaction for the specified operation was completed due to asynchronous abort.  
  
## Description  
 The current transaction was aborted due to another participant voting for Abort, time-outs occurring, or another error inside the participant of a transaction.  
  
## Troubleshooting  
 If this abort is unexpected, check all system logs to determine the real reason for the abort.  
  
## See Also  
 [Tracing](../../../../../docs/framework/wcf/diagnostics/tracing/index.md)  
 [Using Tracing to Troubleshoot Your Application](../../../../../docs/framework/wcf/diagnostics/tracing/using-tracing-to-troubleshoot-your-application.md)  
 [Administration and Diagnostics](../../../../../docs/framework/wcf/diagnostics/index.md)
