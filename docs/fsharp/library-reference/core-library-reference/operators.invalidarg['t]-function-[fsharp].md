---
title: Operators.invalidArg<'T> Function (F#)
description: Operators.invalidArg<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: ed94e978-7fa5-4387-b804-3aaa5ccadbe1
---

# Operators.invalidArg<'T> Function (F#)

Throw a `System.ArgumentException` exception.

**Namespace/Module Path:** Microsoft.FSharp.Core.Operators

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
invalidArg : string -> string -> 'T

// Usage:
invalidArg argumentName message
```

#### Parameters
*argumentName*
Type: [string](https://msdn.microsoft.com/library/12b97856-ec80-4f70-a018-afb0753f755a)


The argument name.


*message*
Type: [string](https://msdn.microsoft.com/library/12b97856-ec80-4f70-a018-afb0753f755a)


The exception message.

## Return Value

The result value.

## Remarks
This function is named `InvalidArg` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Core.Operators Module &#40;F&#35;&#41;](Core.Operators-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)
