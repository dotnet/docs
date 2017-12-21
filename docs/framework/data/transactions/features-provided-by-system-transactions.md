---
title: "Features Provided by System.Transactions"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: e458cef9-63b5-4401-b448-1536dcd9d9e5
caps.latest.revision: 3
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Features Provided by System.Transactions
This section describes how you can use the features provided by the <xref:System.Transactions> namespace to write your own transactional application and resource manager. Specifically, this section covers how to create and participate in a transaction (local or distributed) with one or multiple participants.  
  
## Overview of System.Transactions  
 The infrastructure provided by the classes in the <xref:System.Transactions> namespace makes transactional programming simple and efficient by supporting transactions initiated in SQL Server, ADO.NET, Message Queuing (MSMQ), and the Microsoft Distributed Transaction Coordinator (MSDTC). The <xref:System.Transactions> namespace provides both an explicit programming model based on the <xref:System.Transactions.Transaction> class, as well as an implicit programming model using the <xref:System.Transactions.TransactionScope> class, in which transactions are automatically managed by the infrastructure. For more information on how to create a transactional application using these two models, see [Writing a Transactional Application](../../../../docs/framework/data/transactions/writing-a-transactional-application.md).  
  
 The <xref:System.Transactions> namespace also provides types for you to implement a resource manager. A resource manager manages durable or volatile data used in a transaction, and work in cooperation with the transaction manager to provide the application with a guarantee of atomicity and isolation. The transaction manager that is provided by the <xref:System.Transactions> infrastructure supports transactions involving multiple volatile resources or a single durable resource. For more information on implementing a resource manager, see [Implementing a Resource Manager](../../../../docs/framework/data/transactions/implementing-a-resource-manager.md).  
  
 The transaction manager also transparently escalates local transactions to distributed transactions by coordinating with a disk-based transaction manager like the DTC, when an additional durable resource manager enlists itself with a transaction. There are two key ways that the <xref:System.Transactions> infrastructure provides enhanced performance.  
  
-   Dynamic Escalation, which ensures that the <xref:System.Transactions> infrastructure only engages the MSDTC when a transaction spans across multiple distributed resources. For more information about dynamic escalation. see [Transaction Management Escalation](../../../../docs/framework/data/transactions/transaction-management-escalation.md) topic.  
  
-   Promotable Enlistments, which allows a resource, such as a database, to take ownership of the transaction if it is the only entity participating in the transaction. Later, if needed, the <xref:System.Transactions> infrastructure can still escalate the management of the transaction to the MSDTC. This further reduces the chance of using the MSDTC. Promotable Enlistments are covered in depth in the topic[Optimization using Single Phase Commit and Promotable Single Phase Notification](../../../../docs/framework/data/transactions/optimization-spc-and-promotable-spn.md).  
  
 The <xref:System.Transactions> namespace defines three levels of trust - AllowPartiallyTrustedCallers (APTCA), DistributedTransactionPermission(DTP) and full trust - that restrict access to the types of resources it exposes. For more information on the various trust levels, see [Security Trust Levels in Accessing Resources](../../../../docs/framework/data/transactions/security-trust-levels-in-accessing-resources.md).  
  
## In this section  
  
### Writing A Transactional Application  
 The <xref:System.Transactions> namespace provides two models for creating transactional applications. [Implementing an Implicit Transaction using Transaction Scope](../../../../docs/framework/data/transactions/implementing-an-implicit-transaction-using-transaction-scope.md) describes how the <xref:System.Transactions> namespace supports creating implicit transactions using the <xref:System.Transactions.TransactionScope> class.  
  
 [Implementing an Explicit Transaction using CommittableTransaction](../../../../docs/framework/data/transactions/implementing-an-explicit-transaction-using-committabletransaction.md) describes how the <xref:System.Transactions> namespace supports creating explicit transactions using the <xref:System.Transactions.CommittableTransaction> class.  
  
 For additional topics covering writing a transactional application, see [Writing a Transactional Application](../../../../docs/framework/data/transactions/writing-a-transactional-application.md).  
  
### Implementing A Resource Manager  
 To implement a resource manager that can participate in a transaction, see [Implementing a Resource Manager](../../../../docs/framework/data/transactions/implementing-a-resource-manager.md). This section covers the enlistment of a resource, committing a transaction, recovery after failure, and optimization best practices.
