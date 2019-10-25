---
title: "Task 1: Create a New Windows Presentation Foundation Application"
ms.date: "03/30/2017"
ms.assetid: 270eaeba-9492-4532-af9f-403ce5c9935b
---
# Task 1: Create a New Windows Presentation Foundation Application

In this task, you will create an empty Windows Presentation Foundation (WPF) application by using the WPF Application Visual Studio template and add references to the appropriate [!INCLUDE[netfx_current_short](../../../includes/netfx-current-short-md.md)] workflow assemblies.  
  
## To create the WPF Application project

1. Open Visual Studio and on the **File** menu, point to **New**, and then click **Project**.

2. In the **New Project** dialog box, select either **Visual C#** or **Visual Basic** from the **Installed Templates** pane on the left side of the box. If the language of your choice does not appear, look under **Other Languages**.

3. Select **Windows** in the **Installed Templates** pane.

4. In the top pane, confirm that (the default value) **.NET Framework 4** has been selected in the drop-down list box, and then select **WPF Application**.

5. Set the name of the project to **HostingApplication** at the bottom of the window.

6. Set the solution name to **RehostingTheDesigner**.

7. Click **OK** to create the application project. Visual Studio creates a basic WPF UI for your application and includes the appropriate XAML and code-behind files.

8. Add references to **WorkflowModel** assemblies. To do this, in **Solution Explorer**, right-click the **HostingApplication** project and select **Add Reference**.

9. In the **Add Reference** dialog box, click the **.NET** tab, hold down the CTRL key, select the following assemblies, and then click **OK**:

    - System.Activities
    - System.Activities.Presentation
    - System.Activities.Core.Presentation

10. See [Task 2: Host the Workflow Designer](task-2-host-the-workflow-designer.md) to learn how to host the workflow designer design canvas.

## See also

- [Rehosting the Workflow Designer](rehosting-the-workflow-designer.md)
- [Task 2: Host the Workflow Designer](task-2-host-the-workflow-designer.md)
