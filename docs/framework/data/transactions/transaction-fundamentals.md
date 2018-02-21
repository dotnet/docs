---
title: "Transaction Fundamentals"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 353f4ee2-e6bf-4b1c-b1c8-385fc8a486c0
caps.latest.revision: 3
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Transaction Fundamentals
Transactions bind multiple tasks together. For example, imagine that an application performs two tasks. First, it creates a new table in a database. Next, it calls a specialized object to collect, format, and insert data into the new table. These two tasks are related and even interdependent, such that you want to avoid creating a new table unless you can fill it with data. Executing both tasks within the scope of a single transaction enforces the connection between them. If the second task fails, the first task is rolled back to a point before the new table was created.  
  
 To ensure predictable behavior, all transactions must possess the basic ACID properties (atomic, consistent, isolated, and durable). These properties reinforce the role of mission-critical transactions as all-or-none propositions. For more information on ACID, please see [ACID Properties](http://go.microsoft.com/fwlink/?LinkId=98791). In summary, ACID guarantees that a set of related tasks either succeed or fail as a unit. In transaction processing terminology, the transaction either commits or aborts. For a transaction to commit, all participants must guarantee that any change to data will be permanent. Changes must persist despite system crashes or other unforeseen events. If even a single participant fails to make this guarantee, the entire transaction fails. All changes to data within the scope of the transaction are rolled back to a specific set point.  
  
 A transaction can be confined to a single data resource, such as a database or message queue. In this scenario, the local transaction is managed by the Transaction Manager provided by <xref:System.Transactions> , which generates performance gain. Controlled by the data resource, these transactions are efficient and easy to manage.  
  
 Transactions can also span multiple data resources. Distributed transactions give you the ability to incorporate several distinct operations occurring on different systems into a single pass or fail action. In this scenario, the transactions are coordinated by the Microsoft Distributed Transaction Coordinator (MSDTC) that resides in each system.  
  
 When you develop a transactional application using the classes provided by <xref:System.Transactions>, you do not need to worry about what kind of transactions you need, or the transaction manager involved. The <xref:System.Transactions> infrastructure automatically manages these for you.  
  
 When you create a transaction, you can specify the isolation level that applies to the transaction. The isolation level, defined by the <xref:System.Transactions.IsolationLevel> enum, determines what level of access other transactions will have to the data affected by your transaction.  
  
 You can create transactions using ADO.NET, <xref:System.EnterpriseServices>, or the transactional programming model provided by the <xref:System.Transactions> namespace. The [Features Provided by System.Transactions](../../../../docs/framework/data/transactions/features-provided-by-system-transactions.md) topic discusses the features that you can use to write a transactional application using the <xref:System.Transactions> namespace.  
  
## See Also  
 [Features Provided by System.Transactions](../../../../docs/framework/data/transactions/features-provided-by-system-transactions.md)
