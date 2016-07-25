---
title: Unchecked.unbox<'T> Function (F#)
description: Unchecked.unbox<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 9f8e9a60-289a-4296-9daf-2dc2210f7d58 
---

# Unchecked.unbox<'T> Function (F#)

Unboxes a strongly typed value. This is the inverse of `box`; therefore, `unbox<t>(box<t> a)` equals `a`.

**Namespace/Module Path**: Microsoft.FSharp.Core.Operators.Unchecked

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
unbox : obj -> 'T

// Usage:
unbox
```

#### Parameters
*value*
Type: [obj](https://msdn.microsoft.com/library/dcf2430f-702b-40e5-a0a1-97518bf137f7)


The value to unbox.


## Return Value
The unboxed result.


## Remarks
This function is named `Unbox` in the .NET assembly. If accessing the member from a .NET language other than F#, or through reflection, use this name.


## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Operators.Unchecked Module &#40;F&#35;&#41;](Operators.Unchecked-Module-%5BFSharp%5D.md)

[Core.Operators Module &#40;F&#35;&#41;](Core.Operators-Module-%5BFSharp%5D.md)

[Operators.box&#60;'T&#62; Function &#40;F&#35;&#41;](Operators.box%5B%27T%5D-Function-%5BFSharp%5D.md)