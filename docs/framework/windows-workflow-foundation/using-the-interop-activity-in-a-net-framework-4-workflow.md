---
title: "Using the Interop Activity in a .NET Framework 4 Workflow"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 9bb747f0-eb33-4f70-84cd-317382372dcd
caps.latest.revision: 20
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Using the Interop Activity in a .NET Framework 4 Workflow
Activities created using [!INCLUDE[vstecwinfx](../../../includes/vstecwinfx-md.md)] or [!INCLUDE[netfx35_short](../../../includes/netfx35-short-md.md)] can be used in a [!INCLUDE[netfx_current_short](../../../includes/netfx-current-short-md.md)] workflow by using the <xref:System.Activities.Statements.Interop> activity. This topic provides an overview of using the <xref:System.Activities.Statements.Interop> activity.  
  
> [!NOTE]
>  The <xref:System.Activities.Statements.Interop> activity does not appear in the workflow designer toolbox unless the workflow's project has its **Target Framework** setting set to **.Net Framework 4** or later.  
  
## Using the Interop Activity in .NET Framework 4.5 Workflows  
 In this topic, a [!INCLUDE[netfx35_short](../../../includes/netfx35-short-md.md)] activity library is created that contains a `DiscountCalculator` activity. The `DiscountCalculator` calculates a discount based on a purchase amount and consists of a <xref:System.Workflow.Activities.SequenceActivity> that contains a <xref:System.Workflow.Activities.PolicyActivity>.  
  
> [!NOTE]
>  The [!INCLUDE[netfx35_short](../../../includes/netfx35-short-md.md)] activity created in this topic uses a <xref:System.Workflow.Activities.PolicyActivity> to implement the logic of the activity. It is not required to use a custom [!INCLUDE[netfx35_short](../../../includes/netfx35-short-md.md)] activity or the <xref:System.Activities.Statements.Interop> activity in order to use rules in a [!INCLUDE[netfx_current_short](../../../includes/netfx-current-short-md.md)] workflow. For an example of using rules in a [!INCLUDE[netfx_current_short](../../../includes/netfx-current-short-md.md)] workflow without using the <xref:System.Activities.Statements.Interop> activity, see the [Policy Activity in .NET Framework 4.5](../../../docs/framework/windows-workflow-foundation/samples/policy-activity-in-net-framework-4-5.md) sample.  
  
#### To create the .NET Framework 3.5 activity library project  
  
1.  Open [!INCLUDE[vs_current_long](../../../includes/vs-current-long-md.md)] and select **New** and then **Project…** from the **File** menu.  
  
2.  Expand the **Other Project Types** node in the **Installed Templates** pane and select **Visual Studio Solutions**.  
  
3.  Select **Blank Solution** from the **Visual Studio Solutions** list. Type `PolicyInteropDemo` in the **Name** box and click **OK**.  
  
4.  Right-click **PolicyInteropDemo** in **Solution Explorer** and select **Add** and then **New Project…**.  
  
    > [!TIP]
    >  If the **Solution Explorer** window is not visible, select **Solution Explorer** from the **View** menu.  
  
5.  In the **Installed Templates** list, select **Visual C#** and then **Workflow**. Select **.NET Framework 3.5** from the .NET Framework version drop-down list, and then select **Workflow Activity Library** from the **Templates** list.  
  
6.  Type `PolicyActivityLibrary` in the **Name** box and click **OK**.  
  
7.  Right-click **Activity1.cs** in **Solution Explorer** and select **Delete**. Click **OK** to confirm.  
  
#### To create the DiscountCalculator activity  
  
1.  Right-click **PolicyActivityLibrary** in **Solution Explorer** and select **Add** and then **Activity…**.  
  
2.  Select **Activity (with code separation)** from the **Visual C# Items** list. Type `DiscountCalculator` in the **Name** box and click **OK**.  
  
3.  Right-click **DiscountCalculator.xoml** in **Solution Explorer** and select **View Code**.  
  
