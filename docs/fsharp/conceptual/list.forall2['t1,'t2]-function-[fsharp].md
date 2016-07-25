---
title: List.forall2<'T1,'T2> Function (F#)
description: List.forall2<'T1,'T2> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: a125b984-5e21-4dc4-9734-b0b796807401 
---

# List.forall2<'T1,'T2> Function (F#)

Tests if all corresponding elements of the collection satisfy the given predicate pairwise.

**Namespace/Module Path:** Microsoft.FSharp.Collections.List

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
List.forall2 : ('T1 -> 'T2 -> bool) -> 'T1 list -> 'T2 list -> bool

// Usage:
List.forall2 predicate list1 list2
```

#### Parameters
*predicate*
Type: **'T1 -&gt; 'T2 -&gt;**[bool](https://msdn.microsoft.com/library/89c0cf9c-49ce-4207-a3be-555851a67dd5)


The function to test the input elements.


*list1*
Type: **'T1**[list](https://msdn.microsoft.com/library/c627b668-477b-4409-91ed-06d7f1b3e4a7)


The first input list.


*list2*
Type: **'T2**[list](https://msdn.microsoft.com/library/c627b668-477b-4409-91ed-06d7f1b3e4a7)


The second input list.


## Exceptions

|Exception|Condition|
|----|----|
|[ArgumentException](https://msdn.microsoft.com/library/system.argumentexception.aspx)|Thrown when the input lists differ in length.|

## Return Value

`true` if all of the pairs of elements satisfy the predicate. Otherwise, returns `false`.

## Remarks
The predicate is applied to matching elements in the two collections. If any application returns `false` then the overall result is `false` and no further elements are tested. Otherwise, if one collection is longer than the other then the `System.ArgumentException` exception is raised. Otherwise, `true` is returned.

This function is named `ForAll2` in compiled assemblies. If you are accessing the function from a .NET language other than F#, or through reflection, use this name.

## Example

[!code-fsharp[Main](snippets/fslists/snippet4.fs)]

**Output**

```
true
false
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.List Module &#40;F&#35;&#41;](Collections.List-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)