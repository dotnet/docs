---
title: "Transaction Processing"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: effdc8e6-accf-41eb-98a5-431603ba218b
caps.latest.revision: 4
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Transaction Processing
When you purchase a book from an online bookstore, you exchange money (in the form of credit) for a book. If your credit is good, a series of related operations ensures that you get the book and the bookstore gets your money. However, if a single operation in the series fails during the exchange, the entire exchange fails. You do not get the book and the bookstore does not get your money.  
  
 The technology responsible for making the exchange balanced and predictable is called transaction processing. Transactions ensure that data-oriented resources are not permanently updated unless all operations within the transactional unit complete successfully. By combining a set of related operations into a unit that either completely succeeds or completely fails, you can simplify error recovery and make your application more reliable.  
  
 Transaction processing systems consist of computer hardware and software hosting a transaction-oriented application that performs the routine transactions necessary to conduct business. Examples include systems that manage sales order entry, airline reservations, payroll, employee records, manufacturing, and shipping.  
  
 This section provides both general information on transaction processing, and specific information on how to write transactional applications and resource managers using the Microsoft .NET Framework.  
  
## In This Section  
 [Transaction Fundamentals](../../../../docs/framework/data/transactions/transaction-fundamentals.md)  
 Introduces basic transaction processing terms and concepts.  
  
 [Features Provided by System.Transactions](../../../../docs/framework/data/transactions/features-provided-by-system-transactions.md)  
 Discusses how you can use features in System.Transactions to write your own transactional application.  
  
## Reference  
 <xref:System.Transactions>  
 Provides classes that allow your code to participate in transactions. The classes support transactions with multiple distributed participants, multiple phase notifications, and durable enlistments.
