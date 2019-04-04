---
title: "Lambda expressions - C# Programming Guide"
ms.custom: seodec18
ms.date: 03/14/2019
helpviewer_keywords: 
  - "lambda expressions [C#]"
  - "outer variables [C#]"
  - "statement lambda [C#]"
  - "expression lambda [C#]"
  - "expressions [C#], lambda"
ms.assetid: 57e3ba27-9a82-4067-aca7-5ca446b7bf93
---
# Lambda expressions (C# Programming Guide)

A *lambda expression* is a block of code (an expression or a statement block) that is treated as an object. It can be passed as an argument to methods, and it can also be returned by method calls. Lambda expressions are used extensively for:

- Passing the code that is to be executed to asynchronous methods, such as <xref:System.Threading.Tasks.Task.Run(System.Action)?displayProperty=nameWithType>.

- Writing [LINQ query expressions](../../linq/index.md).

- Creating [expression trees](../concepts/expression-trees/index.md).

Lambda expressions are code that can be represented either as a delegate, or as an expression tree that compiles to a delegate. The specific delegate type of a lambda expression depends on its parameters and return value. Lambda expressions that don't return a value correspond to a specific `Action` delegate, depending on its number of parameters. Lambda expressions that return a value correspond to a specific `Func` delegate, depending on its number of parameters. For example, a lambda expression that has two parameters but returns no value corresponds to an <xref:System.Action%602> delegate. A lambda expression that has one parameter and returns a value corresponds to <xref:System.Func%602> delegate.

A lambda expression uses `=>`, the [lambda declaration operator](../../language-reference/operators/lambda-operator.md), to separate the lambda's parameter list from its executable code. To create a lambda expression, you specify input parameters (if any) on the left side of the lambda operator, and you put the expression or statement block on the other side. For example, the single-line lambda expression `x => x * x` specifies a parameter that’s named `x` and returns the value of `x` squared. You can assign this expression to a delegate type, as the following example shows:

