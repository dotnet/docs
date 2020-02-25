---
title: Exception Handling (F#)
description: Exception Handling (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: ad475c4a-d94e-47d9-b27b-3ff000b65f8e
redirect_url: https://docs.microsoft.com/dotnet/articles/fsharp/language-reference/exception-handling/index 
---

# Exception Handling (F#)

This section contains information about exception handling support in the F# language.


## Exception Handling Basics
Exception handling is the standard way of handling error conditions in the .NET Framework. Thus, any .NET language must support this mechanism, including F#. An *exception* is an object that encapsulates information about an error. When errors occur, exceptions are raised and regular execution stops. Instead, the runtime searches for an appropriate handler for the exception. The search starts in the current function, and proceeds up the stack through the layers of callers until a matching handler is found. Then the handler is executed.

In addition, as the stack is unwound, the runtime executes any code in **finally** blocks, to guarantee that objects are cleaned up correctly during the unwinding process.


## Related Topics

|Title|Description|
|-----|-----------|
|[Exception Types &#40;F&#35;&#41;](Exception-Types-%5BFSharp%5D.md)|Describes how to declare an exception type.|
|[Exceptions: The try...with Expression &#40;F&#35;&#41;](Exceptions-The-try...with-Expression-%5BFSharp%5D.md)|Describes the language construct that supports exception handling.|
|[Exceptions: The try...finally Expression &#40;F&#35;&#41;](Exceptions-The-try...finally-Expression-%5BFSharp%5D.md)|Describes the language construct that enables you to execute clean-up code as the stack unwinds when an exception is thrown.|
|[Exceptions: the raise Function &#40;F&#35;&#41;](Exceptions-the-raise-Function-%5BFSharp%5D.md)|Describes how to throw an exception object.|
|[Exceptions: The failwith Function &#40;F&#35;&#41;](Exceptions-The-failwith-Function-%5BFSharp%5D.md)|Describes how to generate a general F# exception.|
|[Exceptions: The invalidArg Function &#40;F&#35;&#41;](Exceptions-The-invalidArg-Function-%5BFSharp%5D.md)|Describes how to generate an invalid argument exception.|