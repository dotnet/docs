---
title: "Implementing a Resource Manager"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: d5c153f6-4419-49e3-a5f1-a50ae4c81bf3
caps.latest.revision: 3
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Implementing a Resource Manager
Each resource used in a transaction is managed by a resource manager, whose actions are coordinated by a transaction manager. Resource managers work in cooperation with the transaction manager to provide the application with a guarantee of atomicity and isolation. Microsoft SQL Server, durable message queues, in-memory hash tables are all examples of resource managers.  
  
 A resource manager manages either durable or volatile data. The durability (or conversely the volatility) of a resource manager refers to whether the resource manager supports failure recovery. If a resource manager supports failure recovery, it persists data to durable storage during Phase1 (prepare) such that if the resource manager goes down, it can re-enlist in the transaction upon recovery and perform the proper actions based on the notifications received from the transaction manager. In general, volatile resource managers manage volatile resources such as an in-memory data structure (for example, an in-memory transacted-hashtable), and durable resource managers manage resources that have a more persistent backing store (for example, a database whose backing store is disk).  
  
 In order for a resource to participate in a transaction, it must enlist in the transaction. The <xref:System.Transactions.Transaction> class defines a set of methods whose names begin with **Enlist** that provide this functionality. The different **Enlist** methods correspond to the different types of enlistment that a resource manager may have. Specifically, you use the <xref:System.Transactions.Transaction.EnlistVolatile%2A> methods for volatile resources, and the <xref:System.Transactions.Transaction.EnlistDurable%2A> method for durable resources. For simplicity, after deciding whether to use the <xref:System.Transactions.Transaction.EnlistDurable%2A> or <xref:System.Transactions.Transaction.EnlistVolatile%2A> method based on your resource's durability support, you should enlist your resource to participate in Two Phase Commit (2PC) by implementing the <xref:System.Transactions.IEnlistmentNotification> interface for your resource manager. For more information on 2PC, see [Committing a Transaction in Single-Phase and Multi-Phase](../../../../docs/framework/data/transactions/committing-a-transaction-in-single-phase-and-multi-phase.md).  
  
 By enlisting, the resource manager ensures that it gets callbacks from the transaction manager when the transaction commits or aborts. There is one instance of <xref:System.Transactions.IEnlistmentNotification> per enlistment. Typically, there is one enlistment per transaction, but a resource manager can choose to enlist multiple times in the same transaction.  
  
 After enlistment, the resource manager responds to the transaction's requests. A durable resource manager stores enough information to allow it to either undo or redo the transaction's work on resources it manages. There are many ways to do this; keeping versions of data or keeping a log of the changes are two common techniques.  
  
 When the application commits the transaction, the transaction manager initiates the two-phase commit protocol. The transaction manager first asks each enlisted resource manager if it is prepared to commit the transaction. The resource manager must prepare to commit—it readies itself to either commit or abort the transaction.  
  
 During the prepare phase, the durable resource manager records the old and new data in stable storage so that the resource manager can recover it even if the system fails. If the resource manager can prepare, it informs the transaction manager its vote on whether to commit or abort the transaction. If any resource manager reports a failure to prepare, the transaction manager sends a rollback command to each resource manager and indicates the failure of the commit to the application.  
  
 Once prepared, a resource manager must wait until it gets a commit or abort callback from the transaction manager in phase 2. Typically, the entire prepare and commit protocol completes in a fraction of a second. If there are system or communication failures, the commit or abort notification may not arrive for minutes or hours. During this period, the resource manager is in doubt about the outcome of the transaction. It does not know whether the transaction committed or aborted. While the resource manager is in doubt about a transaction, it keeps the data modified by keeping the transaction locked, thereby isolating these changes from any other transactions.  
  
 When a resource manager fails, all of its enlisted transactions are aborted except for those that are prepared or committed prior to the failure. When a durable resource manager restarts, it reconstructs the committed state of the resources it manages by retrieving the prepare information written in the prepare phase, and commits or aborts these transactions accordingly.  
  
 In summary, the two-phase commit protocol and the resource managers combine to make transactions atomic and durable.  
  
 The <xref:System.Transactions.Transaction> class also provides the <xref:System.Transactions.Transaction.EnlistPromotableSinglePhase%2A> method to enlist a Promotable Single Phase Enlistment (PSPE). This allows a durable resource manager (RM) to host and "own" a transaction that can later be escalated to be managed by the MSDTC if necessary. For more information on this, see [Optimization using Single Phase Commit and Promotable Single Phase Notification](../../../../docs/framework/data/transactions/optimization-spc-and-promotable-spn.md).  
  
## In This Section  
 The steps generally followed by a resource manager are outlined in the following topics.  
  
 [Enlisting Resources as Participants in a Transaction](../../../../docs/framework/data/transactions/enlisting-resources-as-participants-in-a-transaction.md)  
  
 Describes how a durable or volatile resource can enlist in a transaction.  
  
 [Committing a Transaction in Single-Phase and Multi-Phase](../../../../docs/framework/data/transactions/committing-a-transaction-in-single-phase-and-multi-phase.md)  
  
 Describes how a resource manager responds to commit notification and prepare the commit.  
  
 [Performing Recovery](../../../../docs/framework/data/transactions/performing-recovery.md)  
  
 Describes how a durable resource manager recovers from failure.  
  
 [Security Trust Levels in Accessing Resources](../../../../docs/framework/data/transactions/security-trust-levels-in-accessing-resources.md)  
  
 Describes how the three levels of trust for System.Transactions restrict access on the types of resources that <xref:System.Transactions> exposes.  
  
 [Optimization using Single Phase Commit and Promotable Single Phase Notification](../../../../docs/framework/data/transactions/optimization-spc-and-promotable-spn.md)  
  
 Describes optimization practices available to implementations of resource managers.
