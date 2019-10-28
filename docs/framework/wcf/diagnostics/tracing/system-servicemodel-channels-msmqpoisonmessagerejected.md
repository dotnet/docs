---
title: "System.ServiceModel.Channels.MsmqPoisonMessageRejected"
ms.date: "03/30/2017"
ms.assetid: 0e64b9bd-1f12-43df-a189-d7be3c2bace1
---
# System.ServiceModel.Channels.MsmqPoisonMessageRejected
Poison message rejected.  
  
## Description  
 The trace indicates that a poison message was encountered and subsequently rejected. This occurs when the `ReceiveErrorHandling` property on the NetMsmqBinding or MsmqIntegrationBinding is set to `Reject`. A rejected message is delivered back to the sender’s [Dead-Letter Queue](/dotnet/framework/wcf/feature-details/using-dead-letter-queues-to-handle-message-transfer-failures).  
  
 See [Poison-Message Handling](/dotnet/framework/wcf/feature-details/poison-message-handling) for more details on when messages become poison and how to configure your service to handle them appropriately. See [MQMarkMessageRejected](/previous-versions/windows/desktop/msmq/ms707071(v%3dvs.85)) for more details on what a rejected message means in MSMQ.  
  
## See also

- [Tracing](../../../../../docs/framework/wcf/diagnostics/tracing/index.md)
- [Using Tracing to Troubleshoot Your Application](../../../../../docs/framework/wcf/diagnostics/tracing/using-tracing-to-troubleshoot-your-application.md)
- [Administration and Diagnostics](../../../../../docs/framework/wcf/diagnostics/index.md)
- [Poison-Message Handling](/dotnet/framework/wcf/feature-details/poison-message-handling)
- [MQMarkMessageRejected](/previous-versions/windows/desktop/msmq/ms707071(v%3dvs.85))
