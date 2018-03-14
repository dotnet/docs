---
title: "WorkflowApplication ReadLine Host"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: f7b362be-cb42-40d7-b9ef-cfc4aed2455b
caps.latest.revision: 14
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# WorkflowApplication ReadLine Host
This sample is a generic ReadLine host. You can load and run any workflow using the included `ReadLine` activity (or other activities like it that get data from bookmarks resumed with strings). Output from the `WriteLine` activity or anything writing to the <xref:System.Activities.Statements.WriteLine.TextWriter%2A> extension is directed to the host window. When an instance is idle, the available bookmarks for that instance appear in a combo box. Selecting a bookmark, inputting some text, and pressing the resume bookmark button continue the execution of the workflow. You can also cancel, abort, or terminate a selected workflow. Persistence is on by default – you can shut down the host and bring it back, and the instance list is populated with the instances stored in the database. Tracking is used to output <xref:System.Activities.WorkflowApplication>-level events to the host with the option to add detailed tracking at the activity level.  
  
## Sample Details  
 There are two layers to this host: the view and the instance manager. The view consists of the `HostView` and `WorkflowApplicationInfo` classes. The general pattern for this host is for the `HostView` class to display available options to the user based on `WorkflowApplicationInfo` objects that are kept reasonably in synchronization with the instances they represent. The instance manager layer consists of the `WorkflowApplicationManager` class, which is the core of all host communications, and the `WorkflowDefinitionExtension` class, which persists the relationship between an instance and the program definition it was started with and a few other classes. The `HostView` calls control operations on the `WorkflowApplicationManager`. These calls are typically asynchronous to maintain a responsive user interface. When the asynchronous calls complete, the `WorkflowApplicationManager` makes calls back into the view layer through a well-defined interface (`IHostView`). The `HostView` class most often dispatches these calls from the `WorkflowApplicationManager` class to the user interface thread. Text writing is done to thread-safe <xref:System.Activities.Statements.WriteLine.TextWriter%2A> objects provided by the `HostView` class. The user interface is not the only thing generating events. The <xref:System.Activities.WorkflowApplication> objects also signal the `WorkflowApplicationManager` when they go `Idle`, `Complete`, or are `Aborted`, for example. The `WorkflowApplicationManager` class gets off the event thread by dispatching clean up or updating work to the host.  
  
 The recording of the file used to launch a <xref:System.Activities.WorkflowApplication> is facilitated by the `WorkflowDefinitionExtension` class. It implements the <xref:System.Activities.Persistence.PersistenceIOParticipant> interface to participate in persistence and persist the path to the workflow definition.  
  
 The `WorkflowApplicationManager.Load` method uses the stored path to instantiate the workflow programs required for loading unfinished <xref:System.Activities.WorkflowApplication> objects.  
  
#### To set up, build, and run the sample  
  
1.  This sample requires SQL Express to be installed. SQL Express comes with [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)].  
  
2.  Open a Visual Studio 2010 command prompt.  
  
3.  Navigate to the sample directory (\WF\Basic\Execution\ControllingWorkflowApplications) and run CreateInstanceStore.cmd.  
  
4.  The CreateInstanceStore.cmd script attempts to create the database on the default instance of SQL Server 2008 Express. If you want to install the database on a different instance, modify the script to do so.  
  
5.  Compile the WorkflowApplicationReadLineHost project and run it from the command line.  
  
6.  Once running, you can optionally turn persistence off or on. Further, you can optionally turn detailed activity tracking on or off.  
  
7.  Press the ellipsis button next to the **Run** button to browse for a workflow defined in a XAML file  
  
     Two samples can be found under the SampleWorkflows folder. The parallel1.xaml example goes idle.  
  
8.  Once an example is selected, press the **Run** button.  
  
9. If or when the workflow goes idle, the **Bookmarks** combo box is populated with available bookmarks.  
  
10. The options at this point are to resume a bookmark, cancel, abort, or terminate the workflow. You can also shut down the host and restart it. If persistence is left on, the instances are unloaded on shutdown and reloaded on start up.  
  
     To resume a bookmark, select the desired bookmark, type in a value in the text box next to the combo box and press **Resume Bookmark**.  
  
#### To remove the instance store database  
  
1.  Open a Visual Studio 2010 command prompt.  
  
2.  Navigate to the sample directory (\WF\Basic\Execution\ControllingWorkflowApplications) and run RemoveInstanceStore.cmd.  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WF\Basic\Execution\ControllingWorkflowApplications`