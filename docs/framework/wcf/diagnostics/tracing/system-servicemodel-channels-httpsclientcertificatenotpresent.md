---
title: "System.ServiceModel.Channels.HttpsClientCertificateNotPresent"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: b13ef1b6-e340-401d-93ca-2710c3842205
caps.latest.revision: 5
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# System.ServiceModel.Channels.HttpsClientCertificateNotPresent
Client certificate is required. No certificate was found in the request.  
  
## Description  
 This trace indicates that the HTTPS listener received an HTTPS request that was not associated with a client certificate. Since the listener was configured to require client certificates on all HTTPS requests, the listener failed to validate the client’s authenticity.  
  
## See Also  
 [Tracing](../../../../../docs/framework/wcf/diagnostics/tracing/index.md)  
 [Using Tracing to Troubleshoot Your Application](../../../../../docs/framework/wcf/diagnostics/tracing/using-tracing-to-troubleshoot-your-application.md)  
 [Administration and Diagnostics](../../../../../docs/framework/wcf/diagnostics/index.md)
