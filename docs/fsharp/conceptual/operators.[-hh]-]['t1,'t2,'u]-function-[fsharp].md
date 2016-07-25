---
title: Operators.( ||> )<'T1,'T2,'U> Function (F#)
description: Operators.( ||> )<'T1,'T2,'U> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 8c939477-1516-45c5-b6a7-9b5781fa35b9 
---

# Operators.( ||> )<'T1,'T2,'U> Function (F#)

Apply a function to two values, the values being a pair on the left, the function on the right.

**Namespace/Module Path:** Microsoft.FSharp.Core.Operators

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
( ||> ) : 'T1 * 'T2 -> ('T1 -> 'T2 -> 'U) -> 'U

// Usage:
(arg1, arg2) ||> func
```

#### Parameters
*arg1*
Type: **'T1**


The first argument.


*arg2*
Type: **'T2**


The second argument.


*func*
Type: **'T1 -&gt; 'T2 -&gt; 'U**


The function.

## Return Value

The function result.

## Example

The following example demonstrates the use of the `||>` operator.

[!code-fsharp[Main](snippets/fsoperators/snippet2.fs)]

**Output:**

```
("abc", "def") ||&gt; append gives "abc.def"
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