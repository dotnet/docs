---
title: "Enlisting Resources as Participants in a Transaction"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
ms.assetid: 786a12c2-d530-49f4-9c59-5c973e15a11d
caps.latest.revision: 3
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Enlisting Resources as Participants in a Transaction
Each resource participating in a transaction is managed by a resource manager, whose actions are coordinated by a transaction manager. The coordination is done through notifications given to subscribers who have enlisted in a transaction through the transaction manager.  
  
 This topic covers how a resource (or multiple resources) can be enlisted in a transaction, as well as the different types of enlistment. The [Committing a Transaction in Single-Phase and Multi-Phase](../../../../docs/framework/data/transactions/committing-a-transaction-in-single-phase-and-multi-phase.md) topic covers how transaction commitment can be coordinated among enlisted resources.  
  
## Enlisting Resources in a Transaction  
 In order for a resource to participate in a transaction, it must enlist in the transaction. The <xref:System.Transactions.Transaction> class defines a set of methods whose names begin with **Enlist** that provide this functionality. The different **Enlist** methods correspond to the different types of enlistment that a resource manager may have. Specifically, you use the <xref:System.Transactions.Transaction.EnlistVolatile%2A> methods for volatile resources, and the <xref:System.Transactions.Transaction.EnlistDurable%2A> method for durable resources. The durability (or conversely the volatility) of a resource manager refers to whether the resource manager supports failure recovery. If a resource manager supports failure recovery, it persists data to durable storage during Phase1 (prepare) such that if the resource manager goes down, it can re-enlist in the transaction upon recovery and perform the proper actions based on the notifications received from the TM. In general, volatile resource managers manage volatile resources such as an in-memory data structure (for example, an in-memory transacted-hashtable), and durable resource managers manage resources that have a more persistent backing store (for example, a database whose backing store is disk).  
  
 For simplicity, after deciding whether to use the <xref:System.Transactions.Transaction.EnlistDurable%2A> or <xref:System.Transactions.Transaction.EnlistVolatile%2A> method based on your resource's durability support, you should enlist your resource to participate in Two Phase Commit (2PC) by implementing the <xref:System.Transactions.IEnlistmentNotification> interface for your resource manager. For more information on 2PC, see [Committing a Transaction in Single-Phase and Multi-Phase](../../../../docs/framework/data/transactions/committing-a-transaction-in-single-phase-and-multi-phase.md).  
  
 A single participant can enlist for more than one of these protocols by calling <xref:System.Transactions.Transaction.EnlistDurable%2A> and <xref:System.Transactions.Transaction.EnlistVolatile%2A> multiple times.  
  
### Durable Enlistment  
 The <xref:System.Transactions.Transaction.EnlistDurable%2A> methods are used to enlist a resource manager for participation in the transaction as a durable resource.  It is expected that if a durable resource manager is brought down in the middle of a transaction, it can perform recovery once it is brought back online by reenlisting (using the <xref:System.Transactions.TransactionManager.Reenlist%2A> method) in all transactions in which it was a participant and did not complete phase 2, and call <xref:System.Transactions.TransactionManager.RecoveryComplete%2A> once it finishes recovery processing. For more information on recovery, see [Performing Recovery](../../../../docs/framework/data/transactions/performing-recovery.md).  
  
 The <xref:System.Transactions.Transaction.EnlistDurable%2A> methods all take a <xref:System.Guid> object as their first parameter. The <xref:System.Guid> is used by the transaction manager to associate a durable enlistment with a particular resource manager. As such, it is imperative that a resource manager consistently uses the same <xref:System.Guid> to identify itself even across different resource managers upon restarting, otherwise the recovery can fail.  
  
 The second parameter of the <xref:System.Transactions.Transaction.EnlistDurable%2A> method is a reference to the object that the resource manager implements to receive transaction notifications. The overload you use informs the transaction manager whether your resource manager supports the Single Phase Commit (SPC) optimization. Most of the time you would implement the <xref:System.Transactions.IEnlistmentNotification> interface to take part in Two-Phase Commit (2PC). However, if you want to optimize the commit process, you can consider implementing the <xref:System.Transactions.ISinglePhaseNotification> interface for SPC. For more information on SPC, see [Committing a Transaction in Single-Phase and Multi-Phase](../../../../docs/framework/data/transactions/committing-a-transaction-in-single-phase-and-multi-phase.md) and [Optimization using Single Phase Commit and Promotable Single Phase Notification](../../../../docs/framework/data/transactions/optimization-spc-and-promotable-spn.md).  
  
 The third parameter is an <xref:System.Transactions.EnlistmentOptions> enumeration, whose value can be either <xref:System.Transactions.EnlistmentOptions.None> or <xref:System.Transactions.EnlistmentOptions.EnlistDuringPrepareRequired>. If the value is set to <xref:System.Transactions.EnlistmentOptions.EnlistDuringPrepareRequired>, the enlistment may enlist additional resource managers upon receiving the Prepare notification from the transaction manager. However, you should be aware that this type of enlistment is not eligible for the Single Phase Commit optimization.  
  
