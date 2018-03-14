---
title: "Performing Recovery"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 6dd17bf6-ba42-460a-a44b-8046f52b10d0
caps.latest.revision: 3
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Performing Recovery
A resource manager facilitates resolution of durable enlistments in a transaction by reenlisting the transaction participant after resource failure.  
  
## The Recovery Process  
 To durably enlist a resource (described by an implementation of the <xref:System.Transactions.IEnlistmentNotification> interface) that can later be eligible for recovery, you should call the <xref:System.Transactions.Transaction.EnlistDurable%2A> method. In addition, you must provide the <xref:System.Transactions.Transaction.EnlistDurable%2A> method with a resource manager identifier (a <xref:System.Guid>) that is used to consistently label the participant of the transaction in the event of a resource failure. For this reason, the <xref:System.Guid> that is provided to the initial Enlist call should be identical to the *resourceManagerIdentifier* parameter in the <xref:System.Transactions.TransactionManager.Reenlist%2A> call during recovery. Otherwise, <xref:System.Transactions.TransactionException> is thrown. For more information on durable enlistments, see [Enlisting Resources as Participants in a Transaction](../../../../docs/framework/data/transactions/enlisting-resources-as-participants-in-a-transaction.md) .  
  
 In the prepare phase (phase 1) of the 2PC protocol, when your implementation of a durable resource manager receives the <xref:System.Transactions.IEnlistmentNotification.Prepare%2A> notification, it should log its prepare record during this phase. The record should contain all the information that is necessary to complete the transaction on commit. The prepare record can later be accessed during recovery by retrieving the <xref:System.Transactions.PreparingEnlistment.RecoveryInformation%2A> property of the *preparingEnlistment* callback. The record logging does not need to be performed within the <xref:System.Transactions.IEnlistmentNotification.Prepare%2A> method as the RM can do this on a worker thread.  
  
 The recovery process consists of the following two steps:  
  
### Step 1 - ReEnlist  
 The resource manager examines the prepare information record for each enlistment that is in-doubt. This is done by examining the <xref:System.Transactions.PreparingEnlistment.RecoveryInformation%2A> property of the <xref:System.Transactions.PreparingEnlistment> callback, which is passed to the resource manager in the <xref:System.Transactions.IEnlistmentNotification.Prepare%2A> notification during phase 1.  
  
 For each such enlistment it examines, it invokes <xref:System.Transactions.TransactionManager.Reenlist%2A> on the transaction manager. This method passes on a unique <xref:System.Guid> that identifies the resource manager, as well as the enlistment's information in a byte array. A new <xref:System.Transactions.Enlistment> object is returned. If the reenlistment fails with an exception, the resource manager will need to retry at a later time.  
  
 You should only call the <xref:System.Transactions.TransactionManager.Reenlist%2A> method when a resource manager restarts from failure. In addition, you should only reenlist unresolved transactions logged by a resource manager during the initial Prepare phase of a two-phase commit. Any attempt to call this method at invalid times can produce erroneous results.  
  
 When a participant is reenlisted using this method, the phase 2 methods of <xref:System.Transactions.IEnlistmentNotification> that correspond to the transaction's outcome (that is, <xref:System.Transactions.IEnlistmentNotification.Commit%2A> , <xref:System.Transactions.IEnlistmentNotification.Rollback%2A> or <xref:System.Transactions.IEnlistmentNotification.InDoubt%2A> ) are called as appropriate.  
  
### Step 2 - Completing the recovery  
 When all the reenlistments are finished, the resource manager calls the <xref:System.Transactions.TransactionManager.RecoveryComplete%2A> method. This method completes the recovery and informs the transaction manager that the resource manager has no more in-doubt transactions. By doing so, the resource manager guarantees that it will not invoke the <xref:System.Transactions.TransactionManager.Reenlist%2A> method again.  
  
 A resource manager is not required to resolve all in-doubt transactions before enlisting in new transactions. The first step can be performed at any time after the resource manager establishes a relationship with the transaction manager, but after <xref:System.Transactions.TransactionManager.RecoveryComplete%2A> has been invoked (step 2); step 1 cannot be performed again. Step 2 can be repeated multiple times without affecting the outcome of transactions.
