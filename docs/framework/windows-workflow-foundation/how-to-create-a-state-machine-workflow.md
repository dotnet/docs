---
title: "How to: Create a State Machine Workflow"
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
ms.assetid: 3ec60e8f-fad4-493e-a426-e7962d7aee8c
caps.latest.revision: 15
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# How to: Create a State Machine Workflow
Workflows can be constructed from built-in activities as well as from custom activities. This topic steps through creating a workflow that uses both built-in activities such as the <xref:System.Activities.Statements.StateMachine> activity, and the custom activities from the previous [How to: Create an Activity](../../../docs/framework/windows-workflow-foundation/how-to-create-an-activity.md) topic. The workflow models a number guessing game.  
  
> [!NOTE]
>  Each topic in the Getting Started tutorial depends on the previous topics. To complete this topic, you must first complete [How to: Create an Activity](../../../docs/framework/windows-workflow-foundation/how-to-create-an-activity.md).  
  
> [!NOTE]
>  To download a completed version of the tutorial, see [Windows Workflow Foundation (WF45) - Getting Started Tutorial](http://go.microsoft.com/fwlink/?LinkID=248976).  
  
### To create the workflow  
  
1.  Right-click **NumberGuessWorkflowActivities** in **Solution Explorer** and select **Add**, **New Item**.  
  
2.  In the **Installed**, **Common Items** node, select **Workflow**. Select **Activity** from the **Workflow** list.  
  
3.  Type `StateMachineNumberGuessWorkflow` into the **Name** box and click **Add**.  
  
4.  Drag a **StateMachine** activity from the **State Machine** section of the **Toolbox** and drop it onto the **Drop activity here** label on the workflow design surface.  
  
### To create the workflow variables and arguments  
  
1.  Double-click **StateMachineNumberGuessWorkflow.xaml** in **Solution Explorer** to display the workflow in the designer, if it is not already displayed.  
  
2.  Click **Arguments** in the lower-left side of the workflow designer to display the **Arguments** pane.  
  
3.  Click **Create Argument**.  
  
4.  Type `MaxNumber` into the **Name** box, select **In** from the **Direction** drop-down list, select **Int32** from the **Argument type** drop-down list, and then press ENTER to save the argument.  
  
5.  Click **Create Argument**.  
  
6.  Type `Turns` into the **Name** box that is below the newly added `MaxNumber` argument, select **Out** from the **Direction** drop-down list, select **Int32** from the **Argument type** drop-down list, and then press ENTER.  
  
7.  Click **Arguments** in the lower-left side of the activity designer to close the **Arguments** pane.  
  
8.  Click **Variables** in the lower-left side of the workflow designer to display the **Variables** pane.  
  
9. Click **Create Variable**.  
  
    > [!TIP]
    >  If no **Create Variable** box is displayed, click the <xref:System.Activities.Statements.StateMachine> activity on the workflow designer surface to select it.  
  
10. Type `Guess` into the **Name** box, select **Int32** from the **Variable type** drop-down list, and then press ENTER to save the variable.  
  
11. Click **Create Variable**.  
  
12. Type `Target` into the **Name** box, select **Int32** from the **Variable type** drop-down list, and then press ENTER to save the variable.  
  
13. Click **Variables** in the lower-left side of the activity designer to close the **Variables** pane.  
  
### To add the workflow activities  
  
1.  Click **State1** to select it. In the **Properties Window**, change the **DisplayName** to `Initialize Target`.  
  
    > [!TIP]
    >  If the **Properties Window** is not displayed, select **Properties Window** from the **View** menu.  
  
2.  Double-click the newly renamed **Initialize Target** state in the workflow designer to expand it.  
  
3.  Drag an **Assign** activity from the **Primitives** section of the **Toolbox** and drop it onto the **Entry** section of the state. Type `Target` into the **To** box and the following expression into the **Enter a C# expression** or **Enter a VB expression** box.  
  
    ```vb  
    New System.Random().Next(1, MaxNumber + 1)  
    ```  
  
    ```csharp  
    new System.Random().Next(1, MaxNumber + 1)  
    ```  
  
    > [!TIP]
    >  If the **Toolbox** window is not displayed, select **Toolbox** from the **View** menu.  
  
4.  Return to the overall state machine view in the workflow designer by clicking **StateMachine** in the breadcrumb display at the top of the workflow designer.  
  
5.  Drag a **State** activity from the **State Machine** section of the **Toolbox** onto the workflow designer and hover it over the **Initialize Target** state. Note that four triangles will appear around the **Initialize Target** state when the new state is over it. Drop the new state on the triangle that is immediately below the **Initialize Target** state. This places the new state onto the workflow and creates a transition from the **Initialize Target** state to the new state.  
  
6.  Click **State1** to select it, change the **DisplayName** to `Enter Guess`, and then double-click the state in the workflow designer to expand it.  
  
7.  Drag a **WriteLine** activity from the **Primitives** section of the **Toolbox** and drop it onto the **Entry** section of the state.  
  
8.  Type the following expression into the **Text** property box of the **WriteLine**.  
  
    ```vb  
    "Please enter a number between 1 and " & MaxNumber  
    ```  
  
    ```csharp  
    "Please enter a number between 1 and " + MaxNumber  
    ```  
  
9. Drag an **Assign** activity from the **Primitives** section of the **Toolbox** and drop onto the **Exit** section of the state.  
  
10. Type `Turns` into the **To** box and `Turns + 1` into the **Enter a C# expression** or **Enter a VB expression** box.  
  
11. Return to the overall state machine view in the workflow designer by clicking **StateMachine** in the breadcrumb display at the top of the workflow designer.  
  
12. Drag a **FinalState** activity from the **State Machine** section of the **Toolbox**, hover it over the **Enter Guess** state, and drop it onto the triangle that appears to the right of the **Enter Guess** state so that a transition is created between **Enter Guess** and **FinalState**.  
  
13. The default name of the transition is **T2**. Click the transition in the workflow designer to select it, and set its **DisplayName** to **Guess Correct**. Then click and select the **FinalState**, and drag it to the right so that there is room for the full transition name to be displayed without overlaying either of the two states. This will make it easier to complete the remaining steps in the tutorial.  
  
14. Double-click the newly renamed **Guess Correct** transition in the workflow designer to expand it.  
  
15. Drag a **ReadInt** activity from the **NumberGuessWorkflowActivities** section of the **Toolbox** and drop it in the **Trigger** section of the transition.  
  
16. In the **Properties Window** for the **ReadInt** activity, type `"EnterGuess"` including the quotes into the **BookmarkName** property value box, and type `Guess` into the **Result** property value box  
  
17. Type the following expression into the **Guess Correct** transition’s **Condition** property value box.  
  
    ```vb  
    Guess = Target  
    ```  
  
    ```csharp  
    Guess == Target  
    ```  
  
18. Return to the overall state machine view in the workflow designer by clicking **StateMachine** in the breadcrumb display at the top of the workflow designer.  
  
    > [!NOTE]
    >  A transition occurs when the trigger event is received and the <xref:System.Activities.Statements.Transition.Condition%2A>, if present, evaluates to `True`. For this transition, if the user’s `Guess` matches the randomly generated `Target`, then control passes to the **FinalState** and the workflow completes.  
  
19. Depending on whether the guess is correct, the workflow should transition either to the **FinalState** or back to the **Enter Guess** state for another try. Both transitions share the same trigger of waiting for the user’s guess to be received via the **ReadInt** activity. This is called a shared transition. To create a shared transition, click the circle that indicates the start of the **Guess Correct** transition and drag it to the desired state. In this case the transition is a self-transition, so drag the start point of the **Guess Correct** transition and drop it back onto the bottom of the **Enter Guess** state. After creating the transition, select it in the workflow designer and set its **DisplayName** property to **Guess Incorrect**.  
  
    > [!NOTE]
    >  Shared transitions can also be created from within the transition designer by clicking **Add shared trigger transition** at the bottom of the transition designer, and then selecting the desired target state from the **Available states to connect** drop-down.  
  
    > [!NOTE]
    >  Note that if the <xref:System.Activities.Statements.Transition.Condition%2A> of a transition evaluates to `false` (or all of the conditions of a shared trigger transition evaluate to `false`), the transition will not occur and all triggers for all the transitions from the state will be rescheduled. In this tutorial, this situation cannot happen because of the way the conditions are configured (we have specific actions for whether the guess is correct or incorrect).  
  
20. Double-click the **Guess Incorrect** transition in the workflow designer to expand it. Note that the **Trigger** is already set to the same **ReadInt** activity that was used by the **Guess Correct** transition.  
  
21. Type the following expression into the **Condition** property value box.  
  
    ```vb  
    Guess <> Target  
    ```  
  
    ```csharp  
    Guess != Target  
    ```  
  
22. Drag an **If** activity from the **Control Flow** section of the **Toolbox** and drop it in the **Action** section of the transition.  
  
23. Type the following expression into the **If** activity’s **Condition** property value box.  
  
    ```
    Guess < Target  
    ```  
  
24. Drag two **WriteLine** activities from the **Primitives** section of the **Toolbox** and drop them so that one is in the **Then** section of the **If** activity, and one is in the **Else** section.  
  
25. Click the **WriteLine** activity in the **Then** section to select it, and type the following expression into the **Text** property value box.  
  
    ```
    "Your guess is too low."  
    ```  
  
26. Click the **WriteLine** activity in the **Else** section to select it, and type the following expression into the **Text** property value box.  
  
    ```
    "Your guess is too high."  
    ```  
  
27. Return to the overall state machine view in the workflow designer by clicking **StateMachine** in the breadcrumb display at the top of the workflow designer.  
  
     The following example illustrates the completed workflow.  
  
     ![Completed State Machine Workflow](../../../docs/framework/windows-workflow-foundation/media/wfstatemachinegettingstartedtutorialcomplete.JPG "WFStateMachineGettingStartedTutorialComplete")  
  
### To build the workflow  
  
1.  Press CTRL+SHIFT+B to build the solution.  
  
     For instructions on how to run the workflow, please see the next topic, [How to: Run a Workflow](../../../docs/framework/windows-workflow-foundation/how-to-run-a-workflow.md). If you have already completed the [How to: Run a Workflow](../../../docs/framework/windows-workflow-foundation/how-to-run-a-workflow.md) step with a different style of workflow and wish to run it using the state machine workflow from this step, skip ahead to the [To build and run the application](../../../docs/framework/windows-workflow-foundation/how-to-run-a-workflow.md#BKMK_ToRunTheApplication) section of [How to: Run a Workflow](../../../docs/framework/windows-workflow-foundation/how-to-run-a-workflow.md).  
  
## See Also  
 <xref:System.Activities.Statements.Flowchart>  
 <xref:System.Activities.Statements.FlowDecision>  
 [Windows Workflow Foundation Programming](../../../docs/framework/windows-workflow-foundation/programming.md)  
 [Designing Workflows](../../../docs/framework/windows-workflow-foundation/designing-workflows.md)  
 [Getting Started Tutorial](../../../docs/framework/windows-workflow-foundation/getting-started-tutorial.md)  
 [How to: Create an Activity](../../../docs/framework/windows-workflow-foundation/how-to-create-an-activity.md)  
 [How to: Run a Workflow](../../../docs/framework/windows-workflow-foundation/how-to-run-a-workflow.md)
