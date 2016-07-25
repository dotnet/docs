---
title: FSharpValue.MakeFunction Method (F#)
description: FSharpValue.MakeFunction Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 916e7c19-01e6-4f10-ae4b-43e1bcc90011 
---

# FSharpValue.MakeFunction Method (F#)

Creates a typed function from object from a dynamic function implementation.

**Namespace/Module Path:** Microsoft.FSharp.Reflection

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
static member MakeFunction : Type * (obj -> obj) -> obj

// Usage:
FSharpValue.MakeFunction (functionType, implementation)
```

#### Parameters
*functionType*
Type: **System.Type**


The function type of the implementation.


*implementation*
Type: [obj](https://msdn.microsoft.com/library/dcf2430f-702b-40e5-a0a1-97518bf137f7)**-&gt;**[obj](https://msdn.microsoft.com/library/dcf2430f-702b-40e5-a0a1-97518bf137f7)


The untyped lambda of the function implementation.

## Return Value

A typed function from the given dynamic implementation.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Reflection.FSharpValue Class &#40;F&#35;&#41;](Reflection.FSharpValue-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Reflection Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Reflection-Namespace-%5BFSharp%5D.md)