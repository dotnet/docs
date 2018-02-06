---
title: "Use of TransactedReceiveScope"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: d455f1dc-bfc5-43d6-8ae9-bc3b3a3ea08a
caps.latest.revision: 10
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Use of TransactedReceiveScope
This sample shows how to flow a transaction from a client to a server using <xref:System.Activities.Statements.TransactionScope> to create a new transaction on the client and a <xref:System.ServiceModel.Activities.TransactedReceiveScope> to receive a message with a flowed transaction and scope the lifetime of the transaction on the server. The sample consists of two projects that fill the roles of client and server.  
  
## Client Application  
 The client application runs a workflow that prints the distributed transaction ID, sends a message to the server, flows the transaction, receives the reply, prints the distributed transaction ID again and completes. When the distributed transaction ID is initially prints, it is an empty GUID as the transaction is still only local.  
  
## Server Application  
 The server project is similar, however, the workflow is hosted in <xref:System.ServiceModel.Activities.WorkflowServiceHost> because it must listen on an endpoint for the message from the client. The workflow is centered on the <xref:System.ServiceModel.Activities.TransactedReceiveScope>, which receives the flowed transaction from the client, prints the message that was sent, prints the distributed transaction ID and sends the reply to the client. The distributed transaction ID is now a non-empty GUID and if a transaction-aware activity was added to the body of the <xref:System.ServiceModel.Activities.TransactedReceiveScope>, it would execute under the flowed transaction.  
  
#### To run the sample  
  
1.  Open the TransactedReceiveScope.sln solution in [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)].  
  
2.  To build the solution, press CTRL+SHIFT+B or select **Build Solution** from the **Build** menu.  
  
3.  Once the build has succeeded, right-click the solution and select **Set Startup Projects**. From the dialog, select **Multiple Startup Projects** and ensure the action for both projects is **Start**.  
  
4.  Press F5 or select **Start Debugging** from the **Debug** menu. Alternatively, you can press CTRL+F5 or select **Start Without Debugging** from the **Debug** menu to run without debugging.  
  
    > [!NOTE]
    >  The server must be running prior to starting the client. The output from the console window hosting the service indicates when it has started.  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WF\Basic\Transactions\TransactedReceiveScope`