### Volatile Enlistment  
 Participants managing volatile resources such as a cache should enlist using the <xref:System.Transactions.Transaction.EnlistVolatile%2A> methods. Such objects might not be able to obtain the outcome of a transaction or recover the state of any transaction they participate in after a system failure.  
  
 As stated previously, a resource manager would make a volatile enlistment if it manages an in-memory, volatile resource. One of the benefits of using <xref:System.Transactions.Transaction.EnlistVolatile%2A> is that it does not force an unnecessary escalation of the transaction. For more information on transaction escalation, see [Transaction Management Escalation](../../../../docs/framework/data/transactions/transaction-management-escalation.md) topic. Enlisting volatilely implies both a difference in how the enlistment is handled by the transaction manager, as well as what is expected of the resource manager by the transaction manager. This is because a volatile resource manager does not perform recovery. The <xref:System.Transactions.Transaction.EnlistVolatile%2A> methods do not take a <xref:System.Guid> parameter, because a volatile resource manager does not perform recovery and would not call the <xref:System.Transactions.TransactionManager.Reenlist%2A> method which needs a <xref:System.Guid>.  
  
 As with durable enlistments, whichever overload method you use to enlist denotes to the transaction manager whether your resource manager supports the Single Phase Commit optimization. Since a volatile resource manager cannot perform recovery, no recovery information is written for a volatile enlistment during the Prepare phase. Therefore, calling the <xref:System.Transactions.PreparingEnlistment.RecoveryInformation%2A> method results in an <xref:System.InvalidOperationException>.  
  
 The following example shows how to enlist such an object as a participant in a transaction using the <xref:System.Transactions.Transaction.EnlistVolatile%2A> method.  
  
 [!code-csharp[Tx_Enlist#1](../../../../samples/snippets/csharp/VS_Snippets_CFX/tx_enlist/cs/enlist.cs#1)]
 [!code-vb[Tx_Enlist#1](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/tx_enlist/vb/enlist.vb#1)]  
  
### Optimizing Performance  
 The <xref:System.Transactions.Transaction> class also provides the <xref:System.Transactions.Transaction.EnlistPromotableSinglePhase%2A> method to enlist a Promotable Single Phase Enlistment (PSPE). This allows a durable resource manager (RM) to host and "own" a transaction that can later be escalated to be managed by the MSDTC if necessary. For more information on this, see [Optimization using Single Phase Commit and Promotable Single Phase Notification](../../../../docs/framework/data/transactions/optimization-spc-and-promotable-spn.md).  
  
## See Also  
 [Optimization using Single Phase Commit and Promotable Single Phase Notification](../../../../docs/framework/data/transactions/optimization-spc-and-promotable-spn.md)  
 [Committing a Transaction in Single-Phase and Multi-Phase](../../../../docs/framework/data/transactions/committing-a-transaction-in-single-phase-and-multi-phase.md)
