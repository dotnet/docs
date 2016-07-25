---
title: Operators.Failure Active Pattern (F#)
description: Operators.Failure Active Pattern (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: ebc0e4c7-71a4-4475-a831-3015873349e3
---

# Operators.Failure Active Pattern (F#)

Matches `System.Exception` objects whose runtime type is precisely `System.Exception`.

**Namespace/Module Path:** Microsoft.FSharp.Core.Operators

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
( |Failure|_| ) : exn -> string option
```

#### Parameters
*error*
Type: [exn](https://msdn.microsoft.com/library/e1569b69-3b30-440b-8c6f-966d1c6a06ab)


The input exception.

## Return Value

A string option.

## Remarks
This function is named `FailurePattern` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Core.Operators Module &#40;F&#35;&#41;](Core.Operators-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)
