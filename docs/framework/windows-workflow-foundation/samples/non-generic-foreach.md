---
title: "Non-Generic ForEach"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 576cd07a-d58d-4536-b514-77bad60bff38
caps.latest.revision: 12
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Non-Generic ForEach
[!INCLUDE[netfx_current_long](../../../../includes/netfx-current-long-md.md)] ships in its toolbox a set of Control Flow activities, including <xref:System.Activities.Statements.ForEach%601>, which allows iterating through <!--zz <xref:System.Collections.IEnumerable%601> --> `System.Collections.IEnumerable` collections.  
  
 <xref:System.Activities.Statements.ForEach%601> requires its <xref:System.Activities.Statements.ForEach%601.Values%2A> property to be of type <!--zz <xref:System.Collections.IEnumerable%601> --> `System.Collections.IEnumerable`. This precludes users from iterating over data structures that implement <!--zz <xref:System.Collections.IEnumerable%601> --> `System.Collections.IEnumerable` interface (for example, <xref:System.Collections.ArrayList>). The non-generic version of <xref:System.Activities.Statements.ForEach%601> overcomes this requirement, at the expense of more run-time complexity for ensuring the compatibility of the types of the values in the collection.  
  
 This sample shows how to implement a non-generic <xref:System.Activities.Statements.ForEach%601> activity and its designer. This activity can be used to iterate through <xref:System.Collections.ArrayList>.  
  
## ForEach Activity  
 The C#/VB `foreach` statement enumerates the elements of a collection, executing an embedded statement for each element of the collection. The [!INCLUDE[wf1](../../../../includes/wf1-md.md)] equivalent activities of `foreach` are <xref:System.Activities.Statements.ForEach%601> and <xref:System.Activities.Statements.ParallelForEach%601>. The <xref:System.Activities.Statements.ForEach%601> activity contains a list of values and a body. At runtime, the list is iterated and the body is executed for each value in the list.  
  
 For most cases, the generic version of the activity should be the preferred solution, because it covers most of the scenarios in which it would be used, and provides type checking at compile time. The non-generic version can be used for iterating through types that implement the non-generic <xref:System.Collections.IEnumerable> interface.  
  
## Class Definition  
 The following code example shows the definition of a non-generic `ForEach` activity.  
  
```  
[ContentProperty("Body")]  
public class ForEach : NativeActivity  
{  
    [RequiredArgument]  
    [DefaultValue(null)]  
    InArgument<IEnumerable> Values { get; set; }  
  
    [DefaultValue(null)]  
    [DependsOn("Values")]  
    ActivityAction<object> Body { get; set; }   
}  
```  
  
 Body (optional)  
 The <xref:System.Activities.ActivityAction> of type <xref:System.Object>, which is executed for each element in the collection. Each individual element is passed into the Body through its `Argument` property.  
  
 Values (optional)  
 The collection of elements that are iterated over. Ensuring that all elements of the collection are of compatible types is done at run-time.  
  
## Example of Using ForEach  
 The following code demonstrates how to use the ForEach activity in an application.  
  
```  
string[] names = { "bill", "steve", "ray" };  
  
DelegateInArgument<object> iterationVariable = new DelegateInArgument<object>() { Name = "iterationVariable" };  
  
Activity sampleUsage =  
    new ForEach  
    {  
       Values = new InArgument<IEnumerable>(c=> names),  
       Body = new ActivityAction<object>   
       {                          
           Argument = iterationVariable,  
           Handler = new WriteLine  
           {  
               Text = new InArgument<string>(env => string.Format("Hello {0}",                                                               iterationVariable.Get(env)))  
           }  
       }  
   };  
```  
  
|Condition|Message|Severity|Exception Type|  
|---------------|-------------|--------------|--------------------|  
|Values is `null`|Value for a required activity argument 'Values' was not supplied.|Error|<xref:System.InvalidOperationException>|  
  
## ForEach Designer  
 The activity designer for the sample is similar in appearance to the designer provided for the built-in <xref:System.Activities.Statements.ForEach%601> activity. The designer appears in the toolbox in the **Samples**, **Non-Generic Activities** category. The designer is named **ForEachWithBodyFactory** in the toolbox, because the activity exposes an <xref:System.Activities.Presentation.IActivityTemplateFactory> in the toolbox, which creates the activity with a properly configured <xref:System.Activities.ActivityAction>.  
  
```  
public sealed class ForEachWithBodyFactory : IActivityTemplateFactory  
{  
    public Activity Create(DependencyObject target)  
    {  
        return new Microsoft.Samples.Activities.Statements.ForEach()  
        {  
            Body = new ActivityAction<object>()  
            {  
                Argument = new DelegateInArgument<object>()  
                {  
                    Name = "item"  
                }  
            }  
        };  
    }  
}  
```  
  
#### To run this sample  
  
1.  Set the project of your choice as the start-up project of the solution:  
  
    1.  **CodeTestClient** shows how to use the activity using code.  
  
    2.  **DesignerTestClient** shows how to use the activity within the designer.  
  
2.  Build and run the project.  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WF\Scenario\ActivityLibrary\NonGenericForEach`
