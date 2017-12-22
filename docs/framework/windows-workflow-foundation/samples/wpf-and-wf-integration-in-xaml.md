---
title: "WPF and WF Integration in XAML"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: a4f53b48-fc90-4315-bca0-ba009562f488
caps.latest.revision: 12
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# WPF and WF Integration in XAML
This sample demonstrates how to create an application that uses [!INCLUDE[avalon1](../../../../includes/avalon1-md.md)] and [!INCLUDE[wf](../../../../includes/wf-md.md)] features in a single XAML document. To accomplish this, the sample uses [!INCLUDE[wf](../../../../includes/wf-md.md)] and XAML extensibility.  
  
## Sample Details  
 The ShowWindow.xaml file deserializes into a <xref:System.Activities.Statements.Sequence> activity with two string variables that are manipulated by the sequence’s activities: `ShowWindow` and `WriteLine`. The <xref:System.Activities.Statements.WriteLine> activity outputs to the console window the expression that it assigns to the <xref:System.Activities.Statements.WriteLine.Text%2A> property. The `ShowWindow` activity displays a [!INCLUDE[avalon2](../../../../includes/avalon2-md.md)] window as part of its execution logic. The <xref:System.Activities.ActivityContext.DataContext%2A> of the window includes the variables declared in the sequence. The controls of the window declared in the `ShowWindow` activity use data binding to manipulate those variables. Finally, the window contains a button control. The `Click` event for the button is handled by a <xref:System.Activities.ActivityDelegate> named `MarkupExtension` that contains a `CloseWindow` activity. `MarkUpExtension` invokes the contained activity that provides, as context, any objects identified by an `x:Name`, as well as the <xref:System.Activities.ActivityContext.DataContext%2A> of the containing window. Thus, the `CloseWindow.InArgument<Window>` can be bound using an expression that references the window’s name.  
  
 The `ShowWindow` activity derives from the <xref:System.Activities.AsyncCodeActivity%601> class to display a [!INCLUDE[avalon2](../../../../includes/avalon2-md.md)] window and completes when the window is closed. The `Window` property is of type `Func<Window>` that allows the window to be created on demand for each execution of the activity. The `Window` property uses a <xref:System.Xaml.XamlDeferringLoader> to enable this deferred evaluation model. The `FuncFactoryDeferringLoader` allows a `XamlReader` to be captured during serialization and then read during activity execution.  
  
 A well-written activity never blocks the scheduler thread. However, the `ShowWindow` activity cannot complete until the window it is displaying is closed. The `ShowWindow` activity achieves this behavior by deriving from <xref:System.Activities.AsyncCodeActivity>, calling the <xref:System.Activities.WorkflowInvoker.BeginInvoke%2A> method in the <xref:System.Activities.AsyncCodeActivity.BeginExecute%2A> method, and showing the window modally. The delegate is invoked through the WPF <xref:System.ServiceModel.InstanceContext.SynchronizationContext%2A>. The `ShowWindow` activity assigns the <xref:System.Activities.ActivityContext.DataContext%2A> property to the `Window.DataContext` property to provide any data bound controls access to the in-scope variables.  
  
 The last point of interest in this sample is a <xref:System.Workflow.ComponentModel.Serialization.MarkupExtension> called `DelegateActivityExtension`. The `ProvideValue` method of this markup extension returns a delegate that invokes an embedded activity. This activity runs in an environment that includes the [!INCLUDE[avalon2](../../../../includes/avalon2-md.md)] data context and any `x:Name` values in scope. In the `GenericInvoke` method, this environment is provided to the activity through a <xref:System.Activities.Hosting.SymbolResolver> extension. This extension is added to a <xref:System.Activities.WorkflowInvoker> that is then used to invoke the embedded activity whenever the markup extension’s delegate is invoked.  
  
> [!NOTE]
>  The default designer does not support the ShowWindow activity; as such, the ShowWindow.Xaml file does not display correctly in the designer.  
  
#### To use this sample  
  
1.  Using [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)], open the WPFWFIntegration.sln solution file.  
  
2.  To build the solution, press CTRL+SHIFT+B.  
  
3.  To run the solution, press F5.  
  
4.  Type your first and last name into the dialog.  
  
5.  Close the dialog and the console echoes your name.  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WF\Scenario\WPFWFIntegration`