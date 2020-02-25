---
title: FSharpFunc.InvokeFast<'T,'U,'V> Method (F#)
description: FSharpFunc.InvokeFast<'T,'U,'V> Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 6b545bb8-96d9-4503-b977-1e61865767ff 
---

# FSharpFunc.InvokeFast<'T,'U,'V> Method (F#)

Invoke an F# first class function value with two curried arguments. In some cases this will result in a more efficient application than applying the arguments successively.

**Namespace/Module Path:** Microsoft.FSharp.Core

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
static member InvokeFast : FSharpFunc<'T,('U -> 'V)> * 'T * 'U -> 'V

// Usage:
FSharpFunc.InvokeFast (func, arg1, arg2)
```

#### Parameters
*func*
Type: [FSharpFunc](https://msdn.microsoft.com/library/6fbc582c-a36a-4154-9bfe-296de5ecba53)**&lt;'T,('U -&gt; 'V)&gt;**


The input function.


*arg1*
Type: **'T**


The first arg.


*arg2*
Type: **'U**


The second arg.

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