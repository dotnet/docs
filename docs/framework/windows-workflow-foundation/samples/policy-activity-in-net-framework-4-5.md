---
title: "Policy Activity in .NET Framework 4.5"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 8e375e0c-d7c1-4d69-88ab-36d52db0aa7e
caps.latest.revision: 15
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Policy Activity in .NET Framework 4.5
The Policy4 activity allows [!INCLUDE[wf2](../../../../includes/wf2-md.md)] in [!INCLUDE[netfx35_long](../../../../includes/netfx35-long-md.md)] (WF 3.5) <xref:System.Workflow.Activities.Rules.RuleSet> objects to be used in [!INCLUDE[wf2](../../../../includes/wf2-md.md)] in [!INCLUDE[netfx_current_long](../../../../includes/netfx-current-long-md.md)] (WF 4.5) directly by using the rules engine that is shipped in WF 3.5. By using this activity, you can create and execute a WF 3.5 <xref:System.Workflow.Activities.Rules.RuleSet>. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] WF 3.5 Rules Engine included as part of Windows Workflow Foundation, please read Introduction to the Windows Workflow Foundation Rules Engine. For more information about migrating rules to WF in [!INCLUDE[netfx_current_long](../../../../includes/netfx-current-long-md.md)], please read [Migration Guidance](../../../../docs/framework/windows-workflow-foundation/migration-guidance.md).  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WF\Scenario\ActivityLibrary\Rules-Policy4`  
  
## Projects in this Sample  
  
|Project Name|Description|Main Files|  
|------------------|-----------------|----------------|  
|Policy4|Contains the Policy4 activity and its [!INCLUDE[wf1](../../../../includes/wf1-md.md)] designer.|**Policy4.cs**: Policy4 activity definition.<br /><br /> **PolicyDesigner.xaml**: Custom designer for Policy4 activity. It uses the rules editor ([RuleSetDialog Class](http://go.microsoft.com/fwlink/?LinkId=150378)) from [!INCLUDE[wf1](../../../../includes/wf1-md.md)] rules engine.|  
|ImperativeCodeClientSample|Sample client application that configures and runs a workflow using a Policy4 application using imperative C# code (no [!INCLUDE[wf1](../../../../includes/wf1-md.md)] Designer used).|**ApplyDiscount.rules**: File with [!INCLUDE[wf1](../../../../includes/wf1-md.md)] rule definitions.<br /><br /> **Order.cs**: Type that represents a customer order. Rules are applied to objects of this type.<br /><br /> **Program.cs**: Configures and runs a workflow that has a Policy4 activity to apply rules defined in ApplyDiscount.rules to instances of Order objects.<br /><br /> **App.config**: Configuration file with the path of the rules file.|  
|DesignerClientSample|Sample client application that configures and runs a workflow using a Policy4 application in the [!INCLUDE[wf1](../../../../includes/wf1-md.md)] Designer.|**Sequence1.xaml**: Sequential workflow that uses a Policy4 activity to perform rule evaluations.<br /><br /> `Program.cs`: Runs an instance of the workflow defined in Sequence1.xaml.|  
  
## The Policy4 Activity  
 The Policy4 activity is a class that derives from <xref:System.Activities.NativeActivity%601> that allows workflows to execute [!INCLUDE[wf1](../../../../includes/wf1-md.md)] RuleSets. The following code example is a simplified definition of the public OM of the activity.  
  
```csharp  
public class Policy4Activity<TResult>: NativeActivity<TResult>  
{  
    public RuleSet RuleSet  
  
    [IsRequired]  
    public InArgument Input  
  
    public OutArgument<ValidationErrorCollection> ValidationErrors  
}  
```  
  
|Property|Description|  
|--------------|-----------------|  
|RuleSet|The WF [RuleSet Class](http://go.microsoft.com/fwlink/?LinkId=150379) for .NET Framework 3.5 to be evaluated when the activity is executed.|  
|TargetObject|The object against which the Rules in the [RuleSet Class](http://go.microsoft.com/fwlink/?LinkId=150379) are evaluated.|  
|ValidationError|The list of validation errors returned by the [!INCLUDE[wf1](../../../../includes/wf1-md.md)] Rule Engine for .NET Framework 3.5 when validating the [RuleSet Class](http://go.microsoft.com/fwlink/?LinkId=150379) against the target object before execution.|  
  
## Policy4 Activity Designer  
 The Policy4 designer adds the capability to configure a Policy4 activity without the need to write code. After building the solution, it can be found in the toolbox in the section **Microsoft.Samples.Activities.Rules**.  
  
 The WF Designer allows you to configure a target object and a RuleSet. When the **Edit RuleSet** button is clicked, the WF [RuleSetDialog Class](http://go.microsoft.com/fwlink/?LinkId=150378) for [!INCLUDE[netfx35_short](../../../../includes/netfx35-short-md.md)] is displayed. This dialog is the re-hosted [!INCLUDE[netfx35_short](../../../../includes/netfx35-short-md.md)] Rules Editor. Use the editor to create and edit the rules that the Policy4 activity executes.  
  
## Using this Sample  
 No special set up is required to run this sample. Just open the solution in Visual Studio, and press F5 to run the application.  
  
 This sample contains two client applications: ImperativeCodeClientSample and DesignerClientSample. The ImperativeCodeClientSample client shows how to configure and run the Policy40 activity using C# imperative code. The DesignerClientSample shows how to configure and run the Policy4 activity using the designer.  
  
#### To run the ImperativeCodeClientSample client application  
  
1.  Using [!INCLUDE[vs_current_long](../../../../includes/vs-current-long-md.md)], open the Policy4Sample.sln solution file.  
  
2.  In **Solution Explorer**, right-click the **ImperativeCodeClientSample** project and then select **Set as startup project**.  
  
3.  To run the project, press CTRL+F5.  
  
#### To run the ImperativeCodeClientSample client application  
  
1.  Using [!INCLUDE[vs_current_long](../../../../includes/vs-current-long-md.md)], open the Policy4Sample.sln solution file.  
  
2.  In **Solution Explorer**, right-click the **DesignerClientSample** project.  
  
    -   Select **Set as startup project**.  
  
3.  To compile the project, press CTRL+SHIFT+B.  
  
4.  To run the project, press CTRL+F5.