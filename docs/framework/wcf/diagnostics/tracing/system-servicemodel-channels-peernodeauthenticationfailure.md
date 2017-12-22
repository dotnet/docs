---
title: "System.ServiceModel.Channels.PeerNodeAuthenticationFailure"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 0b50f782-ca06-4a82-aa7f-71f78ddc5177
caps.latest.revision: 9
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# System.ServiceModel.Channels.PeerNodeAuthenticationFailure
The security handshake with a potential neighbor was not successful.  
  
## Description  
 This trace occurs while attempting to establish a secure neighbor connection. This can happen due to insufficient or incorrect credentials.  
  
 PeerChannel recognizes a single token type for strong identification, X.509 certificates, which provide a strong identity model based on the type of authentication and authorization that can be implemented. PeerChannel also provides support for simple applications through the use of passwords. Passwords can be used only to allow entry to the session; they cannot be used to perform message authentication. This is because a symmetric token that a group of peers share is difficult and inappropriate to use for source authentication.  
  
## Troubleshooting  
 Ensure that all neighbors have the appropriate security credentials.  
  
## See Also  
 [Peer Channel Security](../../../../../docs/framework/wcf/feature-details/peer-channel-security.md)  
 [Tracing](../../../../../docs/framework/wcf/diagnostics/tracing/index.md)  
 [Using Tracing to Troubleshoot Your Application](../../../../../docs/framework/wcf/diagnostics/tracing/using-tracing-to-troubleshoot-your-application.md)  
 [Administration and Diagnostics](../../../../../docs/framework/wcf/diagnostics/index.md)
