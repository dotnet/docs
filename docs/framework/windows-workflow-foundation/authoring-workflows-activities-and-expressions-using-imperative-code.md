---
title: "Authoring Workflows, Activities, and Expressions Using Imperative Code"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: cefc9cfc-2882-4eb9-8c94-7a6da957f2b2
caps.latest.revision: 16
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Authoring Workflows, Activities, and Expressions Using Imperative Code
A workflow definition is a tree of configured activity objects. This tree of activities can be defined many ways, including by hand-editing XAML or by using the Workflow Designer to produce XAML. Use of XAML, however, is not a requirement. Workflow definitions can also be created programmatically. This topic provides an overview of creating workflow definitions, activities, and expressions by using code. For examples of working with XAML workflows using code, see [Serializing Workflows and Activities to and from XAML](../../../docs/framework/windows-workflow-foundation/serializing-workflows-and-activities-to-and-from-xaml.md).  
  
## Creating Workflow Definitions  
 A workflow definition can be created by instantiating an instance of an activity type and configuring the activity object’s properties. For activities that do not contain child activities, this can be accomplished using a few lines of code.  
  
 [!code-csharp[CFX_WorkflowApplicationExample#47](../../../samples/snippets/csharp/VS_Snippets_CFX/cfx_workflowapplicationexample/cs/program.cs#47)]  
  
> [!NOTE]
>  The examples in this topic use <xref:System.Activities.WorkflowInvoker> to run the sample workflows. [!INCLUDE[crabout](../../../includes/crabout-md.md)] invoking workflows, passing arguments, and the different hosting choices that are available, see [Using WorkflowInvoker and WorkflowApplication](../../../docs/framework/windows-workflow-foundation/using-workflowinvoker-and-workflowapplication.md).  
  
 In this example, a workflow that consists of a single <xref:System.Activities.Statements.WriteLine> activity is created. The <xref:System.Activities.Statements.WriteLine> activity’s <xref:System.Activities.Statements.WriteLine.Text%2A> argument is set, and the workflow is invoked. If an activity contains child activities, the method of construction is similar. The following example uses a <xref:System.Activities.Statements.Sequence> activity that contains two <xref:System.Activities.Statements.WriteLine> activities.  
  
 [!code-csharp[CFX_WorkflowApplicationExample#48](../../../samples/snippets/csharp/VS_Snippets_CFX/cfx_workflowapplicationexample/cs/program.cs#48)]  
  
### Using Object Initializers  
 The examples in this topic use object initialization syntax. Object initialization syntax can be a useful way to create workflow definitions in code because it provides a hierarchical view of the activities in the workflow and shows the relationship between the activities. There is no requirement to use object initialization syntax when you programmatically create workflows. The following example is functionally equivalent to the previous example.  
  
 [!code-csharp[CFX_WorkflowApplicationExample#49](../../../samples/snippets/csharp/VS_Snippets_CFX/cfx_workflowapplicationexample/cs/program.cs#49)]  
  
 [!INCLUDE[crabout](../../../includes/crabout-md.md)] object initializers, see [How to: Initialize Objects without Calling a Constructor (C# Programming Guide)](http://go.microsoft.com/fwlink/?LinkId=161015) and [How to: Declare an Object by Using an Object Initializer](http://go.microsoft.com/fwlink/?LinkId=161016).  
  
### Working with Variables, Literal Values, and Expressions  
 When creating a workflow definition using code, be aware of what code executes as part of the creation of the workflow definition and what code executes as part of the execution of an instance of that workflow. For example, the following workflow is intended to generate a random number and write it to the console.  
  
 [!code-csharp[CFX_WorkflowApplicationExample#50](../../../samples/snippets/csharp/VS_Snippets_CFX/cfx_workflowapplicationexample/cs/program.cs#50)]  
  
 When this workflow definition code is executed, the call to `Random.Next` is made and the result is stored in the workflow definition as a literal value. Many instances of this workflow can be invoked, and all would display the same number. To have the random number generation occur during workflow execution, an expression must be used that is evaluated each time the workflow runs. In the following example, a Visual Basic expression is used with a <xref:Microsoft.VisualBasic.Activities.VisualBasicValue%601>.  
  
 [!code-csharp[CFX_WorkflowApplicationExample#51](../../../samples/snippets/csharp/VS_Snippets_CFX/cfx_workflowapplicationexample/cs/program.cs#51)]  
  
 The expression in the previous example could also be implemented using a <xref:Microsoft.CSharp.Activities.CSharpValue%601> and a C# expression.  
  
```csharp  
new Assign<int>  
{  
    To = n,  
    Value = new CSharpValue<int>("new Random().Next(1, 101)")  
}  
```  
  
 C# expressions must be compiled before the workflow containing them is invoked. If the C# expressions are not compiled, a <xref:System.NotSupportedException> is thrown when the workflow is invoked with a message similar to the following: `Expression Activity type 'CSharpValue`1' requires compilation in order to run.  Please ensure that the workflow has been compiled.` In most scenarios involving workflows created in Visual Studio the C# expressions are compiled automatically, but in some scenarios, such as code workflows, the C# expressions must be manually compiled. For an example of how to compile C# expressions, see the [Using C# expressions in code workflows](../../../docs/framework/windows-workflow-foundation/csharp-expressions.md#CodeWorkflows) section of the [C# Expressions](../../../docs/framework/windows-workflow-foundation/csharp-expressions.md) topic.  
  
 A <xref:Microsoft.VisualBasic.Activities.VisualBasicValue%601> represents an expression in Visual Basic syntax that can be used as an r-value in an expression, and a <xref:Microsoft.CSharp.Activities.CSharpValue%601> represents an expression in C# syntax that can be used as an r-value in an expression. These expressions are evaluated each time the containing activity is executed. The result of the expression is assigned to the workflow variable `n`, and these results are used by the next activity in the workflow. To access the value of the workflow variable `n` at runtime, the <xref:System.Activities.ActivityContext> is required. This can be accessed by using the following lambda expression.  
  
> [!NOTE]
>  Note that both of these code are examples are using C# as the programming language, but one uses a <xref:Microsoft.VisualBasic.Activities.VisualBasicValue%601> and one uses a <xref:Microsoft.CSharp.Activities.CSharpValue%601>. <xref:Microsoft.VisualBasic.Activities.VisualBasicValue%601> and <xref:Microsoft.CSharp.Activities.CSharpValue%601> can be used in both Visual Basic and C# projects. By default, expressions created in the workflow designer match the language of the hosting project. When creating workflows in code, the desired language is at the discretion of the workflow author.  
  
 In these examples the result of the expression is assigned to the workflow variable `n`, and these results are used by the next activity in the workflow. To access the value of the workflow variable `n` at runtime, the <xref:System.Activities.ActivityContext> is required. This can be accessed by using the following lambda expression.  
  
 [!code-csharp[CFX_WorkflowApplicationExample#52](../../../samples/snippets/csharp/VS_Snippets_CFX/cfx_workflowapplicationexample/cs/program.cs#52)]  
  
 [!INCLUDE[crabout](../../../includes/crabout-md.md)] lambda expressions, see [Lambda Expressions (C# Programming Guide)](http://go.microsoft.com/fwlink/?LinkID=152436) or [Lambda Expressions (Visual Basic)](http://go.microsoft.com/fwlink/?LinkID=152437).  
  
 Lambda expressions are not serializable to XAML format. If an attempt to serialize a workflow with lambda expressions is made, a <xref:System.Activities.Expressions.LambdaSerializationException> is thrown with the following message: "This workflow contains lambda expressions specified in code. These expressions are not XAML serializable. In order to make your workflow XAML-serializable, either use VisualBasicValue/VisualBasicReference or ExpressionServices.Convert(lambda). This will convert your lambda expressions into expression activities." To make this expression compatible with XAML, use <xref:System.Activities.Expressions.ExpressionServices> and <xref:System.Activities.Expressions.ExpressionServices.Convert%2A>, as shown in the following example.  
  
 [!code-csharp[CFX_WorkflowApplicationExample#53](../../../samples/snippets/csharp/VS_Snippets_CFX/cfx_workflowapplicationexample/cs/program.cs#53)]  
  
 A <xref:Microsoft.VisualBasic.Activities.VisualBasicValue%601> could also be used. Note that no lambda expression is required when using a Visual Basic expression.  
  
 [!code-csharp[CFX_WorkflowApplicationExample#54](../../../samples/snippets/csharp/VS_Snippets_CFX/cfx_workflowapplicationexample/cs/program.cs#54)]  
  
 At run time, Visual Basic expressions are compiled into LINQ expressions. Both of the previous examples are serializable to XAML, but if the serialized XAML is intended to be viewed and edited in the workflow designer, use <xref:Microsoft.VisualBasic.Activities.VisualBasicValue%601> for your expressions. Serialized workflows that use `ExpressionServices.Convert` can be opened in the designer, but the value of the expression will be blank. [!INCLUDE[crabout](../../../includes/crabout-md.md)] serializing workflows to XAML, see [Serializing Workflows and Activities to and from XAML](../../../docs/framework/windows-workflow-foundation/serializing-workflows-and-activities-to-and-from-xaml.md).  
  
#### Literal Expressions and Reference Types  
 Literal expressions are represented in workflows by the <xref:System.Activities.Expressions.Literal%601> activity. The following <xref:System.Activities.Statements.WriteLine> activities are functionally equivalent.  
  
```csharp  
new WriteLine  
{  
    Text = "Hello World."  
},  
new WriteLine  
{  
    Text = new Literal<string>("Hello World.")  
}  
```  
  
 It is invalid to initialize a literal expression with any reference type except <xref:System.String>. In the following example, an <xref:System.Activities.Statements.Assign> activity's <xref:System.Activities.Statements.Assign.Value%2A> property is initialized with a literal expression using a `List<string>`.  
  
```csharp  
new Assign  
{  
    To = new OutArgument<List<string>>(items),  
    Value = new InArgument<List<string>>(new List<string>())  
},  
```  
  
 When the workflow containing this activity is validated, the following validation error is returned: "Literal only supports value types and the immutable type System.String. The type System.Collections.Generic.List`1[System.String] cannot be used as a literal." If the workflow is invoked, an <xref:System.Activities.InvalidWorkflowException> is thrown that contains the text of the validation error. This is a validation error because creating a literal expression with a reference type does not create a new instance of the reference type for each instance of the workflow. To resolve this, replace the literal expression with one that creates and returns a new instance of the reference type.  
  
```csharp  
new Assign  
{  
    To = new OutArgument<List<string>>(items),  
    Value = new InArgument<List<string>>(new VisualBasicValue<List<string>>("New List(Of String)"))  
},  
```  
  
 [!INCLUDE[crabout](../../../includes/crabout-md.md)] expressions, see [Expressions](../../../docs/framework/windows-workflow-foundation/expressions.md).  
  
#### Invoking Methods on Objects using Expressions and the InvokeMethod Activity  
 The <xref:System.Activities.Expressions.InvokeMethod%601> activity can be used to invoke static and instance methods of classes in the .NET Framework. In a previous example in this topic, a random number was generated using the <xref:System.Random> class.  
  
 [!code-csharp[CFX_WorkflowApplicationExample#51](../../../samples/snippets/csharp/VS_Snippets_CFX/cfx_workflowapplicationexample/cs/program.cs#51)]  
  
 The <xref:System.Activities.Expressions.InvokeMethod%601> activity could also have been used to call the <xref:System.Random.Next%2A> method of the <xref:System.Random> class.  
  
```csharp  
new InvokeMethod<int>  
{  
    TargetObject = new InArgument<Random>(new VisualBasicValue<Random>("New Random()")),  
    MethodName = "Next",  
    Parameters =   
    {  
        new InArgument<int>(1),  
        new InArgument<int>(101)  
    },  
    Result = n  
}  
```  
  
 Since <xref:System.Random.Next%2A> is not a static method, an instance of the <xref:System.Random> class is supplied for the <xref:System.Activities.Expressions.InvokeMethod%601.TargetObject%2A> property. In this example a new instance is created using a Visual Basic expression, but it could also have been created previously and stored in a workflow variable. In this example, it would be simpler to use the <xref:System.Activities.Statements.Assign%601> activity instead of the <xref:System.Activities.Expressions.InvokeMethod%601> activity. If the method call ultimately invoked by either the <xref:System.Activities.Statements.Assign%601> or <xref:System.Activities.Expressions.InvokeMethod%601> activities is long running, <xref:System.Activities.Expressions.InvokeMethod%601> has an advantage since it has a <xref:System.Activities.Expressions.InvokeMethod%601.RunAsynchronously%2A> property. When this property is set to `true`, the invoked method will run asynchronously with regard to the workflow. If other activities are in parallel, they will not be blocked while the method is asynchronously executing. Also, if the method to be invoked has no return value, then <xref:System.Activities.Expressions.InvokeMethod%601> is the appropriate way to invoke the method.  
  
## Arguments and Dynamic Activities  
 A workflow definition is created in code by assembling activities into an activity tree and configuring any properties and arguments. Existing arguments can be bound, but new arguments cannot be added to activities. This includes workflow arguments passed to the root activity. In imperative code, workflow arguments are specified as properties on a new CLR type, and in XAML they are declared by using `x:Class` and `x:Member`. Because there is no new CLR type created when a workflow definition is created as a tree of in-memory objects, arguments cannot be added. However, arguments can be added to a <xref:System.Activities.DynamicActivity>. In this example, a <xref:System.Activities.DynamicActivity%601> is created that takes two integer arguments, adds them together, and returns the result. A <xref:System.Activities.DynamicActivityProperty> is created for each argument, and the result of the operation is assigned to the <xref:System.Activities.Activity%601.Result%2A> argument of the <xref:System.Activities.DynamicActivity%601>.  
  
 [!code-csharp[CFX_WorkflowApplicationExample#55](../../../samples/snippets/csharp/VS_Snippets_CFX/cfx_workflowapplicationexample/cs/program.cs#55)]  
  
 [!INCLUDE[crabout](../../../includes/crabout-md.md)] dynamic activities, see [Creating an Activity at Runtime](../../../docs/framework/windows-workflow-foundation/creating-an-activity-at-runtime-with-dynamicactivity.md).  
  
## Compiled Activities  
 Dynamic activities are one way to define an activity that contains arguments using code, but activities can also be created in code and compiled into types. Simple activities can be created that derive from <xref:System.Activities.CodeActivity>, and asynchronous activities that derive from <xref:System.Activities.AsyncCodeActivity>. These activities can have arguments, return values, and define their logic using imperative code. For examples of creating these types of activities, see [CodeActivity Base Class](../../../docs/framework/windows-workflow-foundation/workflow-activity-authoring-using-the-codeactivity-class.md) and [Creating Asynchronous Activities](../../../docs/framework/windows-workflow-foundation/creating-asynchronous-activities-in-wf.md).  
  
 Activities that derive from <xref:System.Activities.NativeActivity> can define their logic using imperative code and they can also contain child activities that define the logic. They also have full access to the features of the runtime such as creating bookmarks. For examples of creating a <xref:System.Activities.NativeActivity>-based activity, see [NativeActivity Base Class](../../../docs/framework/windows-workflow-foundation/nativeactivity-base-class.md), [How to: Create an Activity](../../../docs/framework/windows-workflow-foundation/how-to-create-an-activity.md), and the [Custom Composite using Native Activity](../../../docs/framework/windows-workflow-foundation/samples/custom-composite-using-native-activity.md) sample.  
  
 Activities that derive from <xref:System.Activities.Activity> define their logic solely through the use of child activities. These activities are typically created by using the workflow designer, but can also be defined by using code. In the following example, a `Square` activity is defined that derives from `Activity<int>`. The `Square` activity has a single <xref:System.Activities.InArgument%601> named `Value`, and defines its logic by specifying a <xref:System.Activities.Statements.Sequence> activity using the <xref:System.Activities.Activity.Implementation%2A> property. The <xref:System.Activities.Statements.Sequence> activity contains a <xref:System.Activities.Statements.WriteLine> activity and an <xref:System.Activities.Statements.Assign%601> activity. Together, these three activities implement the logic of the `Square` activity.  
  
```csharp  
class Square : Activity<int>  
{  
    [RequiredArgument]  
    public InArgument<int> Value { get; set; }  
  
    public Square()  
    {  
        this.Implementation = () => new Sequence  
        {  
            Activities =  
            {  
                new WriteLine  
                {  
                    Text = new InArgument<string>((env) => "Squaring the value: " + this.Value.Get(env))  
                },  
                new Assign<int>  
                {  
                    To = new OutArgument<int>((env) => this.Result.Get(env)),  
                    Value = new InArgument<int>((env) => this.Value.Get(env) * this.Value.Get(env))  
                }  
            }  
        };  
    }  
}  
```  
  
 In the following example, a workflow definition consisting of a single `Square` activity is invoked using <xref:System.Activities.WorkflowInvoker>.  
  
```csharp  
Dictionary<string, object> inputs = new Dictionary<string, object> {{ "Value", 5}};  
int result = WorkflowInvoker.Invoke(new Square(), inputs);  
Console.WriteLine("Result: {0}", result);  
```  
  
 When the workflow is invoked, the following output is displayed to the console:  
  
 **Squaring the value: 5**  
**Result: 25**
