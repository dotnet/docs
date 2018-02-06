---
title: "Transaction Models"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 48a8bc1b-128b-4cf1-a421-8cc73223c340
caps.latest.revision: 9
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Transaction Models
This topic describes the relationship between the transaction programming models and the infrastructure components Microsoft provides.  
  
 When using transactions in [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)], it is important to understand that you are not selecting between different transactional models, but rather operating at different layers of an integrated and consistent model.  
  
 The following sections describe the three primary transaction components.  
  
## Windows Communication Foundation Transactions  
 The transaction support in [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] allows you write transactional services. In addition, with its support for the WS-AtomicTransaction (WS-AT) protocol, applications can flow transactions to Web services built using either [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] or third-party technology.  
  
 In a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] service or application, [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] transaction features provide attributes and configuration for declaratively specifying how and when the infrastructure should create, flow, and synchronize transactions.  
  
## System.Transactions Transactions  
 The <xref:System.Transactions> namespace provides both an explicit programming model based on the <xref:System.Transactions.Transaction> class, as well as an implicit programming model using the <xref:System.Transactions.TransactionScope> class, in which the infrastructure automatically manages transactions.  
  
 [!INCLUDE[crabout](../../../../includes/crabout-md.md)] how to create a transactional application using these two models, see [Writing a Transactional Application](http://go.microsoft.com/fwlink/?LinkId=94947).  
  
 In a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] service or application, <xref:System.Transactions> provides the programming model for creating transactions within a client application and for explicitly interacting with a transaction, when required, within a service.  
  
## MSDTC Transactions  
 The Microsoft Distributed Transaction Coordinator (MSDTC) is a transaction manager that provides support for distributed transactions.  
  
 [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] the [DTC Programmer's Reference](http://go.microsoft.com/fwlink/?LinkId=94948).  
  
 In a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] service or application, MSDTC provides the infrastructure for the coordination of transactions created within a client or service.
