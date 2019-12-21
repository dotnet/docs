---
title: "Migration Guidance"
ms.date: "03/30/2017"
ms.assetid: cb65c132-58c9-4028-b3d4-1efc71d5e60e
---
# Migration Guidance

In the .NET Framework 4, Microsoft is releasing the second major version of Windows Workflow Foundation (WF). [!INCLUDE[wf1](../../../includes/wf1-md.md)] was released in WinFX (this included the types in the System.Workflow.\* namespaces; now referred to as WF3) and enhanced in .NET Framework 3.5. WF3 is also part of the .NET Framework 4, but it exists there alongside new workflow technology (the types in the System.Activities.\* namespaces; referred to as WF4). When considering when to adopt WF4, it is important to first recognize that you control the timing.  
  
- WF3 is a fully supported part of the .NET Framework 4.  
  
- WF3 applications run on the .NET Framework 4 without modification and continue to be fully supported.  
  
- New WF3 applications can be created and your existing applications can be edited in Visual Studio 2012 and are fully supported.  
  
 Thus, the decision to adopt the .NET Framework 4 is decoupled from your decision to move to WF4 (System.Activities.\*) from WF3 (System.Workflow.\*). This topic provides links to WF migration guidance that provides information about working with WF3 and WF4.  
  
## WF Migration Whitepapers and Cookbooks  
 The [WF Migration Overview](https://docs.microsoft.com/previous-versions/appfabric/ff383417(v=azure.10)) topic provides a broad overview of the relationship between WF3 and WF4 and migration strategies. Companion topics drill into specific topics.  
  
 [WF Migration Overview](https://docs.microsoft.com/previous-versions/appfabric/ff383417(v=azure.10))  
 Describes the relationship between WF3 and WF4, and the choices you have as a user or a potential user of workflow technology in .NET 4.  
  
 [WF Migration: Best Practices for WF3 Development](https://docs.microsoft.com/previous-versions/appfabric/ff383417(v=azure.10))  
 Discusses how to design WF3 artifacts so they can be more easily migrated to WF4.  
  
 [WF Guidance: Rules](https://docs.microsoft.com/previous-versions/appfabric/ff383417(v=azure.10))  
 Discusses how to bring rules-related investments forward into .NET Framework 4 solutions.  
  
 [WF Guidance: State Machine](https://docs.microsoft.com/previous-versions/appfabric/ff383417(v=azure.10))  
 Discusses WF4 control flow modeling in the absence of a State-Machine activity.  
  
 Note that this guidance only applies to workflow projects that target .NET Framework 4. State Machine workflows were added in .NET 4.0.1 with the release of Platform Update 1, and were included as part of .NET Framework 4.5. For more information about state machine workflows in .NET 4.0.1 - 4.0.3 and .NET Framework 4.5, see [Update 4.0.1 for Microsoft .NET Framework 4 Features](https://docs.microsoft.com/previous-versions/dotnet/netframework-4.0/hh290669(v=vs.100)) and [State Machine Workflows](state-machine-workflows.md).  
  
 [WF Migration Cookbook: Custom Activities](https://docs.microsoft.com/previous-versions/appfabric/ff383417(v=azure.10))  
 Provides examples and instructions for redesigning WF3 custom activities on WF4.  
  
 [WF Migration Cookbook: Advanced Custom Activities](https://docs.microsoft.com/previous-versions/appfabric/ff383417(v=azure.10))  
 Provides guidance for redesigning advanced WF3 custom activities that use WF3 queues and schedule child activities as WF4 custom activities.  
  
 [WF Migration Cookbook: Workflows](https://docs.microsoft.com/previous-versions/appfabric/ff383417(v=azure.10))  
 Provides examples and instructions for redesigning WF3 workflows on WF4.  
  
 [WF Migration Cookbook: Workflow Hosting](https://docs.microsoft.com/previous-versions/appfabric/ff383417(v=azure.10))  
 Provides guidance for redesigning WF3 hosting code as WF4 hosting code. The goal is to cover the key differences in workflow hosting between WF3 and WF4.  
  
 [WF Migration Cookbook: Workflow Tracking](https://docs.microsoft.com/previous-versions/appfabric/ff383417(v=azure.10))  
 Provides guidance for redesigning WF3 tracking code and configuration using equivalent WF4 tracking code and configuration.  
  
 [WF Guidance: Workflow Services](https://docs.microsoft.com/previous-versions/appfabric/ff383417(v=azure.10))  
 Provides example-oriented step-by-step instructions for redesigning workflows that implement Windows Communication Foundation (WCF) web services (commonly referred to as workflow services) created in WF3 to use WF4, for common scenarios for out-of-box activities.  
  
## See also

- <xref:System.Activities.Statements.Interop>
