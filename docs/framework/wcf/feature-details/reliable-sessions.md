---
title: "Reliable Sessions"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
f1_keywords: 
  - "Windows Communication Foundation, sessions and instances"
  - "WCF, sessions and instances"
  - "sessions and instances [WCF]"
helpviewer_keywords: 
  - "instances [WCF]"
  - "sessions [WCF]"
ms.assetid: 143951b3-3aa0-4540-b4b7-d33e77e874a1
caps.latest.revision: 15
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---

# Reliable Sessions

This section describes what a [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] reliable session is, what it's used for, how and when to use one, what binding configurations support it, and pointers on best practices. The following table summarizes details about the essential points and related topics in this section.

The reliable session [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] provides featrues ensuring that messages sent between endpoints are transferred across SOAP or transport intermediaries and are delivered only once and, optionally, in the same order in which they were sent.

To use a reliable session with a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] application, either use one of the system-provided bindings in [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] that support a reliable session by default or as an option, or create your own custom binding that supports the session.

## In This Section

[Reliable Sessions Overview](../../../../docs/framework/wcf/feature-details/reliable-sessions-overview.md)   
Describes reliable sessions, when to use them, the different bindings that support reliable sessions, and how they work.

[How to: Exchange Messages Within a Reliable Session](../../../../docs/framework/wcf/feature-details/how-to-exchange-messages-within-a-reliable-session.md)   
Describes how to create a reliable session over HTTP using a custom binding specified in the configuration.

[How to: Secure Messages within Reliable Sessions](../../../../docs/framework/wcf/feature-details/how-to-secure-messages-within-reliable-sessions.md)   
Describes how to secure a reliable session.

[How to: Create a Custom Reliable Session Binding with HTTPS](../../../../docs/framework/wcf/feature-details/how-to-create-a-custom-reliable-session-binding-with-https.md)   
Describes how to create a reliable session over HTTPS.

[Best Practices for Reliable Sessions](../../../../docs/framework/wcf/feature-details/best-practices-for-reliable-sessions.md)   
Describes some of the best practices associated with using a reliable session.

## Reference

<xref:System.ServiceModel.ReliableSession>

## See Also

[Queues and Reliable Sessions](../../../../docs/framework/wcf/feature-details/queues-and-reliable-sessions.md)   
[Sessions, Instancing, and Concurrency](../../../../docs/framework/wcf/feature-details/sessions-instancing-and-concurrency.md)
