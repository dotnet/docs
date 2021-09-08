---
description: "Learn more about: Non-generic ParallelForEach"
title: "Non-generic ParallelForEach"
ms.date: "03/30/2017"
ms.assetid: de17e7a2-257b-48b3-91a1-860e2e9bf6e6
---
# Non-generic ParallelForEach

[!INCLUDE[netfx_current_long](../../../../includes/netfx-current-long-md.md)] ships in its toolbox a set of Control Flow activities, including <xref:System.Activities.Statements.ParallelForEach%601>, which allows iterating through <xref:System.Collections.Generic.IEnumerable%601> collections.

<xref:System.Activities.Statements.ParallelForEach%601> requires its <xref:System.Activities.Statements.ParallelForEach%601.Values%2A> property to be of type  <xref:System.Collections.Generic.IEnumerable%601>. This precludes users from iterating over data structures that implement <xref:System.Collections.Generic.IEnumerable%601> interface (for example, <xref:System.Collections.ArrayList>). The non-generic version of <xref:System.Activities.Statements.ParallelForEach%601> overcomes this requirement, at the expense of more run-time complexity for ensuring the compatibility of the types of the values in the collection.

The [NonGenericParallelForEach sample](https://github.com/dotnet/samples/tree/main/framework/windows-workflow-foundation/scenario/ActivityLibrary/NonGenericParallelForEach/CS) shows how to implement a non-generic <xref:System.Activities.Statements.ParallelForEach%601> activity and its designer. This activity can be used to iterate through <xref:System.Collections.ArrayList>.

## ParallelForEach activity

The C#/Visual Basic `foreach` statement enumerates the elements of a collection, executing an embedded statement for each element of the collection. The WF equivalent activities are <xref:System.Activities.Statements.ForEach%601> and <xref:System.Activities.Statements.ParallelForEach%601>. The <xref:System.Activities.Statements.ForEach%601> activity contains a list of values and a body. At runtime, the list is iterated and the body is executed for each value in the list.

<xref:System.Activities.Statements.ParallelForEach%601> has a <xref:System.Activities.Statements.ParallelForEach%601.CompletionCondition%2A>, so that the <xref:System.Activities.Statements.ParallelForEach%601> activity could complete early if the evaluation of the <xref:System.Activities.Statements.ParallelForEach%601.CompletionCondition%2A> returns `true`. The <xref:System.Activities.Statements.ParallelForEach%601.CompletionCondition%2A> is evaluated after each iteration is completed.

For most cases, the generic version of the activity should be the preferred solution, because it covers most of the scenarios in which it is used and provides type checking at compile time. The non-generic version can be used for iterating through types that implement the non-generic <xref:System.Collections.IEnumerable> interface.

## Class definition

The following code example shows the definition of a non-generic `ParallelForEach` activity is.

```csharp
[ContentProperty("Body")]
public class ParallelForEach : NativeActivity
{
    [RequiredArgument]
    [DefaultValue(null)]
    InArgument<IEnumerable> Values { get; set; }

    [DefaultValue(null)]
    [DependsOn("Values")]
    public Activity<bool> CompletionCondition
    [DefaultValue(null)]
    [DependsOn("CompletionCondition")]
    ActivityAction<object> Body { get; set; }
}
```

Body (optional)\
The <xref:System.Activities.ActivityAction> of type <xref:System.Object>, which is executed for each element in the collection. Each individual element is passed into the Body through its Argument property.

Values (optional)\
The collection of elements that are iterated over. Ensuring that all elements of the collection are of compatible types is done at run-time.

CompletionCondition (optional)\
The <xref:System.Activities.Statements.ParallelForEach%601.CompletionCondition%2A> property is evaluated after any iteration completes. If it evaluates to `true`, then the scheduled pending iterations are canceled. If this property is not set, all activities in the Branches collection execute until completion.

## Example of using ParallelForEach

The following code demonstrates how to use the ParallelForEach activity in an application.

```csharp
string[] names = { "bill", "steve", "ray" };

DelegateInArgument<object> iterationVariable = new DelegateInArgument<object>() { Name = "iterationVariable" };

Activity sampleUsage =
    new ParallelForEach
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

## ParallelForEach designer

The activity designer for the sample is similar in appearance to the designer provided for the built-in <xref:System.Activities.Statements.ParallelForEach%601> activity. The designer appears in the toolbox in the **Samples**, **Non-Generic Activities** category. The designer is named **ParallelForEachWithBodyFactory** in the toolbox, because the activity exposes an <xref:System.Activities.Presentation.IActivityTemplateFactory> in the toolbox that creates the activity with a properly configured <xref:System.Activities.ActivityAction>.

```csharp
public sealed class ParallelForEachWithBodyFactory : IActivityTemplateFactory
{
    public Activity Create(DependencyObject target)
    {
        return new Microsoft.Samples.Activities.Statements.ParallelForEach()
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

## To run the sample

1. Set the project of your choice as the startup project of the solution.

    1. **CodeTestClient** shows how to use the activity using code.

    2. **DesignerTestClient** shows how to use the activity within the designer.

2. Build and run the project.
