---
title: "Optimization using Single Phase Commit and Promotable Single Phase Notification"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 57beaf1a-fb4d-441a-ab1d-bc0c14ce7899
caps.latest.revision: 3
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Optimization using Single Phase Commit and Promotable Single Phase Notification
This topic describes the mechanisms provided by the <xref:System.Transactions> infrastructure to optimize performance.  
  
## Promotable Single Phase Enlistment  
 The <xref:System.Transactions> infrastructure administrates a transaction inside a single application domain that involves at most a single durable resource or multiple volatile resources. Since the <xref:System.Transactions> infrastructure uses only intra-application domain calls, it yields the best throughput and performance.  
  
 However, if the transaction is provided to another object in another application domain (including across process and machine boundaries) on the same computer, or if you were to enlist another durable resource manager, the <xref:System.Transactions> infrastructure automatically escalates the transaction to be managed by the MSDTC. A transaction managed by MSDTC is not as performance-wise as one managed by the <xref:System.Transactions> infrastructure.  
  
 To optimize performance, the <xref:System.Transactions> infrastructure provides the Promotable Single Phase Enlistment (PSPE) that allows a single remote durable resource, located in a different application domain, process or machine, to participate in a <xref:System.Transactions> transaction without causing it to be escalated to an MSDTC transaction.  This resource manager (RM) can host and "own" a transaction that can later be escalated to a distributed transaction (or MSDTC transaction) if necessary. This reduces the chance of using the MSDTC.  
  
 This specific resource manager usually has its own internal non distributed transactions and it needs to support converting those transactions to distributed transactions at runtime. For example, SQL Server 2005 is such a resource manager. In such case, the <xref:System.Transactions> infrastructure takes a passive management role by just monitoring the transaction for a need for escalation. To support the interaction between the <xref:System.Transactions> infrastructure and resource manager, the latter needs to implement the interface <xref:System.Transactions.IPromotableSinglePhaseNotification>.  
  
 The <xref:System.Transactions.Transaction.EnlistPromotableSinglePhase%2A> method is used to enlist a single durable resource that can be escalated later. This method ensures that the enlistment can be escalated as needed. If the enlistment succeeds, the RM creates its internal transaction and associates it with the <xref:System.Transactions> transaction. If the PSPE enlistment fails, the RM should instead enlist using the <xref:System.Transactions.Transaction.EnlistDurable%2A> method. Failures to enlist in PSPE might happen when the transaction is already a distributed transaction, or when another RM has already performed a PSPE enlistment  
  
 Once enlisted, calls by clients to commit or abort the <xref:System.Transactions> transaction are converted to calls on the Resource Manager by invoking the <xref:System.Transactions.IPromotableSinglePhaseNotification.SinglePhaseCommit%2A> method, or the <xref:System.Transactions.IPromotableSinglePhaseNotification.Rollback%2A> respectively.  
  
 If the <xref:System.Transactions> transaction never requires escalation, when the transaction is committed, the RM receives a <xref:System.Transactions.IPromotableSinglePhaseNotification.SinglePhaseCommit%2A> notification. It can then commit the internal transaction that was initially created.  
  
 If the <xref:System.Transactions> transaction needs to be escalated (e.g., to support multiple RMs), <xref:System.Transactions> informs the resource manager by calling the <xref:System.Transactions.ITransactionPromoter.Promote%2A> method on the <xref:System.Transactions.ITransactionPromoter> interface, from which the <xref:System.Transactions.IPromotableSinglePhaseNotification> interface derives. The resource manager then converts the transaction internally from a local transaction (which does not require logging) to a transaction object that is capable of participating in a DTC transaction, and associates it with the work already done. When the transaction is asked to commit, the transaction manager still sends the <xref:System.Transactions.IPromotableSinglePhaseNotification.SinglePhaseCommit%2A> notification to the resource manager, which commits the distributed transaction that it created during escalation.  
  
> [!NOTE]
>  The **TransactionCommitted** traces (that are generated when a Commit is invoked on the escalated transaction) contain the activity ID of the DTC transaction.  
  
 For more information on management escalation, see [Transaction Management Escalation](../../../../docs/framework/data/transactions/transaction-management-escalation.md).  
  
