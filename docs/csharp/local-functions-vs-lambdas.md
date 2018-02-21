---
title: Local functions vs. lambda expressions
description: Learn why local functions might be a better choice than lambda expressions.
keywords: C#, .NET, .NET Core, Latest Features, What's New, local functions, lambda expressions
author: BillWagner
ms.author: wiwagn
ms.date: 06/27/2016
ms.topic: article
ms.prod: .net
ms.technology: devlang-csharp
ms.devlang: csharp
ms.assetid: 368d1752-3659-489a-97b4-f15d87e49ae3
---
# Local functions compared to lambda expressions

At first glance, [local functions](programming-guide/classes-and-structs/local-functions.md) and [lambda expressions](lambda-expressions.md) are very similar. In many cases, the choice between using
lambda expressions and local functions is a matter of style and personal
preference. However, there are real differences in where you can use one or
the other that you should be aware of.

Let's examine the differences between the local function and lambda expression
implementations of the factorial algorithm. First the version using a local function:

[!code-csharp[LocalFunctionFactorial](../../samples/snippets/csharp/new-in-7/MathUtilities.cs#37_LocalFunctionFactorial "Recursive factorial using local function")]

Contrast that implementation with a version that uses lambda expressions:

[!code-csharp[26_LambdaFactorial](../../samples/snippets/csharp/new-in-7/MathUtilities.cs#38_LambdaFactorial "Recursive factorial using lambda expressions")]

The local functions have names. The lambda expressions are anonymous methods
that are assigned to variables that are `Func` or `Action` types. When you
declare a local function, the argument types and return type are part of the 
function declaration. Instead of being part of the body of the lambda expression, the argument types and return type are part of the lambda
expression's variable type declaration. Those two differences may
result in clearer code.

Local functions have different rules for definite assignment
than lambda expressions. A local function declaration can be referenced
from any code location where it is in scope. A lambda expression must be
assigned to a delegate variable before it can be accessed (or called through the delgate
referencing the lambda expression.) Notice that the version using the
lambda expression must declare and initialize the lambda expression,
`nthFactorial` before defining it. Not doing so results in a compile
time error for referencing `nthFactorial` before assigning it.
These differences mean that recursive algorithms are easier to create
using local functions. You can declare and define a local function that
calls itself. Lambda expressions must be declared, and assigned a default
value before they can be re-assigned to a body that references the same
lambda expression.

Definite assignment rules also affect any variables that are captured
by the local function or lamdba epression. Both local functions and
lambda expression rules demand that any captured variables are definitely
assigned at the point when the local function or lambda expression is
converted to a delegate. The difference is that lambda expressions are converted
to delegates when they are declared. Local functions are converted to delegates
only when used as a delegate. If you declare a local function and only
reference it by calling it like a method, it will not be converted to
a delegate. That rule enables you to declare
a local function at any convenient location in its enclosing scope. It's common
to declare local functions at the end of the parent method, after any return
statements.

Third, the compiler can perform static analysis that enables local functions to
definitely assign captured variables in the enclosing scope. Consider this example:

```csharp
int M()
{
    int y;
    LocalFunction();
    return y;

    void LocalFunction() => y = 0;
}
```

The compiler can determine that `LocalFunction` definitely assigns `y` when called. Because `LocalFunction` is called before the `return` statement, `y` is definitiely
assigned at the `return` statement.

The analysis that enables the example analysis enables the fourth difference.
Depending on their use, local functions can avoid heap allocations that
are always necessary for lambda expressions. If a local function is never
converted to a delegate, and none of the variables captured by the local function is captured by other lambdas or local functions that are converted to delegates, the compiler can avoid heap allocations. 

Consider this async example:

[!code-csharp[TaskLambdaExample](../../samples/snippets/csharp/new-in-7/AsyncWork.cs#36_TaskLambdaExample "Task returning method with lambda expression")]

The closure for this lambda expression contains the `address`,
`index` and `name` variables. In the case of local functions, the object
that implements the closure may be a `struct` type. That struct type would
be passed by reference to the local function. This difference in
implementation would save on
an allocation.

The instantiation necessary for lambda expressions means extra memory
allocations, which may be a performance factor in time-critical code paths.
Local functions do not incur this overhead. In the example above, the local
functions version has 2 fewer allocations than the lambda expression version.

> [!NOTE]
> The local function equivalent of this method also uses a class for the closure. Whether the closure for a local function is implemented as a `class` or a `struct` is an implementation detail. A local function may use a `struct` whereas a lambda will always use a `class`.

[!code-csharp[TaskLocalFunctionExample](../../samples/snippets/csharp/new-in-7/AsyncWork.cs#29_TaskExample "Task returning method with local function")]

One final advantage not demonstrated in this sample is that local
functions can be implemented as iterators, using the `yield return`
syntax to produce a sequence of values. The `yield return` statement
is not allowed in lambda expressions.

While local functions may seem redundant to lambda expressions,
they actually serve different purposes and have different uses.
Local functions are more efficient for the case when you want
to write a function that is called only from the context of
another method.
