---
description: "Learn more about: System.ServiceModel.Channels.MsmqMessageRejected"
title: "System.ServiceModel.Channels.MsmqMessageRejected"
ms.date: "03/30/2017"
ms.assetid: 9b7c10a7-2af6-44a2-8b1a-90bba0c7cf26
---
# System.ServiceModel.Channels.MsmqMessageRejected

MSMQ rejected the message.  
  
## Description  

 This trace indicates that an MSMQ message was rejected.  
  
 MSMQ messages can be rejected when Windows Communication Foundation (WCF) (used with either the NetMsmqBinding or MsmqIntegrationBinding) is unable to process them. Such messages are referred to as poison messages. A poison message is rejected when the `ReceiveErrorHandling` property on the NetMsmqBinding or MsmqIntegrationBinding is set to `Reject`. A rejected message is delivered back to the sender’s [Dead-Letter Queue](../../feature-details/using-dead-letter-queues-to-handle-message-transfer-failures.md).  
  
 For more information on when messages become poison and how to configure your service to handle them appropriately, see [Poison-Message Handling](../../feature-details/poison-message-handling.md).  
  
 For more information on what a rejected message means in MSMQ, see [MQMarkMessageRejected](/previous-versions/windows/desktop/msmq/ms707071(v=vs.85)).  
  
## See also

- [Tracing](index.md)
- [Using Tracing to Troubleshoot Your Application](using-tracing-to-troubleshoot-your-application.md)
- [Administration and Diagnostics](../index.md)
- [Poison-Message Handling](../../feature-details/poison-message-handling.md)
- [MQMarkMessageRejected](/previous-versions/windows/desktop/msmq/ms707071(v=vs.85))
