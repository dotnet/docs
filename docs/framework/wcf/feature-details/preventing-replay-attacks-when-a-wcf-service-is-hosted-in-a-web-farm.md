---
title: "Preventing Replay Attacks When a WCF Service is Hosted in a Web Farm"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 1c2ed695-7a31-4257-92bd-9e9731b886a5
caps.latest.revision: 4
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Preventing Replay Attacks When a WCF Service is Hosted in a Web Farm
When using message security WCF prevents replay attacks by creating a NONCE out of the incoming message and checking the internal `InMemoryNonceCache` to see if the generated NONCE is present. If it is, the message is discarded as a replay. When a WCF service is hosted in a web farm, since the `InMemoryNonceCache` is not shared across the nodes in the web farm, the service is vulnerable to replay attacks.  To mitigate this scenario WCF 4.5 provides an extensibility point that allows you to implement your own shared NONCE cache by deriving a class from the abstract class <xref:System.ServiceModel.Security.NonceCache>.  
  
## NonceCache Implementation  
 To implement your own shared NONCE cache, derive a class from <xref:System.ServiceModel.Security.NonceCache> and override the <xref:System.ServiceModel.Security.NonceCache.CheckNonce%2A> and <xref:System.ServiceModel.Security.NonceCache.TryAddNonce%2A> methods. <xref:System.ServiceModel.Security.NonceCache.CheckNonce%2A> will check to see if the specified NONCE exists in the cache. <xref:System.ServiceModel.Security.NonceCache.TryAddNonce%2A> will attempt to add a NONCE to the cache. Once the class is implemented, you hook it up by instantiating an instance and assigning it to <xref:System.ServiceModel.Channels.LocalClientSecuritySettings.NonceCache%2A> for client-side replay detection and <xref:System.ServiceModel.Channels.LocalServiceSecuritySettings.NonceCache%2A> for server-side replay detection. There is no out of the box configuration support for this feature.  
  
## See Also  
 [Message Security](../../../../docs/framework/wcf/feature-details/message-security-in-wcf.md)  
 [SymmetricSecurityBindingElement](../../../../docs/framework/wcf/diagnostics/wmi/symmetricsecuritybindingelement.md)