4.  Add the following three properties to the `DiscountCalculator` class.  
  
    ```csharp  
    public partial class DiscountCalculator : SequenceActivity  
    {  
        public double Subtotal { get; set; }  
        public double DiscountPercent { get; set; }  
        public double Total { get; set; }  
    }  
    ```  
  
5.  Right-click **DiscountCalculator.xoml** in **Solution Explorer** and select **View Designer**.  
  
6.  Drag a **Policy** activity from the **Windows Workflow v3.0** section of the **Toolbox** and drop it in the **DiscountCalculator** activity.  
  
    > [!TIP]
    >  If the **Toolbox** window is not visible, select **Toolbox** from the **View** menu.  
  
#### To configure the rules  
  
1.  Click the newly added **Policy** activity to select it, if it is not already selected.  
  
2.  Click the **RuleSetReference** property in the **Properties** window to select it, and click the ellipsis button to the right of the property.  
  
    > [!TIP]
    >  If the **Properties** window is not visible, choose **Properties Window** from the **View** menu.  
  
3.  Select **Click New…**.  
  
4.  Click **Add Rule**.  
  
5.  Type the following expression into the **Condition** box.  
  
    ```  
    this.Subtotal >= 50 && this.Subtotal < 100  
    ```  
  
6.  Type the following expression into the **Then Actions** box.  
  
    ```  
    this.DiscountPercent = 0.075  
    ```  
  
7.  Click **Add Rule**.  
  
8.  Type the following expression into the **Condition** box.  
  
    ```  
    this.Subtotal >= 100  
    ```  
  
9. Type the following expression into the **Then Actions** box.  
  
    ```  
    this.DiscountPercent = 0.15  
    ```  
  
10. Click **Add Rule**.  
  
11. Type the following expression into the **Condition** box.  
  
    ```  
    this.DiscountPercent > 0  
    ```  
  
12. Type the following expression into the **Then Actions** box.  
  
    ```  
    this.Total = this.Subtotal - this.Subtotal * this.DiscountPercent  
    ```  
  
13. Type the following expression into the **Else Actions** box.  
  
    ```  
    this.Total = this.Subtotal  
    ```  
  
14. Click **OK** to close the **Rule Set Editor** dialog box.  
  
15. Ensure that the newly-created <xref:System.Workflow.Activities.Rules.RuleSet> is selected in the **Name** list, and click **OK**.  
  
16. Press CTRL+SHIFT+B to build the solution.  
  
 The rules added to the `DiscountCalculator` activity in this procedure are shown in the following code example.  
  
```  
Rule1: IF this.Subtotal >= 50 && this.Subtotal < 100   
       THEN this.DiscountPercent = 0.075   
  
Rule2: IF this. Subtotal >= 100   
       THEN this.DiscountPercent = 0.15   
  
Rule3: IF this.DiscountPercent > 0   
       THEN this.Total = this.Subtotal - this.Subtotal * this.DiscountPercent   
       ELSE this.Total = this.Subtotal  
```  
  
 When the <xref:System.Workflow.Activities.PolicyActivity> executes, these three rules evaluate and modify the `Subtotal`, `DiscountPercent`, and `Total` property values of the `DiscountCalculator` activity to calculate the desired discount.  
  
## Using the DiscountCalculator Activity with the Interop Activity  
 To use the `DiscountCalculator` activity inside a [!INCLUDE[netfx_current_short](../../../includes/netfx-current-short-md.md)] workflow, the <xref:System.Activities.Statements.Interop> activity is used. In this section two workflows are created, one using code and one using the workflow designer, which show how to use the <xref:System.Activities.Statements.Interop> activity with the `DiscountCalculator` activity. The same host application is used for both workflows.  
  
#### To create the host application  
  
1.  Right-click **PolicyInteropDemo** in **Solution Explorer** and select **Add**, and then **New Project…**.  
  
2.  Ensure that **.NET Framework 4.5** is selected in the .NET Framework version drop-down list, and select  **Workflow Console Application** from the **Visual C# Items** list.  
  
3.  Type `PolicyInteropHost` into the **Name** box and click **OK**.  
  
4.  Right-click **PolicyInteropHost** in **Solution Explorer** and select **Properties**.  
  
