---
title: Operators.( <| )<'T,'U> Function (F#)
description: Operators.( <| )<'T,'U> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 9b2a86c3-3cf1-495e-91b2-661667f0218e 
---

# Operators.( <| )<'T,'U> Function (F#)

Applies a function to a value, the value being on the right, the function on the left.

**Namespace/Module Path:** Microsoft.FSharp.Core.Operators

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
( <| ) : ('T -> 'U) -> 'T -> 'U

// Usage:
func <| arg1
```

#### Parameters
*func*
Type: **'T -&gt; 'U**


The function.


*arg1*
Type: **'T**


The argument.

## Return Value

The function result.

## Remarks

The function is referred to as the *backward* or *reverse pipe operator*.

## Example

The following example demonstrates the use of the `<|` operator.

[!code-fsharp[Main](snippets/fsoperators/snippet4.fs)]

**Output:**

```
append1 &lt;| "abc" gives "abc.append1"
result2: "abc.append1.append2"
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Core.Operators Module &#40;F&#35;&#41;](Core.Operators-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)