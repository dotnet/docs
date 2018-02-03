---
title: "Task 1: Create a New Windows Presentation Foundation Application"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 270eaeba-9492-4532-af9f-403ce5c9935b
caps.latest.revision: 14
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Task 1: Create a New Windows Presentation Foundation Application
In this task, you will create an empty [!INCLUDE[avalon1](../../../includes/avalon1-md.md)] application by using the WPF Application Visual Studio template and add references to the appropriate [!INCLUDE[netfx_current_short](../../../includes/netfx-current-short-md.md)] workflow assemblies.  
  
### To create the WPF Application project  
  
1.  Open [!INCLUDE[vs_current_short](../../../includes/vs-current-short-md.md)] and on the **File** menu, point to **New**, and then click **Project**.  
  
2.  In the **New Project** dialog box, select either **Visual C#** or **Visual Basic** from the **Installed Templates** pane on the left side of the box. If the language of your choice does not appear, look under **Other Languages**.  
  
3.  Select **Windows** in the **Installed Templates** pane.  
  
4.  In the top pane, confirm that (the default value) **.NET Framework 4** has been selected in the drop-down list box, and then select **WPF Application**.  
  
5.  Set the name of the project to **HostingApplication** at the bottom of the window.  
  
6.  Set the solution name to **RehostingTheDesigner**.  
  
7.  Click **OK** to create the application project. [!INCLUDE[vs_current_short](../../../includes/vs-current-short-md.md)] creates a basic WPF UI for your application and includes the appropriate XAML and code-behind files.  
  
8.  Add references to **WorkflowModel** assemblies. To do this, in **Solution Explorer**, right-click the **HostingApplication** project and select **Add Reference**.  
  
9. In the **Add Reference** dialog box, click the **.NET** tab, hold down the CTRL key, select the following assemblies, and then click **OK**:  
  
    -   System.Activities  
  
    -   System.Activities.Presentation  
  
    -   System.Activities.Core.Presentation  
  
10. Click **OK**.  
  
11. See [Task 2: Host the Workflow Designer](../../../docs/framework/windows-workflow-foundation/task-2-host-the-workflow-designer.md) to learn how to host the workflow designer design canvas.  
  
## See Also  
 [Rehosting the Workflow Designer](../../../docs/framework/windows-workflow-foundation/rehosting-the-workflow-designer.md)  
 [Task 2: Host the Workflow Designer](../../../docs/framework/windows-workflow-foundation/task-2-host-the-workflow-designer.md)
