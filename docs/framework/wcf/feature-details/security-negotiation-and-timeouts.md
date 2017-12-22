---
title: "Security Negotiation and Timeouts"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 02a428f1-84e5-4d28-a11f-53ce31d63196
caps.latest.revision: 8
author: "BrucePerlerMS"
ms.author: "bruceper"
manager: "mbaldwin"
ms.workload: 
  - "dotnet"
---
# Security Negotiation and Timeouts
When clients and services authenticate, [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] supports a mode where the service credential is negotiated as part of authentication. In such scenarios, a potentially multi-leg exchange occurs between the client and the service to propagate the service credential to the client. The <xref:System.ServiceModel.Channels.LocalServiceSecuritySettings.NegotiationTimeout%2A> property controls how long the multi-leg exchange can take to complete. However, this timeout only applies if the exchange actually takes more that a single request-response. In cases where the negotiation completes in a single round trip, the timeout does not apply.  
  
## See Also  
 <xref:System.ServiceModel.Channels.LocalServiceSecuritySettings>  
 [How to: Set a Max Clock Skew](../../../../docs/framework/wcf/feature-details/how-to-set-a-max-clock-skew.md)
