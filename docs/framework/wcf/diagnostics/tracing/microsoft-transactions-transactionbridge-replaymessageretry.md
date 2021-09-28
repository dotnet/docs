---
description: "Learn more about: Microsoft.Transactions.TransactionBridge.ReplayMessageRetry"
title: "Microsoft.Transactions.TransactionBridge.ReplayMessageRetry"
ms.date: "03/30/2017"
ms.assetid: e5b820ae-504d-405a-926a-9effa41d2369
---
# Microsoft.Transactions.TransactionBridge.ReplayMessageRetry

A replay message retry was sent to an unresponsive coordinator.  
  
## Description  

 Traced if the local Transaction Manager needed to resend a Replay message to a superior coordinator because it did not receive a response in a given amount of time.  
  
## Troubleshooting  

 Investigate potential network or product issues that prevent the response from being delivered on time.  If many of these messages are seen, it can indicate infrastructure problems or abnormally long response times. Both issues will drastically reduce the throughput of transactions within the system.  
  
## See also

- [Tracing](index.md)
- [Using Tracing to Troubleshoot Your Application](using-tracing-to-troubleshoot-your-application.md)
- [Administration and Diagnostics](../index.md)
