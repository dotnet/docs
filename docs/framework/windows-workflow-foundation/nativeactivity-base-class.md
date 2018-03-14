---
title: "NativeActivity Base Class"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 254a4c50-425b-426d-a32f-0f7234925bac
caps.latest.revision: 8
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# NativeActivity Base Class
<xref:System.Activities.NativeActivity> is an abstract class with a protected constructor. Like <xref:System.Activities.CodeActivity>, <xref:System.Activities.NativeActivity> is used for writing imperative behavior by implementing an <xref:System.Activities.NativeActivity.Execute%2A> method. Unlike <xref:System.Activities.CodeActivity>, <xref:System.Activities.NativeActivity> has access to all of the exposed features of the workflow runtime through the <xref:System.Activities.NativeActivityContext> object passed to the <xref:System.Activities.NativeActivity.Execute%2A> method.  
  
## Using NativeActivityContext  
 Features of the workflow runtime can be accessed from within the <xref:System.Activities.NativeActivity.Execute%2A> method by using members of the `context` parameter, of type <xref:System.Activities.NativeActivityContext>. The features available through <xref:System.Activities.NativeActivityContext> include the following:  
  
-   Getting and setting of arguments and variables.  
  
-   Scheduling child activities with <xref:System.Activities.NativeActivityContext.ScheduleActivity%2A>  
  
-   Aborting activity execution using <xref:System.Activities.NativeActivityContext.Abort%2A>.  
  
-   Canceling child execution using <xref:System.Activities.NativeActivityContext.CancelChild%2A> and <xref:System.Activities.NativeActivityContext.CancelChildren%2A>.  
  
-   Access to activity bookmarks using such methods as <xref:System.Activities.NativeActivityContext.CreateBookmark%2A>, <xref:System.Activities.NativeActivityContext.RemoveBookmark%2A>, and <xref:System.Activities.NativeActivityContext.ResumeBookmark%2A>.  
  
-   Custom tracking features using <xref:System.Activities.CodeActivityContext.Track%2A>.  
  
-   Access to the activity’s execution properties and value properties using <xref:System.Activities.CodeActivityContext.GetProperty%2A> and <xref:System.Activities.NativeActivityContext.GetValue%2A>.  
  
-   Scheduling activity actions and functions using <xref:System.Activities.NativeActivityContext.ScheduleAction%2A> and <xref:System.Activities.NativeActivityContext.ScheduleFunc%2A>.  
  
#### To create a custom activity that inherits from NativeActivity  
  
1.  Open[!INCLUDE[vs2010](../../../includes/vs2010-md.md)].  
  
2.  Select **File**, **New**, and then **Project**. Select **Workflow 4.0** under **Visual C#** in the **Project Types** window, and select the **v2010** node. Select **Activity Library** in the **Templates** window. Name the new project HelloActivity.  
  
3.  Right-click Activity1.xaml in the HelloActivity project and select **Delete**.  
  
4.  Right-click the HelloActivity project and select **Add**, and then **Class**. Name the new class HelloActivity.cs.  
  
5.  In the HelloActivity.cs file, add the following `using` directives.  
  
    ```csharp  
    using System.Activities;  
    using System.Activities.Statements;  
    ```  
  
6.  Make the new class inherit from <xref:System.Activities.NativeActivity> by adding a base class to the class declaration.  
  
    ```csharp  
    class HelloActivity : NativeActivity  
    ```  
  
7.  Add functionality to the class by adding an <xref:System.Activities.NativeActivity.Execute%2A> method.  
  
    ```csharp  
    protected override void Execute(NativeActivityContext context)  
    {  
        Console.WriteLine("Hello World!");  
    }  
    ```  
  
8.  Override the <xref:System.Activities.NativeActivity.CacheMetadata%2A> method and call the appropriate Add method to let the workflow runtime know about the custom activity’s variables, arguments, children, and delegates. For more information see the <xref:System.Activities.NativeActivityMetadata> class.  
  
9. Use the <xref:System.Activities.NativeActivityContext> object to schedule a bookmark. See <xref:System.Activities.WorkflowApplicationIdleEventArgs.Bookmarks%2A> for details on how to create, schedule, and resume a bookmark.  
  
    ```  
    protected override void Execute(NativeActivityContext context)  
        {  
            // Create a Bookmark and wait for it to be resumed.  
            context.CreateBookmark(BookmarkName.Get(context),   
                new BookmarkCallback(OnResumeBookmark));  
        }  
    ```
