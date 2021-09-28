---
title: "Procedural Workflows"
description: In Workflow Foundation, procedural workflows use flow-control methods similar to those found in procedural languages.
ms.date: "03/30/2017"
ms.assetid: 52401de9-9115-472d-8fd9-047af6a072b9
---
# Procedural Workflows

Procedural workflows use flow-control methods similar to those found in procedural languages. These constructs include `While` and `If`. These workflows can be freely composed using other flow control activities such as <xref:System.Activities.Statements.Flowchart> and <xref:System.Activities.Statements.Sequence>.  
  
## Controlling Execution Flow  

 The workflow activity library has activities for modeling most flow-control methods used in procedural languages. These include:  
  
- <xref:System.Activities.Statements.While>  
  
- <xref:System.Activities.Statements.DoWhile>  
  
- <xref:System.Activities.Statements.ForEach%601>  
  
- <xref:System.Activities.Statements.Parallel>  
  
- <xref:System.Activities.Statements.ParallelForEach%601>  
  
- <xref:System.Activities.Statements.If>  
  
- <xref:System.Activities.Statements.Switch%601>  
  
- <xref:System.Activities.Statements.Pick>  
  
 To use flow control activities, drag and drop them from the **Activity** toolbox into a composite activity inside the designer window.  
  
> [!NOTE]
> If using the hosting features of Windows Server AppFabric to host workflows on a Web farm, AppFabric will move instances between different AppFabric servers. This requires that the resources are able to be shared between all nodes.  None of the default NET 4 workflow activities contain any operations that access local resources. Since AppFabric does not offer any mechanism to mark a workflow as immovable, a developer must not create custom activities that fail when a workflow is moved.  
  
## See also

- [Flowchart Workflows](flowchart-workflows.md)
