---
title: Operators.( <|| )<'T1,'T2,'U> Function (F#)
description: Operators.( <|| )<'T1,'T2,'U> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: accfa17f-cb8b-40d3-b634-5933447a5a4f 
---

# Operators.( <|| )<'T1,'T2,'U> Function (F#)

Apply a function to two values, the values being a pair on the right, the function on the left

**Namespace/Module Path:** Microsoft.FSharp.Core.Operators

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
( <|| ) : ('T1 -> 'T2 -> 'U) -> 'T1 * 'T2 -> 'U

// Usage:
func <|| (arg1, arg2)
```

#### Parameters
*func*
Type: **'T1 -&gt; 'T2 -&gt; 'U**


The function.


*arg1*
Type: **'T1**


The first argument.


*arg2*
Type: **'T2**


The second argument.

## Return Value

The function result.

## Example

The following example demonstrates the use of the `<||` operator.

[!code-fsharp[Main](snippets/fsoperators/snippet5.fs)]

**Output:**
```
append &lt;|| ("abc", "def") gives "abc.def"
result2: "ABC.DEF"
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Core.Operators Module &#40;F&#35;&#41;](Core.Operators-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)