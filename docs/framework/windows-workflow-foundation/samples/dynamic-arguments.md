---
title: "Dynamic Arguments"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 122ad479-d306-4602-a943-5aefe711329d
caps.latest.revision: 9
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Dynamic Arguments
This sample demonstrates how to implement an activity for which the arguments are defined by the activity consumer rather than the activity author. It does this by overriding the way the runtime constructs the activity’s metadata.  
  
## Sample details  
 Prior to execution, the runtime builds a description of an activity by examining the public members of the activity type and automatically declaring arguments, variables, child activities, and activity delegates as part of an activity’s metadata. It does this to ensure correct construction of a workflow as well as to manage run-time relationships and lifetime rules. Typically an activity author defines the arguments of an activity by specifying public members on the activity type that derive from <xref:System.Activities.Argument>. For each public member that derives from <xref:System.Activities.Argument>, the runtime creates a <xref:System.Activities.RuntimeArgument> and binds it to the user-provided argument set on that member. In some cases, however, the consumer of the activity provides some configuration that determines the set of arguments. An activity author overrides <xref:System.Activities.Activity.CacheMetadata%2A> to customize the way activity metadata is built, which includes the set of arguments associated with the activity.  
  
 This sample demonstrates how to build an argument list dynamically for an activity that invokes a method. The activity consumer specifies the type and the method name they want to invoke along with a collection of arguments to be passed to that method.  
  
> [!NOTE]
>  The purpose of this sample is to demonstrate how to override <xref:System.Activities.CodeActivity.CacheMetadata%2A> and how to use <xref:System.Activities.RuntimeArgument>. There are several caveats with respect to the kinds of methods that this activity can invoke. For example, it does not work with generics or parameter arrays. The <xref:System.Activities.Statements.InvokeMethod> activity that ships in.NET Framework handles these cases and more.  
  
 The `MethodInvoke` activity overrides <xref:System.Activities.CodeActivity.CacheMetadata%2A> and begins by creating a <xref:System.Activities.RuntimeArgument> to handle any result from the method invocation. It binds this <xref:System.Activities.RuntimeArgument> to the publicly settable <xref:System.Activities.OutArgument> named `Result`. If `MethodInvoke.Result` is `null`, the runtime automatically populates it with an <xref:System.Activities.OutArgument> configured with the default expression for its type. This behavior means an activity author never has to check whether an argument property is `null`.  
  
 Next, the <xref:System.Activities.CodeActivity.CacheMetadata%2A> override determines the `MethodInfo` it uses for invocation from the user-provided `MethodName` and `TargetType`. The `DetermineMethodInfo` method takes the <xref:System.Activities.CodeActivityMetadata> parameter passed to the <xref:System.Activities.CodeActivity.CacheMetadata%2A> override so that any configuration errors can be reported as validation errors. This is done by calling `metadata.AddValidationError`.  
  
 Once the `MethodInfo` has been set, the sample iterates over the `MethodInfo` parameters. For each parameter, it creates a <xref:System.Activities.RuntimeArgument> and binds it to the corresponding argument in the user-provided collection from the `Parameters` property. Finally, the collection of <xref:System.Activities.RuntimeArgument>s is associated with the activity by calling `metadata.SetArgumentsCollection`.  
  
 Note that argument resolution can be done using a <xref:System.Activities.RuntimeArgument>, as in the case of `resultArgument` or the user-provided argument, as in the case of the `Parameters` collection.  
  
#### To use this sample  
  
1.  Using [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)], open the DynamicArguments.sln file.  
  
2.  To build the solution, press CTRL+SHIFT+B.  
  
3.  To run the solution, press CTRL+F5.  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WF\Basic\CustomActivities\Code-Bodied\DynamicArguments`