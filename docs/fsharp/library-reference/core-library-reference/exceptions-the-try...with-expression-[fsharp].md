---
title: Exceptions - The try...with Expression (F#)
description: Exceptions - The try...with Expression (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 36721076-95cd-4636-ae43-79dd512bee6c
redirect_url: https://docs.microsoft.com/dotnet/articles/fsharp/language-reference/exception-handling/the-try-with-expression 
---

# Exceptions: The try...with Expression (F#)

This topic describes the `try...with` expression, the expression that is used for exception handling in the F# language.


## Syntax

```fsharp
try
expression1
with
| pattern1 -> expression2
| pattern2 -> expression3
...
```

## Remarks
The `try...with` expression is used to handle exceptions in F#. It is similar to the `try...catch` statement in C#. In the preceding syntax, the code in *expression1* might generate an exception. The `try...with` expression returns a value. If no exception is thrown, the whole expression returns the value of *expression1*. If an exception is thrown, each *pattern* is compared in turn with the exception, and for the first matching pattern, the corresponding *expression*, known as the *exception handler*, for that branch is executed, and the overall expression returns the value of the expression in that exception handler. If no pattern matches, the exception propagates up the call stack until a matching handler is found. The types of the values returned from each expression in the exception handlers must match the type returned from the expression in the `try` block.

Frequently, the fact that an error occurred also means that there is no valid value that can be returned from the expressions in each exception handler. A frequent pattern is to have the type of the expression be an option type. The following code example illustrates this pattern.

[!code-fsharp[Main](snippets/fslangref2/snippet5601.fs)]

Exceptions can be .NET exceptions, or they can be F# exceptions. You can define F# exceptions by using the `exception` keyword.

You can use a variety of patterns to filter on the exception type and other conditions; the options are summarized in the following table.


|Pattern|Description|
|-------|-----------|
|:? *exception-type*|Matches the specified .NET exception type.|
|:? *exception-type* as *identifier*|Matches the specified .NET exception type, but gives the exception a named value.|
|*exception-name*(*arguments*)|Matches an F# exception type and binds the arguments.|
|*identifier*|Matches any exception and binds the name to the exception object. Equivalent to **:? System.Exception as***identifier*|
|*identifier* when *condition*|Matches any exception if the condition is true.|

## Examples
The following code examples illustrate the use of the various exception handler patterns.

[!code-fsharp[Main](snippets/fslangref2/snippet5602.fs)]
    
>[!NOTE] 
The `try...with` construct is a separate expression from the `try...finally` expression. Therefore, if your code requires both a `with` block and a `finally` block, you will have to nest the two expressions.

>[!NOTE] 
You can use `try...with` in asynchronous workflows and other computation expressions, in which case a customized version of the `try...with` expression is used. For more information, see [Asynchronous Workflows &#40;F&#35;&#41;](Asynchronous-Workflows-%5BFSharp%5D.md), and [Computation Expressions &#40;F&#35;&#41;](Computation-Expressions-%5BFSharp%5D.md).


## See Also
[Exception Handling &#40;F&#35;&#41;](Exception-Handling-%5BFSharp%5D.md)

[Exception Types &#40;F&#35;&#41;](Exception-Types-%5BFSharp%5D.md)

[Exceptions: The try...finally Expression &#40;F&#35;&#41;](Exceptions-The-try...finally-Expression-%5BFSharp%5D.md)