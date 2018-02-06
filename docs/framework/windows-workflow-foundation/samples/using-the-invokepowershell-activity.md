---
title: "Using the InvokePowerShell Activity"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 956251a0-31ca-4183-bf76-d277c08585df
caps.latest.revision: 10
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Using the InvokePowerShell Activity
The InvokePowerShell sample demonstrates how to invoke Windows PowerShell commands using the `InvokePowerShell` activity.  
  
## Demonstrates  
  
-   Simple innovation of Windows PowerShell commands.  
  
-   Retrieve values from the Windows PowerShell output pipeline and store them in workflow variables.  
  
-   Pass data into windows PowerShell as input pipeline for an executing command.  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WF\Scenario\ActivityLibrary\PowerShell`  
  
## Discussion  
 This sample contains the following three projects.  
  
|Project Name|Description|Main Files|  
|------------------|-----------------|----------------|  
|CodedClient|A sample client application that uses the PowerShell activity.|-   **Program.cs**: Programmatically creates a sequence-based workflow that calls the InvokePowerShell activity.|  
|DesignerClient|A set of custom activities that contain the `InvokePowerShell` custom activity and other miscellaneous custom activities, and a workflow that uses them.|<ul><li>Activities:<br /><br /> <ul><li>**PrintCollection.cs**: A helper activity that prints all the items in a collection to the console.</li><li>**ReadLine.cs**: A helper activity for reading input from the console.</li></ul></li><li>File System:<br /><br /> <ul><li>**Copy.xaml**: An activity that copies a file.</li><li>**CreateFile.xaml**: An activity that creates a file.</li><li>**DeleteFile.xaml**: An activity that deletes a file.</li><li>**MakeDir.xaml**: An activity that creates a directory.</li><li>**Move.xaml**: An activity that moves a file.</li><li>**ReadFile.xaml**: An activity that reads a file and returns its contents.</li><li>**TestPath.xaml**: An activity that tests for the existence of a path.</li></ul></li><li>Process:<br /><br /> <ul><li>**GetProcess.xaml**: An activity that gets a list of running processes.</li><li>**StopProcess.xaml**: An activity that stops a specific process.</li></ul></li><li>**Program.cs**: Calls the Sequence1 workflow.</li><li>**Sequence1.xaml**: A sequence-based workflow.</li></ul>|  
|PowerShell|The `InvokePowerShell` activity and its associated designers.|Activity Files<br /><br /> -   **ExecutePowerShell.cs**: The main execution logic of the activity.<br />-   **InvokePowerShell.cs**: The wrapper around the main execution logic, which contains a generic (return value) version and a non-generic (non-return value) version. This is the public interface for the activity.<br />-   **NoPersistZone.cs**: This activity prevents any child activities from persisting. This class is used within the `InvokePowerShell` activity implementation to prevent the activity from being persisted mid-execution.<br /><br /> Designer files:<br /><br /> 1.  **ArgumentDictionaryEditor.cs**: A Windows dialog that allows the user to edit the arguments of the `InvokePowerShell` activity.<br />2.  **GenericInvokePowerShellDesigner.xaml** and **GenericInvokePowerShellDesigner.xaml.cs**: Defines the appearance of the generic `InvokePowerShell` activity in [!INCLUDE[wfd2](../../../../includes/wfd2-md.md)].<br />3.  **InvokePowerShellDesigner.xaml** and **InvokePowerShellDesigner.cs**: Defines the appearance of the non-generic `InvokePowerShell` activity in [!INCLUDE[wfd2](../../../../includes/wfd2-md.md)].|  
  
 The client projects are discussed first, as it is easier to understand the internal functionality of the PowerShell activity once its use is understood.  
  
## Using This Sample  
 The following sections describe how to use the three projects in the sample.  
  
### Using the Coded Client Project  
 The sample client programmatically creates a sequence activity, which contains examples of several different methods of using the `InvokePowerShell` activity. The first invocation launches Notepad.  
  
```  
new InvokePowerShell()  
{  
    CommandText = "notepad"  
},  
```  
  
 The second invocation gets a list of the processes running on the local machine.  
  
```  
new InvokePowerShell<Process>()  
{  
    CommandText = "Get-Process",  
    Output = processes1,  
},  
```  
  
 `Output` is the variable used to store the output of the command.  
  
 The next call demonstrates how to run a post-processing step on each individual output of the PowerShell invocation. `InitializationAction` is set to the function that outputs a string representation for each process. The collection of these strings is returned in the `Output` variable by the `InvokePowerShell<string>` activity.  
  
 The succeeding `InvokePowerShell` calls demonstrate passing data into the activity and getting outputs and errors out.  
  
### Using the Designer Client Project  
 The DesignerClient project consists of a set of custom activities, almost all of which are built containing the `InvokePowerShell` activity. Most of the activities call the non-generic version of the `InvokePowerShell` activity, and do not expect a return value. Other activities use the generic version of the `InvokePowerShell` activity, and use the `InitializationAction` argument to post-process the results.  
  
## Using the PowerShell Project  
 The main action of the activity takes place in the `ExecutePowerShell` class. Because the execution of PowerShell commands should not block the main workflow thread, the activity is created to be an asynchronous activity by inheriting from the <xref:System.Activities.AsyncCodeActivity> class.  
  
 The <xref:System.Activities.AsyncCodeActivity.BeginExecute%2A> method is called by the workflow runtime to begin running the activity. It starts by calling PowerShell APIs to create a PowerShell pipeline.  
  
```  
runspace = RunspaceFactory.CreateRunspace();  
runspace.Open();  
pipeline = runspace.CreatePipeline();  
```  
  
 It then creates a PowerShell command and populates it with parameters and variables.  
  
```  
Command cmd = new Command(this.CommandText, this.IsScript);   
// loop over parameters and run: cmd.Parameters.Add(...)  
// loop over variables and run: runspace.SessionStateProxy.SetVariable(...)  
pipeline.Commands.Add(cmd);  
```  
  
 The inputs piped in are also sent to the pipeline at this point. Finally, the pipeline is wrapped in a `PipelineInvokerAsyncResult` object and returned. The `PipelineInvokerAsyncResult` object registers a listener and invokes the pipeline.  
  
```  
pipeline.InvokeAsync();  
```  
  
 When execution finishes, output and errors are stored within the same `PipelineInvokerAsyncResult` object, and control is handed back to the workflow runtime by calling the callback method originally passed to <xref:System.Activities.AsyncCodeActivity.BeginExecute%2A>.  
  
 At the end of the method's execution, the workflow runtime calls the activity’s <xref:System.Activities.AsyncCodeActivity.EndExecute%2A> method.  
  
 The `InvokePowerShell` class wraps the `ExecutePowerShellCommand` class and creates two versions of the activity; a generic version and a non-generic version. The non-generic version returns the output of the PowerShell execution directly, whereas the generic version transforms the individual results to the generic type.  
  
 The generic version of the activity is implemented as a sequential workflow that calls `ExecutePowerShellCommand` and post-processes its results. For each element in the result collection, the post-processing step calls `InitializationAction` if it is set. Otherwise, it does a simple cast.  
  
```  
new ForEach<PSObject>  
{  
    Values = psObjects,  
    Body = new ActivityAction<PSObject>  
    {  
        Argument = psObject,  
        Handler = new Sequence  
        {  
            Activities =  
            {  
                new If  
                {  
                    Condition = // Is InitializationAction set?  
                    Then = new InvokeFunc<PSObject, TResult>  
                    {  
                        Argument = psObject,  
                        Result = outputObject,  
                        Func = this.InitializationAction  
                    },  
                    Else = new Assign<TResult>  
                    {  
                        To = outputObject,  
                        Value = new InArgument<TResult>(ctx => (TResult) psObject.Get(ctx).BaseObject),  
                    }  
                },  
                new AddToCollection<TResult>  
                {  
                    Collection = outputObjects,  
                    Item = outputObject  
                },  
            }  
        }  
    }  
},  
```  
  
 For each of the two `InvokePowerShell` activities (generic, and non-generic), a designer was created. InvokePowerShellDesigner.xaml and its associated .cs file define the appearance in [!INCLUDE[wfd2](../../../../includes/wfd2-md.md)] for the non-generic version of the `InvokePowerShell` activity. Inside InvokePowerShellDesigner.xaml, a <xref:System.Windows.Controls.DockPanel> is used to represent the graphical interface.  
  
```  
<DockPanel x:Uid="DockPanel_1" LastChildFill="True">  
        <TextBlock x:Uid="TextBlock_1" Text="CommandText" />  
        <TextBox x:Uid="TextBox_1" Text="{Binding Path=ModelItem.CommandText, Mode=TwoWay}"  
                 TextWrapping="WrapWithOverflow"  AcceptsReturn="True" MinLines="4" MaxLines="4"  
                 Background="{x:Null}" Margin="3" />  
    </DockPanel>  
