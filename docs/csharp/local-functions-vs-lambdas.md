---
title: Local functions vs. lambda expressions
description: Learn why local functions might be a better choice than lambda expressions.
keywords: C#, .NET, .NET Core, Latest Features, What's New, local functions, lambda expressions
author: BillWagner
ms.author: wiwagn

ms.date: 06/27/2016
ms.topic: article
ms.prod: visual-studio-dev-15
ms.technology: devlang-csharp
ms.devlang: csharp
ms.assetid: 368d1752-3659-489a-97b4-f15d87e49ae3
---

### Local functions compared to Lambda expressions

At first glance, [local functions](programming-guide/classes-and/structs/local-functions.md) and [lambda expressions](lambda-expressions.md) are very similar.
Depending on your needs, local functions may be a much better and simpler
solution.

Let's examine the differences between the local function and lambda expression
implementations of the factorial algorithm. First the version using a local function:

[!code-csharp[LocalFunctionFactorial](../../samples/snippets/csharp/new-in-7/MathUtilities.cs#37_LocalFunctionFactorial "Recursive factorial using local function")]

Contrast that implementation with a version that uses lambda expressions:

[!code-csharp[26_LambdaFactorial](../../samples/snippets/csharp/new-in-7/MathUtilities.cs#38_LambdaFactorial "Recursive factorial using lambda expressions")]

First, lambda expressions are implemented by instantiating a delegate
and invoking that delegate. Local functions are implemented as method calls.
The instantiation necessary for lambda expressions means extra memory
allocations, which may be a performance factor in time critical code paths.
Local functions do not incur this overhead. In the example above, the local
functions version has 2 fewer allocations than the lambda expression version.

This recursive method is simple enough that the local function is implemented
as a private method with a compiler generated name. Its only difference from
other private methods is that it is semantically scoped inside the outer function.

Second, local functions can be called before they are defined. Lambda
expressions must be declared before they are defined. This
means local functions are easier to use in recursive algorithms, as shown
above.

Notice that the version using the lambda expression must declare and initialize
the lambda expression, `nthFactorial` before defining it. Not doing so results
in a compile time error for referencing `nthFactorial` before assigning it.
Recursive algorithms are easier to create using local functions.

Third, for lambda expressions, the compiler must always create an anonymous class
and an instance of that class to store any variables captured by the
closure. Consider this async example:

[!code-csharp[TaskLambdaExample](../../samples/snippets/csharp/new-in-7/AsyncWork.cs#36_TaskLambdaExample "Task returning method with lambda expression")]

The closure for this lambda expression contains the `address`,
`index` and `name` variables. In the case of local functions, the object
that implements the closure may be a `struct` type. That would save on
an allocation.

> [!NOTE]
> The local function equivalent of this method also uses a class for the closure. Whether the closure for a local function is implemented as a `class` or a `struct` is an implementation detail. A local function may use a `struct` whereas a lambda will always use a `class`.

[!code-csharp[TaskLocalFunctionExample](../../samples/snippets/csharp/new-in-7/AsyncWork.cs#29_TaskExample "Task returning method with local function")]

One final advantage not demonstrated in this sample is that local
functions can be implemented as iterators, using the `yield return`
syntax to produce a sequence of values.

While local functions may seem redundant to lambda expressions,
they actually serve different purposes and have different uses.
Local functions are more efficient for the case when you want
to write a function that is called only from the context of
another method.
