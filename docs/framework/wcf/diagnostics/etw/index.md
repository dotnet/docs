---
description: "Learn more about: Analytic Tracing with ETW"
title: "Analytic Tracing with ETW"
ms.date: "03/30/2017"
helpviewer_keywords:
  - "diagnostics [WCF], analytic tracing"
  - "administration [WCF], analytic tracing"
  - "analytic tracing [WCF]"
ms.assetid: 1d518e47-a38d-41e8-93d7-8c3b361f6a56
---
# Analytic tracing with ETW

Windows Communication Foundation (WCF) analytic tracing offers a way to capture diagnostic information during the execution of a WCF service. WCF analytic tracing events are emitted at key points in the WCF stack to allow troubleshooting of WCF services in a production environment. Analytic tracing for WCF services has minimal impact on the performance of a product server that hosts .NET Framework WCF services as these events are very efficiently emitted to an Event Tracing for Windows (ETW) session.

## In This Section

 [Analytic Tracing Overview](analytic-tracing-overview.md)\
 Discusses how WCF analytic tracing works in .NET Framework.

 [Dynamically Enabling Analytic Tracing](dynamically-enabling-analytic-tracing.md)\
 Discusses how to enable or disable tracing dynamically using ETW.

 [Configuring Message Flow Tracing](configuring-message-flow-tracing.md)\
 Describes how to configure message flow tracing.

 [Analytic Trace Event Reference](analytic-trace-event-reference.md)\
 Shows a table of event IDs with their event levels, event messages and keywords.

## See also

- [WCF Services and Event Tracing for Windows](../../samples/wcf-services-and-event-tracing-for-windows.md)
- [Tracking Events into Event Tracing in Windows](../../../windows-workflow-foundation/samples/tracking-events-into-event-tracing-in-windows.md)
