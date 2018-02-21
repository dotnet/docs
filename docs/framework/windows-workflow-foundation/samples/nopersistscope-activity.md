---
title: "NoPersistScope Activity"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 9a0baeb7-a05c-4fac-b905-252758cb71bb
caps.latest.revision: 10
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# NoPersistScope Activity
This sample shows how to manipulate a non-serializable and disposable state within a workflow. It is important that workflows do not attempt to persist non-serializable state and it is also important for disposable objects to be cleaned up after they are used in workflow.  
  
## Demonstrates  
 `NoPersistScope` custom activity and designer.  
  
## Using the NoPersistZone activity  
 When the sample workflow runs, a custom activity called `CreateTextWriter` creates an object of type <xref:System.IO.TextWriter> and saves it into a workflow variable. <xref:System.IO.TextWriter> is an <xref:System.IDisposable> object. This <xref:System.IO.TextWriter>, which is configured to write to a file named ‘out.txt’ in the directory in which the sample runs, is used by a <xref:System.Activities.Statements.WriteLine> activity as it echoes any text you type in at the console.  
  
 The echo logic runs within a `NoPersistScope` activity (the code for which is also part of this sample), which prevents the workflow from being persisted. If you type in `unload` at the console, the host attempts to persist the workflow instance but this operation times out because the workflow remains within a `NoPersistScope`. The workflow also utilizes a custom activity called `Dispose` to dispose the <xref:System.IO.TextWriter> object when the workflow is finished using it. The `Dispose` activity is placed within the <xref:System.Activities.Statements.TryCatch.Finally%2A> block of the <xref:System.Activities.Statements.TryCatch> activity in which the <xref:System.IO.TextWriter> variable is declared, to ensure that it runs even if an exception should occur during execution of the Try block.  
  
 You can type in `exit` to complete the workflow instance and exit the program.  
  
#### To run the sample  
  
1.  Open the NoPersistZone.sln solution in [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)].  
  
2.  To build the solution, press CTRL+SHIFT+B or select **Build Solution** from the **Build** menu.  
  
3.  Once the build has succeeded, press F5 or select **Start Debugging** from the **Debug** menu alternatively, you can press CTRL+F5 or select **Start Without Debugging** from the **Debug** menu to run without debugging.  
  
#### To cleanup (optional)  
  
1.  To remove the SQL Instance Store, run Cleanup.cmd.  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WF\Scenario\ActivityLibrary\NoPersistScope`