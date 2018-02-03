---
title: "Custom Activity to Switch on a Range of Values"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 441e0a17-421f-430c-ba97-59e4cc6c88e3
caps.latest.revision: 10
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Custom Activity to Switch on a Range of Values
This sample demonstrates how to create a custom activity that extends the use of a <xref:System.Activities.Statements.Switch%601>. A conventional <xref:System.Activities.Statements.Switch%601> statement allows switching based upon a single value. But, there are business scenarios where an activity must switch based upon a range of values. For example, an activity might execute one action when the value being switched upon is between 1 and 5, another action when the value is between 6 and 10, and a default action for all other values. This custom activity enables exactly that scenario.  
  
## The SwitchRange Activity  
 The `SwitchRange` activity schedules a child activity when the result value of its expression is included within the range of one of its `Cases`.  
  
 The following code example is a custom activity that switches based upon a range of values.  
  
```csharp  
public sealed class SwitchRange<T> : NativeActivity where T : IComparable  
{  
   [RequiredArgument]  
   [DefaultValue(null)]  
   public InArgument<T> Expression { get; set; }  
  
   public IList<CaseRange<T>> Cases  
  
   [DefaultValue(null)]  
   public Activity Default { get; set; }}  
}  
```  
  
|Property|Description|  
|-|-|  
|Expression|This is the expression to be evaluated and compared against the ranges in the Cases list. The result of the expression is of type T.|  
|Cases|Each case consists of a range (From and To) and an activity (Body). The expression is evaluated and compared against the ranges. If the result of the expression is within the range of one of the cases, the corresponding activity is executed.|  
|Default|The activity that is executed when no case is matched. When set to `null`, no action is taken.|  
  
## CaseRange Class  
 The `CaseRange` class represents a range within a `SwitchRange` activity. Every instance of `CaseRange` contains a range (composed of a `From` and a `To`) and a `Body` activity that is scheduled if the expression in the `SwitchRange` is evaluated within the range.  
  
 The following code example is the definition for the `CaseRange` class.  
  
```  
public class CaseRange<T> where T : IComparable  
{  
    public T From { get; set; }  
  
    public T To { get; set; }  
  
    public Activity Action { get; set; }  
}  
```  
  
> [!NOTE]
>  Both the `SwitchRange` and `CaseRange` classes, which are defined in the sample are generic classes that can work with any type that implements `IComparable`, like the <xref:System.Activities.Statements.Switch%601> class.  
  
## Sample Usage  
 The following code example demonstrates how to use the `SwitchRange` activity.  
  
```csharp  
Activity SwitchRange = new SwitchRange<int>  
{  
    Expression = new InArgument<int>(value),  
    Cases =   
    {  
        new CaseRange<int>                      
        {  
            From = 1,  
            To = 5,  
            Action = new WriteLine  
            {  
                Text = "Case 1-5 selected",  
            }  
        },  
        new CaseRange<int>  
        {  
            From = 6,  
            To = 10,  
            Action = new WriteLine  
            {  
                Text = "Case 6-10 selected",  
            }  
        }  
    },  
    Default = new WriteLine { Text = "Default Case selected" }  
};  
```  
  
#### To use this sample  
  
1.  Using [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)], open the SwitchRange.sln solution file.  
  
2.  To build the solution, press CTRL+SHIFT+B.  
  
3.  To run the solution, press CTRL+F5.  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WF\Scenario\ActivityLibrary\SwitchRange`