---
title: "Variables and Arguments"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: d03dbe34-5b2e-4f21-8b57-693ee49611b8
caps.latest.revision: 15
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Variables and Arguments
In [!INCLUDE[wf](../../../includes/wf-md.md)], variables represent the storage of data and arguments represent the flow of data into and out of an activity. An activity has a set of arguments and they make up the signature of the activity. Additionally, an activity can maintain a list of variables to which a developer can add or remove variables during the design of a workflow. An argument is bound using an expression that returns a value.  
  
## Variables  
 Variables are storage locations for data. Variables are declared as part of the definition of a workflow. Variables take on values at runtime and these values are stored as part of the state of a workflow instance. A variable definition specifies the type of the variable and optionally, the name. The following code shows how to declare a variable, assign a value to it using an <xref:System.Activities.Statements.Assign%601> activity, and then display its value to the console using a <xref:System.Activities.Statements.WriteLine> activity.  
  
```csharp  
// Define a variable named "str" of type string.  
Variable<string> var = new Variable<string>  
{  
    Name = "str"  
};  
  
// Declare the variable within a Sequence, assign  
// a value to it, and then display it.  
Activity wf = new Sequence()  
{  
    Variables = { var },  
    Activities =  
    {  
        new Assign<string>  
        {  
            To = var,  
            Value = "Hello World."  
        },  
        new WriteLine  
        {  
            Text = var  
        }  
    }  
};  
  
WorkflowInvoker.Invoke(wf);  
```  
  
 A default value expression can optionally be specified as part of a variable declaration. Variables also can have modifiers. For example, if a variable is read-only then the read-only <xref:System.Activities.VariableModifiers> modifier can be applied. In the following example, a read-only variable is created that has a default value assigned.  
  
```csharp  
// Define a read-only variable with a default value.  
Variable<string> var = new Variable<string>  
{  
    Default = "Hello World.",  
    Modifiers = VariableModifiers.ReadOnly  
};  
```  
  
## Variable Scoping  
 The lifetime of a variable at runtime is equal to the lifetime of the activity that declares it. When an activity completes, its variables are cleaned up and can no longer be referenced.  
  
## Arguments  
 Activity authors use arguments to define the way data flows into and out of an activity. Each argument has a specified direction: <xref:System.Activities.ArgumentDirection.In>, <xref:System.Activities.ArgumentDirection.Out>, or <xref:System.Activities.ArgumentDirection.InOut>.  
  
 The workflow runtime makes the following guarantees about the timing of data movement into and out of activities:  
  
1.  When an activity starts executing, the values of all of its input and input/output arguments are calculated. For example, regardless of when <xref:System.Activities.Argument.Get%2A> is called, the value returned is the one calculated by the runtime prior to its invocation of `Execute`.  
  
2.  When <xref:System.Activities.InOutArgument%601.Set%2A> is called, the runtime sets the value immediately.  
  
3.  Arguments can optionally have their <xref:System.Activities.Argument.EvaluationOrder%2A> specified. <xref:System.Activities.Argument.EvaluationOrder%2A> is a zero-based value that specifies the order in which the argument is evaluated. By default, the evaluation order of the argument is unspecified and is equal to the <xref:System.Activities.Argument.UnspecifiedEvaluationOrder> value. Set <xref:System.Activities.Argument.EvaluationOrder%2A> to a value greater or equal to zero to specify an evaluation order for this argument. [!INCLUDE[wf2](../../../includes/wf2-md.md)] evaluates arguments with a specified evaluation order in ascending order. Note that arguments with an unspecified evaluation order are evaluated before those with a specified evaluation order.  
  
 An activity author can use a strongly-typed mechanism for exposing its arguments. This is accomplished by declaring properties of type <xref:System.Activities.InArgument%601>, <xref:System.Activities.OutArgument%601>, and <xref:System.Activities.InOutArgument%601>. This allows an activity author to establish a specific contract about the data going into and out of an activity.  
  
### Defining the Arguments on an Activity  
 Arguments can be defined on an activity by specifying properties of type <xref:System.Activities.InArgument%601>, <xref:System.Activities.OutArgument%601>, and <xref:System.Activities.InOutArgument%601>. The following code shows how to define the arguments for a `Prompt` activity that takes in a string to display to the user and returns a string that contains the user's response.  
  
