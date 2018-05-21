---
title: "Transactions2"
ms.date: "03/30/2017"
ms.assetid: 51212219-a39e-448e-bff3-10064ff5de64
---
# Transactions
This section contains samples that demonstrate workflow transactions in Windows Workflow Foundation (WF).  
  
## In This Section  
 [Basic TransactionScope](../../../../docs/framework/windows-workflow-foundation/samples/basic-transactionscope.md)  
 Consists of four scenarios that show how to nest <xref:System.Activities.Statements.TransactionScope> instances.  
  
 [Use of TransactedReceiveScope](../../../../docs/framework/windows-workflow-foundation/samples/use-of-transactedreceivescope.md)  
 Demonstrates how to flow a transaction from a client to a server using <xref:System.Activities.Statements.TransactionScope> to create a new transaction on the client and a <xref:System.ServiceModel.Activities.TransactedReceiveScope> to receive a message with a flowed transaction and scope the lifetime of the transaction on the server.  
  
 [Nesting of TransactionScope within a service](../../../../docs/framework/windows-workflow-foundation/samples/nesting-of-transactionscope-within-a-service.md)  
 Consists of two scenarios that show how to handle <xref:System.Activities.Statements.TransactionScope> activity instances within a service.
