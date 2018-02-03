---
title: "Nesting of TransactionScope within a service"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: e7e1ba64-1384-4eba-add8-415636e2d6d0
caps.latest.revision: 7
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Nesting of TransactionScope within a service
This sample consists of two scenarios that run showing how to handle <xref:System.Activities.Statements.TransactionScope> activity instances within a service. First the transaction is initiated using the <xref:System.Activities.Statements.TransactionScope> activity to create a new transaction on the client and <xref:System.ServiceModel.Activities.TransactedReceiveScope> to receive and scope the lifetime of the transaction on the server. The first scenario within the service runs a secondary <xref:System.Activities.Statements.TransactionScope> activity to demonstrate the nesting of the <xref:System.Activities.Statements.TransactionScope> activities within the service. The second scenario shows how time-outs are respected within the nested <xref:System.Activities.Statements.TransactionScope> activities.  
  
## Client Application  
 The client application runs a workflow that starts a <xref:System.Activities.Statements.TransactionScope> activity, prints the distributed transaction ID, sends a message to the server, flows the transaction, receives the reply, prints the distributed transaction ID again and completes. It does this once for each service scenario.  
  
## Server Application  
 The server project is hosted in <xref:System.ServiceModel.Activities.WorkflowServiceHost>, which creates the endpoint to listen for the message from the client. The workflow is centered on the <xref:System.ServiceModel.Activities.TransactedReceiveScope>, which receives the flowed transaction from the client, prints the distributed transaction ID and then executes a second <xref:System.Activities.Statements.TransactionScope> activity. In the first scenario, the transaction is completed successfully. In the second scenario, the body of the <xref:System.Activities.Statements.TransactionScope> activity is a five-second delay and the time-out for the transaction is set to two seconds. When the transaction times out the transaction is aborted.  
  
#### To run the sample  
  
1.  Open the TransactionServiceExample.sln solution in [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)].  
  
2.  To build the solution, press CTRL+SHIFT+B or select **Build Solution** from the **Build** menu.  
  
3.  Once the build has succeeded, right-click the solution and select **Set Startup Projects**. From the dialog box, select **Multiple Startup Projects** and ensure the action for both projects is **Start**.  
  
4.  Press F5 or select **Start Debugging** from the **Debug** menu. Alternatively, you can press CTRL+F5 or select **Start Without Debugging** from the **Debug** menu to run without debugging.  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WF\Basic\Transactions\TRSComposability`
