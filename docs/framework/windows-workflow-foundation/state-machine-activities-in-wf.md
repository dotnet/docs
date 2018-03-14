---
title: "State Machine Activities in WF"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 93312eaf-07e0-4a55-b4f7-4cdbbc4dee2d
caps.latest.revision: 7
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# State Machine Activities in WF
[!INCLUDE[net_v45](../../../includes/net-v45-md.md)] provides several system-provided activities and activity designers for creating state machine workflows.  
  
|||  
|-|-|  
|<xref:System.Activities.Statements.StateMachine>|Executes contained activities using the familiar state machine paradigm.|  
|<xref:System.Activities.Statements.State>|Represents a state in a state machine.|  
|<xref:System.Activities.Core.Presentation.FinalState>|Represents a terminating state in a state machine. <xref:System.Activities.Core.Presentation.FinalState> is an activity designer that when used creates a <xref:System.Activities.Statements.State> preconfigured as a terminating state. For more information, see [FinalState Activity Designer](/visualstudio/workflow-designer/finalstate-activity-designer).|  
|<xref:System.Activities.Statements.Transition>|Represents the transition between two states. There is no **Toolbox** item for <xref:System.Activities.Statements.Transition>; transitions are created on the workflow designer by dragging and dropping a line between two states, or by dropping a state on the triangles that appear when one state is hovered over another. For more information, see [Transition Activity Designer](/visualstudio/workflow-designer/transition-activity-designer).|  
  
## See Also  
 [Getting Started Tutorial](../../../docs/framework/windows-workflow-foundation/getting-started-tutorial.md)
