---
title: "Using Collection Activities"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: e1977cf8-1695-4071-b946-7046fe39601e
caps.latest.revision: 10
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Using Collection Activities
This sample demonstrates how to use the collection activities (<xref:System.Activities.Statements.AddToCollection%601>, <xref:System.Activities.Statements.ClearCollection%601>, <xref:System.Activities.Statements.ExistsInCollection%601>, and <xref:System.Activities.Statements.RemoveFromCollection%601>) with a class that implements the <xref:System.Collections.ICollection> interface and how to create a custom activity that iterates over a collection to print out the contents of each element in the collection. The custom activity, which is named `PrintCollection`, prints to the console the item members of a collection named `Numbers`.  
  
 The following table describes the four activities that provide collection manipulation for workflows.  
  
|Activity name|Description|  
|-------------------|-----------------|  
|<xref:System.Activities.Statements.AddToCollection%601>|Adds an item to a collection.|  
|<xref:System.Activities.Statements.ClearCollection%601>|Clears all items in a collection|  
|<xref:System.Activities.Statements.ExistsInCollection%601>|Returns `true` if specified item exists in collection.|  
|<xref:System.Activities.Statements.RemoveFromCollection%601>|Removes an item from a collection.|  
  
 The sample consists of two solutions, one under the CodedWorkflow directory and the other under the DesignerWorkflow directory. They demonstrate two different ways of using the activities for the same purposes.  
  
|Solution|Description|Main Files|  
|-|-|-|  
|CodedWorkflow|Sample client application that demonstrates how to invoke the collection activities programmatically.|**PrintCollection.cs**: helper activity to print out to the console every item in a collection.<br /><br /> **Program.cs**: programmatically builds a sequence activity that contains a series of collection activities, and executes it.|  
|DesignerWorkflow|Sample client application that demonstrates how to use the collection activities declaratively in the workflow designer.|**CollectionWorkflow.xaml**: a workflow created declaratively with the designer that uses the collection activities.<br /><br /> **PrintCollection.cs**: helper activity to print out to the console every item in a collection.<br /><br /> **Program.cs**: invokes the workflow described in CollectionWorkflow.xaml.|  
  
 In the demonstration, the item members of collection `Numbers` are printed on the console using a custom-defined activity called `PrintCollection`.  
  
#### To use this sample  
  
1.  Using [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)], open the Collection.sln solution file.  
  
2.  To build the solution, press CTRL+SHIFT+B.  
  
3.  To run the solution, press CTRL+F5.  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WF\Basic\Built-InActivities\Collection`