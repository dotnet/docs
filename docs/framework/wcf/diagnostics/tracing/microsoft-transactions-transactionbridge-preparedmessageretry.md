---
title: "Microsoft.Transactions.TransactionBridge.PreparedMessageRetry"
ms.date: "03/30/2017"
ms.assetid: 2194292d-bf5f-4aef-9336-cd3c4795cb71
---
# Microsoft.Transactions.TransactionBridge.PreparedMessageRetry
A prepared message retry was sent to an unresponsive coordinator.  
  
## Description  
 Traced if the local Transaction Manager needed to resend a Prepared message to a superior coordinator because it did not receive a response in a given amount of time/  
  
## Troubleshooting  
 Investigate potential network or product issues that prevent the response from being delivered on time.  If many of these messages are seen, it can indicate infrastructure problems or abnormally long response times. Both issues will drastically reduce the throughput of transactions within the system.  
  
## See also
 [Tracing](../../../../../docs/framework/wcf/diagnostics/tracing/index.md)  
 [Using Tracing to Troubleshoot Your Application](../../../../../docs/framework/wcf/diagnostics/tracing/using-tracing-to-troubleshoot-your-application.md)  
 [Administration and Diagnostics](../../../../../docs/framework/wcf/diagnostics/index.md)
