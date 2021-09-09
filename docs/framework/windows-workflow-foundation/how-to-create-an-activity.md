---
title: "How to: Create an Activity"
description: "This article shows you how to create two activities in Workflow Foundation: one that uses code to implement its logic and one defined by using other activities."
ms.date: 09/14/2018
dev_langs:
  - "csharp"
  - "vb"
ms.assetid: c09b1e99-21b5-4d96-9c04-ec31db3f4436
---
# How to: Create an Activity

Activities are the core unit of behavior in WF. The execution logic of an activity can be implemented in managed code or it can be implemented by using other activities. This topic demonstrates how to create two activities. The first activity is a simple activity that uses code to implement its execution logic. The implementation of the second activity is defined by using other activities. These activities are used in following steps in the tutorial.

## Create the activity library project

1. Open Visual Studio and choose **New** > **Project** from the **File** menu.

2. In the **New Project** dialog, under the **Installed** category, select **Visual C#** > **Workflow** (or **Visual Basic** > **Workflow**).

    > [!NOTE]
    > If you don't see the **Workflow** template category, you may need to install the **Windows Workflow Foundation** component of Visual Studio. Choose the **Open Visual Studio Installer** link on the left-hand side of the **New Project** dialog. In Visual Studio Installer, select the **Individual components** tab. Then, under the **Development activities** category, select the **Windows Workflow Foundation** component. Choose **Modify** to install the component.

3. Select the **Activity Library** project template. Type `NumberGuessWorkflowActivities` in the **Name** box and then click **OK**.

4. Right-click **Activity1.xaml** in **Solution Explorer** and choose **Delete**. Click **OK** to confirm.

## Create the ReadInt activity

1. Choose **Add New Item** from the **Project** menu.

2. In the **Installed** > **Common Items** node, select **Workflow**. Select **Code Activity** from the **Workflow** list.

3. Type `ReadInt` into the **Name** box and then click **Add**.

4. Replace the existing `ReadInt` definition with the following definition.

     [!code-csharp[CFX_WF_GettingStarted#1](~/samples/snippets/csharp/VS_Snippets_CFX/cfx_wf_gettingstarted/cs/readint.cs#1)]
     [!code-vb[CFX_WF_GettingStarted#1](~/samples/snippets/visualbasic/VS_Snippets_CFX/cfx_wf_gettingstarted/vb/readint.vb#1)]

    > [!NOTE]
    > The `ReadInt` activity derives from <xref:System.Activities.NativeActivity%601> instead of <xref:System.Activities.CodeActivity>, which is the default for the code activity template. <xref:System.Activities.CodeActivity%601> can be used if the activity provides a single result, which is exposed through the <xref:System.Activities.Activity%601.Result%2A> argument, but <xref:System.Activities.CodeActivity%601> does not support the use of bookmarks, so <xref:System.Activities.NativeActivity%601> is used.

## Create the Prompt activity

1. Press **Ctrl**+**Shift**+**B** to build the project. Building the project enables the `ReadInt` activity in this project to be used to build the custom activity from this step.

2. Choose **Add New Item** from the **Project** menu.

3. In the **Installed** > **Common Items** node, select **Workflow**. Select **Activity** from the **Workflow** list.

4. Type `Prompt` into the **Name** box and then click **Add**.

5. Double-click **Prompt.xaml** in **Solution Explorer** to display it in the designer if it is not already displayed.

6. Click **Arguments** in the lower-left side of the activity designer to display the **Arguments** pane.

7. Click **Create Argument**.

8. Type `BookmarkName` into the **Name** box, select **In** from the **Direction** drop-down list, select **String** from the **Argument type** drop-down list, and then press **Enter** to save the argument.

9. Click **Create Argument**.

10. Type `Result` into the **Name** box that is underneath the newly added `BookmarkName` argument, select **Out** from the **Direction** drop-down list, select **Int32** from the **Argument type** drop-down list, and then press **Enter**.

11. Click **Create Argument**.

12. Type `Text` into the **Name** box, select **In** from the **Direction** drop-down list, select **String** from the **Argument type** drop-down list, and then press **Enter** to save the argument.

     These three arguments are bound to the corresponding arguments of the <xref:System.Activities.Statements.WriteLine> and `ReadInt` activities that are added to the `Prompt` activity in the following steps.

13. Click **Arguments** in the lower-left side of the activity designer to close the **Arguments** pane.

14. Drag a **Sequence** activity from the **Control Flow** section of the **Toolbox** and drop it onto the **Drop activity here** label of the **Prompt** activity designer.

    > [!TIP]
    > If the **Toolbox** window is not displayed, select **Toolbox** from the **View** menu.

15. Drag a **WriteLine** activity from the **Primitives** section of the **Toolbox** and drop it onto the **Drop activity here** label of the **Sequence** activity.

16. Bind the **Text** argument of the **WriteLine** activity to the **Text** argument of the **Prompt** activity by typing `Text` into the **Enter a C# expression** or **Enter a VB expression** box in the **Properties** window, and then press the **Tab** key two times. This dismisses the IntelliSense list members window and saves the property value by moving the selection off the property. This property can also be set by typing `Text` into the **Enter a C# expression** or **Enter a VB expression** box on the activity itself.

    > [!TIP]
    > If the **Properties Window** is not displayed, select **Properties Window** from the **View** menu.

17. Drag a **ReadInt** activity from the **NumberGuessWorkflowActivities** section of the **Toolbox** and drop it in the **Sequence** activity so that it follows the **WriteLine** activity.

18. Bind the **BookmarkName** argument of the **ReadInt** activity to the **BookmarkName** argument of the **Prompt** activity by typing `BookmarkName` into the **Enter a VB expression** box to the right of the **BookmarkName** argument in the **Properties Window**, and then press the **Tab** key two times to close the IntelliSense list members window and save the property.

19. Bind the **Result** argument of the **ReadInt** activity to the **Result** argument of the **Prompt** activity by typing `Result` into the **Enter a VB expression** box to the right of the **Result** argument in the **Properties Window**, and then press the **Tab** key two times.

20. Press **Ctrl**+**Shift**+**B** to build the solution.

## Next steps

For instructions on how to create a workflow by using these activities, see the next step in the tutorial, [How to: Create a Workflow](how-to-create-a-workflow.md).

## See also

- <xref:System.Activities.CodeActivity>
- <xref:System.Activities.NativeActivity%601>
- [Designing and Implementing Custom Activities](designing-and-implementing-custom-activities.md)
- [Getting Started Tutorial](getting-started-tutorial.md)
- [How to: Create a Workflow](how-to-create-a-workflow.md)
- [Using the ExpressionTextBox in a Custom Activity Designer](./samples/using-the-expressiontextbox-in-a-custom-activity-designer.md)
