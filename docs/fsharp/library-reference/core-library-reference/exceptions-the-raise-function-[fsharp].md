---
title: Exceptions - the raise Function (F#)
description: Exceptions - the raise Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: b00da469-4789-4cdd-9f77-7a2e29f28637
redirect_url: https://docs.microsoft.com/dotnet/articles/fsharp/language-reference/exception-handling/the-raise-function 
---

# Exceptions: the raise Function (F#)

The `raise` function is used to indicate that an error or exceptional condition has occurred. Information about the error is captured in an exception object.


## Syntax

```fsharp
raise (expression)
```

## Remarks
The `raise` function generates an exception object and initiates a stack unwinding process. The stack unwinding process is managed by the common language runtime (CLR), so the behavior of this process is the same as it is in any other .NET language. The stack unwinding process is a search for an exception handler that matches the generated exception. The search starts in the current `try...with` expression, if there is one. Each pattern in the `with` block is checked, in order. When a matching exception handler is found, the exception is considered handled; otherwise, the stack is unwound and `with` blocks up the call chain are checked until a matching handler is found. Any `finally` blocks that are encountered in the call chain are also executed in sequence as the stack unwinds.

The `raise` function is the equivalent of `throw` in C# or C++. Use `reraise` in a catch handler to propagate the same exception up the call chain.

The following code examples illustrate the use of the `raise` function to generate an exception.

[!code-fsharp[Main](snippets/fslangref2/snippet5801.fs)]

The `raise` function can also be used to raise .NET exceptions, as shown in the following example.

[!code-fsharp[Main](snippets/fslangref2/snippet5802.fs)]
    
## See Also
[Exception Handling &#40;F&#35;&#41;](Exception-Handling-%5BFSharp%5D.md)

[Exception Types &#40;F&#35;&#41;](Exception-Types-%5BFSharp%5D.md)

[Exceptions: The try...with Expression &#40;F&#35;&#41;](Exceptions-The-try...with-Expression-%5BFSharp%5D.md)

[Exceptions: The try...finally Expression &#40;F&#35;&#41;](Exceptions-The-try...finally-Expression-%5BFSharp%5D.md)

[Exceptions: The failwith Function &#40;F&#35;&#41;](Exceptions-The-failwith-Function-%5BFSharp%5D.md)

[Exceptions: The invalidArg Function &#40;F&#35;&#41;](Exceptions-The-invalidArg-Function-%5BFSharp%5D.md)