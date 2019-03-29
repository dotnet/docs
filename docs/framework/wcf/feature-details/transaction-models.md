---
title: "Transaction Models"
ms.date: "03/30/2017"
ms.assetid: 48a8bc1b-128b-4cf1-a421-8cc73223c340
---
# Transaction Models
This topic describes the relationship between the transaction programming models and the infrastructure components Microsoft provides.  
  
 When using transactions in Windows Communication Foundation (WCF), it is important to understand that you are not selecting between different transactional models, but rather operating at different layers of an integrated and consistent model.  
  
 The following sections describe the three primary transaction components.  
  
## Windows Communication Foundation Transactions  
 The transaction support in WCF allows you write transactional services. In addition, with its support for the WS-AtomicTransaction (WS-AT) protocol, applications can flow transactions to Web services built using either WCF or third-party technology.  
  
 In a WCF service or application, WCF transaction features provide attributes and configuration for declaratively specifying how and when the infrastructure should create, flow, and synchronize transactions.  
  
## System.Transactions Transactions  
 The <xref:System.Transactions> namespace provides both an explicit programming model based on the <xref:System.Transactions.Transaction> class, as well as an implicit programming model using the <xref:System.Transactions.TransactionScope> class, in which the infrastructure automatically manages transactions.  
  
 For more information about how to create a transactional application using these two models, see [Writing a Transactional Application](https://go.microsoft.com/fwlink/?LinkId=94947).  
  
 In a WCF service or application, <xref:System.Transactions> provides the programming model for creating transactions within a client application and for explicitly interacting with a transaction, when required, within a service.  
  
## MSDTC Transactions  
 The Microsoft Distributed Transaction Coordinator (MSDTC) is a transaction manager that provides support for distributed transactions.  
  
 For more information, see the [DTC Programmer's Reference](https://go.microsoft.com/fwlink/?LinkId=94948).  
  
 In a WCF service or application, MSDTC provides the infrastructure for the coordination of transactions created within a client or service.
