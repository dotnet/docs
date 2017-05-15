---
title: Local functions vs. lambda expressions 
description: Why Local Functions might be a better choice than Lambda Expressions    
keywords: C#, .NET, .NET Core, Latest Features, What's New, local functions, lambda expressions
author: BillWagner
ms.author: wiwagn

ms.date: 10/27/2016
ms.topic: article
ms.prod: visual-studio-dev-15
ms.technology: devlang-csharp
ms.devlang: csharp
ms.assetid: 368d1752-3659-489a-97b4-f15d87e49ae3
---

### Local functions compared to Lambda expressions

In some use cases, you could create a lambda expression and use it
without needing to create a local function. Here's an example async
method that does just that:

[!code-csharp[TaskLambdaExample](../../samples/snippets/csharp/new-in-7/AsyncWork.cs#36_TaskLambdaExample "Task returning method with lambda expression")]

However, there are a number of reasons to prefer using local functions
instead of defining and calling lambda expressions.

First, for lambda expressions, the compiler must create an anonymous class
and an instance of that class to store any variables captured by the
closure. The closure for this lambda expression contains the `address`,
`index` and `name` variables. 

Second, lambda expressions are implemented by instantiating a delegate
and invoking that delegate. Local functions are implemented as method calls.
The instantiation necessary for lambda expressions means extra memory
allocations, which may be a performance factor in time critical code paths.
Local functions do not incur this overhead.

Third, local functions can be called before they are defined. Lambda
expressions must be declared before they are defined. This
means local functions are easier to use in recursive algorithms:

[!code-csharp[LocalFunctionFactorial](../../samples/snippets/csharp/new-in-7/MathUtilities.cs#37_LocalFunctionFactorial "Recursive factorial using local function")]

Contrast that implementation with a version that uses lambda expressions:

[!code-csharp[26_LambdaFactorial](../../samples/snippets/csharp/new-in-7/MathUtilities.cs#38_LambdaFactorial "Recursive factorial using lambda expressions")]

Notice that the version using the lambda expression must declare and initialize
the lambda expression, `nthFactorial` before defining it. Not doing so results
in a compile time error for referencing `nthFactorial` before assigning it.
Recursive algorithms are easier to create using local functions. 

While local functions may seem redundant to lambda expressions,
they actually serve different purposes and have different uses.
Local functions are more efficient for the case when you want
to write a function that is called only from the context of
another method.

