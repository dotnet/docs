---
title: "Migration Guidance"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: cb65c132-58c9-4028-b3d4-1efc71d5e60e
caps.latest.revision: 7
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Migration Guidance
In the [!INCLUDE[netfx40_short](../../../includes/netfx40-short-md.md)], Microsoft is releasing the second major version of [!INCLUDE[wf](../../../includes/wf-md.md)]. [!INCLUDE[wf1](../../../includes/wf1-md.md)] was released in [!INCLUDE[vstecwinfx](../../../includes/vstecwinfx-md.md)] (this included the types in the System.Workflow.* namespaces; now referred to as WF3) and enhanced in [!INCLUDE[netfx35_short](../../../includes/netfx35-short-md.md)]. WF3 is also part of the [!INCLUDE[netfx40_short](../../../includes/netfx40-short-md.md)], but it exists there alongside new workflow technology (the types in the System.Activities.\* namespaces; referred to as WF4). When considering when to adopt WF4, it is important to first recognize that you control the timing.  
  
-   WF3 is a fully supported part of the [!INCLUDE[netfx40_short](../../../includes/netfx40-short-md.md)].  
  
-   WF3 applications run on the [!INCLUDE[netfx40_short](../../../includes/netfx40-short-md.md)] without modification and continue to be fully supported.  
  
-   New WF3 applications can be created and your existing applications can be edited in [!INCLUDE[vs_current_long](../../../includes/vs-current-long-md.md)] and are fully supported.  
  
 Thus, the decision to adopt the .NET Framework 4 is decoupled from your decision to move to WF4 (System.Activities.*) from WF3 (System.Workflow.\*). This topic provides links to WF migration guidance that provides information about working with WF3 and WF4.  
  
## WF Migration Whitepapers and Cookbooks  
 The [WF Migration Overview](http://go.microsoft.com/fwlink/?LinkId=153873) topic provides a broad overview of the relationship between WF3 and WF4 and migration strategies. Companion topics drill into specific topics.  
  
 [WF Migration Overview](http://go.microsoft.com/fwlink/?LinkId=153873)  
 Describes the relationship between WF3 and WF4, and the choices you have as a user or a potential user of workflow technology in .NET 4.  
  
 [WF Migration: Best Practices for WF3 Development](http://go.microsoft.com/fwlink/?LinkId=153852)  
 Discusses how to design WF3 artifacts so they can be more easily migrated to WF4.  
  
 [WF Guidance: Rules](http://go.microsoft.com/fwlink/?LinkId=153854)  
 Discusses how to bring rules-related investments forward into [!INCLUDE[netfx40_short](../../../includes/netfx40-short-md.md)] solutions.  
  
 [WF Guidance: State Machine](http://go.microsoft.com/fwlink/?LinkId=153855)  
 Discusses WF4 control flow modeling in the absence of a State-Machine activity.  
  
 Note that this guidance only applies to workflow projects that target .NET Framework 4. State Machine workflows were added in .NET 4.0.1 with the release of Platform Update 1, and were included as part of .NET Framework 4.5. [!INCLUDE[crabout](../../../includes/crabout-md.md)] state machine workflows in .NET 4.0.1 - 4.0.3 and .NET Framework 4.5, see [Update 4.0.1 for Microsoft .NET Framework 4 Features](http://msdn.microsoft.com/library/de3297bd-c3e1-4126-95be-2ed7fe2a98fc) and [State Machine Workflows](../../../docs/framework/windows-workflow-foundation/state-machine-workflows.md).  
  
 [WF Migration Cookbook: Custom Activities](http://go.microsoft.com/fwlink/?LinkId=153856)  
 Provides examples and instructions for redesigning WF3 custom activities on WF4.  
  
 [WF Migration Cookbook: Advanced Custom Activities](http://go.microsoft.com/fwlink/?LinkId=275560)  
 Provides guidance for redesigning advanced WF3 custom activities that use WF3 queues and schedule child activities as WF4 custom activities.  
  
 [WF Migration Cookbook: Workflows](http://go.microsoft.com/fwlink/?LinkId=153858)  
 Provides examples and instructions for redesigning WF3 workflows on WF4.  
  
 [WF Migration Cookbook: Workflow Hosting](http://go.microsoft.com/fwlink/?LinkId=275561)  
 Provides guidance for redesigning WF3 hosting code as WF4 hosting code. The goal is to cover the key differences in workflow hosting between WF3 and WF4.  
  
 [WF Migration Cookbook: Workflow Tracking](http://go.microsoft.com/fwlink/?LinkId=275562)  
 Provides guidance for redesigning WF3 tracking code and configuration using equivalent WF4 tracking code and configuration.  
  
 [WF Guidance: Workflow Services](http://go.microsoft.com/fwlink/?LinkId=275564)  
 Provides example-oriented step-by-step instructions for redesigning workflows that implement Windows Communication Foundation (WCF) web services (commonly referred to as workflow services) created in WF3 to use WF4, for common scenarios for out-of-box activities.  
  
## See Also  
 <xref:System.Activities.Statements.Interop>
