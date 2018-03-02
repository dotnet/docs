---
title: Lambda Expressions
description: Lean to use lambda expressions, which are executable code blocks that can be passed as arguments. 
keywords: .NET, .NET Core, lambda expressions, lambdas, delegates 
ms-author: ronpet
author: rpetrusha
ms.date: 11/22/2016
ms.topic: article 
ms.prod: .net
ms.technology: devlang-csharp
ms.devlang: csharp
ms.assetid: b6a0539a-8ce5-4da7-adcf-44be345a2714
---

# Lambda expressions #

A *lambda expression* is a block of code (an expression or a statement block) that is treated as an object. It can be passed as an argument to methods, and it can also be returned by method calls. Lambda expressions are used extensively for:

- Passing the code that is to be executed to asynchronous methods, such as <xref:System.Threading.Tasks.Task.Run(System.Action)>.

- Writing [LINQ query expressions](linq/index.md).

- Creating [expression trees](expression-trees-building.md).

Lambda expressions are code that can be represented either as a delegate, or as an expression tree that compiles to a delegate. The specific delegate type of a lambda expression depends on its parameters and return value. Lambda expressions that don't return a value correspond to a specific `Action` delegate, depending on its number of parameters. Lambda expressions that return a value correspond to a specific `Func` delegate, depending on its number of parameters. For example, a lambda expression that has two parameters but returns no value corresponds to an <xref:System.Action%602> delegate. A lambda expression that has one parameter and returns a value corresponds to <xref:System.Func%602> delegate.

A lambda expression uses `=>`, the [lambda declaration operator](language-reference/operators/lambda-operator.md), to separate the lambda's parameter list from its executable code. To create a lambda expression, you specify input parameters (if any) on the left side of the lambda operator, and you put the expression or statement block on the other side. For example, the single-line lambda expression `x => x * x` specifies a parameter that’s named `x` and returns the value of `x` squared. You can assign this expression to a delegate type, as the following example shows:

