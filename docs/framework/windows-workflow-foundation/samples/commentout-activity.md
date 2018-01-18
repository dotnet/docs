---
title: "CommentOut Activity"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 340204c3-f827-45fb-870e-55e2ac457ca5
caps.latest.revision: 8
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# CommentOut Activity
This sample demonstrates how to write a custom activity that removes other activities from the path of execution, effectively commenting them out.  
  
## The CommentOut Activity  
 To achieve its goal, the CommentOut activity derives from the <xref:System.Activities.CodeActivity> base class and implements an empty <xref:System.Activities.CodeActivity.Execute%2A> method.  
  
```  
protected override void Execute(CodeActivityContext context)  
{  
}  
```  
  
 The class is declared as shown in the following example.  
  
```  
[Designer(typeof(CommentOutDesigner))]  
[ContentProperty("Body")]  
public sealed class CommentOut : CodeActivity  
```  
  
 The `Designer` attribute specifies the class that implements the visual interface of the activity at design time. The `ContentProperty` attribute declares that the `"Body"` property can be skipped in the XAML representation of an instance of this activity.  
  
```  
<Border x:Uid="Border_1" BorderThickness ="1">  
    <sad:WorkflowItemPresenter   
    x:Uid="sad:WorkflowItemPresenter_1" AutomationProperties.AutomationId="Body" Item="{Binding Path=ModelItem.Body, Mode=TwoWay}"  
    AllowedItemType="{x:Type sa:Activity}"  
    HintText="Drop activity here"   
    Margin="5,5,5,5" />  
</Border>  
```  
  
 In the designer class, XAML is used to create a custom visual representation of the activity. <xref:System.Activities.Presentation.WorkflowItemPresenter> is a class that provides the visual editor.  
  
 A single activity can be dropped onto the `CommentOut` activity surface. If you want to add multiple activities to this surface, drag a sequence activity here first.  
  
#### To use this sample  
  
1.  Open CommentOut.sln in [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)].  
  
2.  Compile the solution by pressing CTRL+SHIFT+B.  
  
3.  Start the sample without debugging by pressing CTRL+F5.  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WF\Scenario\ActivityLibrary\CommentOut`
