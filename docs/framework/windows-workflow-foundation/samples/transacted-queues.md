---
title: "Transacted Queues"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: b1b011dd-5e0b-482c-9bb0-9d8727038f14
caps.latest.revision: 9
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Transacted Queues
This sample shows how to integrate queues and transactions in [!INCLUDE[wf](../../../../includes/wf-md.md)] to create reliable and scalable services. A <!--zz <xref:System.Activities.TransactionScope>--> `System.Activities.TransactionScope` is used in the client workflow to send message to a queue under a transaction using the <xref:System.ServiceModel.NetMsmqBinding>. A <xref:System.ServiceModel.Activities.TransactedReceiveScope> is used on the server to receive messages from the queue and update the state of the workflow under the same transaction.  
  
## Demonstrates  
 <xref:System.Activities.Statements.TransactionScope>, <xref:System.ServiceModel.Activities.TransactedReceiveScope>, <xref:System.ServiceModel.NetMsmqBinding>, <xref:System.ServiceModel.Activities.Receive>, and content-based correlation.  
  
## Discussion  
 To demonstrate the features covered in this sample, a `RewardsPoints` workflow service is created, which keeps track of the points earned and used for a given account. The client uses <xref:System.Activities.WorkflowInvoker> to simulate posting various requests to the queue. To post a message to the queue under a transaction, the <xref:System.ServiceModel.Activities.Send> activity can be placed inside the <xref:System.Activities.Statements.TransactionScope.Body%2A> of a <xref:System.Activities.Statements.TransactionScope>. In this sample, the client runs first, followed by the server, to demonstrate how queued messages can decouple the client and server applications.  
  
 Once the client completes, the service is configured and hosted. As soon as it opens, it starts processing the messages that have already been placed in the queue. Each message is received and processed under the same server transaction. In this sample, the first message received is a `CreateAccount` request that creates the instance and initializes the content correlation based on the account name passed as part of the request message. To model the kind of service you might expect in the real world, the following two <xref:System.ServiceModel.Activities.TransactedReceiveScope> activities that process the `AddPoints` and `UsePoints` messages are placed in parallel branches within a `while` loop so that they can process these messages repeatedly in any order.  
  
 <xref:System.Activities.Statements.TransactionScope> and <xref:System.ServiceModel.Activities.TransactedReceiveScope> each have an implicit persistence point at the end of their scopes, so using these activities in [!INCLUDE[wf1](../../../../includes/wf1-md.md)] combined with queues is a reliable way to move your workflow from one consistent state to the next, while ensuring that messages are never lost.  
  
#### To set up, build, and run the sample  
  
1.  Install and configure MSMQ. See [Installing Message Queuing](http://go.microsoft.com/fwlink/?LinkId=178526) for details.  
  
2.  Ensure that MSDTC is running by executing the following command on a command line. `net start msdtc`  
  
3.  Compile the project and open the executable, or open the project in [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)] and select a start option from the debug menu. First, the queue is created, then the client runs and posts messages to the queue, and finally the service starts and the messages are processed. To exit the program, press ENTER.  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WF\Scenario\Transactions\TransactedQueues`