5.  In the **Target framework** drop-down list, change the selection from **.NET Framework 4 Client Profile** to **.NET Framework 4.5**. Click **Yes** to confirm.  
  
6.  Right-click **PolicyInteropHost** in **Solution Explorer** and select **Add Reference…**.  
  
7.  Select **PolicyActivityLibrary** from the **Projects** tab and click **OK**.  
  
8.  Right-click **PolicyInteropHost** in **Solution Explorer** and select **Add Reference…**.  
  
9. Select **System.Workflow.Activities**, **System.Workflow.ComponentModel**, and then **System.Workflow.Runtime** from the **.NET** tab and click **OK**.  
  
10. Right-click **PolicyInteropHost** in **Solution Explorer** and select **Set as StartUp Project**.  
  
11. Press CTRL+SHIFT+B to build the solution.  
  
### Using the Interop Activity in Code  
 In this example, a workflow definition is created using code that contains the <xref:System.Activities.Statements.Interop> activity and the `DiscountCalculator` activity. This workflow is invoked using <xref:System.Activities.WorkflowInvoker> and the results of the rule evaluation are written to the console using a <xref:System.Activities.Statements.WriteLine> activity.  
  
##### To use the Interop activity in code  
  
1.  Right-click **Program.cs** in **Solution Explorer** and select **View Code**.  
  
2.  Add the following `using` statement at the top of the file.  
  
    ```csharp  
    using PolicyActivityLibrary;  
    ```  
  
3.  Remove the contents of the `Main` method and replace with the following code.  
  
    ```csharp  
    static void Main(string[] args)  
    {  
        CalculateDiscountUsingCodeWorkflow();  
    }  
    ```  
  
4.  Create a new method in the `Program` class called `CalculateDiscountUsingCodeWorkflow` that contains the following code.  
  
    ```csharp  
    static void CalculateDiscountUsingCodeWorkflow()  
    {  
        Variable<double> Subtotal = new Variable<double>  
        {  
            Default = 75.99,  
            Name = "Subtotal"  
        };  
  
        Variable<double> DiscountPercent = new Variable<double>  
        {  
            Name = "DiscountPercent"  
        };  
  
        Variable<double> Total = new Variable<double>  
        {  
            Name = "Total"  
        };  
  
        Activity wf = new Sequence  
        {  
            Variables = { Subtotal, DiscountPercent, Total },  
            Activities =   
            {  
                new Interop  
                {  
                    ActivityType = typeof(DiscountCalculator),  
                    ActivityProperties =   
                    {  
                        { "Subtotal", new InArgument<double>(Subtotal) },  
                        { "DiscountPercentOut", new OutArgument<double>(DiscountPercent) },  
                        { "TotalOut", new OutArgument<double>(Total) }  
                    }  
                },  
                new WriteLine  
                {  
                    Text =  new InArgument<string>(env =>   
                        string.Format("Subtotal: {0:C}, Discount {1}%, Total {2:C}",   
                        Subtotal.Get(env), DiscountPercent.Get(env) * 100, Total.Get(env)))  
                }  
            }  
        };  
  
        WorkflowInvoker.Invoke(wf);  
    }  
    ```  
  
    > [!NOTE]
    >  The `Subtotal`, `DiscountPercent`, and `Total` properties of the `DiscountCalculator` activity are surfaced as arguments of the <xref:System.Activities.Statements.Interop> activity, and bound to local workflow variables in the <xref:System.Activities.Statements.Interop> activity’s <xref:System.Activities.Statements.Interop.ActivityProperties%2A> collection. `Subtotal` is added as an <xref:System.Activities.ArgumentDirection.In> argument because the `Subtotal` data flows into the <xref:System.Activities.Statements.Interop> activity, and `DiscountPercent` and `Total` are added as <xref:System.Activities.ArgumentDirection.Out> arguments because their data flows out of the <xref:System.Activities.Statements.Interop> activity. Note that the two <xref:System.Activities.ArgumentDirection.Out> arguments are added with the names `DiscountPercentOut` and `TotalOut` to indicate that they represent <xref:System.Activities.ArgumentDirection.Out> arguments. The `DiscountCalculator` type is specified as the <xref:System.Activities.Statements.Interop> activity’s <xref:System.Activities.Statements.Interop.ActivityType%2A>.  
  
