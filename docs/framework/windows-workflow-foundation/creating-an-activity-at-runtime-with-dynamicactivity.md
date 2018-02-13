---
title: "Creating an Activity at Runtime with DynamicActivity"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 1af85cc6-912d-449e-90c5-c5db3eca5ace
caps.latest.revision: 9
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Creating an Activity at Runtime with DynamicActivity
<xref:System.Activities.DynamicActivity> is a concrete, sealed class with a public constructor. <xref:System.Activities.DynamicActivity> can be used to assemble activity functionality at runtime using an activity DOM.  
  
## DynamicActivity Features  
 <xref:System.Activities.DynamicActivity> has access to execution properties, arguments and variables, but no access to run-time services such as scheduling child activities or tracking.  
  
 Top-level properties can be set using workflow <xref:System.Activities.Argument> objects. In imperative code, these arguments are created using CLR properties on a new type. In XAML, they are declared using `x:Class` and `x:Member` tags.  
  
 Activities constructed using <xref:System.Activities.DynamicActivity> interface with the designer using <xref:System.ComponentModel.ICustomTypeDescriptor>. Activities created in the designer can be loaded dynamically using <xref:System.Activities.XamlIntegration.ActivityXamlServices.Load%2A>, as demonstrated in the following procedure.  
  
#### To create an activity at runtime using imperative code  
  
1.  Open[!INCLUDE[vs2010](../../../includes/vs2010-md.md)].  
  
2.  Select **File**, **New**, **Project**. Select **Workflow 4.0** under **Visual C#** in the **Project Types** window, and select the **v2010** node. Select **Sequential Workflow Console Application** in the **Templates** window. Name the new project DynamicActivitySample.  
  
3.  Right-click Workflow1.xaml in the HelloActivity project and select **Delete**.  
  
4.  Open Program.cs. Add the following directive to the top of the file.  
  
    ```  
    using System.Collections.Generic;  
    ```  
  
5.  Replace the contents of the `Main` method with the following code, which creates a <xref:System.Activities.Statements.Sequence> activity that contains a single <xref:System.Activities.Statements.WriteLine> activity and assigns it to the <xref:System.Activities.DynamicActivity.Implementation%2A> property of a new dynamic activity.  
  
    ```csharp  
    //Define the input argument for the activity  
    var textOut = new InArgument<string>();  
    //Create the activity, property, and implementation  
                Activity dynamicWorkflow = new DynamicActivity()  
                {  
                    Properties =   
                    {  
                        new DynamicActivityProperty  
                        {  
                            Name = "Text",  
                            Type = typeof(InArgument<String>),  
                            Value = textOut  
                        }  
                    },  
                    Implementation = () => new Sequence()  
                    {  
                        Activities =   
                        {  
                            new WriteLine()  
                            {  
                                Text = new InArgument<string>(env => textOut.Get(env))  
                            }  
                        }  
                    }  
                };  
    //Execute the activity with a parameter dictionary  
                WorkflowInvoker.Invoke(dynamicWorkflow, new Dictionary<string, object> { { "Text", "Hello World!" } });  
                Console.ReadLine();  
    ```  
  
6.  Execute the application. A console window with the text "Hello World!" displays.  
  
#### To create an activity at runtime using XAML  
  
1.  Open [!INCLUDE[vs2010](../../../includes/vs2010-md.md)].  
  
2.  Select **File**, **New**, **Project**. Select **Workflow 4.0** under **Visual C#** in the **Project Types** window, and select the **v2010** node. Select  **Workflow Console Application** in the **Templates** window. Name the new project DynamicActivitySample.  
  
3.  Open Workflow1.xaml in the HelloActivity project. Click the **Arguments** option at the bottom of the designer. Create a new `In` argument called `TextToWrite` of type `String`.  
  
4.  Drag a **WriteLine** activity from the **Primitives** section of the toolbox onto the designer surface. Assign the value `TextToWrite` to the **Text** property of the activity.  
  
5.  Open Program.cs. Add the following directive to the top of the file.  
  
    ```  
    using System.Activities.XamlIntegration;  
    ```  
  
6.  Replace the contents of the `Main` method with the following code.  
  
    ```  
    Activity act2 = ActivityXamlServices.Load(@"Workflow1.xaml");  
                    results = WorkflowInvoker.Invoke(act2, new Dictionary<string, object> { { "TextToWrite", "HelloWorld!" } });  
    Console.ReadLine();  
    ```  
  
7.  Execute the application. A console window with the text "Hello World!" appears.  
  
8.  Right-click the Workflow1.xaml file in the **Solution Explorer** and select **View Code**. Note that the activity class is created with `x:Class` and the property is created with `x:Property`.  
  
## See Also  
 [Authoring Workflows, Activities, and Expressions Using Imperative Code](../../../docs/framework/windows-workflow-foundation/authoring-workflows-activities-and-expressions-using-imperative-code.md)  
 [DynamicActivity Creation](../../../docs/framework/windows-workflow-foundation/samples/dynamicactivity-creation.md)
