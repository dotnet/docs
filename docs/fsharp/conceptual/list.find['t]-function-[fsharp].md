---
title: List.find<'T> Function (F#)
description: List.find<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: a67bb2f7-408d-47b9-a2ec-07ff899271b3 
---

# List.find<'T> Function (F#)

Returns the first element for which the given function returns `true`. Raises `System.Collections.Generic.KeyNotFoundException` if no such element exists.

**Namespace/Module Path:** Microsoft.FSharp.Collections.List

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
List.find : ('T -> bool) -> 'T list -> 'T

// Usage:
List.find predicate list
```

#### Parameters
*predicate*
Type: **'T -&gt;**[bool](https://msdn.microsoft.com/library/89c0cf9c-49ce-4207-a3be-555851a67dd5)


The function to test the input elements.


*list*
Type: **'T**[list](https://msdn.microsoft.com/library/c627b668-477b-4409-91ed-06d7f1b3e4a7)


The input list.

## Exceptions

|Exception|Condition|
|----|----|
|[KeyNotFoundException](https://msdn.microsoft.com/library/system.collections.generic.keynotfoundexception.aspx)|Thrown if the predicate evaluates to false for all the elements of the list.|

## Return Value

The first element that satisfies the predicate.

## Remarks
This function is named `Find` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example

[!code-fsharp[Main](snippets/fslists/snippet8.fs)]

**Output**

```
5
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.List Module &#40;F&#35;&#41;](Collections.List-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)