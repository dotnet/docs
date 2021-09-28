---
description: "Learn more about: Using WS-AtomicTransaction"
title: "Using WS-AtomicTransaction"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "WS-AT protocol [WCF]"
ms.assetid: 04a4c200-0af0-4c5d-a3d9-87cb7339e054
---
# Using WS-AtomicTransaction

WS-AtomicTransaction (WS-AT) is an interoperable transaction protocol. It enables you to flow distributed transactions by using Web service messages, and coordinate in an interoperable manner between heterogeneous transaction infrastructures. WS-AT uses the two-phase commit protocol to drive an atomic outcome between distributed applications, transaction managers, and resource managers.  
  
 The WS-AT implementation Windows Communication Foundation (WCF) provides includes a protocol service built into the Microsoft Distributed Transaction Coordinator (MSDTC) transaction manager. Using WS-AT, WCF applications can flow transactions to other applications, including interoperable Web services built using third-party technology.  
  
 When flowing a transaction between a client application and a server application, the transaction protocol used is determined by the binding that the server exposes on the endpoint the client selected. Some WCF system-provided bindings default to specifying the `OleTransactions` protocol as the transaction propagation format, while others default to specifying WS-AT. You can also programmatically modify the choice of transaction protocol inside a given binding.  
  
 The choice of protocol influences:  
  
- The format of the message headers used to flow the transaction from client to server.  
  
- The network protocol used to run the two-phase commit protocol between the client's transaction manager and the server's transaction, in order to resolve the outcome of the transaction.  
  
 If the server and client are written using WCF, you do not need to use WS-AT. Instead, you can use the default settings of `NetTcpBinding` with the `TransactionFlow` attribute enabled, which will use the `OleTransactions` protocol instead. For more information, see [\<netTcpBinding>](../../configure-apps/file-schema/wcf/nettcpbinding.md). Otherwise, if you are flowing transactions to Web services built on third-party technologies, you must use WS-AT.  
  
## See also

- [Configuring WS-Atomic Transaction Support](configuring-ws-atomic-transaction-support.md)
