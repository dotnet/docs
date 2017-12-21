---
title: "Determining Workflow Execution Duration Using Tracing"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: f04ad0fd-edc7-4cbc-8979-356f2a1131c4
caps.latest.revision: 9
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Determining Workflow Execution Duration Using Tracing
This topic demonstrates how to determine the time it takes for a successfully completed, self-hosted workflow to execute by using workflow tracing.  
  
### To determine workflow application execution duration by using workflow tracing  
  
1.  Open [!INCLUDE[vs2010](../../../includes/vs2010-md.md)].  Select **File**, **New**, **Project**.  Under **C#**, select the **Workflow** node.  Select **Workflow Console Application** from the list of templates.  Name the new project `WorkflowDurationTracing` and click **OK**.  
  
2.  Open Workflow1.xaml.  Drag a <xref:System.Activities.Statements.Delay> activity onto the designer surface. Assign the value 00:00:10 (ten seconds) to the Duration property of the activity.  
  
3.  Open Event Viewer by clicking **Start**, **Run**, and entering `eventvwr.exe`.  
  
4.  If you haven’t enabled workflow tracing, expand **Applications and Services Logs**, **Microsoft**, **Windows**, **Application Server-Applications**. Select **View**, **Show Analytic and Debug Logs**. Right-click **Debug** and select **Enable Log**. Leave Event Viewer open so that traces can be viewed after the workflow is run.  
  
5.  Execute the workflow application by pressing CTRL+SHIFT+B.  
  
6.  In Event Viewer, find a recent event with ID 1009 and a message similar to the following. Make a note of the time that the message was logged.  
  
 **Parent Activity '', DisplayName: '', InstanceId: '' scheduled child Activity 'WorkflowDurationTracking.Workflow1', DisplayName: 'Workflow1', InstanceId: '1'.**  
  
7.  Find another recent event with ID 1001 and a message similar to the following.  Subtract the previous message time from this message’s Logged value to determine workflow execution duration, which should be around 10 seconds.  
  
 **WorkflowInstance Id: '1bbac57b-3322-498e-9e27-8833fda3a5bf' has completed in the Closed state.**  
  
## See Also  
 [Workflow Tracing](../../../docs/framework/windows-workflow-foundation/workflow-tracing.md)  
 [Windows Server App Fabric Monitoring](http://go.microsoft.com/fwlink/?LinkId=201273)  
 [Monitoring Applications with App Fabric](http://go.microsoft.com/fwlink/?LinkId=201275)
