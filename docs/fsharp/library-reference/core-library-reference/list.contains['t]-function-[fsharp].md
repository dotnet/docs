---
title: List.contains<'T> Function (F#)
description: List.contains<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: liboz
manager: danielfe
ms.date: 07/6/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 52f70370-0c04-4823-bc6e-e92b60369420 
---

# List.contains<'T> Function (F#)

Evaluates to `true` if the given element is in the input list.

**Namespace/Module Path:** Microsoft.FSharp.Collections.List

**Assembly:** FSharp.Core (in FSharp.Core.dll)

## Syntax

```fsharp
// Signature:
List.contains : 'T -> 'T list -> bool

// Usage:
List.contains element source
```

#### Parameters
*element*
Type: **'T**

The element to find.

*source*
Type: **'T** [list](https://msdn.microsoft.com/library/c627b668-477b-4409-91ed-06d7f1b3e4a7)

The input list.

## Exceptions

|Exception|Condition|
|----|----|
|[ArgumentNullException](https://msdn.microsoft.com/library/system.argumentnullexception.aspx)|Thrown when the input list is null.|

## Return Value

Evaluates to `true` if the given element is in the input list. Otherwise, it will return **false**.

## Remarks
This function is named `Contains` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example

The following code shows how to use List.contains.

[!code-fsharp[Main](snippets/fslists/snippet113.fs)]

**Output**

```
true
false
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 4.0, Portable

## See Also

[Collections.List Module &#40;F&#35;&#41;](Collections.List-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)