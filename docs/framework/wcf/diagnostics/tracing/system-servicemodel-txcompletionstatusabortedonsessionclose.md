---
title: "System.ServiceModel.TxCompletionStatusAbortedOnSessionClose"
ms.date: "03/30/2017"
ms.assetid: 7e142e9d-e81b-4309-974a-02e9cc064ea0
---
# System.ServiceModel.TxCompletionStatusAbortedOnSessionClose
The specified transaction was aborted because it was uncompleted when the session was closed and the TransactionAutoCompleteOnSessionClose OperationBehaviorAttribute was set to false.  
  
## Description  
 Traced if the current active session was closed, and the transaction was not completed, and TransactionAutoCompleteOnSessionClose is set to `false`.  
  
## Troubleshooting  
 This trace indicates a potential application bug that should be investigated.  
  
## See also
- [Tracing](../../../../../docs/framework/wcf/diagnostics/tracing/index.md)
- [Using Tracing to Troubleshoot Your Application](../../../../../docs/framework/wcf/diagnostics/tracing/using-tracing-to-troubleshoot-your-application.md)
- [Administration and Diagnostics](../../../../../docs/framework/wcf/diagnostics/index.md)
