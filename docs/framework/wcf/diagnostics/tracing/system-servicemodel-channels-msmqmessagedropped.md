---
title: "System.ServiceModel.Channels.MsmqMessageDropped"
ms.date: "03/30/2017"
ms.assetid: 8b6e644d-fa68-4be7-abe9-3659671a37c1
---
# System.ServiceModel.Channels.MsmqMessageDropped
MSMQ dropped the message.  
  
## Description  
 The trace indicates that an MSMQ message was dropped. MSMQ messages can be dropped when Windows Communication Foundation (WCF) (used with either the NetMsmqBinding or MsmqIntegrationBinding) is unable to process them. Such messages are referred to as poison messages.  
  
 A poison message is dropped when the `ReceiveErrorHandling` property on the NetMsmqBinding or MsmqIntegrationBinding is set to `Drop`. A dropped message is removed from the queue and is no longer recoverable.  
  
 See [Poison-Message Handling](https://go.microsoft.com/fwlink/?LinkID=99546) for more details on when messages become poison and how to configure your service to handle them appropriately.  
  
## See also

- [Tracing](../../../../../docs/framework/wcf/diagnostics/tracing/index.md)
- [Using Tracing to Troubleshoot Your Application](../../../../../docs/framework/wcf/diagnostics/tracing/using-tracing-to-troubleshoot-your-application.md)
- [Administration and Diagnostics](../../../../../docs/framework/wcf/diagnostics/index.md)
- [Poison-Message Handling](https://go.microsoft.com/fwlink/?LinkID=99546)
