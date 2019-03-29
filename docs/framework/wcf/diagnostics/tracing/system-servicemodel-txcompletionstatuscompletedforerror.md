---
title: "System.ServiceModel.TxCompletionStatusCompletedForError"
ms.date: "03/30/2017"
ms.assetid: 8ade4722-a6d5-471c-b960-1cfea4ea2aa9
---
# System.ServiceModel.TxCompletionStatusCompletedForError
The specified transaction for the specified operation was completed due to an unhandled execution exception.  
  
## Description  
 Traced when an error occurs during an attempt to complete the current transaction. This happens before a reply or fault is sent to the caller.  
  
## Troubleshooting  
 Inspect the traced message for the exception message and any actionable items.  
  
## See also
- [Tracing](../../../../../docs/framework/wcf/diagnostics/tracing/index.md)
- [Using Tracing to Troubleshoot Your Application](../../../../../docs/framework/wcf/diagnostics/tracing/using-tracing-to-troubleshoot-your-application.md)
- [Administration and Diagnostics](../../../../../docs/framework/wcf/diagnostics/index.md)
