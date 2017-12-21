---
title: "Activity Tree Inspection"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 100d00e4-8c1d-4233-8fbb-dd443a01155d
caps.latest.revision: 10
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Activity Tree Inspection
Activity tree inspection is used by workflow application authors to inspect the workflows hosted by the application. By using <xref:System.Activities.WorkflowInspectionServices>, workflows can be searched for specific child activities, individual activities and their properties can be enumerated, and runtime metadata of the activities can be cached at a specific time. This topic provides an overview of <xref:System.Activities.WorkflowInspectionServices> and how to use it to inspect an activity tree.  
  
## Using WorkflowInspectionServices  
 The <xref:System.Activities.WorkflowInspectionServices.GetActivities%2A> method is used to enumerate all of the activities in the specified activity tree. <xref:System.Activities.WorkflowInspectionServices.GetActivities%2A> returns an enumerable that touches all activities within the tree including children, delegate handlers, variable defaults, and argument expressions. In the following example, a workflow definition is created by using a <xref:System.Activities.Statements.Sequence>, <xref:System.Activities.Statements.While>, <xref:System.Activities.Statements.ForEach%601>, <xref:System.Activities.Statements.WriteLine>, and expressions. After the workflow definition is created, it is invoked and then the `InspectActivity` method is called.  
  
 [!code-csharp[CFX_WorkflowApplicationExample#45](../../../samples/snippets/csharp/VS_Snippets_CFX/cfx_workflowapplicationexample/cs/program.cs#45)]  
  
 To enumerate the activities, the <xref:System.Activities.WorkflowInspectionServices.GetActivities%2A> is called on the root activity, and again recursively on each returned activity. In the following example, the <xref:System.Activities.Activity.DisplayName%2A> of each activity and expression in the activity tree is written to the console.  
  
 [!code-csharp[CFX_WorkflowApplicationExample#46](../../../samples/snippets/csharp/VS_Snippets_CFX/cfx_workflowapplicationexample/cs/program.cs#46)]  
  
 This sample code provides the following output.  
  
 **List Item 1**  
**List Item 2**   
**List Item 3**   
**List Item 4**   
**List Item 5**   
**Items added to collection.**   
**Sequence**   
 **Literal<List\<String>>**  
 **While**  
 **AddToCollection\<String>**  
 **VariableValue<ICollection\<String>>**  
 **LambdaValue\<String>**  
 **LocationReferenceValue<List\<String>>**  
 **LambdaValue\<Boolean>**  
 **LocationReferenceValue<List\<String>>**  
 **ForEach\<String>**  
 **VariableValue<IEnumerable\<String>>**  
 **WriteLine**  
 **DelegateArgumentValue\<String>**  
 **Sequence**  
 **WriteLine**  
 **Literal\<String>**  To retrieve a specific activity instead of enumerating all of the activities, <xref:System.Activities.WorkflowInspectionServices.Resolve%2A> is used. Both <xref:System.Activities.WorkflowInspectionServices.Resolve%2A> and <xref:System.Activities.WorkflowInspectionServices.GetActivities%2A> perform metadata caching if `WorkflowInspectionServices.CacheMetadata` has not been previously called. If <xref:System.Activities.WorkflowInspectionServices.CacheMetadata%2A> has been called then <xref:System.Activities.WorkflowInspectionServices.GetActivities%2A> is based on the existing metadata. Therefore, if tree changes have been made since the last call to <xref:System.Activities.WorkflowInspectionServices.CacheMetadata%2A>, <xref:System.Activities.WorkflowInspectionServices.GetActivities%2A> might give unexpected results. If changes have been made to the workflow after calling <xref:System.Activities.WorkflowInspectionServices.GetActivities%2A>, metadata can be re-cached by calling the <xref:System.Activities.Validation.ActivityValidationServices> <xref:System.Activities.Validation.ActivityValidationServices.Validate%2A> method. Caching metadata is discussed in the next section.  
  
### Caching Metadata  
 Caching the metadata for an activity builds and validates a description of the activity’s arguments, variables, child activities, and activity delegates. Metadata, by default, is cached by the runtime when an activity is prepared for execution. If a workflow host author wants to cache the metadata for an activity or activity tree before this, for example to take all of the cost upfront, then <xref:System.Activities.WorkflowInspectionServices.CacheMetadata%2A> can be used to cache the metadata at the desired time.
