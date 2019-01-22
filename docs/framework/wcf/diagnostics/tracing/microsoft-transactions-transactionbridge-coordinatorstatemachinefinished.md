---
title: "Microsoft.Transactions.TransactionBridge.CoordinatorStateMachineFinished"
ms.date: "03/30/2017"
ms.assetid: 16cb428d-d886-4789-a961-6fded4b0dbba
---
# Microsoft.Transactions.TransactionBridge.CoordinatorStateMachineFinished
The state machine for a coordinator enlistment has entered the finished state.  
  
## Description  
 Traced when the local Transaction Manager believes a superior coordinator enlistment has completed 2pc processing. The outcome for the enlistment can be Committed or Aborted or Forgotten. It is also traced if the local Transaction Manager votes ReadOnly during Prepare.  
  
## See also
 [Tracing](../../../../../docs/framework/wcf/diagnostics/tracing/index.md)  
 [Using Tracing to Troubleshoot Your Application](../../../../../docs/framework/wcf/diagnostics/tracing/using-tracing-to-troubleshoot-your-application.md)  
 [Administration and Diagnostics](../../../../../docs/framework/wcf/diagnostics/index.md)
