---
description: "Learn more about: Reliable Sessions"
title: "Reliable Sessions"
ms.date: "03/30/2017"
f1_keywords:
  - "Windows Communication Foundation, sessions and instances"
  - "WCF, sessions and instances"
  - "sessions and instances [WCF]"
helpviewer_keywords:
  - "instances [WCF]"
  - "sessions [WCF]"
ms.assetid: 143951b3-3aa0-4540-b4b7-d33e77e874a1
ms.topic: article
---

# Reliable Sessions

This section describes what a Windows Communication Foundation (WCF) reliable session is, what it's used for, how and when to use one, what binding configurations support it, and pointers on best practices. The following table summarizes details about the essential points and related topics in this section.

The reliable session WCF provides features ensuring that messages sent between endpoints are transferred across SOAP or transport intermediaries and are delivered only once and, optionally, in the same order in which they were sent.

To use a reliable session with a WCF application, either use one of the system-provided bindings in WCF that support a reliable session by default or as an option, or create your own custom binding that supports the session.

## In This Section

[Reliable Sessions Overview](reliable-sessions-overview.md)
Describes reliable sessions, when to use them, the different bindings that support reliable sessions, and how they work.

[How to: Exchange Messages Within a Reliable Session](how-to-exchange-messages-within-a-reliable-session.md)
Describes how to create a reliable session over HTTP using a custom binding specified in the configuration.

[How to: Secure Messages within Reliable Sessions](how-to-secure-messages-within-reliable-sessions.md)
Describes how to secure a reliable session.

[How to: Create a Custom Reliable Session Binding with HTTPS](how-to-create-a-custom-reliable-session-binding-with-https.md)
Describes how to create a reliable session over HTTPS.

[Best Practices for Reliable Sessions](best-practices-for-reliable-sessions.md)
Describes some of the best practices associated with using a reliable session.

## Reference

<xref:System.ServiceModel.ReliableSession>

## See also

- [Queues and Reliable Sessions](queues-and-reliable-sessions.md)
- [Sessions, Instancing, and Concurrency](sessions-instancing-and-concurrency.md)
