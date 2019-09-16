---
title: "System.ServiceModel.TxCompletionStatusCompletedForAsyncAbort"
ms.date: "03/30/2017"
ms.assetid: 155c3203-2e17-4709-b896-2254e22da45e
---
# System.ServiceModel.TxCompletionStatusCompletedForAsyncAbort
The specified transaction for the specified operation was completed due to asynchronous abort.  
  
## Description  
 The current transaction was aborted due to another participant voting for Abort, time-outs occurring, or another error inside the participant of a transaction.  
  
## Troubleshooting  
 If this abort is unexpected, check all system logs to determine the real reason for the abort.  
  
## See also

- [Tracing](../../../../../docs/framework/wcf/diagnostics/tracing/index.md)
- [Using Tracing to Troubleshoot Your Application](../../../../../docs/framework/wcf/diagnostics/tracing/using-tracing-to-troubleshoot-your-application.md)
- [Administration and Diagnostics](../../../../../docs/framework/wcf/diagnostics/index.md)
