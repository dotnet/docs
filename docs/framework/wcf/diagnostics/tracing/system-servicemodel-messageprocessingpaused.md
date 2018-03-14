---
title: "System.ServiceModel.MessageProcessingPaused"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 36b5302a-93cc-478a-9bb2-8a1601fba1df
caps.latest.revision: 6
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# System.ServiceModel.MessageProcessingPaused
System.ServiceModel.MessageProcessingPaused  
  
## Description  
 The threads were switched while processing a message.  
  
 Message processing can be paused by the following reasons:  
  
-   ConcurrencyMode is single or reentrant, and the service is processing another message.  
  
-   Transaction is enabled and the service is processing another transaction.  
  
-   Synchronization context is not current.  
  
## See Also  
 [Tracing](../../../../../docs/framework/wcf/diagnostics/tracing/index.md)  
 [Using Tracing to Troubleshoot Your Application](../../../../../docs/framework/wcf/diagnostics/tracing/using-tracing-to-troubleshoot-your-application.md)  
 [Administration and Diagnostics](../../../../../docs/framework/wcf/diagnostics/index.md)
