---
description: "Learn more about: System.ServiceModel.Channels.MsmqMoveOrDeleteAttemptFailed"
title: "System.ServiceModel.Channels.MsmqMoveOrDeleteAttemptFailed"
ms.date: "03/30/2017"
ms.assetid: d75d39da-7502-4a6a-91b9-eaa05b8e24d5
---
# System.ServiceModel.Channels.MsmqMoveOrDeleteAttemptFailed

Cannot move or delete message.  
  
## Description  

 The trace indicates that a failure occurred when attempting to move, delete, or reject an MSMQ message.  
  
 MSMQ messages are employed by Windows Communication Foundation (WCF) (when used with either the NetMsmqBinding or the MsmqIntegrationBinding).This trace is related to the chosen value of the `ReceiveErrorHandling` property on the NetMsmqBinding or MsmqIntegrationBinding.  
  
 This trace is not indicative of an overall system failure. However, it indicates that the chosen poison message disposition failed for a message. For more information on when messages become poison and how to configure your service to handle them appropriately, see [Poison-Message Handling](../../feature-details/poison-message-handling.md).  
  
## See also

- [Tracing](index.md)
- [Using Tracing to Troubleshoot Your Application](using-tracing-to-troubleshoot-your-application.md)
- [Administration and Diagnostics](../index.md)
