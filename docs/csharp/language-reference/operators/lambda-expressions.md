---
title: "Lambda expressions - C# reference"
description: Learn about C# lambda expressions that are used to create anonymous functions.
ms.date: 11/08/2021
helpviewer_keywords: 
  - "lambda expressions [C#]"
  - "outer variables [C#]"
  - "statement lambda [C#]"
  - "expression lambda [C#]"
  - "expressions [C#], lambda"
ms.assetid: 57e3ba27-9a82-4067-aca7-5ca446b7bf93
---
# Lambda expressions (C# reference)

You use a *lambda expression* to create an anonymous function. Use the [lambda declaration operator `=>`](lambda-operator.md) to separate the lambda's parameter list from its body. A lambda expression can be of any of the following two forms:

- [Expression lambda](#expression-lambdas) that has an expression as its body:

  ```csharp
  (input-parameters) => expression
  ```

- [Statement lambda](#statement-lambdas) that has a statement block as its body:

  ```csharp  
  (input-parameters) => { <sequence-of-statements> }
  ```

To create a lambda expression, you specify input parameters (if any) on the left side of the lambda operator and an expression or a statement block on the other side.

Any lambda expression can be converted to a [delegate](../builtin-types/reference-types.md#the-delegate-type) type. The delegate type to which a lambda expression can be converted is defined by the types of its parameters and return value. If a lambda expression doesn't return a value, it can be converted to one of the `Action` delegate types; otherwise, it can be converted to one of the `Func` delegate types. For example, a lambda expression that has two parameters and returns no value can be converted to an <xref:System.Action%602> delegate. A lambda expression that has one parameter and returns a value can be converted to a <xref:System.Func%602> delegate. In the following example, the lambda expression `x => x * x`, which specifies a parameter that's named `x` and returns the value of `x` squared, is assigned to a variable of a delegate type:

[!code-csharp-interactive[lambda is delegate](snippets/lambda-expressions/Introduction.cs#Delegate)]

Expression lambdas can also be converted to the [expression tree](../../programming-guide/concepts/expression-trees/index.md) types, as the following example shows:

[!code-csharp-interactive[lambda is expression tree](snippets/lambda-expressions/Introduction.cs#ExpressionTree)]

You can use lambda expressions in any code that requires instances of delegate types or expression trees, for example as an argument to the <xref:System.Threading.Tasks.Task.Run(System.Action)?displayProperty=nameWithType> method to pass the code that should be executed in the background. You can also use lambda expressions when you write [LINQ in C#](../../linq/index.md), as the following example shows:

[!code-csharp-interactive[lambda is argument in LINQ](snippets/lambda-expressions/Introduction.cs#Argument)]

When you use method-based syntax to call the <xref:System.Linq.Enumerable.Select%2A?displayProperty=nameWithType> method in the <xref:System.Linq.Enumerable?displayProperty=nameWithType> class, for example in LINQ to Objects and LINQ to XML, the parameter is a delegate type <xref:System.Func%602?displayProperty=nameWithType>. When you call the <xref:System.Linq.Queryable.Select%2A?displayProperty=nameWithType> method in the <xref:System.Linq.Queryable?displayProperty=nameWithType> class, for example in LINQ to SQL, the parameter type is an expression tree type [`Expression<Func<TSource,TResult>>`](<xref:System.Linq.Expressions.Expression%601>). In both cases, you can use the same lambda expression to specify the parameter value. That makes the two `Select` calls to look similar although in fact the type of objects created from the lambdas is different.
  
## Expression lambdas

A lambda expression with an expression on the right side of the `=>` operator is called an *expression lambda*. An expression lambda returns the result of the expression and takes the following basic form:

```csharp
(input-parameters) => expression
```

The body of an expression lambda can consist of a method call. However, if you're creating [expression trees](../../programming-guide/concepts/expression-trees/index.md) that are evaluated outside the context of the .NET Common Language Runtime (CLR), such as in SQL Server, you shouldn't use method calls in lambda expressions. The methods will have no meaning outside the context of the .NET Common Language Runtime (CLR).

## Statement lambdas

A statement lambda resembles an expression lambda except that its statements are enclosed in braces:

```csharp  
(input-parameters) => { <sequence-of-statements> }
```

The body of a statement lambda can consist of any number of statements; however, in practice there are typically no more than two or three.

:::code language="csharp" interactive="try-dotnet-method" source="snippets/lambda-expressions/GeneralExamples.cs" id="SnippetStatementLambda":::

You can't use statement lambdas to create expression trees.

## Input parameters of a lambda expression

You enclose input parameters of a lambda expression in parentheses. Specify zero input parameters with empty parentheses:  

:::code language="csharp" source="snippets/lambda-expressions/GeneralExamples.cs" id="SnippetZeroParameters":::

If a lambda expression has only one input parameter, parentheses are optional:

:::code language="csharp" source="snippets/lambda-expressions/GeneralExamples.cs" id="SnippetOneParameter":::

Two or more input parameters are separated by commas:

:::code language="csharp" source="snippets/lambda-expressions/GeneralExamples.cs" id="SnippetTwoParameters":::

Sometimes the compiler can't infer the types of input parameters. You can specify the types explicitly as shown in the following example:

:::code language="csharp" source="snippets/lambda-expressions/GeneralExamples.cs" id="SnippetExplicitlyTypedParameters":::

Input parameter types must be all explicit or all implicit; otherwise, a [CS0748](../../misc/cs0748.md) compiler error occurs.

Beginning with C# 9.0, you can use [discards](../../fundamentals/functional/discards.md) to specify two or more input parameters of a lambda expression that aren't used in the expression:

:::code language="csharp" source="snippets/lambda-expressions/GeneralExamples.cs" id="SnippetDiscards":::

Lambda discard parameters may be useful when you use a lambda expression to [provide an event handler](../../programming-guide/events/how-to-subscribe-to-and-unsubscribe-from-events.md).

> [!NOTE]
> For backwards compatibility, if only a single input parameter is named `_`, then, within a lambda expression, `_` is treated as the name of that parameter.

## Async lambdas

You can easily create lambda expressions and statements that incorporate asynchronous processing by using the [async](../keywords/async.md) and [await](await.md) keywords. For example, the following Windows Forms example contains an event handler that calls and awaits an async method, `ExampleMethodAsync`.

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

For more information about how to create and use async methods, see [Asynchronous Programming with async and await](../../programming-guide/concepts/async/index.md).

## Lambda expressions and tuples

Starting with C# 7.0, the C# language provides built-in support for [tuples](../builtin-types/value-tuples.md). You can provide a tuple as an argument to a lambda expression, and your lambda expression can also return a tuple. In some cases, the C# compiler uses type inference to determine the types of tuple components.

You define a tuple by enclosing a comma-delimited list of its components in parentheses. The following example uses tuple with three components to pass a sequence of numbers to a lambda expression, which doubles each value and returns a tuple with three components that contains the result of the multiplications.

[!code-csharp-interactive[lambda and tuples](snippets/lambda-expressions/LambdasAndTuples.cs#WithoutComponentName)]

Ordinarily, the fields of a tuple are named `Item1`, `Item2`, and so on. You can, however, define a tuple with named components, as the following example does.

[!code-csharp-interactive[lambda and named tuples](snippets/lambda-expressions/LambdasAndTuples.cs#WithComponentName)]

For more information about C# tuples, see [Tuple types](../../language-reference/builtin-types/value-tuples.md).

## Lambdas with the standard query operators

LINQ to Objects, among other implementations, have an input parameter whose type is one of the <xref:System.Func%601> family of generic delegates. These delegates use type parameters to define the number and type of input parameters, and the return type of the delegate. `Func` delegates are useful for encapsulating user-defined expressions that are applied to each element in a set of source data. For example, consider the <xref:System.Func%602> delegate type:  

```csharp
public delegate TResult Func<in T, out TResult>(T arg)
```

The delegate can be instantiated as a `Func<int, bool>` instance where `int` is an input parameter and `bool` is the return value. The return value is always specified in the last type parameter. For example, `Func<int, string, bool>` defines a delegate with two input parameters, `int` and `string`, and a return type of `bool`. The following `Func` delegate, when it's invoked, returns Boolean value that indicates whether the input parameter is equal to five:

[!code-csharp-interactive[Func example](snippets/lambda-expressions/LambdasWithQueryMethods.cs#Func)]

You can also supply a lambda expression when the argument type is an <xref:System.Linq.Expressions.Expression%601>, for example in the standard query operators that are defined in the <xref:System.Linq.Queryable> type. When you specify an <xref:System.Linq.Expressions.Expression%601> argument, the lambda is compiled to an expression tree.
  
The following example uses the <xref:System.Linq.Enumerable.Count%2A> standard query operator:

[!code-csharp-interactive[Count example](snippets/lambda-expressions/LambdasWithQueryMethods.cs#Count)]

The compiler can infer the type of the input parameter, or you can also specify it explicitly. This particular lambda expression counts those integers (`n`) which when divided by two have a remainder of 1.

The following example produces a sequence that contains all elements in the `numbers` array that precede the 9, because that's the first number in the sequence that doesn't meet the condition:

[!code-csharp-interactive[TakeWhile example](snippets/lambda-expressions/LambdasWithQueryMethods.cs#TakeWhile)]

The following example specifies multiple input parameters by enclosing them in parentheses. The method returns all the elements in the `numbers` array until it finds a number whose value is less than its ordinal position in the array:

[!code-csharp-interactive[TakeWhile example 2](snippets/lambda-expressions/LambdasWithQueryMethods.cs#TakeWhileWithIndex)]

You don't use lambda expressions directly in [query expressions](../keywords/query-keywords.md), but you can use them in method calls within query expressions, as the following example shows:

:::code language="csharp" interactive="try-dotnet-method" source="snippets/lambda-expressions/LambdasWithQueryMethods.cs" id="Query":::

## Type inference in lambda expressions

When writing lambdas, you often don't have to specify a type for the input parameters because the compiler can infer the type based on the lambda body, the parameter types, and other factors as described in the C# language specification. For most of the standard query operators, the first input is the type of the elements in the source sequence. If you're querying an `IEnumerable<Customer>`, then the input variable is inferred to be a `Customer` object, which means you have access to its methods and properties:  

```csharp
customers.Where(c => c.City == "London");
```

The general rules for type inference for lambdas are as follows:

- The lambda must contain the same number of parameters as the delegate type.
- Each input parameter in the lambda must be implicitly convertible to its corresponding delegate parameter.
- The return value of the lambda (if any) must be implicitly convertible to the delegate's return type.
  
## Natural type of a lambda expression

A lambda expression in itself doesn't have a type because the common type system has no intrinsic concept of "lambda expression." However, it's sometimes convenient to speak informally of the "type" of a lambda expression. That informal "type" refers to the delegate type or <xref:System.Linq.Expressions.Expression> type to which the lambda expression is converted.

Beginning with C# 10, a lambda expression may have a *natural type*. Instead of forcing you to declare a delegate type, such as `Func<...>` or `Action<...>` for a lambda expression, the compiler may infer the delegate type from the lambda expression. For example, consider the following declaration:

```csharp
var parse = (string s) => int.Parse(s);
```

The compiler can infer `parse` to be a `Func<string, int>`. The compiler chooses an available `Func` or `Action` delegate, if a suitable one exists. Otherwise, it synthesizes a delegate type. For example, the delegate type is synthesized if the lambda expression has `ref` parameters. When a lambda expression has a natural type, it can be assigned to a less explicit type, such as <xref:System.Object?displayProperty=nameWithType> or <xref:System.Delegate?displayProperty=nameWithType>:

```csharp
object parse = (string s) => int.Parse(s);   // Func<string, int>
Delegate parse = (string s) => int.Parse(s); // Func<string, int>
```

Method groups (that is, method names without parameter lists) with exactly one overload have a natural type:

```csharp
var read = Console.Read; // Just one overload; Func<int> inferred
var write = Console.Write; // ERROR: Multiple overloads, can't choose
```

If you assign a lambda expression to <xref:System.Linq.Expressions.LambdaExpression?displayProperty=nameWithType>, or <xref:System.Linq.Expressions.Expression?displayProperty=nameWithType>, and the lambda has a natural delegate type, the expression has a natural type of <xref:System.Linq.Expressions.Expression%601?displayProperty=nameWithType>, with the natural delegate type used as the argument for the type parameter:

```csharp
LambdaExpression parseExpr = (string s) => int.Parse(s); // Expression<Func<string, int>>
Expression parseExpr = (string s) => int.Parse(s);       // Expression<Func<string, int>>
```

Not all lambda expressions have a natural type. Consider the following declaration:

```csharp
var parse = s => int.Parse(s); // ERROR: Not enough type info in the lambda
```

The compiler can't infer a parameter type for `s`. When the compiler can't infer a natural type, you must declare the type:

```csharp
Func<string, int> parse = s => int.Parse(s);
```

## Explicit return type

Typically, the return type of a lambda expression is obvious and inferred. For some expressions, that doesn't work:

```csharp
var choose = (bool b) => b ? 1 : "two"; // ERROR: Can't infer return type
```

Beginning with C# 10, you can specify the return type of a lambda expression before the input parameters. When you specify an explicit return type, you must parenthesize the input parameters:

```csharp
var choose = object (bool b) => b ? 1 : "two"; // Func<bool, object>
```

## Attributes

Beginning with C# 10, you can add attributes to a lambda expression and its parameters. The following example shows how to add attributes to a lambda expression:

```csharp
Func<string, int> parse = [Example(1)] (s) => int.Parse(s);
var choose = [Example(2)][Example(3)] object (bool b) => b ? 1 : "two";
```

You can also add attributes to the input parameters or return value, as the following example shows:

```csharp
var sum = ([Example(1)] int a, [Example(2), Example(3)] int b) => a + b;
var inc = [return: Example(1)] (int s) => s++;
```

As the preceding examples show, you must parenthesize the input parameters when you add attributes to a lambda expression or its parameters.

> [!IMPORTANT]
> Lambda expressions are invoked through the underlying delegate type. That is different than methods and local functions. The delegate's `Invoke` method doesn't check attributes on the lambda expression. Attributes don't have any effect when the lambda expression is invoked. Attributes on lambda expressions are useful for code analysis, and can be discovered via reflection. One consequence of this decision is that the <xref:System.Diagnostics.ConditionalAttribute?displayProperty=nameWithType> cannot be applied to a lambda expression.

## Capture of outer variables and variable scope in lambda expressions

Lambdas can refer to *outer variables*. These are the variables that are in scope in the method that defines the lambda expression, or in scope in the type that contains the lambda expression. Variables that are captured in this manner are stored for use in the lambda expression even if the variables would otherwise go out of scope and be garbage collected. An outer variable must be definitely assigned before it can be consumed in a lambda expression. The following example demonstrates these rules:

[!code-csharp[variable scope](snippets/lambda-expressions/VariableScopeWithLambdas.cs#VariableScope)]

The following rules apply to variable scope in lambda expressions:  

- A variable that is captured won't be garbage-collected until the delegate that references it becomes eligible for garbage collection.
- Variables introduced within a lambda expression aren't visible in the enclosing method.
- A lambda expression can't directly capture an [in](../keywords/in-parameter-modifier.md), [ref](../keywords/ref.md), or [out](../keywords/out-parameter-modifier.md) parameter from the enclosing method.
- A [return](../statements/jump-statements.md#the-return-statement) statement in a lambda expression doesn't cause the enclosing method to return.
- A lambda expression can't contain a [goto](../statements/jump-statements.md#the-goto-statement), [break](../statements/jump-statements.md#the-break-statement), or [continue](../statements/jump-statements.md#the-continue-statement) statement if the target of that jump statement is outside the lambda expression block. It's also an error to have a jump statement outside the lambda expression block if the target is inside the block.

Beginning with C# 9.0, you can apply the `static` modifier to a lambda expression to prevent unintentional capture of local variables or instance state by the lambda:

:::code language="csharp" source="snippets/lambda-expressions/GeneralExamples.cs" id="SnippetStatic":::

A static lambda can't capture local variables or instance state from enclosing scopes, but may reference static members and constant definitions.

## C# language specification

For more information, see the [Anonymous function expressions](~/_csharplang/spec/expressions.md#anonymous-function-expressions) section of the [C# language specification](~/_csharplang/spec/introduction.md).

For more information about features added in C# 9.0 and later, see the following feature proposal notes:

- [Lambda discard parameters (C# 9.0)](~/_csharplang/proposals/csharp-9.0/lambda-discard-parameters.md)
- [Static anonymous functions (C# 9.0)](~/_csharplang/proposals/csharp-9.0/static-anonymous-functions.md)
- [Lambda improvements (C# 10)](~/_csharplang/proposals/csharp-10.0/lambda-improvements.md)

## See also

- [C# reference](../index.md)
- [C# operators and expressions](index.md)
- [LINQ (Language-Integrated Query)](../../programming-guide/concepts/linq/index.md)
- [Expression trees](../../programming-guide/concepts/expression-trees/index.md)
- [Local functions vs. lambda expressions](../../programming-guide/classes-and-structs/local-functions.md#local-functions-vs-lambda-expressions)
- [LINQ sample queries](https://github.com/microsoftarchive/msdn-code-gallery-microsoft/tree/master/Visual%20Studio%20Product%20Team/Official%20Visual%20Studio%202008%20C%23%20Samples/%5BC%23%5D-Official%20Visual%20Studio%202008%20C%23%20Samples/LINQ%20-%20Sample%20Queries/C%23)
- [XQuery sample](https://github.com/microsoftarchive/msdn-code-gallery-microsoft/tree/master/Visual%20Studio%20Product%20Team/Official%20Visual%20Studio%202008%20C%23%20Samples/%5BC%23%5D-Official%20Visual%20Studio%202008%20C%23%20Samples/XQuery/C%23)
- [101 LINQ samples](/samples/dotnet/try-samples/101-linq-samples/)
