---
title: List.pick<'T,'U> Function (F#)
description: List.pick<'T,'U> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 9862d7a2-a067-4ae3-9c35-b7831763a80b 
---

# List.pick<'T,'U> Function (F#)

Applies the given function to successive elements, returning the first result where function returns `Some` for some value. If no such element exists then this function raises `System.Collections.Generic.KeyNotFoundException`.

**Namespace/Module Path:** Microsoft.FSharp.Collections.List

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
List.pick : ('T -> 'U option) -> 'T list -> 'U

// Usage:
List.pick chooser list
```

#### Parameters
*chooser*
Type: **'T -&gt; 'U**[option](https://msdn.microsoft.com/library/b08add48-34bf-4410-80a1-ef6a8daddc58)


The function to generate options from the elements.


*list*
Type: **'T**[list](https://msdn.microsoft.com/library/c627b668-477b-4409-91ed-06d7f1b3e4a7)


The input list.

## Exceptions

|Exception|Condition|
|----|----|
|[KeyNotFoundException](https://msdn.microsoft.com/library/system.collections.generic.keynotfoundexception.aspx)|Thrown when a matching element is not found or when the list is empty.|

## Return Value

The first resulting value where `Some` is returned.

## Remarks
This function is named `Pick` in compiled assemblies. If you are accessing the function from a .NET language other than F#, or through reflection, use this name.

## Example

[!code-fsharp[Main](snippets/fslists/snippet9.fs)]

**Output**

```
"b"
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.List Module &#40;F&#35;&#41;](Collections.List-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)