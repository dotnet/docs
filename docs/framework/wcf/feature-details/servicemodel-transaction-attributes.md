---
title: "ServiceModel Transaction Attributes"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "transactions [WCF], ServiceModel attributes"
ms.assetid: 1e0d2436-6ae5-439b-9765-a448d6f60000
caps.latest.revision: 18
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ServiceModel Transaction Attributes
[!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] provides properties on three standard <xref:System.ServiceModel> attributes that enable you to configure the behavior of transactions for a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] service:  
  
-   <xref:System.ServiceModel.TransactionFlowAttribute>  
  
-   <xref:System.ServiceModel.ServiceBehaviorAttribute>  
  
-   <xref:System.ServiceModel.OperationBehaviorAttribute>  
  
## TransactionFlowAttribute  
 The <xref:System.ServiceModel.TransactionFlowAttribute> attribute specifies the willingness of an operation in a service contract to accept incoming transactions from a client. The attribute provides this control with the following property: Transactions use the <xref:System.ServiceModel.TransactionFlowOption> enumeration to specify whether an incoming transaction is <xref:System.ServiceModel.TransactionFlowOption.Mandatory>, <xref:System.ServiceModel.TransactionFlowOption.Allowed>, or <xref:System.ServiceModel.TransactionFlowOption.NotAllowed>.  
  
 This is the only attribute that relates service operations to external interactions with a client. The attributes described in the following sections relate to the use of transactions within the execution of the operation.  
  
## ServiceBehaviorAttribute  
 The <xref:System.ServiceModel.ServiceBehaviorAttribute> attribute specifies the internal execution behavior of a service contract implementation. Transaction-specific properties of this attribute include:  
  
-   <xref:System.ServiceModel.ServiceBehaviorAttribute.TransactionAutoCompleteOnSessionClose%2A> specifies whether to complete an uncompleted transaction when the session closes. The default value for this property is `false`. If this property is `true`, and the incoming session was gracefully shut down instead of closing due to network or client faults, any uncompleted transaction is successfully completed. Otherwise, if this property is `false` or if the session was not gracefully closed, any uncompleted transaction is rolled back when the session closes. If this property is `true`, the incoming channel must be session-based.  
  
-   <xref:System.ServiceModel.ServiceBehaviorAttribute.ReleaseServiceInstanceOnTransactionComplete%2A> specifies whether the underlying service instance is released when a transaction completes. The default value for this property is `true`. The next inbound message causes a new underlying instance to be created, discarding any per-transaction state that the previous instance might have held. Releasing a service instance is an internal action the service takes and has no impact on any existing connections or sessions that clients might have established. This functionality is equivalent to the just-in-time activation feature COM+ provides. If the property is `true`, <xref:System.ServiceModel.ServiceBehaviorAttribute.ConcurrencyMode%2A> must be equal to <xref:System.ServiceModel.ConcurrencyMode.Single>. Otherwise, the service throws an invalid configuration validation exception during startup.  
  
-   <xref:System.ServiceModel.ServiceBehaviorAttribute.TransactionIsolationLevel%2A> specifies the isolation level to use for transactions within the service; this property takes one of the <xref:System.Transactions.IsolationLevel> values. If the local isolation level property is anything other than <xref:System.Transactions.IsolationLevel.Unspecified>, the isolation level of an incoming transaction must match the setting of this local property. Otherwise, the incoming transaction is rejected, and a fault is sent back to the client. If <xref:System.ServiceModel.OperationBehaviorAttribute.TransactionScopeRequired%2A> is `true`, and no transaction is flowed, this property determines the <xref:System.Transactions.IsolationLevel> value to use for the locally created transaction. If <xref:System.Transactions.IsolationLevel> is set to <xref:System.Transactions.IsolationLevel.Unspecified>, <xref:System.Transactions.IsolationLevel><xref:System.Transactions.IsolationLevel.Serializable> is used.  
  
-   <xref:System.ServiceModel.ServiceBehaviorAttribute.TransactionTimeout%2A> specifies the time period within which a new transaction created at the service must complete. If this time is reached and the transaction has not been completed, it will abort. The <xref:System.TimeSpan> is used as the <xref:System.Transactions.TransactionScope> time-out for any operations that have <xref:System.ServiceModel.OperationBehaviorAttribute.TransactionScopeRequired%2A> set to `true` and for which a new transaction was created. The time-out is the maximum allowed duration from the creation of the transaction to the completion of phase 1 in the two-phase commit protocol. The time-out value used is always the lower value between the <xref:System.ServiceModel.ServiceBehaviorAttribute.TransactionTimeout%2A> property and the `transactionTimeout` configuration setting.  
  
## OperationBehaviorAttribute  
 The <xref:System.ServiceModel.OperationBehaviorAttribute> attribute specifies the behaviors of the methods in the service implementation. You can use it to indicate the operation's specific execution behavior. Properties of this attribute do not affect the Web Service Description Language (WSDL) description of the service contract, and are purely elements of the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] programming model that enable common features that developers otherwise have to implement themselves.  
  
 This attribute has the following transaction-specific properties:  
  
-   <xref:System.ServiceModel.OperationBehaviorAttribute.TransactionScopeRequired%2A> specifies whether a method must execute within an active transaction scope. The default is `false`. If the <xref:System.ServiceModel.OperationBehaviorAttribute> attribute is not set for a method, it also implies that the method will not execute in a transaction. If a transaction scope is not required for an operation, any transaction that is present within the message header is not activated and remains as an element of the <xref:System.ServiceModel.OperationContext.IncomingMessageProperties%2A> of the <xref:System.ServiceModel.OperationContext>. If a transaction scope is required for an operation, the source for the transaction is derived from one of the following:  
  
    -   If a transaction is flowed from the client, the method is executed under a transaction scope created using that distributed transaction.  
  
    -   With a queued transport, the transaction used to dequeue the message is used. Note that the transaction used is not a flowed transaction, in that it was not provided by the original sender of the message.  
  
    -   A custom transport can provide a transaction through the use of the `TransportTransactionProperty`.  
  
    -   If none of the above provides an external source for a transaction, a new <xref:System.Transactions.Transaction> instance is created immediately prior to calling the method.  
  
-   <xref:System.ServiceModel.OperationBehaviorAttribute.TransactionAutoComplete%2A> specifies whether the transaction in which the method executes is automatically completed if no unhandled exceptions are thrown. If this property is `true`, the calling infrastructure automatically marks the transaction as "completed" if the user method returns without throwing an exception. If this property is `false`, the transaction is attached to the instance, and is only marked as "completed" if the client calls a subsequent method that is marked with this property equal to `true`, or if a subsequent method explicitly calls <xref:System.ServiceModel.OperationContext.SetTransactionComplete%2A>. Failure to perform either of these results in the transaction never being "completed," and the contained work is not committed, unless the <xref:System.ServiceModel.ServiceBehaviorAttribute.TransactionAutoCompleteOnSessionClose%2A> property is set to `true`. If this property is set to `true`, you must use a channel with a session, and the <xref:System.ServiceModel.ServiceBehaviorAttribute.InstanceContextMode%2A> must be set to <xref:System.ServiceModel.InstanceContextMode.PerSession>.
