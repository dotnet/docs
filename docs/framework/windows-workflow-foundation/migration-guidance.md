---
title: "Migration Guidance"
description: "Learn more about: Migration Guidance"
ms.date: "03/30/2017"
ms.assetid: cb65c132-58c9-4028-b3d4-1efc71d5e60e
---
# Migration guidance

In .NET Framework 4, Microsoft released the second major version of Windows Workflow Foundation (WF). WF was released in WinFX (this included the types in the System.Workflow.\* namespaces; now referred to as WF3) and enhanced in .NET Framework 3.5. WF3 is also part of .NET Framework 4, but it exists there alongside new workflow technology (the types in the System.Activities.\* namespaces; referred to as WF4). When considering when to adopt WF4, it is important to first recognize that you control the timing.

- WF3 is a fully supported part of .NET Framework 4.

- WF3 applications run on .NET Framework 4 without modification and continue to be fully supported.

- New WF3 applications can be created and your existing applications can be edited in Visual Studio 2012 and are fully supported.

Thus, the decision to adopt .NET Framework 4 is decoupled from your decision to move to WF4 (System.Activities.\*) from WF3 (System.Workflow.\*). This topic provides links to WF migration guidance that provides information about working with WF3 and WF4.

## WF migration white papers and cookbooks

 [WF Migration Overview](https://download.microsoft.com/download/5/9/9/599CF8A9-5FE2-426A-A536-A83F84D38BF9/WF%20Migration%20Overview.docx)\
 Describes the relationship between WF3 and WF4, and the choices you have as a user or a potential user of workflow technology in .NET Framework 4.

 [WF Migration: Best Practices for WF3 Development](https://download.microsoft.com/download/5/9/9/599CF8A9-5FE2-426A-A536-A83F84D38BF9/WF%20Migration%20Best%20Practices.docx)\
 Discusses how to design WF3 artifacts so they can be more easily migrated to WF4.

 [WF Guidance: Rules](https://download.microsoft.com/download/5/9/9/599CF8A9-5FE2-426A-A536-A83F84D38BF9/WF4%20Rules%20Guidance.docx)\
 Discusses how to bring rules-related investments forward into .NET Framework 4 solutions.

 [WF Guidance: State Machine](https://download.microsoft.com/download/5/9/9/599CF8A9-5FE2-426A-A536-A83F84D38BF9/WF4%20State%20Machine%20Guidance.doc)
 Discusses WF4 control flow modeling in the absence of a State-Machine activity. This guidance only applies to workflow projects that target .NET Framework 4. State Machine workflows were added in .NET Framework 4.0.1 with the release of Platform Update 1, and were included as part of .NET Framework 4.5. For more information about state machine workflows in .NET Framework 4.0.1 - 4.0.3 and .NET Framework 4.5, see [Update 4.0.1 for Microsoft .NET Framework 4 Features](/previous-versions/dotnet/netframework-4.0/hh290669(v=vs.100)) and [State Machine Workflows](state-machine-workflows.md).

 [WF Migration Cookbook: Custom Activities](https://download.microsoft.com/download/5/9/9/599CF8A9-5FE2-426A-A536-A83F84D38BF9/WF%20Migration%20Cookbook%20Custom%20Activities.docx)\
 Provides examples and instructions for redesigning WF3 custom activities on WF4.

 [WF Migration Cookbook: Advanced Custom Activities](https://download.microsoft.com/download/5/9/9/599CF8A9-5FE2-426A-A536-A83F84D38BF9/WF%20Migration%20Cookbook%20Advanced%20Custom%20Activities.docx)\
 Provides guidance for redesigning advanced WF3 custom activities that use WF3 queues and schedule child activities as WF4 custom activities.
%20
 [WF Migration Cookbook: Workflows](https://download.microsoft.com/download/5/9/9/599CF8A9-5FE2-426A-A536-A83F84D38BF9/WF%20Migration%20Cookbook%20Workflows.docx)\
 Provides examples and instructions for redesigning WF3 workflows on WF4.

 [WF Migration Cookbook: Workflow Hosting](https://download.microsoft.com/download/5/9/9/599CF8A9-5FE2-426A-A536-A83F84D38BF9/WF%20Migration%20Cookbook%20Workflow%20Hosting.docx)\
 Provides guidance for redesigning WF3 hosting code as WF4 hosting code. The goal is to cover the key differences in workflow hosting between WF3 and WF4.

 [WF Migration Cookbook: Workflow Tracking](https://download.microsoft.com/download/5/9/9/599CF8A9-5FE2-426A-A536-A83F84D38BF9/WF%20Migration%20Cookbook%20Workflow%20Tracking.docx)\
 Provides guidance for redesigning WF3 tracking code and configuration using equivalent WF4 tracking code and configuration.

 [WF Guidance: Workflow Services](https://download.microsoft.com/download/5/9/9/599CF8A9-5FE2-426A-A536-A83F84D38BF9/WF4%20Workflow%20Services%20Guidance.docx)\
 Provides example-oriented step-by-step instructions for redesigning workflows that implement Windows Communication Foundation (WCF) web services (commonly referred to as workflow services) created in WF3 to use WF4, for common scenarios for out-of-box activities.

## See also

- <xref:System.Activities.Statements.Interop>
