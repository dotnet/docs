---
description: "Learn more about: System.ServiceModel.Channels.MsmqPoisonMessageRejected"
title: "System.ServiceModel.Channels.MsmqPoisonMessageRejected"
ms.date: "03/30/2017"
ms.assetid: 0e64b9bd-1f12-43df-a189-d7be3c2bace1
---
# System.ServiceModel.Channels.MsmqPoisonMessageRejected

Poison message rejected.  
  
## Description  

 The trace indicates that a poison message was encountered and subsequently rejected. This occurs when the `ReceiveErrorHandling` property on the NetMsmqBinding or MsmqIntegrationBinding is set to `Reject`. A rejected message is delivered back to the sender’s [Dead-Letter Queue](../../feature-details/using-dead-letter-queues-to-handle-message-transfer-failures.md).  
  
 For more information on when messages become poison and how to configure your service to handle them appropriately, see [Poison-Message Handling](../../feature-details/poison-message-handling.md). For more information on what a rejected message means in MSMQ, see [MQMarkMessageRejected](/previous-versions/windows/desktop/msmq/ms707071(v=vs.85)).  
  
## See also

- [Tracing](index.md)
- [Using Tracing to Troubleshoot Your Application](using-tracing-to-troubleshoot-your-application.md)
- [Administration and Diagnostics](../index.md)
- [Poison-Message Handling](../../feature-details/poison-message-handling.md)
- [MQMarkMessageRejected](/previous-versions/windows/desktop/msmq/ms707071(v=vs.85))
