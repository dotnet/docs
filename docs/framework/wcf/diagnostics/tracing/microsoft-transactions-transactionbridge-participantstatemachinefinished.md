---
description: "Learn more about: Microsoft.Transactions.TransactionBridge.ParticipantStateMachineFinished"
title: "Microsoft.Transactions.TransactionBridge.ParticipantStateMachineFinished"
ms.date: "03/30/2017"
ms.assetid: 54b677f7-03ad-40f2-9c5d-297a8ad9bf90
---
# Microsoft.Transactions.TransactionBridge.ParticipantStateMachineFinished

The state machine for a participant enlistment entered the finished state.  
  
## Description  

 Traced when a subordinate participant enlistment has completed 2pc processing. The outcome for the enlistment can be Committed or Aborted. It is also traced if any participant votes ReadOnly during Prepare.  
  
## See also

- [Tracing](index.md)
- [Using Tracing to Troubleshoot Your Application](using-tracing-to-troubleshoot-your-application.md)
- [Administration and Diagnostics](../index.md)
