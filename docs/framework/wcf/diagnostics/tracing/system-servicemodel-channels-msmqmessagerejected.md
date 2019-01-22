---
title: "System.ServiceModel.Channels.MsmqMessageRejected"
ms.date: "03/30/2017"
ms.assetid: 9b7c10a7-2af6-44a2-8b1a-90bba0c7cf26
---
# System.ServiceModel.Channels.MsmqMessageRejected
MSMQ rejected the message.  
  
## Description  
 This trace indicates that an MSMQ message was rejected.  
  
 MSMQ messages can be rejected when Windows Communication Foundation (WCF) (used with either the NetMsmqBinding or MsmqIntegrationBinding) is unable to process them. Such messages are referred to as poison messages. A poison message is rejected when the `ReceiveErrorHandling` property on the NetMsmqBinding or MsmqIntegrationBinding is set to `Reject`. A rejected message is delivered back to the sender’s [Dead-Letter Queue](https://go.microsoft.com/fwlink/?LinkID=99544).  
  
 See [Poison-Message Handling](https://go.microsoft.com/fwlink/?LinkID=99546) for more details on when messages become poison and how to configure your service to handle them appropriately.  
  
 See [MQMarkMessageRejected](https://go.microsoft.com/fwlink/?LinkID=99548) for more details on what a rejected message means in MSMQ.  
  
## See also
 [Tracing](../../../../../docs/framework/wcf/diagnostics/tracing/index.md)  
 [Using Tracing to Troubleshoot Your Application](../../../../../docs/framework/wcf/diagnostics/tracing/using-tracing-to-troubleshoot-your-application.md)  
 [Administration and Diagnostics](../../../../../docs/framework/wcf/diagnostics/index.md)  
 [Poison-Message Handling](https://go.microsoft.com/fwlink/?LinkID=99546)  
 [MQMarkMessageRejected](https://go.microsoft.com/fwlink/?LinkID=99548)
