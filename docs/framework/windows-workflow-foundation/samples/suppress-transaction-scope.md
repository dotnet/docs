---
title: "Suppress Transaction Scope"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 49fb6dd4-30d4-4067-925c-c5de44c8c740
caps.latest.revision: 8
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Suppress Transaction Scope
The sample demonstrates how to author a custom `SuppressTransactionScope` activity to suppress the ambient run-time transaction, if present.  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WF\Scenario\Transactions\SuppressTransactionScope`  
  
## Sample Details  
 The custom activity is useful to prevent a transaction from being flowed out to another service if transaction flow is undesirable for the particular scenario. The workflow runtime has built-in support for suppressing the ambient transaction in the <xref:System.Activities.NativeActivity> class, but to use this support it is necessary to author a custom <xref:System.Activities.NativeActivity> such as the one in this sample.  
  
 The scenario consists of three parts. First, a <xref:System.Activities.Statements.TransactionScope> creates a run-time transaction that becomes ambient. This is verified by a custom activity that prints the local and distributed identifiers of the transaction. The transaction is then flowed to a remote service before beginning the second part. During the second part, the workflow enters a `SuppressTransactionScope` and again repeats the process of printing the transaction identifiers and flowing the transaction. However, the custom activity does not find an ambient transaction and the message flowed to the service does not contain the transaction. As a result, the service creates a transaction, which means the distributed ID printed on the client and service do not match. The final part occurs after the `SuppressTransactionScope` exits and the run-time transaction again becomes ambient as verified by another message to the service with a distributed identifier that matches the identifier of the first message.  
  
 The activity itself derives from <xref:System.Activities.NativeActivity> because it must schedule a child activity and add an execution property. The `SuppressTransactionScope` has a <xref:System.Activities.Variable> of type <xref:System.Activities.RuntimeTransactionHandle>, which must be used rather than an instance field of type <xref:System.Activities.RuntimeTransactionHandle> because the handle must be initialized. The `Variable<RuntimeTransactionHandle>` is added to the activity’s metadata as an implementation variable because it is only used internally.  
  
 When the activity is executed it first checks to see whether a body was specified and if so, sets the `SuppressTransaction` property on the <xref:System.Activities.RuntimeTransactionHandle>. Once the property is set, it is added to the execution properties and becomes ambient. This means that any activity that is a child of the `SuppressTransactionScope` is able to see the property and therefore enforces the suppression of the run-time transaction and causes a nested <xref:System.Activities.Statements.TransactionScope> to throw an exception. Once the handle is added to the execution properties the body is scheduled to run.  
  
#### To use this sample  
  
1.  Open the SuppressTransactionScope.sln solution in [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)].  
  
2.  To build the solution, press CTRL+SHIFT+B or select **Build Solution** from the **Build** menu.  
  
3.  Once the build has succeeded, right-click the solution and select **Set Startup Projects**. From the dialog, select **Multiple Startup Projects** and ensure the action for both projects is **Start**.  
  
4.  Press F5 or select **Start Debugging** from the **Debug** menu. Alternatively, you can press CTRL+F5 or select **Start Without Debugging** from the **Debug** menu to run without debugging.  
  
    > [!NOTE]
    >  The server must be running prior to starting the client. The output from the console window that hosts the service indicates when it has started.  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WF\Scenario\Transactions\SuppressTransactionScope`