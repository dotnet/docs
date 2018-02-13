---
title: "InvokeMethod"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 04988eb3-65f8-456d-b1bd-509f5d05a57c
caps.latest.revision: 6
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# InvokeMethod
This sample shows the different ways of using the <xref:System.Activities.Statements.InvokeMethod> activity to invoke methods of a class.  
  
 A method belongs to a class and represents a contained set of operations. The <xref:System.Activities.Statements.InvokeMethod> activity gives you the ability to call methods against objects or types, pass in parameters, and get the return value. Methods can be invoked synchronously or asynchronously.  
  
## Sample Details  
 This sample uses the <xref:System.Activities.Statements.InvokeMethod> activity to perform the following scenarios:  
  
1.  Invoke an instance method without parameters.  
  
2.  Invoke an instance method with two parameters (<xref:System.String> and <xref:System.Int32>).  
  
3.  Invoke an instance method with two parameters (<xref:System.String> and <xref:System.Int32>) and a parameter array of type <xref:System.String>[].  
  
4.  Invoke an instance method with two parameters of type <xref:System.Int32> and a result of type <xref:System.Int32>. In this scenario, the result value is bound to a variable and used in another activity. It is displayed in the console using the <xref:System.Activities.Statements.WriteLine> activity.  
  
5.  Invoke a static method with two parameters of type <xref:System.String> and <xref:System.Int32>.  
  
6.  Invoke an instance method with one generic parameter of type <xref:System.String>.  
  
7.  Invoke a static method with two generic parameters of type <xref:System.String> and <xref:System.Int32>.  
  
8.  Invoke an instance method that has one parameter passed by reference of type <xref:System.String>. In this scenario, the reference parameter is bound to a variable (`outParam`) and used in another activity. It is displayed on the console using the <xref:System.Activities.Statements.WriteLine> activity.  
  
9. Invoke an asynchronous instance method.  
  
10. Invoke two different methods on the same instance of an object using two <xref:System.Activities.Statements.InvokeMethod> activities.  
  
11. Store a value in an instance of an object.  
  
12. Retrieve a value from an instance of an object.  
  
## To use this sample  
 This sample is provided in two versions. The first version of this sample demonstrates the usage of <xref:System.Activities.Statements.InvokeMethod> through C# code using the [!INCLUDE[wf](../../../../includes/wf-md.md)] programming model and can be found under the CodedWorkflow\CS folder. The second version demonstrates the usage of <xref:System.Activities.Statements.InvokeMethod> using XAML and can be found under the DesignerWorkflow\CS folder.  
  
#### To run the coded workflow sample  
  
1.  Using [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)], open the InvokeMethodUsage.sln solution file in the CodedWorkflow\CS folder.  
  
2.  To build the solution, press CTRL+SHIFT+B.  
  
3.  To run the solution, press CTRL+F5.  
  
#### To run the designer workflow sample  
  
1.  Using [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)], open the InvokeMethodUsage.sln solution file in the DesignerWorkflow\CS folder.  
  
2.  To build the solution, press CTRL+SHIFT+B.  
  
3.  To run the solution, press CTRL+F5.  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WF\Basic\Built-InActivities\InvokeMethod`