## Transaction Management Escalation Scenario  
 The following scenario demonstrates an escalation to a distributed transaction using the <xref:System.Data> namespace as the ‘proxy’ for the resource manager. This scenario assumes that there is already one <xref:System.Data> connection to the database, CN1, involved in the transaction, and the application wants to involve another <xref:System.Data> connection, CN2. The transaction must be escalated to DTC, as a full distributed two-phase commit transaction.  
  
 In this scenario,  
  
1.  CN1 calls the <xref:System.Transactions.Transaction.EnlistPromotableSinglePhase%2A> method to enlist in the transaction. Then, the transaction is still local and there are no other promotable enlistments on the transaction, so the <xref:System.Transactions.Transaction.EnlistPromotableSinglePhase%2A> call succeeds.  
  
2.  When the second connection, CN2 calls <xref:System.Transactions.Transaction.EnlistPromotableSinglePhase%2A>, the call fails because there is another promotable enlistment involved. Because of this, CN2 must get a DTC transaction in order to pass it to SQL. To do this, it uses one of the methods provided by the <xref:System.Transactions.TransactionInterop> class to produce a format of the transaction that can be given to SQL.  
  
3.  <xref:System.Transactions> calls the <xref:System.Transactions.ITransactionPromoter.Promote%2A> method on the <xref:System.Transactions.ITransactionPromoter> interface implemented by CN1.  
  
4.  At this point, CN1 escalates the transaction, using some mechanism specific to SQL 2005 and <xref:System.Data>.  
  
5.  The return value from the <xref:System.Transactions.ITransactionPromoter.Promote%2A> method is a byte array that contains a propagation token for the transaction. <xref:System.Transactions> uses this propagaition token to create a DTC transaction that it can incorporate into the local transaction.  
  
6.  At this point, CN2 can use the data received from calling one of the methods by <xref:System.Transactions.TransactionInterop> to pass the transaction to SQL.  
  
7.  Now, both are enlisted in a DTC distributed transaction.  
  
## Single Phase Commit Optimization  
 The Single Phase Commit protocol is more efficient at runtime as all updates are done without any explicit coordination. To take advantage of this optimization, you should implement a resource manager using <xref:System.Transactions.ISinglePhaseNotification> interface for the resource and enlist in a transaction using the <xref:System.Transactions.Transaction.EnlistDurable%2A> or <xref:System.Transactions.Transaction.EnlistVolatile%2A> method. Specifically, the *EnlistmentOptions* parameter should equal to <xref:System.Transactions.EnlistmentOptions.None> to ensure that a single phase commit would be performed.  
  
 Since the <xref:System.Transactions.ISinglePhaseNotification> interface derives from the <xref:System.Transactions.IEnlistmentNotification> interface, if your RM is not eligible for single phase commit, it can still receive the two phase commit notifications.  If your RM receives a <xref:System.Transactions.ISinglePhaseNotification.SinglePhaseCommit%2A> notification from the TM, it should try to do the work necessary for it to commit and correspondingly inform the transaction manager if the transaction is to be committed or rolled back by calling the <xref:System.Transactions.SinglePhaseEnlistment.Committed%2A>, <xref:System.Transactions.SinglePhaseEnlistment.Aborted%2A>, or <xref:System.Transactions.SinglePhaseEnlistment.InDoubt%2A> method on the <xref:System.Transactions.SinglePhaseEnlistment> parameter. A response of <xref:System.Transactions.Enlistment.Done%2A> on the enlistment at this stage implies ReadOnly semantics. Therefore, you should not reply <xref:System.Transactions.Enlistment.Done%2A> in addition to any of the other methods.  
  
 If there is only one volatile enlistment and no durable enlistment, the volatile enlistment receives SPC notification.  If there are any volatile enlistments and only one durable enlistment, the volatile enlistments receive 2PC. When it is completed, the durable enlistment receives SPC.  
  
## See Also  
 [Enlisting Resources as Participants in a Transaction](../../../../docs/framework/data/transactions/enlisting-resources-as-participants-in-a-transaction.md)  
 [Committing a Transaction in Single-Phase and Multi-Phase](../../../../docs/framework/data/transactions/committing-a-transaction-in-single-phase-and-multi-phase.md)
