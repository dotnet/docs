---
title: "Toolbox Service"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 742212d0-445e-41ed-9739-9ee848ce7f1b
caps.latest.revision: 6
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Toolbox Service
This sample demonstrates how to update the [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)] Toolbox activities based on the context of the workflow. The sample contains a workflow that changes the toolbox contents based on whether a custom activity is selected.  
  
## Discussion  
 During workflow authoring, customers generally want their Toolbox to be context sensitive. For example, the user may want to ensure that the Toolbox shows a few additional activities when a specific activity is added to the workflow. If the activities are removed from the workflow, the toolbox should react appropriately based on the domain requirements.  
  
 In a re-hosted workflow designer, you control the Toolbox control and can ensure that based on the Model changes in the workflow, the host triggers appropriate changes in the Toolbox control. However, in [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)], the toolbox is not controlled by the user and thus an interface is required to modify its contents. `IActivityToolboxService` is that interface.  
  
 The API provides the following four methods.  
  
```  
public interface IActivityToolboxService   
{   
        void AddCategory(string categoryName);   
        void RemoveCategory(string categoryName);   
        void AddItem(string qualifiedTypeName, string categoryName);   
        void RemoveItem(string qualifiedTypeName, string categoryName);   
        IList<string> EnumCategories();   
        IList<string> EnumItems(string categoryName);   
}  
```  
  
#### To set up, build, and run the sample  
  
1.  Using [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)], open the WorkflowSimulator.sln solution file.  
  
2.  Build the solution by pressing CTRL+SHIFT+B.  
  
3.  Open the Workflow.xaml file.  
  
4.  Add a **CustomActivity** by dragging and dropping it from the toolbox. Notice that an additional Toolbox category called: **New WF Category** with an additional activity **Assign**.  
  
5.  Now unselect the **CustomActivity** by dragging another activity into it.  
  
6.  The item **Assign** in the category **New WF Category** under Toolbox is now removed. Also, because there are no more items left in the category, the category is removed as well.  
  
7.  Select the **CustomActivity** again and the category and **Assign** activity is added back.  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WF\Basic\Designer\IActivityToolboxService`
