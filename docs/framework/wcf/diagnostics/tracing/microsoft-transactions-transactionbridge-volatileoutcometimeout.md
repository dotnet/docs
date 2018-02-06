---
title: "Microsoft.Transactions.TransactionBridge.VolatileOutcomeTimeout"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 2dbe34c5-57c7-4b64-9257-63021911d03c
caps.latest.revision: 5
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Microsoft.Transactions.TransactionBridge.VolatileOutcomeTimeout
The WS-AT protocol service timed out waiting for a response to an outcome message from a volatile participant. The transaction outcome may be in doubt if the participant returns.  
  
## Description  
 Traced when a Volatile participant has decided to Commit or Abort but has not responded to a Commit or Rollback request within a given amount of time.  
  
## Troubleshooting  
 Ensure that all Volatile participants are able to respond within the given amount of time. The default time period is 180 seconds.  If this is insufficient, increase the `VolatileOutcomeDelay` timer policy for WS-AT.  
  
## See Also  
 [Tracing](../../../../../docs/framework/wcf/diagnostics/tracing/index.md)  
 [Using Tracing to Troubleshoot Your Application](../../../../../docs/framework/wcf/diagnostics/tracing/using-tracing-to-troubleshoot-your-application.md)  
 [Administration and Diagnostics](../../../../../docs/framework/wcf/diagnostics/index.md)