```  
  
 Note that the `Text` property of the text box is a two-way binding that ensures that the value of the activity’s `CommandText` property is equivalent to the value input into the designer.  
  
 GenericInvokePowerShellDesigner.xaml and its associated .cs file define the graphical interface for the generic `InvokePowerShell` activity. The designer is slightly more complicated because it allows users to set an `InitializationAction`. The key element is the usage of <xref:System.Activities.Presentation.WorkflowItemPresenter> to allow drag and drop of child activities onto the `InvokePowerShell` designer surface.  
  
```  
<sap:WorkflowItemPresenter x:Uid="sap:WorkflowItemPresenter_1" Margin="0,10,0,10"  
    HintText="Drop Activities Here"  
    AllowedItemType="{x:Type sa:Activity}"  
    Item="{Binding Path=ModelItem.InitializationAction.Handler, Mode=TwoWay}"  
    Grid.Row="1" Grid.Column="1" />  
```  
  
 The designer customization does not stop with the .xaml files that define the appearance of the activity on the design canvas. The dialog boxes used to display the parameters of the activity can also be customized. These parameters and PowerShell variables affect the behavior of PowerShell commands. The activity exposes them as <!--zz <xref:System.Collections.Generic.Dictionary%601>--> `System.Collections.Generic.Dictionary` types. ArgumentDictionaryEditor.cs, PropertyEditorResources.xaml and PropertyEditorResources.cs define the dialog box that allows you to edit these types.  
  
## To set up, build, and run the sample  
 You must install Windows PowerShell to run this sample. Windows PowerShell can be installed from this location: [Windows PowerShell](http://go.microsoft.com/fwlink/?LinkId=150383).  
  
#### To run the coded client  
  
1.  Open PowerShell.sln using [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)].  
  
2.  Right-click the solution and build it.  
  
3.  Right-click the **CodedClient** project and select **Set as Startup Project**.  
  
4.  Press CTRL+F5 to run the application.  
  
#### To run the designer client  
  
1.  Open PowerShell.sln using [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)].  
  
2.  Right-click the solution and build it.  
  
3.  Right-click the **DesignerClient** project and select **Set as Startup Project**.  
  
4.  Press CTRL+F5 to run the application.  
  
## Known Issues  
  
1.  If referencing the `InvokePowerShell` activity assembly or project from another project results in a build error, you may need to manually add the `<SpecificVersion>True</SpecificVersion>` element to the .csproj file of the new project under the line that references `InvokePowerShell`.  
  
2.  If Windows PowerShell is not installed, the following error message is displayed in Visual Studio as soon as you add an `InvokePowerShell` activity onto a workflow: `Workflow Designer encountered problems with your document. Could not load file or assembly ‘System.Management.Automation’ ... or one of its dependencies. The system cannot find the file specified.`  
  
3.  In Windows PowerShell 2.0, programmatically calling `$input.MoveNext()` fails and scripts using `$input.MoveNext()` produce unintended errors and results. To work around this issue, consider using the PowerShell verb `foreach` instead of calling `MoveNext()` when iterating an array.  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WF\Scenario\ActivityLibrary\PowerShell`