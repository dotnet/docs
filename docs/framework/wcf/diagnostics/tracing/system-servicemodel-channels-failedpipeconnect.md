---
title: "System.ServiceModel.Channels.FailedPipeConnect"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 9a827e0f-fb91-46bb-bd54-926d4b74d8a6
caps.latest.revision: 6
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# System.ServiceModel.Channels.FailedPipeConnect
An attempt to connect to the named pipe endpoint failed. Another attempt is made within the specified timeout period.  
  
## Description  
 This informational trace indicates a failure to connect to a named pipe endpoint. This could happen if the named pipe endpoint is not found or is busy. Additional attempts are made, each separated by a short amount of time, until one succeeds or the OpenTimeout expires.  
  
## See Also  
 [Tracing](../../../../../docs/framework/wcf/diagnostics/tracing/index.md)  
 [Using Tracing to Troubleshoot Your Application](../../../../../docs/framework/wcf/diagnostics/tracing/using-tracing-to-troubleshoot-your-application.md)  
 [Administration and Diagnostics](../../../../../docs/framework/wcf/diagnostics/index.md)
