---
title: "Microsoft.Transactions.TransactionBridge.EnlistTransactionFailure"
ms.date: "03/30/2017"
ms.assetid: 1b9f5139-e122-4716-9ef7-2f38e1813993
---
# Microsoft.Transactions.TransactionBridge.EnlistTransactionFailure
The WS-AT protocol service failed to enlist on a transaction using the provided coordination context.  
  
## Description  
 Traced when MSDTC is unable to enlist on a transaction for a given 2pc protocol.  This can happen because the transaction no longer exists, enlisting is no longer allowed, or too many enlistments are already present.  
  
## Troubleshooting  
 Inspect the status string within the trace message to determine if any actionable item exists.  
  
## See also

- [Tracing](../../../../../docs/framework/wcf/diagnostics/tracing/index.md)
- [Using Tracing to Troubleshoot Your Application](../../../../../docs/framework/wcf/diagnostics/tracing/using-tracing-to-troubleshoot-your-application.md)
- [Administration and Diagnostics](../../../../../docs/framework/wcf/diagnostics/index.md)
