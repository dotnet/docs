---
title: "Secure Conversations and Secure Sessions"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 48cb104a-532d-40ae-aa57-769dae103fda
caps.latest.revision: 13
author: "BrucePerlerMS"
ms.author: "bruceper"
manager: "mbaldwin"
ms.workload: 
  - "dotnet"
---
# Secure Conversations and Secure Sessions
A feature of [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] is the ability to establish secure sessions between two endpoints that authenticate each other and agree upon an encryption and digital signature process. For example, the service endpoint might require a client endpoint to send a security token based upon an X.509 certificate for authentication. Once the client is authenticated, the service endpoint returns a security context token (SCT) back to the client that is then used to secure all subsequent messages within the session. Establishing this secure session enables the set of messages that are exchanged between the two endpoints to be more efficient, because the SCT has a symmetric key. Asymmetric keys, which X.509 certificates are based upon, require significantly more computational power than symmetric keys when generating a digital signature or encrypting a set of data.  
  
 The bootstrap policy (defined in section 6.2.7 of the [WS-SecurityPolicy](http://go.microsoft.com/fwlink/?LinkId=99817) standard) contains the message security assertions used to secure the channel and authenticate the client prior to the RST/SCT and RSTR/SCT exchange. Certain [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] standard bindings have a `Security.Message.EstablishSecurityContext` property which controls whether secure conversation is used. When using custom bindings the bootstrap is indicated by nesting security binding elements, either through [\<secureConversationBootstrap>](../../../../docs/framework/configure-apps/file-schema/wcf/secureconversationbootstrap.md) in the configuration file, or by calling <xref:System.ServiceModel.Channels.SecurityBindingElement.CreateSecureConversationBindingElement%2A> in code.  
  
 [!INCLUDE[crabout](../../../../includes/crabout-md.md)] sessions, see [Using Sessions](../../../../docs/framework/wcf/using-sessions.md).  
  
## See Also  
 [Sessions, Instancing, and Concurrency](../../../../docs/framework/wcf/feature-details/sessions-instancing-and-concurrency.md)  
 [How to: Create a Service That Requires Sessions](../../../../docs/framework/wcf/feature-details/how-to-create-a-service-that-requires-sessions.md)
