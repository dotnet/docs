---
title: "Local functions (C# Programming Guide) | Microsoft Docs"
ms.date: "2017-06-14"
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "fields [C#]"
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
> In some cases, you can use a lambda expression to implement functionality also supported by a lambda expression. For a comparison, see [Local functions compared to Lambda expressions](../../local-functions-vs-lambdas.md).

Local functions make the intent of your code clear. Anyone reading you code can see that the method is private and is not callable except by the containing method. For team projects, they also make it impossible for another developer to mistakenly call the method directly from elsewhere in the class or stuct.
 
## Local function syntax

A local function is defined as a nested method inside a containing member. Its definition has the following syntax:

```csharp
<return-value> <method-name> <parameter-list>
```

Unlike a method definition, a local function definition cannot include the following elements:

- The [private](..\..\language-reference\keywords\private.md) member access modifier. Because all local functions are private, including the `private` keyword generates compiler error CS0106, "The modifier 'private' is not valid for this item."
 
- The [static](..\..\language-reference\keywords\static.md) keyword. Whether a local function is static or instance depends on its enclosing member. Including the `static` keyword generates compiler error CS0106, "The modifier 'static' is not valid for this item."

In addition, note that any local variables, including any method parameters, defined in the containing member are visible in the local function. 
 
The following example defines a local function named `AppendPathSeparator` that is private to a method named `GetText`:
   
[!code-cs[LocalFunctionExample](../../../../samples/snippets/csharp/programming-guide/classes-and-structs/local-functions1.cs)]  
   
## Local functions and exceptions

One of the useful features of local functions is that they can allow exceptions to surface immediately. For method iterators, exceptions are surfaced only when the returned sequence is enumerated, and not when the iterator is retrieved. For async methods, any exceptions thrown by a task are surfaced when the task is awaited. 

The following example defines an `OddSequence` method that enumerates odd numbers between a specified range. Because it passes a number greater than 100 to the `OddSequence` enumerator method, the method throws an <xref:System.ArgumentOutOfRangeException>. As the output from the example shows, the exception surfaces only when you iterate the numbers, and not when you retrieve the enumerator.

[!code-cs[LocalFunctionIterator1](../../../../samples/snippets/csharp/programming-guide/classes-and-structs/local-functions-iterator1.cs)] 

Instead, you can throw an exception when performing validation and before retrieving the iterator by retrieving the iterator and returning it from a local function, as the following example shows.

[!code-cs[LocalFunctionIterator2](../../../../samples/snippets/csharp/programming-guide/classes-and-structs/local-functions-iterator2.cs)]

Local functions can be used in a similar way to handle exceptions outside of the asynchronous operation, which eliminates the need to examine the inner exceptions of an <xref:System.AggregateException>. The following example uses an asynchronous method named `GetMultipleAsync` to pause for a specified number of seconds and return a value that is a random multiple of that number of seconds. The maximum delay is 5 seconds; an <xref:System.ArgumentOutOfRangeException> results if the value is greater than 5. As the following example shows, the exception that is thrown when a value of 6 is passed to the `GetMultipleAsync` method is wrapped in an <xref:System.AggregateException> after the `GetMultipleAsync` method begins execution.

[!code-cs[LocalFunctionAsync`](../../../../samples/snippets/csharp/programming-guide/classes-and-structs/local-functions-async1.cs)] 

As we did with the method iterator, we can refactor the code from this example to perform the validation before calling the asynchronous method. As the output from the following example shows, the <xref:System.ArgumentOutOfRangeException> is not wrapped in a <x:System.AggregateException>.

[!code-cs[LocalFunctionAsync`](../../../../samples/snippets/csharp/programming-guide/classes-and-structs/local-functions-async2.cs)] 

## See also
[Methods](methods.md)
