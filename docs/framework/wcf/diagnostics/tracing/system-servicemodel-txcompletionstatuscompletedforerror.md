---
title: "System.ServiceModel.TxCompletionStatusCompletedForError"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 8ade4722-a6d5-471c-b960-1cfea4ea2aa9
caps.latest.revision: 6
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# System.ServiceModel.TxCompletionStatusCompletedForError
The specified transaction for the specified operation was completed due to an unhandled execution exception.  
  
## Description  
 Traced when an error occurs during an attempt to complete the current transaction. This happens before a reply or fault is sent to the caller.  
  
## Troubleshooting  
 Inspect the traced message for the exception message and any actionable items.  
  
## See Also  
 [Tracing](../../../../../docs/framework/wcf/diagnostics/tracing/index.md)  
 [Using Tracing to Troubleshoot Your Application](../../../../../docs/framework/wcf/diagnostics/tracing/using-tracing-to-troubleshoot-your-application.md)  
 [Administration and Diagnostics](../../../../../docs/framework/wcf/diagnostics/index.md)
