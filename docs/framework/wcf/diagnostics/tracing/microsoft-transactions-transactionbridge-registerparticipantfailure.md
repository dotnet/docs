---
title: "Microsoft.Transactions.TransactionBridge.RegisterParticipantFailure"
ms.date: "03/30/2017"
ms.assetid: 3a4ead79-8550-4037-84e3-fd70ff56e001
---
# Microsoft.Transactions.TransactionBridge.RegisterParticipantFailure
The WS-AT protocol service failed to register a participant for a control protocol.  
  
## Description  
 Traced if MSDTC detects an invalid Registration request. This can be caused by  multiple Completion registration requests and internal errors.  
  
## Troubleshooting  
 Do not try to Register for Completion more than once.  Also, inspect the status string within the trace message to determine if any actionable item exists.  
  
## See also
- [Tracing](../../../../../docs/framework/wcf/diagnostics/tracing/index.md)
- [Using Tracing to Troubleshoot Your Application](../../../../../docs/framework/wcf/diagnostics/tracing/using-tracing-to-troubleshoot-your-application.md)
- [Administration and Diagnostics](../../../../../docs/framework/wcf/diagnostics/index.md)
