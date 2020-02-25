---
title: Option.filter<'T> Function (F#)
description: Option.filter<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: eriawan
manager: danielfe
ms.date: 07/01/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: ff36174c-0820-47e4-b7ce-6fa93f19bcb5 
---

# Option.filter<'T> Function (F#)

Invokes a function on an optional value that itself yields an option.

**Namespace/Module Path**: Microsoft.FSharp.Core.Option

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
filter : ('T -> bool) -> option:'T option -> 'T option

// Usage:
filter predicate option
```

#### Parameters
*predicate*
Type: **'T -&gt;**[bool](https://msdn.microsoft.com/library/89c0cf9c-49ce-4207-a3be-555851a67dd5)


A function that evaluates whether the value contained in the option should remain, or be filtered out.

*option*
Type: **'T** [option](https://msdn.microsoft.com/library/b08add48-34bf-4410-80a1-ef6a8daddc58)


The input option.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 4.0, Portable


## See Also
[Core.Option Module &#40;F&#35;&#41;](core.option-module-%5Bfsharp%5D.md)

[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](microsoft.fsharp.core-namespace-%5Bfsharp%5D.md)

