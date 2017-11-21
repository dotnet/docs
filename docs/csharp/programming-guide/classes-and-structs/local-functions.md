---
title: "Local functions (C# Programming Guide)"
ms.date: 06/14/2017
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
helpviewer_keywords: 
  - "local functions [C#]"
author: "rpetrusha"
ms.author: "ronpet"
---
# Local functions (C# Programming Guide)

Starting with C# 7, C# supports *local functions*. Local functions are private methods of a type that are nested in another member. They can only be called from their containing member. Local functions can be declared in and called from:

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
> In some cases, you can use a lambda expression to implement functionality also supported by a local function. For a comparison, see [Local functions compared to Lambda expressions](../../local-functions-vs-lambdas.md).

Local functions make the intent of your code clear. Anyone reading you code can see that the method is not callable except by the containing method. For team projects, they also make it impossible for another developer to mistakenly call the method directly from elsewhere in the class or stuct.
 
## Local function syntax

A local function is defined as a nested method inside a containing member. Its definition has the following syntax:

```txt
<modifiers: async | unsafe> <return-type> <method-name> <parameter-list>
```

Local functions can use the [async](../../language-reference/keywords/async.md) and [unsafe](../../language-reference/keywords/unsafe.md) modifiers. 

Note that all local variables that are defined in the containing member, including its method parameters, are accessible in the local function. 

Unlike a method definition, a local function definition cannot include the following elements:

- The member access modifier. Because all local functions are private, including an access modifier, such as the `private` keyword, generates compiler error CS0106, "The modifier 'private' is not valid for this item."
 
- The [static](../../language-reference/keywords/static.md) keyword. Including the `static` keyword generates compiler error CS0106, "The modifier 'static' is not valid for this item."

In addition, attributes can't be applied to the local function or to its parameters and type parameters. 
 
The following example defines a local function named `AppendPathSeparator` that is private to a method named `GetText`:
   
[!code-csharp[LocalFunctionExample](../../../../samples/snippets/csharp/programming-guide/classes-and-structs/local-functions1.cs)]  
   
## Local functions and exceptions

One of the useful features of local functions is that they can allow exceptions to surface immediately. For method iterators, exceptions are surfaced only when the returned sequence is enumerated, and not when the iterator is retrieved. For async methods, any exceptions thrown in an async method are observed when the returned task is awaited. 

The following example defines an `OddSequence` method that enumerates odd numbers between a specified range. Because it passes a number greater than 100 to the `OddSequence` enumerator method, the method throws an <xref:System.ArgumentOutOfRangeException>. As the output from the example shows, the exception surfaces only when you iterate the numbers, and not when you retrieve the enumerator.

[!code-csharp[LocalFunctionIterator1](../../../../samples/snippets/csharp/programming-guide/classes-and-structs/local-functions-iterator1.cs)] 

Instead, you can throw an exception when performing validation and before retrieving the iterator by returning the iterator from a local function, as the following example shows.

[!code-csharp[LocalFunctionIterator2](../../../../samples/snippets/csharp/programming-guide/classes-and-structs/local-functions-iterator2.cs)]

Local functions can be used in a similar way to handle exceptions outside of the asynchronous operation. Ordinarily, exceptions thrown in async method require that you examine the inner exceptions of an <xref:System.AggregateException>. Local functions allow your code to fail fast and allow your exception to be both thrown and observed synchronously.

The following example uses an asynchronous method named `GetMultipleAsync` to pause for a specified number of seconds and return a value that is a random multiple of that number of seconds. The maximum delay is 5 seconds; an <xref:System.ArgumentOutOfRangeException> results if the value is greater than 5. As the following example shows, the exception that is thrown when a value of 6 is passed to the `GetMultipleAsync` method is wrapped in an <xref:System.AggregateException> after the `GetMultipleAsync` method begins execution.

[!code-csharp[LocalFunctionAsync`](../../../../samples/snippets/csharp/programming-guide/classes-and-structs/local-functions-async1.cs)] 

As we did with the method iterator, we can refactor the code from this example to perform the validation before calling the asynchronous method. As the output from the following example shows, the <xref:System.ArgumentOutOfRangeException> is not wrapped in a <x:System.AggregateException>.

[!code-csharp[LocalFunctionAsync`](../../../../samples/snippets/csharp/programming-guide/classes-and-structs/local-functions-async2.cs)] 

## See also
[Methods](methods.md)
