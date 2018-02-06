---
title: "How to: Create a Sequential Workflow"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
ms.assetid: 5280e816-ae17-48c4-8de0-a1e6895dd8f0
caps.latest.revision: 7
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# How to: Create a Sequential Workflow
Workflows can be constructed from built-in activities as well as from custom activities. This topic steps through creating a workflow that uses both built-in activities such as the <xref:System.Activities.Statements.Sequence> activity, and the custom activities from the previous [How to: Create an Activity](../../../docs/framework/windows-workflow-foundation/how-to-create-an-activity.md) topic. The workflow models a number guessing game.  
  
> [!NOTE]
>  Each topic in the Getting Started tutorial depends on the previous topics. To complete this topic, you must first complete [How to: Create an Activity](../../../docs/framework/windows-workflow-foundation/how-to-create-an-activity.md).  
  
> [!NOTE]
>  To download a completed version of the tutorial, see [Windows Workflow Foundation (WF45) - Getting Started Tutorial](http://go.microsoft.com/fwlink/?LinkID=248976).  
  
### To create the workflow  
  
1.  Right-click **NumberGuessWorkflowActivities** in **Solution Explorer** and select **Add**, **New Item**.  
  
2.  In the **Installed**, **Common Items** node, select **Workflow**. Select **Activity** from the **Workflow** list.  
  
3.  Type `SequentialNumberGuessWorkflow` into the **Name** box and click **Add**.  
  
4.  Drag a **Sequence** activity from the **Control Flow** section of the **Toolbox** and drop it onto the **Drop activity here** label on the workflow design surface.  
  
### To create the workflow variables and arguments  
  
1.  Double-click **SequentialNumberGuessWorkflow.xaml** in **Solution Explorer** to display the workflow in the designer, if it is not already displayed.  
  
2.  Click **Arguments** in the lower-left side of the workflow designer to display the **Arguments** pane.  
  
3.  Click **Create Argument**.  
  
4.  Type `MaxNumber` into the **Name** box, select **In** from the **Direction** drop-down list, select **Int32** from the **Argument type** drop-down list, and then press ENTER to save the argument.  
  
5.  Click **Create Argument**.  
  
6.  Type `Turns` into the **Name** box that is below the newly added `MaxNumber` argument, select **Out** from the **Direction** drop-down list, select **Int32** from the **Argument type** drop-down list, and then press ENTER.  
  
7.  Click **Arguments** in the lower-left side of the activity designer to close the **Arguments** pane.  
  
8.  Click **Variables** in the lower-left side of the workflow designer to display the **Variables** pane.  
  
9. Click **Create Variable**.  
  
    > [!TIP]
    >  If no **Create Variable** box is displayed, click the **Sequence** activity on the workflow designer surface to select it.  
  
10. Type `Guess` into the **Name** box, select **Int32** from the **Variable type** drop-down list, and then press ENTER to save the variable.  
  
11. Click **Create Variable**.  
  
12. Type `Target` into the **Name** box, select **Int32** from the **Variable type** drop-down list, and then press ENTER to save the variable.  
  
13. Click **Variables** in the lower-left side of the activity designer to close the **Variables** pane.  
  
### To add the workflow activities  
  
1.  Drag an **Assign** activity from the **Primitives** section of the **Toolbox** and drop it onto the **Sequence** activity. Type `Target` into the **To** box and the following expression into the **Enter a C# expression** or **Enter a VB expression** box.  
  
    ```vb  
    New System.Random().Next(1, MaxNumber + 1)  
    ```  
  
    ```csharp  
    new System.Random().Next(1, MaxNumber + 1)  
    ```  
  
    > [!TIP]
    >  If the **Toolbox** window is not displayed, select **Toolbox** from the **View** menu.  
  
2.  Drag a **DoWhile** activity from the **Control Flow** section of the **Toolbox** and drop it on the workflow so that it is below the **Assign** activity.  
  
3.  Type the following expression into the **DoWhile** activity’s **Condition** property value box.  
  
    ```vb  
    Guess <> Target  
    ```  
  
    ```csharp  
    Guess != Target  
    ```  
  
     A <xref:System.Activities.Statements.DoWhile> activity executes its child activities and then evaluates its <xref:System.Activities.Statements.DoWhile.Condition%2A>. If the <xref:System.Activities.Statements.DoWhile.Condition%2A> evaluates to `True`, then the activities in the <xref:System.Activities.Statements.DoWhile> execute again. In this example, the user’s guess is evaluated and the <xref:System.Activities.Statements.DoWhile> continues until the guess is correct.  
  
4.  Drag a **Prompt** activity from the **NumberGuessWorkflowActivities** section of the **Toolbox** and drop it in the **DoWhile** activity from the previous step.  
  
5.  In the **Properties Window**, type `"EnterGuess"` including the quotes into the **BookmarkName** property value box for the **Prompt** activity. Type `Guess` into the **Result** property value box, and type the following expression into the **Text** property box.  
  
    ```vb  
    "Please enter a number between 1 and " & MaxNumber  
    ```  
  
    ```csharp  
    "Please enter a number between 1 and " + MaxNumber  
    ```  
  
    > [!TIP]
    >  If the **Properties Window** is not displayed, select **Properties Window** from the **View** menu.  
  
6.  Drag an **Assign** activity from the **Primitives** section of the **Toolbox** and drop it in the **DoWhile** activity so that it follows the **Prompt** activity.  
  
    > [!NOTE]
    >  When you drop the **Assign** activity, note how the workflow designer automatically adds a **Sequence** activity to contain both the **Prompt** activity and the newly added **Assign** activity.  
  
7.  Type `Turns` into the **To** box and `Turns + 1` into the **Enter a C# expression** or **Enter a VB expression** box.  
  
8.  Drag an **If** activity from the **Control Flow** section of the **Toolbox** and drop it in the **Sequence** activity so that it follows the newly added **Assign** activity.  
  
9. Type the following expression into the **If** activity’s **Condition** property value box.  
  
    ```vb  
    Guess <> Target  
    ```  
  
    ```csharp  
    Guess != Target  
    ```  
  
10. Drag another **If** activity from the **Control Flow** section of the **Toolbox** and drop it in the **Then** section of the first **If** activity.  
  
11. Type the following expression into the newly added **If** activity’s **Condition** property value box.  
  
    ```
    Guess < Target  
    ```  
  
12. Drag two **WriteLine** activities from the **Primitives** section of the **Toolbox** and drop them so that one is in the **Then** section of the newly added **If** activity, and one is in the **Else** section.  
  
13. Click the **WriteLine** activity in the **Then** section to select it, and type the following expression into the **Text** property value box.  
  
    ```vb  
    "Your guess is too low."  
    ```  
  
14. Click the **WriteLine** activity in the **Else** section to select it, and type the following expression into the **Text** property value box.  
  
    ```vb  
    "Your guess is too high."  
    ```  
  
     The following example illustrates the completed workflow.  
  
     ![Completed Sequential Workflow](../../../docs/framework/windows-workflow-foundation/media/wfsequentialgettingstartedtutorialcomplete.JPG "WFSequentialGettingStartedTutorialComplete")  
  
### To build the workflow  
  
1.  Press CTRL+SHIFT+B to build the solution.  
  
     For instructions on how to run the workflow, please see the next topic, [How to: Run a Workflow](../../../docs/framework/windows-workflow-foundation/how-to-run-a-workflow.md). If you have already completed the [How to: Run a Workflow](../../../docs/framework/windows-workflow-foundation/how-to-run-a-workflow.md) step with a different style of workflow and wish to run it using the sequential workflow from this step, skip ahead to the [To build and run the application](../../../docs/framework/windows-workflow-foundation/how-to-run-a-workflow.md#BKMK_ToRunTheApplication) section of [How to: Run a Workflow](../../../docs/framework/windows-workflow-foundation/how-to-run-a-workflow.md).  
  
## See Also  
 <xref:System.Activities.Statements.Flowchart>  
 <xref:System.Activities.Statements.FlowDecision>  
 [Windows Workflow Foundation Programming](../../../docs/framework/windows-workflow-foundation/programming.md)  
 [Designing Workflows](../../../docs/framework/windows-workflow-foundation/designing-workflows.md)  
 [Getting Started Tutorial](../../../docs/framework/windows-workflow-foundation/getting-started-tutorial.md)  
 [How to: Create an Activity](../../../docs/framework/windows-workflow-foundation/how-to-create-an-activity.md)  
 [How to: Run a Workflow](../../../docs/framework/windows-workflow-foundation/how-to-run-a-workflow.md)
