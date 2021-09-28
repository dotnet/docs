---
description: "Learn more about: Secure Conversations and Secure Sessions"
title: "Secure Conversations and Secure Sessions"
ms.date: "03/30/2017"
ms.assetid: 48cb104a-532d-40ae-aa57-769dae103fda
---
# Secure Conversations and Secure Sessions

A feature of Windows Communication Foundation (WCF) is the ability to establish secure sessions between two endpoints that authenticate each other and agree upon an encryption and digital signature process. For example, the service endpoint might require a client endpoint to send a security token based upon an X.509 certificate for authentication. Once the client is authenticated, the service endpoint returns a security context token (SCT) back to the client that is then used to secure all subsequent messages within the session. Establishing this secure session enables the set of messages that are exchanged between the two endpoints to be more efficient, because the SCT has a symmetric key. Asymmetric keys, which X.509 certificates are based upon, require significantly more computational power than symmetric keys when generating a digital signature or encrypting a set of data.  
  
 The bootstrap policy (defined in section 6.2.7 of the [WS-SecurityPolicy](https://docs.oasis-open.org/ws-sx/ws-securitypolicy/200702/ws-securitypolicy-1.2-spec-os.html) standard) contains the message security assertions used to secure the channel and authenticate the client prior to the RST/SCT and RSTR/SCT exchange. Certain WCF standard bindings have a `Security.Message.EstablishSecurityContext` property which controls whether secure conversation is used. When using custom bindings the bootstrap is indicated by nesting security binding elements, either through [\<secureConversationBootstrap>](../../configure-apps/file-schema/wcf/secureconversationbootstrap.md) in the configuration file, or by calling <xref:System.ServiceModel.Channels.SecurityBindingElement.CreateSecureConversationBindingElement%2A> in code.  
  
 For more information about sessions, see [Using Sessions](../using-sessions.md).  
  
## See also

- [Sessions, Instancing, and Concurrency](sessions-instancing-and-concurrency.md)
- [How to: Create a Service That Requires Sessions](how-to-create-a-service-that-requires-sessions.md)
