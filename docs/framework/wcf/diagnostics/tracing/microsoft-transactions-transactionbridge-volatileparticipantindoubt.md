---
description: "Learn more about: Microsoft.Transactions.TransactionBridge.VolatileParticipantInDoubt"
title: "Microsoft.Transactions.TransactionBridge.VolatileParticipantInDoubt"
ms.date: "03/30/2017"
ms.assetid: 3e8fc825-9f22-47e7-9c16-d64ef291c932
---
# Microsoft.Transactions.TransactionBridge.VolatileParticipantInDoubt

The WS-AT protocol service received a Prepared or Replay message from an unrecognized volatile participant. A fault was returned to the participant, declares that the transaction's outcome is in doubt.  
  
## Description  

 Traced when the local Transaction Manager receives a Prepared or Replay message from a Volatile enlistment that it has already forgotten.  
  
## Troubleshooting  

 Investigate potential causes of late messages coming from the Volatile participant.  
  
## See also

- [Tracing](index.md)
- [Using Tracing to Troubleshoot Your Application](using-tracing-to-troubleshoot-your-application.md)
- [Administration and Diagnostics](../index.md)
