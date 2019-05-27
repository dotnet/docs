---
title: "Microsoft.Transactions.TransactionBridge.PrepareMessageRetry"
ms.date: "03/30/2017"
ms.assetid: ada4baa5-b60d-46b8-ad46-4d69f8d8a9fa
---
# Microsoft.Transactions.TransactionBridge.PrepareMessageRetry
A prepare message retry was sent to an unresponsive participant.  
  
## Description  
 Traced if the local Transaction Manager needed to resend a Prepare message to a subordinate participant because it did not receive a response in a given amount of time.  
  
## Troubleshooting  
 Investigate potential network or product issues that prevent the response from being delivered on time.  If many of these messages are seen, it can indicate infrastructure problems or abnormally long response times. Both issues can drastically reduce the throughput of transactions within the system.  
  
## See also

- [Tracing](../../../../../docs/framework/wcf/diagnostics/tracing/index.md)
- [Using Tracing to Troubleshoot Your Application](../../../../../docs/framework/wcf/diagnostics/tracing/using-tracing-to-troubleshoot-your-application.md)
- [Administration and Diagnostics](../../../../../docs/framework/wcf/diagnostics/index.md)
