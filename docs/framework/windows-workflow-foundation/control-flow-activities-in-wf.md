---
title: "Control Flow Activities in WF"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 6892885b-f7c5-4aea-8f5e-28863fb4ae75
caps.latest.revision: 16
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Control Flow Activities in WF
The [!INCLUDE[netfx_current_long](../../../includes/netfx-current-long-md.md)] provides several activities for controlling flow of execution within a workflow. Some of these activities (such as `Switch` and `If`) implement flow control structures similar to those in programming environments such as [!INCLUDE[csprcs](../../../includes/csprcs-md.md)], while others (such as `Pick`) model new programming structures.  
  
 Note that while activities such as the `Parallel` and `ParallelForEach` activities schedule multiple child activities for execution simultaneously, only a single thread is used for a workflow. Each child activity of these activities executes sequentially and successive activities do not execute until previous activities either complete or go idle. As a result, these activities are most useful for applications in which several potentially blocking activities must execute in an interleaved fashion. If none of the child activities of these activities go idle, a `Parallel` activity executes just like a `Sequence` activity, and a `ParallelForEach` activity executes just like a `ForEach` activity. If, however, asynchronous activities (such as activities that derive from <xref:System.Activities.AsyncCodeActivity>) or messaging activities are used, control will pass to the next branch while the child activity waits for its message to be received or its asynchronous work to be completed.  
  
## Flow control activities  
  
|Activity|Description|  
|--------------|-----------------|  
|<xref:System.Activities.Statements.DoWhile>|Executes the contained activities once and continues to do so while a condition is `true`.|  
|<xref:System.Activities.Statements.ForEach%601>|Executes an embedded statement in sequence for each element in a collection. <xref:System.Activities.Statements.ForEach%601> is similar to the keyword `foreach`, but is implemented as an activity rather than a language statement.|  
|<xref:System.Activities.Statements.If>|Executes contained activities if a condition is `true`, and can execute activities contained in the <xref:System.Activities.Statements.If.Else%2A> property if the condition is `false`.|  
|<xref:System.Activities.Statements.Parallel>|Executes contained activities in parallel.|  
|<xref:System.Activities.Statements.ParallelForEach%601>|Executes an embedded statement in parallel for each element in a collection.|  
|<xref:System.Activities.Statements.Pick>|Provides event-based control flow modeling.|  
|<xref:System.Activities.Statements.PickBranch>|Represents a potential path of execution in a <xref:System.Activities.Statements.Pick> activity.|  
|<xref:System.Activities.Statements.Sequence>|Executes contained activities in sequence.|  
|<xref:System.Activities.Statements.Switch%601>|Selects one choice from a number of activities to execute, based on the value of a given expression.|  
|<xref:System.Activities.Statements.While>|Executes contained activities while a condition is `true`.|
