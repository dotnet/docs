---
title: "Workflow Activity Authoring Using the CodeActivity Class"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: cfe315c1-f86d-43ec-b9ce-2f8c469b1106
caps.latest.revision: 11
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Workflow Activity Authoring Using the CodeActivity Class
Activities created by inheriting from <xref:System.Activities.CodeActivity> can implement basic imperative behavior by overriding the <xref:System.Activities.CodeActivity.Execute%2A> method.  
  
## Using CodeActivityContext  
 Features of the workflow runtime can be accessed from within the <xref:System.Activities.CodeActivity.Execute%2A> method by using members of the `context` parameter, of type <xref:System.Activities.CodeActivityContext>. The features available through <xref:System.Activities.CodeActivityContext> include the following:  
  
-   Getting and setting the values of variables and arguments.  
  
-   Custom tracking features using <xref:System.Activities.CodeActivityContext.Track%2A>.  
  
-   Access to the activity’s execution properties using <xref:System.Activities.CodeActivityContext.GetProperty%2A>.  
  
#### To create a custom activity that inherits from CodeActivity  
  
1.  Open[!INCLUDE[vs2010](../../../includes/vs2010-md.md)].  
  
2.  Select **File**, **New**, and then **Project**. Select **Workflow 4.0** under **Visual C#** in the **Project Types** window, and select the **v2010** node. Select **Activity Library** in the **Templates** window. Name the new project HelloActivity.  
  
3.  Right-click Activity1.xaml in the HelloActivity project and select **Delete**.  
  
4.  Right-click the HelloActivity project and select **Add** , and then **Class**. Name the new class HelloActivity.cs.  
  
5.  In the HelloActivity.cs file, add the following `using` directives.  
  
    ```csharp  
    using System.Activities;  
    using System.Activities.Statements;  
    ```  
  
6.  Make the new class inherit from <xref:System.Activities.CodeActivity> by adding a base class to the class declaration.  
  
    ```csharp  
    class HelloActivity : CodeActivity  
    ```  
  
7.  Add functionality to the class by adding an <xref:System.Activities.CodeActivity.Execute%2A> method.  
  
    ```csharp  
    protected override void Execute(CodeActivityContext context)  
    {  
        Console.WriteLine("Hello World!");  
    }  
    ```  
  
8.  Use the <xref:System.Activities.CodeActivityContext> to create a tracking record.  
  
    ```csharp  
    protected override void Execute(CodeActivityContext context)  
    {  
        Console.WriteLine("Hello World!");  
        CustomTrackingRecord record = new CustomTrackingRecord("MyRecord");  
        record.Data.Add(new KeyValuePair<String, Object>("ExecutionTime", DateTime.Now));  
        context.Track(record);  
    }  
    ```