5.  Press CTRL+F5 to build and run the application. Substitute different values for the `Subtotal` value to test out the different discount levels provided by the `DiscountCalculator` activity.  
  
    ```csharp  
    Variable<double> Subtotal = new Variable<double>  
    {  
        Default = 75.99, // Change this value.  
        Name = "Subtotal"  
    };  
    ```  
  
### Using the Interop Activity in the Workflow Designer  
 In this example, a workflow is created using the workflow designer. This workflow has the same functionality as the previous example, except than instead of using a <xref:System.Activities.Statements.WriteLine> activity to display the discount, the host application retrieves and displays the discount information when the workflow completes. Also, instead of using local workflow variables to contain the data, arguments are created in the workflow designer and the values are passed in from the host when the workflow is invoked.  
  
##### To host the PolicyActivity using a Workflow Designer-created workflow  
  
1.  Right-click **Workflow1.xaml** in **Solution Explorer** and select **Delete**. Click **OK** to confirm.  
  
2.  Right-click **PolicyInteropHost** in **Solution Explorer** and select **Add**, **New Item…**.  
  
3.  Expand the **Visual C# Items** node and select **Workflow**. Select **Activity** from the **Visual C# Items** list.  
  
4.  Type `DiscountWorkflow` into the **Name** box and click **Add**.  
  
5.  Click the **Arguments** button on the lower left side of the workflow designer to display the **Arguments** pane.  
  
6.  Click **Create Argument**.  
  
7.  Type `Subtotal` into the **Name** box, select **In** from the **Direction** drop-down, select **Double** from the **Argument type** drop-down, and then press ENTER to save the argument.  
  
    > [!NOTE]
    >  If **Double** is not in the **Argument type** drop-down list, select **Browse for Types …**, type `System.Double` in the **Type Name** box, and click **OK**.  
  
8.  Click **Create Argument**.  
  
9. Type `DiscountPercent` into the **Name** box, select **Out** from the **Direction** drop-down, select **Double** from the **Argument type** drop-down, and then press ENTER to save the argument.  
  
10. Click **Create Argument**.  
  
11. Type `Total` into the **Name** box, select **Out** from the **Direction** drop-down, select **Double** from the **Argument type** drop-down, and then press ENTER to save the argument.  
  
12. Click the **Arguments** button on the lower left side of the workflow designer to close the **Arguments** pane.  
  
13. Drag a **Sequence** activity from the **Control Flow** section of the **Toolbox** and drop it onto the workflow designer surface.  
  
14. Drag an **Interop** activity from the **Migration** section of the **Toolbox** and drop it in the **Sequence** activity.  
  
15. Click the **Interop** activity on the **Click to browse…** label, type **DiscountCalculator** in the **Type Name** box, and click **OK**.  
  
    > [!NOTE]
    >  When the <xref:System.Activities.Statements.Interop> activity is added to the workflow and the `DiscountCalculator` type is specified as its <xref:System.Activities.Statements.Interop.ActivityType%2A>, the <xref:System.Activities.Statements.Interop> activity exposes three <xref:System.Activities.ArgumentDirection.In> arguments and three <xref:System.Activities.ArgumentDirection.Out> arguments that represent the three public properties of the `DiscountCalculator` activity. The <xref:System.Activities.ArgumentDirection.In> arguments have the same name as the three public properties, and the three <xref:System.Activities.ArgumentDirection.Out> arguments have the same names with **Out** appended to the property name. In the following steps, the workflow arguments created in the previous steps are bound to the <xref:System.Activities.Statements.Interop> activity’s arguments.  
  
16. Type `DiscountPercent` into the **Enter a VB expression** box to the right of the **DiscountPercentOut** property and press TAB.  
  
17. Type `Subtotal` into the **Enter a VB expression** box to the right of the **Subtotal** property and press TAB.  
  
