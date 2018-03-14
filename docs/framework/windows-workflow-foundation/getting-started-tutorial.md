---
title: "Getting Started Tutorial2"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "WF [WF], getting started"
  - "Windows Workflow Foundation [WF], getting started"
ms.assetid: c2d3585f-6b1a-4d4f-9865-bd7cd31c5d42
caps.latest.revision: 21
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Getting Started Tutorial
This section contains a set of walkthrough topics that introduce you to programming [!INCLUDE[wf](../../../includes/wf-md.md)] applications. By following the procedures in these topics, you will build an application that is a number guessing game. The first topic in the tutorial leads you through the steps to create the custom activities required for the workflow. In the second topic, these activities are assembled along with built-in workflow activities into a flowchart workflow. In the third topic, the host application is configured to run the workflow, and in the final topic persistence is introduced. Each step in this process depends on the previous steps, so we recommend that you complete them in order.  
  
## In This Section  
 [How to: Create an Activity](../../../docs/framework/windows-workflow-foundation/how-to-create-an-activity.md)  
 Describes how to create a custom activity that derives from <xref:System.Activities.NativeActivity%601>, and how to compose this activity along with a built-in activity into a composite activity using the activity designer.  
  
 [How to: Create a Workflow](../../../docs/framework/windows-workflow-foundation/how-to-create-a-workflow.md)  
 Describes how to create flowchart, sequential, and state machine workflows by using built-in activities and the custom activities from the preceding tutorial.  
  
 [How to: Run a Workflow](../../../docs/framework/windows-workflow-foundation/how-to-run-a-workflow.md)  
 Describes how to invoke a workflow from a host environment, pass data into and out of a workflow, and how to resume bookmarks.  
  
 [How to: Create and Run a Long Running Workflow](../../../docs/framework/windows-workflow-foundation/how-to-create-and-run-a-long-running-workflow.md)  
 Describes how to add persistence to a workflow application.  
  
 [How to: Create a Custom Tracking Participant](../../../docs/framework/windows-workflow-foundation/how-to-create-a-custom-tracking-participant.md)  
 Describes how to create a custom tracking participant and tracking profile.  
  
 [How to: Host Multiple Versions of a Workflow Side-by-Side](../../../docs/framework/windows-workflow-foundation/how-to-host-multiple-versions-of-a-workflow-side-by-side.md)  
 Describes how to use `WorkflowIdentity` to host multiple versions of a workflow side-by-side.  
  
 [How to: Update the Definition of a Running Workflow Instance](../../../docs/framework/windows-workflow-foundation/how-to-update-the-definition-of-a-running-workflow-instance.md)  
 Describes how to use dynamic update to modify running workflow instances.  
  
## See Also  
 [Windows Workflow Foundation Programming](../../../docs/framework/windows-workflow-foundation/programming.md)
