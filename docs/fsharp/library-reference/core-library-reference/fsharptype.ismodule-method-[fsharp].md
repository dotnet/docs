---
title: FSharpType.IsModule Method (F#)
description: FSharpType.IsModule Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: bf81f8fc-32bf-4c83-be5c-d7dd54fc4861 
---

# FSharpType.IsModule Method (F#)

Returns `true` if the specified type is a `System.Type` value corresponding to the compiled form of an F# module.

**Namespace/Module Path:** Microsoft.FSharp.Reflection

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
static member IsModule : Type -> bool

// Usage:
FSharpType.IsModule (typ)
```

#### Parameters
*typ*
Type: **System.Type**


The type to check.

## Return Value

Returns `true` if the type check succeeds.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Reflection.FSharpType Class &#40;F&#35;&#41;](Reflection.FSharpType-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Reflection Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Reflection-Namespace-%5BFSharp%5D.md)