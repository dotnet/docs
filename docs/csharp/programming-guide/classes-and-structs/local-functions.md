---
title: "Local functions - C# Programming Guide"
description: Local functions in C# are private methods that are nested in another member and can be called from their containing member.
ms.date: 06/14/2017
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
<modifiers: async | unsafe> <return-type> <method-name> <parameter-list>
```

Local functions can use the [async](../../language-reference/keywords/async.md) and [unsafe](../../language-reference/keywords/unsafe.md) modifiers.

Note that all local variables that are defined in the containing member, including its method parameters, are accessible in the local function.

Unlike a method definition, a local function definition cannot include the member access modifier. Because all local functions are private, including an access modifier, such as the `private` keyword, generates compiler error CS0106, "The modifier 'private' is not valid for this item."

> [!NOTE]
> Prior to C# 8.0, local functions cannot include the `static` modifier. Including the `static` keyword generates compiler error CS0106, "The modifier 'static' is not valid for this item.", or a compiler error stating that you should use C# 8.0 or higher.

In addition, attributes can't be applied to the local function or to its parameters and type parameters.

The following example defines a local function named `AppendPathSeparator` that is private to a method named `GetText`:

[!code-csharp[LocalFunctionExample](~/samples/snippets/csharp/programming-guide/classes-and-structs/local-functions1.cs)]  

## Local functions and exceptions

One of the useful features of local functions is that they can allow exceptions to surface immediately. For method iterators, exceptions are surfaced only when the returned sequence is enumerated, and not when the iterator is retrieved. For async methods, any exceptions thrown in an async method are observed when the returned task is awaited.

The following example defines an `OddSequence` method that enumerates odd numbers between a specified range. Because it passes a number greater than 100 to the `OddSequence` enumerator method, the method throws an <xref:System.ArgumentOutOfRangeException>. As the output from the example shows, the exception surfaces only when you iterate the numbers, and not when you retrieve the enumerator.

[!code-csharp[LocalFunctionIterator1](~/samples/snippets/csharp/programming-guide/classes-and-structs/local-functions-iterator1.cs)]

Instead, you can throw an exception when performing validation and before retrieving the iterator by returning the iterator from a local function, as the following example shows.

[!code-csharp[LocalFunctionIterator2](~/samples/snippets/csharp/programming-guide/classes-and-structs/local-functions-iterator2.cs)]

Local functions can be used in a similar way to handle exceptions outside of the asynchronous operation. Ordinarily, exceptions thrown in async method require that you examine the inner exceptions of an <xref:System.AggregateException>. Local functions allow your code to fail fast and allow your exception to be both thrown and observed synchronously.

The following example uses an asynchronous method named `GetMultipleAsync` to pause for a specified number of seconds and return a value that is a random multiple of that number of seconds. The maximum delay is 5 seconds; an <xref:System.ArgumentOutOfRangeException> results if the value is greater than 5. As the following example shows, the exception that is thrown when a value of 6 is passed to the `GetMultipleAsync` method is wrapped in an <xref:System.AggregateException> after the `GetMultipleAsync` method begins execution.

[!code-csharp[LocalFunctionAsync](~/samples/snippets/csharp/programming-guide/classes-and-structs/local-functions-async1.cs)]

As we did with the method iterator, we can refactor the code from this example to perform the validation before calling the asynchronous method. As the output from the following example shows, the <xref:System.ArgumentOutOfRangeException> is not wrapped in a <xref:System.AggregateException>.

[!code-csharp[LocalFunctionAsync](~/samples/snippets/csharp/programming-guide/classes-and-structs/local-functions-async2.cs)]

## Local functions vs. lambda expressions

At first glance, local functions and [lambda expressions](../../language-reference/operators/lambda-expressions.md) are very similar. In many cases, the choice between using lambda expressions and local functions is a matter of style and personal preference. However, there are real differences in where you can use one or the other that you should be aware of.

Let's examine the differences between the local function and lambda expression implementations of the factorial algorithm. First the version using a local function:

[!code-csharp[LocalFunctionFactorial](../../../../samples/snippets/csharp/new-in-7/MathUtilities.cs#37_LocalFunctionFactorial "Recursive factorial using local function")]

Contrast that implementation with a version that uses lambda expressions:

[!code-csharp[26_LambdaFactorial](../../../../samples/snippets/csharp/new-in-7/MathUtilities.cs#38_LambdaFactorial "Recursive factorial using lambda expressions")]

The local functions have names. The lambda expressions are anonymous methods that are assigned to variables that are `Func` or `Action` types. When you
declare a local function, the argument types and return type are part of the function declaration. Instead of being part of the body of the lambda expression, the argument types and return type are part of the lambda expression's variable type declaration. Those two differences may result in clearer code.

Local functions have different rules for definite assignment than lambda expressions. A local function declaration can be referenced from any code location where it is in scope. A lambda expression must be assigned to a delegate variable before it can be accessed (or called through the delegate referencing the lambda expression). Notice that the version using the lambda expression must declare and initialize the lambda expression `nthFactorial` before defining it. Not doing so results in a compile time error for referencing `nthFactorial` before assigning it. These differences mean that recursive algorithms are easier to create using local functions. You can declare and define a local function that calls itself. Lambda expressions must be declared, and assigned a default value before they can be re-assigned to a body that references the same lambda expression.

Definite assignment rules also affect any variables that are captured by the local function or lambda expression. Both local functions and lambda expression rules demand that any captured variables are definitely assigned at the point when the local function or lambda expression is converted to a delegate. The difference is that lambda expressions are converted to delegates when they are declared. Local functions are converted to delegates only when used as a delegate. If you declare a local function and only reference it by calling it like a method, it will not be converted to a delegate. That rule enables you to declare a local function at any convenient location in its enclosing scope. It's common to declare local functions at the end of the parent method, after any return statements.

Third, the compiler can perform static analysis that enables local functions to definitely assign captured variables in the enclosing scope. Consider this example:

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

The analysis that enables the example analysis enables the fourth difference. Depending on their use, local functions can avoid heap allocations that are always necessary for lambda expressions. If a local function is never converted to a delegate, and none of the variables captured by the local function is captured by other lambdas or local functions that are converted to delegates, the compiler can avoid heap allocations.

Consider this async example:

[!code-csharp[TaskLambdaExample](../../../../samples/snippets/csharp/new-in-7/AsyncWork.cs#36_TaskLambdaExample "Task returning method with lambda expression")]

The closure for this lambda expression contains the `address`, `index` and `name` variables. In the case of local functions, the object that implements the closure may be a `struct` type. That struct type would be passed by reference to the local function. This difference in implementation would save on an allocation.

The instantiation necessary for lambda expressions means extra memory allocations, which may be a performance factor in time-critical code paths. Local functions do not incur this overhead. In the example above, the local functions version has 2 fewer allocations than the lambda expression version.

> [!NOTE]
> The local function equivalent of this method also uses a class for the closure. Whether the closure for a local function is implemented as a `class` or a `struct` is an implementation detail. A local function may use a `struct` whereas a lambda will always use a `class`.

[!code-csharp[TaskLocalFunctionExample](../../../../samples/snippets/csharp/new-in-7/AsyncWork.cs#TaskExample "Task returning method with local function")]

One final advantage not demonstrated in this sample is that local functions can be implemented as iterators, using the `yield return` syntax to produce a sequence of values. The `yield return` statement is not allowed in lambda expressions.

While local functions may seem redundant to lambda expressions, they actually serve different purposes and have different uses. Local functions are more efficient for the case when you want to write a function that is called only from the context of another method.

## See also

- [Methods](methods.md)
