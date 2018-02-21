---
title: "Deprecated types in Windows Workflow Foundation"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 4aebe928-a964-4c1c-abf7-0dbbd3604b13
caps.latest.revision: 2
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Deprecated types in Windows Workflow Foundation
In .NET 4 the Workflow Team released an all new Workflow engine in the <xref:System.Activities> namespace. With the release of .NET 4.5 Beta we are marking most of the types in the "WF 3" <xref:System.Workflow.Activities>, <xref:System.Workflow.ComponentModel>, and  <xref:System.Workflow.Runtime> namespaces as obsolete.  
  
## Obsolete namespaces and tools  
 The following assemblies have one or more public types that will be deprecated:  
  
-   System.Workflow.Activities.dll  
  
-   System.Workflow.ComponentModel.dll  
  
-   System.Workflow.Runtime.dll  
  
-   System.WorkflowServices.dll  
  
-   Microsoft.Workflow.DebugController.dll  
  
-   Microsoft.Workflow.Compiler.exe  
  
-   Wfc.exe  
  
 As a result, customers who are using the deprecated WF 3 APIs will encounter build warnings with a message similar to the following:  
  
 **Warning BC40000: X is obsolete: WF 3 types are deprecated. Please use WF 4 instead.** We will remove the types from the .NET Framework in a future release, but we have not yet determined that timeframe (not in 4.5). This current step allows us to communicate our direction to our customers and allow them plenty of time to move to the new WF4 model. We will, of course, continue to support these WF 3 types under the [Microsoft Support Lifecycle Policy](http://aka.ms/MicrosoftSupportLifecycle). Existing WF3 applications will run without issue on .NET 4.5, and [!INCLUDE[vs_current_long](../../../includes/vs-current-long-md.md)] will support new and existing WF3-based solutions.  
  
 Rules related types in the <xref:System.Workflow.Activities.Rules> namespace, which do not have a replacement in WF 4.5, have not been deprecated.  
  
 Customers who want to migrate their applications to WF 4 will find help in the [Workflow 4 Migration Guidance](migration-guidance.md).
