---
title: "Using the InvokeMethod Activity"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: b6643550-d043-4ac7-8069-9c55ebbb4233
caps.latest.revision: 7
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Using the InvokeMethod Activity
This sample demonstrates how to use the <!--zz <xref:System.Activities.Statements.InvokeMethod%601> -->[<code>System.Activities.Statements.InvokeMethod\`1</code>](https://msdn.microsoft.com/library/dd647677.aspx) activity to invoke public methods in public classes. The <!--zz <xref:System.Activities.Statements.InvokeMethod%601> -->[<code>System.Activities.Statements.InvokeMethod\`1</code>](https://msdn.microsoft.com/library/dd647677.aspx) activity allows a workflow to call methods against objects, pass in parameters, get the return value, specify types for generic methods, and specify whether the method is synchronous or asynchronous. 
  
There is a non-generic version of the <xref:System.Activities.Statements.InvokeMethod> activity where the return value is set to the <xref:System.Activities.Statements.InvokeMethod.Result%2A> property and a generic version of the <!--zz <xref:System.Activities.Statements.InvokeMethod%601> -->[<code>System.Activities.Statements.InvokeMethod\`1</code>](https://msdn.microsoft.com/library/dd647677.aspx) activity where the return value is returned through the <!--zz <xref:System.Activities.Statements.InvokeMethod.Result%601.Result%2A> -->[<code>System.Activities.Statements.InvokeMethod\`1.Result</code>](https://msdn.microsoft.com/library/dd987724.aspx) property of type `TResult`. 
  
 This sample demonstrates how to call various method types. The following list details the method types demonstrated in this sample:  
  
-   Invoke an instance method without parameters.  
  
-   Invoke an instance method with two parameters (System.String and System.Int32).  
  
-   Invoke an instance method with two parameters (System.String and System.Int32) and a parameter array of type System.String[].  
  
-   Invoke an instance method with two parameters (two System.Int32 numbers) and a result of type System.Int32.  
  
     The return value is bound to a variable and printed to the console using the <xref:System.Activities.Statements.WriteLine> activity.  
  
-   Invoke a static method with two parameters (System.String and System.Int32).  
  
-   Invoke an instance method with one generic parameter (System.String).  
  
-   Invoke a static method with two generic parameters (System.String and System.Int32).  
  
-   Invoke an instance method that has one parameter passed by reference (System.String).  
  
     The referenced parameter is bound to a variable and printed to the console using the <xref:System.Activities.Statements.WriteLine> activity.  
  
-   Invoke an asynchronous instance method.  
  
## To use this sample  
  
1.  Using [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)], open the InvokeMethodUsage.sln solution file.  
  
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