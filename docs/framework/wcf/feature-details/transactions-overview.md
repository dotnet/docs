---
title: "Windows Communication Foundation Transactions Overview"
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
  - "transactions [WCF]"
  - "WCF, transactions"
  - "Windows Communication Foundation, transactions"
ms.assetid: c7757854-1207-4019-8b31-552578b7d570
caps.latest.revision: 16
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Windows Communication Foundation Transactions Overview
Transactions provide a way to group a set of actions or operations into a single indivisible unit of execution. A transaction is a collection of operations with the following properties:  
  
-   Atomicity. This ensures that either all of the updates completed under a specific transaction are committed and made durable or they are all aborted and rolled back to their previous state.  
  
-   Consistency. This guarantees that the changes made under a transaction represent a transformation from one consistent state to another. For example, a transaction that transfers money from a checking account to a savings account does not change the amount of money in the overall bank account.  
  
-   Isolation. This prevents a transaction from observing uncommitted changes belonging to other concurrent transactions. Isolation provides an abstraction of concurrency while ensuring one transaction cannot have an unexpected impact on the execution of another transaction.  
  
-   Durability. This means that once committed, updates to managed resources (such as a database record) will be persistent in the face of failures.  
  
 [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] provides a rich set of features that enable you to create distributed transactions in your Web service application.  
  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] implements support for the WS-AtomicTransaction (WS-AT) protocol that enables [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] applications to flow transactions to interoperable applications, such as interoperable Web services built using third-party technology. [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] also implements support for the OLE Transactions protocol, which can be used in scenarios where you do not need interop functionality to enable transaction flow.  
  
 You can use an application configuration file to configure bindings to enable or disable transaction flow, as well as set the desired transaction protocol on a binding. In addition, you can set transaction time-outs at the service level using the configuration file. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [Enabling Transaction Flow](../../../../docs/framework/wcf/feature-details/enabling-transaction-flow.md).  
  
 Transaction attributes in the <xref:System.ServiceModel> namespace allow you to do the following:  
  
-   Configure transaction time-outs and isolation-level filtering using the <xref:System.ServiceModel.ServiceBehaviorAttribute> attribute.  
  
-   Enable transactions functionality and configure transaction completion behavior using the <xref:System.ServiceModel.OperationBehaviorAttribute> attribute.  
  
-   Use the <xref:System.ServiceModel.ServiceContractAttribute> and <xref:System.ServiceModel.OperationContractAttribute> attributes on a contract method to require, allow or deny transaction flow.  
  
 [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [ServiceModel Transaction Attributes](../../../../docs/framework/wcf/feature-details/servicemodel-transaction-attributes.md).  
  
## See Also  
 [ServiceModel Transaction Attributes](../../../../docs/framework/wcf/feature-details/servicemodel-transaction-attributes.md)  
 [Enabling Transaction Flow](../../../../docs/framework/wcf/feature-details/enabling-transaction-flow.md)
