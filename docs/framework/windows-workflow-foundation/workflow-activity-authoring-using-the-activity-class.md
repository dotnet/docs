---
title: "Workflow Activity Authoring Using the Activity Class"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 7b7b1c66-f093-43c3-b4d1-7173b46516da
caps.latest.revision: 7
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Workflow Activity Authoring Using the Activity Class
The most basic way to create an activity using [!INCLUDE[wf](../../../includes/wf-md.md)] in [!INCLUDE[netfx_current_long](../../../includes/netfx-current-long-md.md)] is to create a class that inherits from <xref:System.Activities.Activity> that creates functionality by assembling custom activities or activities from the [Built-In Activity Library](../../../docs/framework/windows-workflow-foundation/net-framework-4-5-built-in-activity-library.md). This topic demonstrates how to create an activity that writes two messages to the console.  
  
### To create a custom Activity using the activity designer  
  
1.  Open [!INCLUDE[vs_current_long](../../../includes/vs-current-long-md.md)].  
  
2.  Select File, New, Project. Select **Workflow 4.0** under **Visual C#** in the **Project Types** window, and select the **v2010** node. Select **Activity Library** in the **Templates** window. Name the new project HelloActivity.  
  
3.  Open the new activity.  Drag a <xref:System.Activities.Statements.Sequence> activity from the toolbox onto the designer surface.  
  
4.  Drag a <xref:System.Activities.Statements.WriteLine> activity into the <xref:System.Activities.Statements.Sequence> activity. Enter `"Hello World"` (with quotes) into the **Text** field.  
  
5.  Drag a second <xref:System.Activities.Statements.WriteLine> activity into the <xref:System.Activities.Statements.Sequence> activity, below the first one. Enter `"Goodbye"` (with quotes) into the **Text** field.
