---
title: "Local functions - C# Programming Guide"
description: Local functions in C# are private methods that are nested in another member and can be called from their containing member.
ms.date: 10/09/2020
helpviewer_keywords: 
  - "local functions [C#]"
---
# Local functions (C# Programming Guide)

Starting with C# 7.0, C# supports *local functions*. Local functions are private methods of a type that are nested in another member. They can only be called from their containing member. Local functions can be declared in and called from:

- Methods, especially iterator methods and async methods
- Constructors
- Property accessors
- Event accessors
- Anonymous methods
- Lambda expressions
- Finalizers
- Other local functions

However, local functions can't be declared inside an expression-bodied member.

> [!NOTE]
> In some cases, you can use a lambda expression to implement functionality also supported by a local function. For a comparison, see [Local functions vs. lambda expressions](#local-functions-vs-lambda-expressions).

Local functions make the intent of your code clear. Anyone reading your code can see that the method is not callable except by the containing method. For team projects, they also make it impossible for another developer to mistakenly call the method directly from elsewhere in the class or struct.

## Local function syntax

A local function is defined as a nested method inside a containing member. Its definition has the following syntax:

```csharp
<modifiers> <return-type> <method-name> <parameter-list>
```

You can use the following modifiers with a local function:

- [`async`](../../language-reference/keywords/async.md)
- [`unsafe`](../../language-reference/keywords/unsafe.md)
- [`static`](../../language-reference/keywords/static.md) (in C# 8.0 and later). A static local function can't capture local variables or instance state.
- [`extern`](../../language-reference/keywords/extern.md) (in C# 9.0 and later). An external local function must be `static`.

All local variables that are defined in the containing member, including its method parameters, are accessible in a non-static local function.

Unlike a method definition, a local function definition cannot include the member access modifier. Because all local functions are private, including an access modifier, such as the `private` keyword, generates compiler error CS0106, "The modifier 'private' is not valid for this item."

The following example defines a local function named `AppendPathSeparator` that is private to a method named `GetText`:

:::code language="csharp" source="snippets/local-functions/Program.cs" id="Basic" :::

Beginning with C# 9.0, you can apply attributes to a local function, its parameters and type parameters, as the following example shows:

:::code language="csharp" source="snippets/local-functions/Program.cs" id="WithAttributes" :::

The preceding example uses a [special attribute](../../language-reference/attributes/nullable-analysis.md) to assist the compiler in static analysis in a nullable context.

## Local functions and exceptions

One of the useful features of local functions is that they can allow exceptions to surface immediately. For method iterators, exceptions are surfaced only when the returned sequence is enumerated, and not when the iterator is retrieved. For async methods, any exceptions thrown in an async method are observed when the returned task is awaited.

The following example defines an `OddSequence` method that enumerates odd numbers in a specified range. Because it passes a number greater than 100 to the `OddSequence` enumerator method, the method throws an <xref:System.ArgumentOutOfRangeException>. As the output from the example shows, the exception surfaces only when you iterate the numbers, and not when you retrieve the enumerator.

:::code language="csharp" source="snippets/local-functions/IteratorWithoutLocal.cs" :::

If you put iterator logic into a local function, argument validation exceptions are thrown when you retrieve the enumerator, as the following example shows:

:::code language="csharp" source="snippets/local-functions/IteratorWithLocal.cs" :::

You can use local functions in a similar way with asynchronous operations. Exceptions thrown in an async method surface when the corresponding task is awaited. Local functions allow your code to fail fast and allow your exception to be both thrown and observed synchronously.

The following example uses an asynchronous method named `GetMultipleAsync` to pause for a specified number of seconds and return a value that is a random multiple of that number of seconds. The maximum delay is 5 seconds; an <xref:System.ArgumentOutOfRangeException> results if the value is greater than 5. As the following example shows, the exception that is thrown when a value of 6 is passed to the `GetMultipleAsync` method is observed only when the task is awaited.

:::code language="csharp" source="snippets/local-functions/AsyncWithoutLocal.cs" :::

Like with the method iterator, you can refactor the preceding example and put the code of asynchronous operation in a local function. As the output from the following example shows, the <xref:System.ArgumentOutOfRangeException> is thrown as soon as the `GetMultiple` method is called.

:::code language="csharp" source="snippets/local-functions/AsyncWithLocal.cs" :::

## Local functions vs. lambda expressions

At first glance, local functions and [lambda expressions](../../language-reference/operators/lambda-expressions.md) are very similar. In many cases, the choice between using lambda expressions and local functions is a matter of style and personal preference. However, there are real differences in where you can use one or the other that you should be aware of.

Let's examine the differences between the local function and lambda expression implementations of the factorial algorithm. Here's the version using a local function:

:::code language="csharp" source="snippets/local-functions/Program.cs" id="FactorialWithLocal" :::

This version uses lambda expressions:

:::code language="csharp" source="snippets/local-functions/Program.cs" id="FactorialWithLambda" :::

### Naming

Local functions are explicitly named like methods. Lambda expressions are anonymous methods and need to be assigned to variables that are either `Func` or `Action` types. When you declare a local function, the process is like writing a normal method; you declare a return type and a function signature.

### Typing

Lambda expressions rely on the typing of the `Func`/`Action` variable that they're assigned to determine the argument and return types. In local functions, since the syntax is much like writing a normal method, argument types and return type are already part of the function declaration.

### Definite Assignment

Local functions have different rules for definite assignment than lambda expressions. A local function declaration can be referenced from any code location where it is in scope; in our first example `LocalFunctionFactorial`, we could declare our local function either above or below the `return` statement and not trigger any compiler errors.

Lambda expressions follow the rules for definite assignment more closely. In order for a lambda expression to be used, the `Func`/`Action` variable that it will be assigned to must be declared and the lambda expression assigned to it. Notice that `LambdaFactorial` must declare and initialize the lambda expression `nthFactorial` before defining it. Not doing so results in a compile time error for referencing `nthFactorial` before assigning it.

These differences mean that recursive algorithms are easier to create using local functions. You can declare and define a local function that calls itself. Lambda expressions must be declared, and assigned a default value before they can be re-assigned to a body that references the same lambda expression.

### Conversion to a Delegate

Both local functions and lambda expressions require that any captured variables are definitely assigned when either is converted to a delegate, but *when* they're converted differs. Lambda expressions are converted to delegates when they're declared, while local functions are only converted to delegates when ***used*** as a delegate.

If you declare a local function and only reference it by calling it like a method, it will not be converted to a delegate. That rule enables you to declare a local function at any convenient location in its enclosing scope. It's common to declare local functions at the end of the parent method, after any return statements.

### Variable Capture

The rules of definite assignment also affect any variables that are captured by the local function or lambda expression. The compiler can perform static analysis that enables local functions to definitely assign captured variables in the enclosing scope. Consider this example:

```csharp
int M()
{
    int y;
    LocalFunction();
    return y;

    void LocalFunction() => y = 0;
}
```

The compiler can determine that `LocalFunction` definitely assigns `y` when called. Because `LocalFunction` is called before the `return` statement, `y` is definitely assigned at the `return` statement.

### Heap Allocations

Depending on their use, local functions can avoid heap allocations that are always necessary for lambda expressions. If a local function is never converted to a delegate, and none of the variables captured by the local function is captured by other lambdas or local functions that are converted to delegates, the compiler can avoid heap allocations.

Consider this async example:

:::code language="csharp" source="snippets/local-functions/Program.cs" id="AsyncWithLambda" :::

The closure for this lambda expression contains the `address`, `index` and `name` variables. In the case of local functions, the object that implements the closure may be a `struct` type. That struct type would be passed by reference to the local function. This difference in implementation would save on an allocation.

The instantiation necessary for lambda expressions means extra memory allocations, which may be a performance factor in time-critical code paths. Local functions do not incur this overhead. In the example above, the local functions version has two fewer allocations than the lambda expression version.

> [!NOTE]
> The local function equivalent of this method also uses a class for the closure. Whether the closure for a local function is implemented as a `class` or a `struct` is an implementation detail. A local function may use a `struct` whereas a lambda will always use a `class`.

:::code language="csharp" source="snippets/local-functions/Program.cs" id="AsyncWithLocal" :::

### Usage of the `yield` Keyword

One final advantage not demonstrated in this sample is that local functions can be implemented as iterators, using the `yield return` syntax to produce a sequence of values.

[!code-csharp[TaskLocalFunctionExample](../../../../samples/snippets/csharp/new-in-7/YieldLocalFunc.cs#YieldExample "Local function leveraging yield return")]

The `yield return` statement is not allowed in lambda expressions, see [compiler error CS1621](../../misc/cs1621.md).

While local functions may seem redundant to lambda expressions, they actually serve different purposes and have different uses. Local functions are more efficient for the case when you want to write a function that is called only from the context of another method.

## See also

- [Methods](methods.md)
