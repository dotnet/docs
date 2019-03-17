---
title: "Microsoft.Transactions.TransactionBridge.CreateTransactionFailure"
ms.date: "03/30/2017"
ms.assetid: c3468e23-49a9-4a84-972d-a79a658851b3
---
# Microsoft.Transactions.TransactionBridge.CreateTransactionFailure
A transaction could not be created.  
  
## Description  
 This trace is generated when MSDTC is unable to create a transaction. This can be due to low resources, insufficient log space, or other errors.  
  
## Troubleshooting  
 Inspect the status string within the trace message to determine if any actionable item exists.  
  
## See also
- [Tracing](../../../../../docs/framework/wcf/diagnostics/tracing/index.md)
- [Using Tracing to Troubleshoot Your Application](../../../../../docs/framework/wcf/diagnostics/tracing/using-tracing-to-troubleshoot-your-application.md)
- [Administration and Diagnostics](../../../../../docs/framework/wcf/diagnostics/index.md)