18. Type `Total` into the **Enter a VB expression** box to the right of the **TotalOut** property and press TAB.  
  
19. Right-click **Program.cs** in **Solution Explorer** and select **View Code**.  
  
20. Add the following `using` statement at the top of the file.  
  
    ```csharp  
    using System.Collections.Generic;  
    ```  
  
21. Comment out the call to the `CalculateDiscountInCode` method in the `Main` method and add the following code.  
  
    > [!NOTE]
    >  If you did not follow the previous procedure and the default `Main` code is present, replace the contents of `Main` with the following code.  
  
    ```csharp  
    static void Main(string[] args)  
    {  
        CalculateDiscountUsingDesignerWorkflow();  
        //CalculateDiscountUsingCodeWorkflow();  
    }  
    ```  
  
22. Create a new method in the `Program` class called `CalculateDiscountUsingDesignerWorkflow` that contains the following code.  
  
    ```csharp  
    static void CalculateDiscountUsingDesignerWorkflow()  
    {  
        double SubtotalValue = 125.99;  
        Dictionary<string, object> wfargs = new Dictionary<string, object>  
        {  
            {"Subtotal", SubtotalValue}  
        };  
  
        Activity wf = new DiscountWorkflow();  
  
        IDictionary<string, object> outputs =  
            WorkflowInvoker.Invoke(wf, wfargs);  
  
        Console.WriteLine("Subtotal: {0:C}, Discount {1}%, Total {2:C}",  
            SubtotalValue, (double)outputs["DiscountPercent"] * 100,  
            outputs["Total"]);  
    }  
    ```  
  
23. Press CTRL+F5 to build and run the application. To specify a different `Subtotal` amount, change the value of `SubtotalValue` in the following code.  
  
    ```csharp  
    double SubtotalValue = 125.99; // Change this value.  
    ```  
  
## Rules Features Overview  
 The [!INCLUDE[wf1](../../../includes/wf1-md.md)] rules engine provides support for processing rules in a priority-based manner with support for forward chaining. Rules can be evaluated for a single item or for items in a collection. For an overview of rules and information on specific rules functionality, please refer to the following table.  
  
|Rules Feature|Documentation|  
|-------------------|-------------------|  
|Rules Overview|[Introduction to the Windows Workflow Foundation Rules Engine](http://go.microsoft.com/fwlink/?LinkID=152836)|  
|RuleSet|[Using RuleSets in Workflows](http://go.microsoft.com/fwlink/?LinkId=178516) and <xref:System.Workflow.Activities.Rules.RuleSet>|  
|Evaluation of Rules|[Rules Evaluation in RuleSets](http://go.microsoft.com/fwlink/?LinkId=178517)|  
|Rules Chaining|[Forward Chaining Control](http://go.microsoft.com/fwlink/?LinkId=178518) and [Forward Chaining of Rules](http://go.microsoft.com/fwlink/?LinkId=178519)|  
|Processing Collections in Rules|[Processing Collections in Rules](http://go.microsoft.com/fwlink/?LinkId=178520)|  
|Using the PolicyActivity|[Using the PolicyActivity Activity](http://go.microsoft.com/fwlink/?LinkId=178521) and <xref:System.Workflow.Activities.PolicyActivity>|  
  
 Workflows created in [!INCLUDE[netfx_current_short](../../../includes/netfx-current-short-md.md)] do not use all of the rules features provided by [!INCLUDE[wf1](../../../includes/wf1-md.md)], such as declarative activity conditions and conditional activities such as the <xref:System.Workflow.Activities.ConditionedActivityGroup> and <xref:System.Workflow.Activities.ReplicatorActivity>. If required, this functionality is available for workflows created using [!INCLUDE[vstecwinfx](../../../includes/vstecwinfx-md.md)] and [!INCLUDE[netfx35_short](../../../includes/netfx35-short-md.md)]. [!INCLUDE[crdefault](../../../includes/crdefault-md.md)] [Migration Guidance](../../../docs/framework/windows-workflow-foundation/migration-guidance.md).
