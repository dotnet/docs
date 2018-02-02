---
title: "System.ServiceModel.Channels.FailedAcceptFromPool"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: d535b1b5-ee58-45e8-b400-7d9570f4eb9a
caps.latest.revision: 6
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# System.ServiceModel.Channels.FailedAcceptFromPool
An attempt to reuse a pooled connection failed. Another attempt is made within the specified timeout period.  
  
## Description  
 This informational trace indicates that an error has occurred while attempting to reuse a pooled connection. This could happen because the pooled connection was not compatible, ready, or still active. Additional attempts to reuse other pooled connection are made within a given timeout and a new connection is created in case no usable connections are found.  
  
## See Also  
 [Tracing](../../../../../docs/framework/wcf/diagnostics/tracing/index.md)  
 [Using Tracing to Troubleshoot Your Application](../../../../../docs/framework/wcf/diagnostics/tracing/using-tracing-to-troubleshoot-your-application.md)  
 [Administration and Diagnostics](../../../../../docs/framework/wcf/diagnostics/index.md)
