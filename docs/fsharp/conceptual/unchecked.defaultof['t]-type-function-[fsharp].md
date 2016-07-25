---
title: Unchecked.defaultof<'T> Type Function (F#)
description: Unchecked.defaultof<'T> Type Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 6234532d-ab6d-42c3-8f1d-6d7109bb5bed 
---

# Unchecked.defaultof<'T> Type Function (F#)

Generate a default value for any type. This is `null` for reference types. For structures, this is structure value where all fields have the default value. This function is unsafe in the sense that some F# values do not have proper `null` values.

**Namespace/Module Path:** Microsoft.FSharp.Core.Operators.Unchecked

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
defaultof<'T> :  'T

// Usage:
defaultof
```

## Remarks
This function is named `DefaultOf` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Operators.Unchecked Module &#40;F&#35;&#41;](Operators.Unchecked-Module-%5BFSharp%5D.md)

[Core.Operators Module &#40;F&#35;&#41;](Core.Operators-Module-%5BFSharp%5D.md)