[!code-csharp-interactive[lambda is delegate](~/samples/snippets/csharp/programming-guide/lambda-expressions/Introduction.cs#Delegate)]

You also can assign a lambda expression to an expression tree type:

[!code-csharp-interactive[lambda is expression tree](~/samples/snippets/csharp/programming-guide/lambda-expressions/Introduction.cs#ExpressionTree)]

Or you can pass it directly as a method argument:

[!code-csharp-interactive[lambda is argument](~/samples/snippets/csharp/programming-guide/lambda-expressions/Introduction.cs#Argument)]

When you use method-based syntax to call the <xref:System.Linq.Enumerable.Select%2A?displayProperty=nameWithType> method in the <xref:System.Linq.Enumerable?displayProperty=nameWithType> class (as you do in LINQ to Objects and LINQ to XML) the parameter is a delegate type <xref:System.Func%602?displayProperty=nameWithType>. A lambda expression is the most convenient way to create that delegate. When you call the <xref:System.Linq.Queryable.Select%2A?displayProperty=nameWithType> method in the <xref:System.Linq.Queryable?displayProperty=nameWithType> class (as you do in LINQ to SQL) the parameter type is an expression tree type [`Expression<Func<TSource,TResult>>`](<xref:System.Linq.Expressions.Expression%601>). Again, a lambda expression is just a very concise way to construct that expression tree. The lambdas allow the `Select` calls to look similar although in fact the type of object created from the lambda is different.

All restrictions that apply to [anonymous methods](anonymous-methods.md) also apply to lambda expressions.
  
## Expression lambdas

A lambda expression with an expression on the right side of the `=>` operator is called an *expression lambda*. Expression lambdas are used extensively in the construction of [expression trees](../concepts/expression-trees/index.md). An expression lambda returns the result of the expression and takes the following basic form:

```csharp
(input-parameters) => expression
```

The parentheses are optional only if the lambda has one input parameter; otherwise they are required.

Specify zero input parameters with empty parentheses:  

[!code-csharp[zero parameters](~/samples/snippets/csharp/programming-guide/lambda-expressions/ExpressionAndStatementLambdas.cs#ZeroParameters)]

Two or more input parameters are separated by commas enclosed in parentheses:

[!code-csharp[two parameters](~/samples/snippets/csharp/programming-guide/lambda-expressions/ExpressionAndStatementLambdas.cs#TwoParameters)]

Sometimes it's impossible for the compiler to infer the input types. You can specify the types explicitly as shown in the following example:

[!code-csharp[explicitly typed parameters](~/samples/snippets/csharp/programming-guide/lambda-expressions/ExpressionAndStatementLambdas.cs#ExplicitlyTypedParameters)]

Input parameter types must be all explicit or all implicit; otherwise, a [CS0748](../../misc/cs0748.md) compiler error occurs.

The body of an expression lambda can consist of a method call. However, if you are creating expression trees that are evaluated outside the context of the .NET common language runtime, such as in SQL Server, you should not use method calls in lambda expressions. The methods will have no meaning outside the context of the .NET common language runtime.

## Statement lambdas

A statement lambda resembles an expression lambda except that the statement(s) is enclosed in braces:

```csharp  
(input-parameters) => { statement; }
```

The body of a statement lambda can consist of any number of statements; however, in practice there are typically no more than two or three.

[!code-csharp-interactive[statement lambda](~/samples/snippets/csharp/programming-guide/lambda-expressions/ExpressionAndStatementLambdas.cs#StatementLambda)]

Statement lambdas, like anonymous methods, cannot be used to create expression trees.
  
## Async lambdas

You can easily create lambda expressions and statements that incorporate asynchronous processing by using the [async](../../language-reference/keywords/async.md) and [await](../../language-reference/keywords/await.md) keywords. For example, the following Windows Forms example contains an event handler that calls and awaits an async method, `ExampleMethodAsync`.

```csharp
public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        button1.Click += button1_Click;
    }

    private async void button1_Click(object sender, EventArgs e)
    {
        await ExampleMethodAsync();
        textBox1.Text += "\r\nControl returned to Click event handler.\n";
    }

    private async Task ExampleMethodAsync()
    {
        // The following line simulates a task-returning asynchronous process.
        await Task.Delay(1000);
    }
}
```

You can add the same event handler by using an async lambda. To add this handler, add an `async` modifier before the lambda parameter list, as the following example shows:

```csharp
public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        button1.Click += async (sender, e) =>
        {
            await ExampleMethodAsync();
            textBox1.Text += "\r\nControl returned to Click event handler.\n";
        };
    }

    private async Task ExampleMethodAsync()
    {
        // The following line simulates a task-returning asynchronous process.
        await Task.Delay(1000);
    }
}
```

For more information about how to create and use async methods, see [Asynchronous Programming with async and await](../concepts/async/index.md).

## Lambda expressions and tuples

Starting with C# 7.0, the C# language provides built-in support for [tuples](../../tuples.md). You can provide a tuple as an argument to a lambda expression, and your lambda expression can also return a tuple. In some cases, the C# compiler uses type inference to determine the types of tuple components.

You define a tuple by enclosing a comma-delimited list of its components in parentheses. The following example uses tuple with three components to pass a sequence of numbers to a lambda expression, which doubles each value and returns a tuple with three components that contains the result of the multiplications.

[!code-csharp-interactive[lambda and tuples](~/samples/snippets/csharp/programming-guide/lambda-expressions/LambdasAndTuples.cs#WithoutComponentName)]

Ordinarily, the fields of a tuple are named `Item1`, `Item2`, etc. You can, however, define a tuple with named components, as the following example does.

[!code-csharp-interactive[lambda and named tuples](~/samples/snippets/csharp/programming-guide/lambda-expressions/LambdasAndTuples.cs#WithComponentName)]

For more information about C# tuples, see [C# tuple types](../../tuples.md).

## Lambdas with the standard query operators

LINQ to Objects, among other implementations, have an input parameter whose type is one of the <xref:System.Func%601> family of generic delegates. These delegates use type parameters to define the number and type of input parameters, and the return type of the delegate. `Func` delegates are very useful for encapsulating user-defined expressions that are applied to each element in a set of source data. For example, consider the <xref:System.Func%602> delegate type:  

```csharp
public delegate TResult Func<in T, out TResult>(T arg)
```

The delegate can be instantiated as a `Func<int, bool>` instance where `int` is an input parameter and `bool` is the return value. The return value is always specified in the last type parameter. For example, `Func<int, string, bool>` defines a delegate with two input parameters, `int` and `string`, and a return type of `bool`. The following `Func` delegate, when it's invoked, returns Boolean value that indicates whether the input parameter is equal to five:

[!code-csharp-interactive[Func example](~/samples/snippets/csharp/programming-guide/lambda-expressions/LambdasWithQueryMethods.cs#Func)]

You can also supply a lambda expression when the argument type is an <xref:System.Linq.Expressions.Expression%601>, for example in the standard query operators that are defined in the <xref:System.Linq.Queryable> type. When you specify an <xref:System.Linq.Expressions.Expression%601> argument, the lambda is compiled to an expression tree.
  
The following example uses the <xref:System.Linq.Enumerable.Count%2A> standard query operator:

[!code-csharp-interactive[Count example](~/samples/snippets/csharp/programming-guide/lambda-expressions/LambdasWithQueryMethods.cs#Count)]

The compiler can infer the type of the input parameter, or you can also specify it explicitly. This particular lambda expression counts those integers (`n`) which when divided by two have a remainder of 1.

The following example produces a sequence that contains all elements in the `numbers` array that precede the 9, because that's the first number in the sequence that doesn't meet the condition:

[!code-csharp-interactive[TakeWhile example](~/samples/snippets/csharp/programming-guide/lambda-expressions/LambdasWithQueryMethods.cs#TakeWhile)]

The following example specifies multiple input parameters by enclosing them in parentheses. The method returns all the elements in the `numbers` array until it encounters a number whose value is less than its ordinal position in the array:

[!code-csharp-interactive[TakeWhile example 2](~/samples/snippets/csharp/programming-guide/lambda-expressions/LambdasWithQueryMethods.cs#TakeWhileWithIndex)]

## Type inference in lambda expressions

When writing lambdas, you often don't have to specify a type for the input parameters because the compiler can infer the type based on the lambda body, the parameter types, and other factors as described in the C# language specification. For most of the standard query operators, the first input is the type of the elements in the source sequence. If you are querying an `IEnumerable<Customer>`, then the input variable is inferred to be a `Customer` object, which means you have access to its methods and properties:  

```csharp
customers.Where(c => c.City == "London");
```

The general rules for type inference for lambdas are as follows:

- The lambda must contain the same number of parameters as the delegate type.

- Each input parameter in the lambda must be implicitly convertible to its corresponding delegate parameter.

- The return value of the lambda (if any) must be implicitly convertible to the delegate's return type.
  
Note that lambda expressions in themselves don't have a type because the common type system has no intrinsic concept of "lambda expression." However, it's sometimes convenient to speak informally of the "type" of a lambda expression. In these cases the type refers to the delegate type or <xref:System.Linq.Expressions.Expression> type to which the lambda expression is converted.

## Variable scope in lambda expressions

Lambdas can refer to *outer variables* (see [Anonymous methods](anonymous-methods.md)) that are in scope in the method that defines the lambda expression, or in scope in the type that contains the lambda expression. Variables that are captured in this manner are stored for use in the lambda expression even if the variables would otherwise go out of scope and be garbage collected. An outer variable must be definitely assigned before it can be consumed in a lambda expression. The following example demonstrates these rules:

[!code-csharp[variable scope](~/samples/snippets/csharp/programming-guide/lambda-expressions/VariableScopeWithLambdas.cs#VariableScope)]

The following rules apply to variable scope in lambda expressions:  

- A variable that is captured will not be garbage-collected until the delegate that references it becomes eligible for garbage collection.

- Variables introduced within a lambda expression are not visible in the enclosing method.

- A lambda expression cannot directly capture an [in](../../language-reference/keywords/in-parameter-modifier.md), [ref](../../language-reference/keywords/ref.md), or [out](../../language-reference/keywords/out-parameter-modifier.md) parameter from the enclosing method.

- A [return](../../language-reference/keywords/return.md) statement in a lambda expression doesn't cause the enclosing method to return.

- A lambda expression cannot contain a [goto](../../language-reference/keywords/goto.md), [break](../../language-reference/keywords/break.md), or [continue](../../language-reference/keywords/continue.md) statement if the target of that jump statement is outside the lambda expression block. It's also an error to have a jump statement outside the lambda expression block if the target is inside the block.

## C# language specification

For more information, see the [Anonymous function expressions](~/_csharplang/spec/expressions.md#anonymous-function-expressions) section of the [C# language specification](~/_csharplang/spec/introduction.md).

## Featured book chapter

[Delegates, Events, and Lambda Expressions](https://docs.microsoft.com/previous-versions/visualstudio/visual-studio-2008/ff518994%28v=orm.10%29) in [C# 3.0 Cookbook, Third Edition: More than 250 solutions for C# 3.0 programmers](https://docs.microsoft.com/previous-versions/visualstudio/visual-studio-2008/ff518995%28v=orm.10%29)  
  
## See also

- [C# Programming Guide](../index.md)
- [LINQ (Language-Integrated Query)](../concepts/linq/index.md)
- [Anonymous Methods](anonymous-methods.md)
- [Expression Trees](../concepts/expression-trees/index.md)
- [Local functions compared to lambda expressions](../../local-functions-vs-lambdas.md)
- [Implicitly typed lambda expressions](../../implicitly-typed-lambda-expressions.md)
- [Visual Studio 2008 C# Samples (see LINQ Sample Queries files and XQuery program)](https://code.msdn.microsoft.com/Visual-Studio-2008-C-d295cdba)
- [Recursive lambda expressions](https://blogs.msdn.microsoft.com/madst/2007/05/11/recursive-lambda-expressions/)
