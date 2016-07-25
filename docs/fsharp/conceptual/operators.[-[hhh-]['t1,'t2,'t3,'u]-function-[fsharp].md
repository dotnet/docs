---
title: Operators.( <||| )<'T1,'T2,'T3,'U> Function (F#)
description: Operators.( <||| )<'T1,'T2,'T3,'U> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: ad95efc5-d03b-40c6-a4c4-b03eadfa053e 
---

# Operators.( <||| )<'T1,'T2,'T3,'U> Function (F#)

Apply a function to three values, the values being a triple on the right, the function on the left

**Namespace/Module Path:** Microsoft.FSharp.Core.Operators

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
( <||| ) : ('T1 -> 'T2 -> 'T3 -> 'U) -> 'T1 * 'T2 * 'T3 -> 'U

// Usage:
func <||| (arg1, arg2, arg3)
```

#### Parameters
*func*
Type: **'T1 -&gt; 'T2 -&gt; 'T3 -&gt; 'U**


The function.


*arg1*
Type: **'T1**


The first argument.


*arg2*
Type: **'T2**


The second argument.


*arg3*
Type: **'T3**


The third argument.

## Return Value

The function result.

## Example

The following code demonstrates the use of the `<|||` operator.

[!code-fsharp[Main](snippets/fsoperators/snippet6.fs)]

**Output:**

```
append4 &lt;||| ("abc", "def", "ghi") gives  "abc.def.ghi"
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Core.Operators Module &#40;F&#35;&#41;](Core.Operators-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)