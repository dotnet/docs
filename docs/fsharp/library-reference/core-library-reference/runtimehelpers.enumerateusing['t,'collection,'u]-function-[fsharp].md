---
title: RuntimeHelpers.EnumerateUsing<'T,'Collection,'U> Function (F#)
description: RuntimeHelpers.EnumerateUsing<'T,'Collection,'U> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: b9139387-f31b-43c1-a826-143b633c484f
---

# RuntimeHelpers.EnumerateUsing<'T,'Collection,'U> Function (F#)

The F# compiler emits calls to this function to implement the `use` keyword for F# sequence expressions.

**Namespace/Module Path:** Microsoft.FSharp.Core.CompilerServices.RuntimeHelpers

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
RuntimeHelpers.EnumerateUsing : 'T -> ('T -> 'Collection) -> seq<'U> (requires 'T :> IDisposable and 'Collection :> seq<'U>)

// Usage:
RuntimeHelpers.EnumerateUsing resource source
```

#### Parameters
*resource*
Type: **'T**


The resource to be used and disposed.


*source*
Type: **'T -&gt; 'Collection**


The input sequence.

## Return Value

The result sequence.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[CompilerServices.RuntimeHelpers Module &#40;F&#35;&#41;](CompilerServices.RuntimeHelpers-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Core.CompilerServices Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core.CompilerServices-Namespace-%5BFSharp%5D.md)
