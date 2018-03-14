---
title: "RangeEnumeration Activity"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: ca5b78f4-94fa-4aa7-830d-26039ac422c8
caps.latest.revision: 6
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# RangeEnumeration Activity
This sample demonstrates how to create a custom activity that iterates over a collection of numbers.The following table details the main files included in the sample.  
  
|File name|Description|  
|---------------|-----------------|  
|RangeEnumeration.cs|Defines a custom activity named `RangeEnumeration` that overrides the <xref:System.Activities.NativeActivity> class and loops through a series of numbers.|  
|RangeEnumerationSample.cs|A client application that uses the `RangeEnumeration` activity to iterate over a collection of numbers.|  
  
 The following table details the properties of the `RangeEnumeration` activity.  
  
|Property|Description|  
|--------------|-----------------|  
|Start|The integer to start the loop from.|  
|Stop|The integer to stop the loop at.|  
|Step|Specifies how much to iterate each time.|  
|Body|Specifies the code to execute during each iteration.|  
  
#### To use this sample  
  
1.  Using [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)], open the RangeEnumeration.sln solution file.  
  
2.  To build the solution, press CTRL+SHIFT+B.  
  
3.  To run the solution, press CTRL+F5.  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WF\Scenario\ActivityLibrary\RangeEnumeration`