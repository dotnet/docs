---
title: "System.ServiceModel.Channels.ConnectionPoolCloseException"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 8358898e-129e-4fac-a6bf-bf3aa4293ae2
caps.latest.revision: 5
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# System.ServiceModel.Channels.ConnectionPoolCloseException
An exception occurred while closing the connections in this connection pool.  
  
## Description  
 This error level trace indicates that an error has occurred while closing the connection pools used by [!INCLUDE[indigo1](../../../../../includes/indigo1-md.md)]’s connection pooling feature. One possible reason for this is an unsuccessful closure of a pooled connection, or a set of pooled connections within the CloseTimeout. When this exception is thrown, any remaining unclosed connections within that pool are aborted; unclosed connections within other pools are abandoned.  
  
## See Also  
 [Tracing](../../../../../docs/framework/wcf/diagnostics/tracing/index.md)  
 [Using Tracing to Troubleshoot Your Application](../../../../../docs/framework/wcf/diagnostics/tracing/using-tracing-to-troubleshoot-your-application.md)  
 [Administration and Diagnostics](../../../../../docs/framework/wcf/diagnostics/index.md)
