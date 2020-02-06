---
title: Array.filter<'T> Function (F#)
description: Array.filter<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: f01e95ba-4398-4b22-8373-b6de6c51a851 
---

# Array.filter<'T> Function (F#)

Returns a new collection containing only the elements of the collection for which the given predicate returns `true`.

**Namespace/Module Path:** Microsoft.FSharp.Collections.Array

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Array.filter : ('T -> bool) -> 'T [] -> 'T []

// Usage:
Array.filter predicate array
```

#### Parameters
*predicate*
Type: **'T -&gt;**[bool](https://msdn.microsoft.com/library/89c0cf9c-49ce-4207-a3be-555851a67dd5)


The function to test the input elements.


*array*
Type: **'T**[[]](https://msdn.microsoft.com/library/def20292-9aae-4596-9275-b94e594f8493)


The input array.


## Return Value

An array containing the elements for which the given predicate returns true.

## Remarks
This function is named `Filter` in compiled assemblies. If accessing the function from a language other than F#, or through reflection, use this name.

## Example
The following example shows how to use Array.filter to select elements from an array.

[!code-fsharp[Main](snippets/fssamples101/snippet1007.fs)]

```
names = [|"Bob"; "Ann"; "Stephen"; "Vivek"; "Fred"; "Kim"; "Brian"; "Ling"; "Jane"; "Jonathan"|]

longNames = [|"Stephen"; "Vivek"; "Brian"; "Jonathan"|]
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable




## See Also
[Collections.Array Module &#40;F&#35;&#41;](Collections.Array-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)