```csharp  
public class Prompt : Activity  
{  
    public InArgument<string> Text { get; set; }  
    public OutArgument<string> Response { get; set; }  
    // Rest of activity definition omitted.  
}  
```  
  
> [!NOTE]
>  Activities that return a single value can derive from <xref:System.Activities.Activity%601>, <xref:System.Activities.NativeActivity%601>, or <xref:System.Activities.CodeActivity%601>. These activities have a well-defined <xref:System.Activities.OutArgument%601> named <xref:System.Activities.Activity%601.Result%2A> that contains the return value of the activity.  
  
### Using Variables and Arguments in Workflows  
 The following example shows how variables and arguments are used in a workflow. The workflow is a sequence that declares three variables: `var1`, `var2`, and `var3`. The first activity in the workflow is an `Assign` activity that assigns the value of variable `var1` to the variable `var2`. This is followed by a `WriteLine` activity that prints the value of the `var2` variable. Next is another `Assign` activity that assigns the value of variable `var2` to the variable `var3`. Finally there is another `WriteLine` activity that prints the value of the `var3` variable. The first `Assign` activity uses `InArgument<string>` and `OutArgument<string>` objects that explicitly represent the bindings for the activity's arguments. `InArgument<string>` is used for <xref:System.Activities.Statements.Assign.Value%2A> because the value is flowing into the <xref:System.Activities.Statements.Assign%601> activity through its <xref:System.Activities.Statements.Assign.Value%2A> argument, and `OutArgument<string>` is used for <xref:System.Activities.Statements.Assign.To%2A> because the value is flowing out of the <xref:System.Activities.Statements.Assign.To%2A> argument into the variable. The second `Assign` activity accomplishes the same thing with more compact but equivalent syntax that uses implicit casts. The `WriteLine` activities also use the compact syntax.  
  
```csharp  
// Declare three variables; the first one is given an initial value.  
Variable<string> var1 = new Variable<string>()  
{  
    Default = "one"  
};  
Variable<string> var2 = new Variable<string>();  
Variable<string> var3 = new Variable<string>();  
  
// Define the workflow  
Activity wf = new Sequence  
{  
    Variables = { var1, var2, var3 },  
    Activities =   
    {  
        new Assign<string>()  
        {  
            Value = new InArgument<string>(var1),  
            To = new OutArgument<string>(var2)  
        },  
        new WriteLine() { Text = var2 },  
        new Assign<string>()  
        {  
            Value = var2,  
            To = var3  
        },  
        new WriteLine() { Text = var3 }  
    }  
};  
  
WorkflowInvoker.Invoke(wf);  
```  
  
### Using Variables and Arguments in Code-Based Activities  
 The previous examples show how to use arguments and variables in workflows and declarative activities. Arguments and variables are also used in code-based activities. Conceptually the usage is very similar. Variables represent data storage within the activity, and arguments represent the flow of data into or out of the activity, and are bound by the workflow author to other variables or arguments in the workflow that represent where the data flows to or from. To get or set the value of a variable or argument in an activity, an activity context must be used that represents the current execution environment of the activity. This is passed into the <xref:System.Activities.CodeActivity%601.Execute%2A> method of the activity by the workflow runtime. In this example, a custom `Add` activity is defined that has two <xref:System.Activities.ArgumentDirection.In> arguments. To access the value of the arguments, the <xref:System.Activities.Argument.Get%2A> method is used and the context that was passed in by the workflow runtime is used.  
  
```csharp  
public sealed class Add : CodeActivity<int>  
{  
    [RequiredArgument]  
    public InArgument<int> Operand1 { get; set; }  
  
    [RequiredArgument]  
    public InArgument<int> Operand2 { get; set; }  
  
    protected override int Execute(CodeActivityContext context)  
    {  
        return Operand1.Get(context) + Operand2.Get(context);  
    }  
}  
```  
  
 [!INCLUDE[crabout](../../../includes/crabout-md.md)] working with arguments, variables, and expressions in code, see [Authoring Workflows, Activities, and Expressions Using Imperative Code](../../../docs/framework/windows-workflow-foundation/authoring-workflows-activities-and-expressions-using-imperative-code.md) and [Required Arguments and Overload Groups](../../../docs/framework/windows-workflow-foundation/required-arguments-and-overload-groups.md).
