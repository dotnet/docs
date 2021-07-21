---
description: "Learn more about: Debugging Workflows"
title: "Debugging Workflows"
ms.date: "03/30/2017"
ms.assetid: b23b4814-ebb1-4c51-b7a9-469f4da7a96d
---
# Debugging Workflows

[!INCLUDE[netfx_current_long](../../../includes/netfx-current-long-md.md)] offers several options for debugging running workflows from the development environment. Workflows can be debugged in the designer, in XAML, and in code.

## Debugging in the Workflow Designer

Breakpoints can be set on activities in the workflow designer by either highlighting the activity and pressing <kbd>F9</kbd> or by using the activity’s context menu. Execution of the workflow then breaks when the workflow host is run in debug mode. In the following screenshot, workflow execution is paused at a breakpoint. For more information, see [Debugging Workflows with the Workflow Designer](/visualstudio/workflow-designer/debugging-workflows-with-the-workflow-designer).

## Debugging in XAML

If a workflow has paused at a breakpoint in the designer, the workflow can also be debugged in XAML. To view the point of execution in XAML, select **XAML View** in the workflow designer when workflow execution is paused. Debugging can be switched back to the designer by re-opening the workflow in the designer from the solution explorer. For more information, see [How to: Debug XAML with the Workflow Designer](/visualstudio/workflow-designer/how-to-debug-xaml-with-the-workflow-designer).

## Debugging in Code

To set a breakpoint, click the left margin of the code pane, or press <kbd>F9</kbd> with the cursor at the line where you want to set it.

## Attaching to a Workflow Process

Workflow debugging also supports using Visual Studio’s infrastructure to attach to a process. This enables the workflow author to debug a workflow running in a different host environment such as Internet Information Services (IIS) 7.0.

## Remote Debugging

Windows Workflow Foundation (WF) remote debugging functions the same as remote debugging for other Visual Studio components. For information on using remote debugging, see [How to: Enable Remote Debugging](/previous-versions/visualstudio/visual-studio-2010/febz73k0(v=vs.100)).

> [!NOTE]
> If the workflow application targets the x86 architecture and is hosted on a computer running a 64 bit operating system, then remote debugging will not work unless Visual Studio is installed on the remote computer or the target for the workflow application is changed to **Any CPU**.

## Extending the Workflow Debugging Service

The workflow debugger service is now public and can be used to create custom applications such as monitoring, simulation, and debugging in a re-hosted designer. For more information, see the <xref:System.Activities.Presentation.Debug.DebuggerService> article.
