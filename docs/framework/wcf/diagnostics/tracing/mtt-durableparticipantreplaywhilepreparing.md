---
title: "Microsoft.Transactions.TransactionBridge.DurableParticipantReplayWhilePreparing"
ms.date: "03/30/2017"
ms.assetid: 10ef3876-6f8e-4d4e-8444-f47847b64795
---
# Microsoft.Transactions.TransactionBridge.DurableParticipantReplayWhilePreparing
The WS-AT protocol service received a Replay message from a durable participant, which did not respond to Prepare. Consequently, the transaction was aborted.  
  
## Description  
 Traced if a Replay message is received while a Durable participant is still Preparing. This is an illegal message for this state and the transaction is going to be aborted.  
  
## Troubleshooting

Receiving this error can indicate that a Durable participant (including Subordinate TransactionManagers) has recovered from failure; however, it is unsure of the transaction outcome and requests its status.  
  
## See also

- [Tracing](../../../../../docs/framework/wcf/diagnostics/tracing/index.md)
- [Using Tracing to Troubleshoot Your Application](../../../../../docs/framework/wcf/diagnostics/tracing/using-tracing-to-troubleshoot-your-application.md)
- [Administration and Diagnostics](../../../../../docs/framework/wcf/diagnostics/index.md)
