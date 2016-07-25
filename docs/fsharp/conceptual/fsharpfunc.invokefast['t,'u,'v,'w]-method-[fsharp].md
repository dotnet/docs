---
title: FSharpFunc.InvokeFast<'T,'U,'V,'W> Method (F#)
description: FSharpFunc.InvokeFast<'T,'U,'V,'W> Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 8fe36a62-cdfd-468e-9cd9-e3ff7c0b821e 
---

# FSharpFunc.InvokeFast<'T,'U,'V,'W> Method (F#)

Invoke an F# first class function value with three curried arguments. In some cases this will result in a more efficient application than applying the arguments successively.

**Namespace/Module Path:** Microsoft.FSharp.Core

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
static member InvokeFast : FSharpFunc<'T,('U -> 'V -> 'W)> * 'T * 'U * 'V -> 'W

// Usage:
FSharpFunc.InvokeFast (func, arg1, arg2, arg3)
```

#### Parameters
*func*
Type: [FSharpFunc](https://msdn.microsoft.com/library/6fbc582c-a36a-4154-9bfe-296de5ecba53)**&lt;'T,('U -&gt; 'V -&gt; 'W)&gt;**


The input function.


*arg1*
Type: **'T**


The first arg.


*arg2*
Type: **'U**


The second arg.


*arg3*
Type: **'V**


The third arg.

## Return Value

The function result.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Core.FSharpFunc&#60;'T,'U&#62; Class &#40;F&#35;&#41;](Core.FSharpFunc%5B%27T%2C%27U%5D-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)