[!code-csharp[csSnippets.Lambdas](../../samples/snippets/csharp/concepts/lambda-expressions/lambda1.cs#1)]

Or you can pass it directly as a method argument:

[!code-csharp[csSnippets.Lambdas](../../samples/snippets/csharp/concepts/lambda-expressions/lambda2.cs#2)]

## Expression lambdas ##

 A lambda expression with an expression on the right side of the => operator is called an *expression lambda*. Expression lambdas are used extensively in the construction of [expression trees](expression-trees.md). An expression lambda returns the result of the expression and takes the following basic form:

```csharp
(input parameters) => expression
```

The parentheses are optional only if the lambda has one input parameter; otherwise they are required. Specify zero input parameters with empty parentheses:

[!code-csharp[csSnippets.Lambdas](../../samples/snippets/csharp/concepts/lambda-expressions/expression3.cs#1)]

Two or more input parameters are separated by commas enclosed in parentheses:

[!code-csharp[csSnippets.Lambdas](../../samples/snippets/csharp/concepts/lambda-expressions/expression3.cs#2)]

Ordinarily, the compiler uses type inference in determining parameter types. However, sometimes it is difficult or impossible for the compiler to infer the input types. When this occurs, you can specify the types explicitly, as in the following example:

[!code-csharp[csSnippets.Lambdas](../../samples/snippets/csharp/concepts/lambda-expressions/expression3.cs#3)]

Note in the previous example that the body of an expression lambda can consist of a method call. However, if you are creating expression trees that are evaluated outside of the .NET Framework, such as in SQL Server or Entity Framework (EF), you should refrain from using method calls in lambda expressions, since the methods may have no meaning outside the context of the .NET implementation. If you do choose to use method calls in this case, be sure to test them thoroughly to ensure that the method calls can be successfuly resolved.

## Statement lambdas ##

A statement lambda resembles an expression lambda except that the statement(s) is enclosed in braces:

```csharp
(input parameters) => { statement; }
```

The body of a statement lambda can consist of any number of statements; however, in practice there are typically no more than two or three.

[!code-csharp[csSnippets.Lambdas](../../samples/snippets/csharp/concepts/lambda-expressions/statement1.cs#1)]

Statement lambdas, like anonymous methods, cannot be used to create expression trees.

## Async lambdas ##

You can easily create lambda expressions and statements that incorporate asynchronous processing by using the [async](language-reference/keywords/async.md) and [await](language-reference/keywords/await.md) keywords. For example, the example calls a `ShowSquares` method that executes asynchronously.

[!code-csharp[csSnippets.Lambdas](../../samples/snippets/csharp/concepts/lambda-expressions/async1.cs#1)]

For more information about how to create and use async methods, see [Asynchronous programming with async and await](programming-guide/concepts/async/index.md).

## Lambda expressions and tuples ##

Starting with C# 7.0, the C# language provides built-in support for tuples. You can provide a tuple as an argument to a lambda expression, and your lambda expression can also return a tuple. In some cases, the C# compiler uses type inference to determine the types of tuple components. 

You define a tuple by enclosing a comma-delimited list of its components in parentheses. The following example uses tuple with 5 components to pass a sequence of numbers to a lambda expression, which doubles each value and returns a tuple with 5 components that contains the result of the multiplications.

[!code-csharp[csSnippets.Lambdas](../../samples/snippets/csharp/concepts/lambda-expressions/tuples1.cs#1)]

Ordinarily, the fields of a tuple are named `Item1`, `Item2`, etc. You can, however, define a tuple with named components, as the following example does.

[!code-csharp[csSnippets.Lambdas](../../samples/snippets/csharp/concepts/lambda-expressions/tuples2.cs#1)]

For more information on support for tuples in C#, see [C# Tuple types](tuples.md).

## Lambdas with the standard query operators ##

LINQ to Objects, among other implementations, have an input parameter whose type is one of the <xref:System.Func%601> family of generic delegates. These delegates use type parameters to define the number and type of input parameters, and the return type of the delegate. `Func` delegates are very useful for encapsulating user-defined expressions that are applied to each element in a set of source data. For example, consider the <xref:System.Func%601> delegate, whose syntax is:

[!code-csharp[csSnippets.Lambdas](../../samples/snippets/csharp/concepts/lambda-expressions/query1.cs#1)]

The delegate can be instantiated with code like the following

[!code-csharp[csSnippets.Lambdas](../../samples/snippets/csharp/concepts/lambda-expressions/query1.cs#2)]

where `int` is an input parameter, and `bool` is the return value. The return value is always specified in the last type parameter. When the following `Func` delegate is invoked, it returns true or false to indicate whether the input parameter is equal to 5:

[!code-csharp[csSnippets.Lambdas](../../samples/snippets/csharp/concepts/lambda-expressions/query1.cs#3)]

You can also supply a lambda expression when the argument type is an <xref:System.Linq.Expressions.Expression%601>, for example in the standard query operators that are defined in the <xref:System.Linq.Queryable> type. When you specify an <xref:System.Linq.Expressions.Expression%601> argument, the lambda is compiled to an expression tree. The following example uses the [System.Linq.Enumerable.Count](xref:System.Linq.Enumerable.Count%60%601(System.Collections.Generic.IEnumerable{%60%600})) standard query operator.

[!code-csharp[csSnippets.Lambdas](../../samples/snippets/csharp/concepts/lambda-expressions/query1.cs#4)]

The compiler can infer the type of the input parameter, or you can also specify it explicitly. This particular lambda expression counts those integers (`n`) that, when divided by two, have a remainder of 1.

The following example produces a sequence that contains all elements in the `numbers` array that precede the 9, because that's the first number in the sequence that doesn't meet the condition.

[!code-csharp[csSnippets.Lambdas](../../samples/snippets/csharp/concepts/lambda-expressions/query1.cs#5)]

The following example specifies multiple input parameters by enclosing them in parentheses. The method returns all the elements in the numbers array until it encounters a number whose value is less than its ordinal position in the array.

[!code-csharp[csSnippets.Lambdas](../../samples/snippets/csharp/concepts/lambda-expressions/query1.cs#6)]

## Type inference in lambda expressions ##

When writing lambdas, you often do not have to specify a type for the input parameters because the compiler can infer the type based on the lambda body, the parameter types, and other factors, as described in the C# Language Specification. For most of the standard query operators, the first input is the type of the elements in the source sequence. If you are querying an `IEnumerable<Customer>`, then the input variable is inferred to be a `Customer` object, which means you have access to its methods and properties:

[!code-csharp[csSnippets.Lambdas](../../samples/snippets/csharp/concepts/lambda-expressions/infer1.cs#1)]

The general rules for type inference for lambdas are:

- The lambda must contain the same number of parameters as the delegate type.

- Each input argument in the lambda must be implicitly convertible to its corresponding delegate parameter.

- The return value of the lambda (if any) must be implicitly convertible to the delegate's return type.

Note that lambda expressions in themselves do not have a type because the common type system has no intrinsic concept of "lambda expression." However, it is sometimes convenient to speak informally of the "type" of a lambda expression. In these cases the type refers to the delegate type or <xref:System.Linq.Expressions.Expression> type to which the lambda expression is converted.

## Variable Scope in Lambda Expressions ##

Lambdas can refer to *outer variables* (see [Anonymous methods](programming-guide/statements-expressions-operators/anonymous-methods.md)) that are in scope in the method that defines the lambda function, or in scope in the type that contains the lambda expression. Variables that are captured in this manner are stored for use in the lambda expression even if the variables would otherwise go out of scope and be garbage collected. An outer variable must be definitely assigned before it can be consumed in a lambda expression. The following example demonstrates these rules.

[!code-csharp[csSnippets.Lambdas](../../samples/snippets/csharp/concepts/lambda-expressions/scope.cs#1)]

 The following rules apply to variable scope in lambda expressions:

- A variable that is captured will not be garbage-collected until the delegate that references it becomes eligible for garbage collection.

- Variables introduced within a lambda expression are not visible in the outer method.

- A lambda expression cannot directly capture an `in`, `ref`, or `out` parameter from an enclosing method.

- A return statement in a lambda expression does not cause the enclosing method to return.

- A lambda expression cannot contain a `goto` statement, `break` statement, or `continue` statement that is inside the lambda function if the jump statement’s target is outside the block. It is also an error to have a jump statement outside the lambda function block if the target is inside the block.

## See also ##

[LINQ (Language-Integrated Query)](../standard/using-linq.md)   
[Anonymous methods](programming-guide/statements-expressions-operators/anonymous-methods.md)   
[Expression trees](expression-trees.md)
