---
title: "Transaction Management Escalation"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 1e96331e-31b6-4272-bbbd-29ed1e110460
caps.latest.revision: 3
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Transaction Management Escalation
Windows hosts a set of services and modules that together constitute a transaction manager. Transaction management escalation describes the process of migrating a transaction from one of the transaction manager's components to another.  
  
 <xref:System.Transactions> includes a transaction manager component that coordinates a transaction involving at most, a single durable resource or multiple volatile resources. Because the transaction manager uses only intra-application domain calls, it yields the best performance. Developers need not interact with the transaction manager directly. Instead, a common infrastructure that defines interfaces, common behavior, and helper classes is provided by the <xref:System.Transactions> namespace.  
  
 When you want to provide the transaction to an object in another application domain (including across process and machine boundaries) on the same computer, the <xref:System.Transactions> infrastructure automatically escalates the transaction to be managed by the Microsoft Distributed Transaction Coordinator (MSDTC). The escalation also occurs if you enlist another durable resource manager. When escalated, the transaction remains managed in its elevated state until its completion.  
  
 Between the <xref:System.Transactions> transaction and MSDTC transaction, there is an intermediary type of transaction that is made available through the Promotable Single Phase Enlistment (PSPE). PSPE is another important mechanism in <xref:System.Transactions> for performance optimization. It allows a remote durable resource, located in a different application domain, process or computer, to participate in a <xref:System.Transactions> transaction without causing it to be escalated to an MSDTC transaction. For more information about PSPE, see [Enlisting Resources as Participants in a Transaction](../../../../docs/framework/data/transactions/enlisting-resources-as-participants-in-a-transaction.md).  
  
## How Escalation is Initiated  
 Transaction escalation reduces performance because the MSDTC resides in a separate process, and escalating a transaction to the MSDTC results in messages being sent across process. To improve performance, you should delay or avoid escalation to MSDTC; thus, you need to know how and when the escalation is initiated.  
  
 As long as the <xref:System.Transactions> infrastructure handles volatile resources and at most one durable resource that supports single-phase notifications, the transaction remains in the ownership of the <xref:System.Transactions> infrastructure. The transaction manager avails itself only to those resources that live in the same application domain and for which logging (writing the transaction outcome to disk) is not required. An escalation that results in the <xref:System.Transactions> infrastructure transferring the ownership of the transaction to MSDTC happens when:  
  
-   At least one durable resource that does not support single-phase notifications is enlisted in the transaction.  
  
-   At least two durable resources that support single-phase notifications are enlisted in the transaction. For example, enlisting a single connection with [!INCLUDE[sqprsqlong](../../../../includes/sqprsqlong-md.md)] does not cause a transaction to be promoted. However, whenever you open a second connection to a [!INCLUDE[sqprsqlong](../../../../includes/sqprsqlong-md.md)] database causing the database to enlist, the <xref:System.Transactions> infrastructure detects that it is the second durable resource in the transaction, and escalates it to an MSDTC transaction.  
  
-   A request to "marshal" the transaction to a different application domain or different process is invoked. For example, the serialization of the transaction object across an application domain boundary. The transaction object is marshaled-by-value, meaning that any attempt to pass it across an application domain boundary (even in the same process) results in serialization of the transaction object. You can pass the transaction objects by making a call on a remote method that takes a <xref:System.Transactions.Transaction> as a parameter or you can try to access a remote transactional-serviced component. This serializes the transaction object and results in an escalation, as when a transaction is serialized across an application domain. It is being distributed and the local transaction manager is no longer adequate.  
  
 The following table lists all the possible exceptions that can be thrown during escalation.  
  
|Exception type|Condition|  
|--------------------|---------------|  
|<xref:System.InvalidOperationException>|An attempt to escalate a transaction with isolation level equal to <xref:System.Transactions.IsolationLevel.Snapshot>.|  
|<xref:System.Transactions.TransactionAbortedException>|The transaction manager is down.|  
|<xref:System.Transactions.TransactionException>|The escalation fails and the application is aborted.|
