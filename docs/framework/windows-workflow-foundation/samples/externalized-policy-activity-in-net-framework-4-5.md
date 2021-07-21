---
description: "Learn more about: Externalized Policy Activity in .NET Framework 4.5"
title: "Externalized Policy Activity in .NET Framework 4.5"
ms.date: "03/30/2017"
ms.assetid: 92fd6f92-23a1-4adf-b96a-2754ea93ad3e
---
# Externalized Policy Activity in .NET Framework 4.5

The [Rules-ExternalizedPolicy4 sample](https://github.com/dotnet/samples/tree/main/framework/windows-workflow-foundation/scenario/ActivityLibrary/Rules-ExternalizedPolicy4/CS) demonstrates how the ExternalizedPolicy4 activity allows executing existing .NET Framework 3.5 Windows Workflow Foundation (WF 3.5) <xref:System.Workflow.Activities.Rules.RuleSet> objects in [!INCLUDE[netfx_current_long](../../../../includes/netfx-current-long-md.md)] Windows Workflow Foundation (WF 4.5) directly by using the rules engine that is shipped in WF 3.5. By using this activity, you can open and execute any existing WF 3.5 <xref:System.Workflow.Activities.Rules.RuleSet>. For more information about WF 3.5 Rules Engine included as part of Windows Workflow Foundation, please read [Introduction to the Windows Workflow Foundation Rules Engine](/previous-versions/dotnet/articles/aa480193(v=msdn.10)). For more information about migrating rules to WF in [!INCLUDE[netfx_current_short](../../../../includes/netfx-current-short-md.md)], see the [Migration Guidance](../migration-guidance.md).

## Projects in this Sample

|Project Name|Description|Main Files|
|-|-|-|
|ExternalizedPolicy4|Contains the ExternalizedPolicy4 activity and its WF 4.5 designer.|**ExternalizedPolicy4.cs**: activity definition.<br /><br /> **ExternalizedPolicy4Designer.xaml**: Custom designer for ExternalizedPolicy4 activity. It uses the Rules editor (<xref:System.Workflow.Activities.Rules.Design.RuleSetDialog>) from WF 3.5 Rules Engine.|
|ImperativeCodeClientSample|Sample client application that configures and runs a workflow using an ExternalizedPolicy4 application using imperative C# code (no designer used).|**ApplyDiscount.rules**: File with WF rule definitions.<br /><br /> **Order.cs**: Type that represents a customer order. Rules are applied to objects of this type.<br /><br /> **Program.cs**: Configures and runs a workflow that has a Policy4 activity to apply rules defined in ApplyDiscount.rules to instances of Order objects.<br /><br /> App.config: The configuration file with the path of the rules file.|
|DesignerClientSample|Sample client application that configures and runs a workflow using an ExternalPolicy4 application in the WF Designer.|**Sequence1.xaml**: Sequential workflow that uses a Policy4 activity to perform rule evaluations.<br /><br /> **Program.cs**: Runs an instance of the workflow defined in Sequence1.xaml.|

## The ExternalizedPolicy4 Activity

The ExternalizedPolicy4 activity is a <xref:System.Activities.NativeActivity> that allows executing WF 3.5 <xref:System.Workflow.Activities.Rules.RuleSet> objects within WF 4.5 workflows. The following example is a simplified definition of the public object model of the activity.

```csharp
public class ExternalizedPolicy4Activity<TResult>: CodeActivity
{
    public string RulesFilePath

    public string RuleSetName

    [RequiredArgument]
    public InArgument<T> TargetObject

    [RequiredArgument]
    public OutArgument<T> ResultObject

    public OutArgument<ValidationErrorCollection> ValidationErrors
}
```

|Property|Description|
|-|-|
|RuleSetFilePath|Path to the .NET Framework 3.5 <xref:System.Workflow.Activities.Rules.RuleSet> file to be evaluated when the activity is executed.|
|RuleSetName|Name of the <xref:System.Workflow.Activities.Rules.RuleSet> to be used within the .rules file.|
|TargetObject|The object on which the <xref:System.Workflow.Activities.Rules.Rule> objects in the <xref:System.Workflow.Activities.Rules.RuleSet> is evaluated against.|
|ResultObject|The resulting object after the rules are applied (for example, rules are applied against the Input argument and the result is stored in the Result argument.|
|ValidationError|The list of validation errors returned by the WF 3.5 Rules Engine when validating the <xref:System.Workflow.Activities.Rules.RuleSet> against the target object before execution.|

## ExternalizedPolicy4 Activity Designer

The ExternalizedPolicy4 designer allows you to configure an activity to use an existing RuleSet without writing code. Just set the path where the .rules file is located and specify the <xref:System.Workflow.Activities.Rules.RuleSet> name that you want use. It also allows you to modify the <xref:System.Workflow.Activities.Rules.RuleSet>. After building the solution, it can be found in the toolbox in the section Microsoft.Samples.Activities.Rules. The designer allows you to select a .rules file and a <xref:System.Workflow.Activities.Rules.RuleSet>. When the **Edit RuleSet** button is clicked, the WF 3.5 <xref:System.Workflow.Activities.Rules.Design.RuleSetDialog> is displayed. This dialog is the re-hosted WF 3.5 rules editor and it is used to view and edit the rules that the ExternalizedPolicy4 activity executes.

## Policy4 and ExternalPolicy4

The Policy activity allows you to create and execute a .NET Framework 3.5 RuleSet in a WF 4.5 workflow. The <xref:System.Workflow.Activities.Rules.RuleSet> is serialized inline in the Policy4 activity XAML definition. The ExternalizedPolicy4 sample shows how to use an existing external <xref:System.Workflow.Activities.Rules.RuleSet> (contained in a .rules file).

## Use this sample

No special set-up is required to run this sample. Open the solution in Visual Studio, and then press **F5** to run the application.

This sample contains two client applications: ImperativeCodeClientSample and DesignerClientSample. The ImperativeCodeClientSample client shows how to configure and run the ExternalizedPolicy4 activity using C# imperative code. The DesignerClientSample shows how to configure and run the ExternalizedPolicy4 activity using the designer.

### Run the ImperativeCodeClientSample application

1. Using Visual Studio, open the *Policy4sample.sln* solution file.

2. In **Solution Explorer**, right-click the **ImperativeCodeClientSample** project and then select **Set as startup project**.

3. To run the project, press **Ctrl**+**F5**.

### Run the DesignerClientSample application

1. Using Visual Studio, open the *Policy4sample.sln* solution file.

2. In **Solution Explorer**, right-click the **DesignerClientSample** project and then select **Set as startup project**.

3. Press **Ctrl**+**Shift**+**B** to compile the project.

4. Press **Ctrl**+**F5** to run the project.
