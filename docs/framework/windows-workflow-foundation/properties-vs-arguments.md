---
title: "Properties vs. Arguments"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 14651389-4a49-4cbb-9ddf-c83fdc155df1
caps.latest.revision: 3
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Properties vs. Arguments
There are several options available for passing data into an activity. In addition to using <xref:System.Activities.InArgument>, activities can also be developed that receive data using either standard CLR Properties or public <xref:System.Activities.ActivityAction> properties. This topic discusses how to select the appropriate method type.  
  
## Using CLR Properties  
 When passing data into an activity, CLR properties (that is, public methods that use Get and Set routines to expose data) are the option that has the most restrictions. The value of a parameter passed into a CLR property must be known when the solution is compiled; this value will be the same for every instance of the workflow. In this way, a value passed into a CLR property is similar to a constant defined in code; this value can’t change for the life of the activity, and can’t be changed for different instances of the activity. <xref:System.Activities.Expressions.InvokeMethod%601.MethodName%2A> is an example of a CLR property exposed by an activity; the method name that the activity calls can’t be changed based on runtime conditions, and will be the same for every instance of the activity.  
  
## Using Arguments  
 Arguments should be used when data is only evaluated once during the lifetime of the activity; that is, its value will not change during the lifetime of the activity, but the value can be different for different instances of the activity. <xref:System.Activities.Statements.If.Condition%2A> is an example of a value that gets evaluated once; therefore it is defined as an argument. <xref:System.Activities.Statements.WriteLine.Text%2A> is another example of a method that should be defined as an argument, since it is only evaluated once during the activity’s execution, but it can be different for different instances of the activity.  
  
## Using ActivityAction  
 When data needs to be evaluated multiple times during the lifetime of an activity’s execution, an <xref:System.Activities.ActivityAction> should be used. For example, the <xref:System.Activities.Statements.While.Condition%2A> property is evaluated for each iteration of the <xref:System.Activities.Statements.While> loop. If an <xref:System.Activities.InArgument> were used for this purpose, the loop would never exit, since the argument would not be reevaluated for each iteration, and would always return the same result.
